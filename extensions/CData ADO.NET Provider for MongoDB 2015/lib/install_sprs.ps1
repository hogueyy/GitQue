param(
[String]$path = $("..\SSRS\")
)

$snapin = Get-PsSnapin -Name Microsoft.SharePoint.PowerShell -Registered
if ($snapin) {
	Write-Output "Adding SharePoint PowerShell Snapin..."
	Add-PsSnapin Microsoft.SharePoint.PowerShell
} else {
	exit
}

$snapin = Get-PsSnapin -Name SqlServerCmdletSnapin100 -Registered
if ($snapin) {
	Write-Output "Adding SQLServer PowerShell Snapin..."
	Add-PsSnapin SqlServerCmdletSnapin100
} else {
	exit
}

$productVersion = Invoke-sqlcmd -query "select convert(sysname, serverproperty('ProductVersion'))"
[String] $SQLServerVersion = $null
if($productVersion -eq $null) {
	Write-Error "Can not get SQL Server version." 
	exit
} else {
	$SQLServerVersion = $productVersion[0].ToString()
}

if (!$SQLServerVersion.StartsWith("11")) {
	Write-Host "Not necessary to execute this for your SQL Server." 
	exit
}

[System.IO.Directory]::SetCurrentDirectory((Get-Location).Path)
if ([System.IO.Directory]::Exists($path)) {
	Write-Output "Looking for CData SPRS DLL in given path..." 
	[String[]] $files = [System.IO.Directory]::GetFiles($path, "CDATA.SSRS2012.MongoDB.dll", [System.IO.SearchOption]::AllDirectories)
	if ($files) {
		$files | ForEach-Object {
			$path = $_
		}
	}
}

if ($path.EndsWith(".dll", [StringComparison]::CurrentCultureIgnoreCase) -and [System.IO.File]::Exists($path)) {
	$filename = [System.IO.Path]::GetFileName($path)
	if ($filename -ne "CData.SSRS2012.MongoDB.dll") {
		Write-Error "The given DLL is not supported. Please input the correct path." 
		exit
	}
} else {
	Write-Error "Can not find any CData SPRS DLL in given path." 
	exit
}

[System.Reflection.Assembly] $asm = [System.Reflection.Assembly]::LoadFrom($path);
[String] $sprsConfigPath = $null
[String] $spVersion = (Get-PSSnapin microsoft.sharepoint.powershell).Version.Major
if ($spVersion -eq "14") {
	$sprsConfigPath = (Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\14.0" "Location").Location.ToString()
} elseif ($spVersion -eq "15") {
	$sprsConfigPath = (Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\15.0" "Location").Location.ToString()
} else {
	Write-Error "Unsupport SharePoint Version."
	exit
}

if ($sprsConfigPath -eq $null) {
	Write-Error "Can not find SharePoint Reporing Services." 
	exit
}

Write-Output "Updating configuration file..."
[String] $sprsBinPath = $sprsConfigPath +"WebServices\Reporting\bin\"
[System.IO.File]::Copy($path, $sprsBinPath + $filename, $true)

[String] $sprsConfigPath = $sprsConfigPath + "WebServices\Reporting\"
[System.Resources.ResourceManager] $resmgr = New-Object -TypeName System.Resources.ResourceManager("SSRSResources", $asm)
[String] $codeGroupName = $resmgr.GetString("CodeGroupName")
[String] $codeGroupDescription = $resmgr.GetString("CodeGroupDescription")

[System.Xml.XmlDocument] $doc = New-Object -TypeName System.Xml.XmlDocument
$doc.Load($sprsConfigPath + "rssrvpolicy.config")
write-output ([string]::Format("Loaded {0}", $sprsConfigPath + "rssrvpolicy.config."))
[String] $CodeGroupXPath = [string]::Format("//CodeGroup[@PermissionSetName='Execution']")
[System.Xml.XmlNode] $CodeGroupNode = $doc.SelectSingleNode($CodeGroupXPath)
if ($CodeGroupNode -eq $null) {
	Write-Error "Error: Report Service configuration section not found."
	exit
}

[System.Xml.XmlNode] $ourCodeGroupNode = $CodeGroupNode.SelectSingleNode([string]::Format("CodeGroup[@Name='{0}']", $codeGroupName));
if ($ourCodeGroupNode -eq $null) {
	$ourCodeGroupNode = $doc.CreateElement("CodeGroup")
	$CodeGroupNode.AppendChild($ourCodeGroupNode) | Out-Null
}
$ourCodeGroupNode.RemoveAll()

[System.Xml.XmlAttribute] $attr = $doc.CreateAttribute("class")
$attr.Value = "UnionCodeGroup"
$ourCodeGroupNode.Attributes.Append($attr) | Out-Null

$attr = $doc.CreateAttribute("version")
$attr.Value = "1"
$ourCodeGroupNode.Attributes.Append($attr) | Out-Null

$attr = $doc.CreateAttribute("PermissionSetName")
$attr.Value = "FullTrust"
$ourCodeGroupNode.Attributes.Append($attr) | Out-Null

$attr = $doc.CreateAttribute("Name")
$attr.Value = $codeGroupName
$ourCodeGroupNode.Attributes.Append($attr) | Out-Null

$attr = $doc.CreateAttribute("Description")
$attr.Value = $codeGroupDescription
$ourCodeGroupNode.Attributes.Append($attr) | Out-Null

[System.Xml.XmlNode] $imemberShipConditionNode = $doc.CreateElement("IMembershipCondition")
$ourCodeGroupNode.AppendChild($imemberShipConditionNode) | Out-Null

$attr = $doc.CreateAttribute("class")
$attr.Value = "StrongNameMembershipCondition"
$imemberShipConditionNode.Attributes.Append($attr) | Out-Null

$attr = $doc.CreateAttribute("version")
$attr.Value = "1";
$imemberShipConditionNode.Attributes.Append($attr) | Out-Null

$key = $asm.GetName().GetPublicKey()
$PKBlob = ""
$key | Foreach -Process {$PKBlob = $PKBlob + ("{0:x2}" -f $_)}
$attr = $doc.CreateAttribute("PublicKeyBlob")
$attr.Value = $PKBlob.ToString()
$imemberShipConditionNode.Attributes.Append($attr) | Out-Null

$doc.Save($sprsConfigPath + "rssrvpolicy.config")
Write-Output "Configuration file updated successfully."

[String] $entensionName = $resmgr.GetString("EntensionName")
$app = get-sprsserviceapplication | select-object -property id
if ($app) {
	Write-Output "Adding CData.MongoDB Data Extension..."
	$app | ForEach-Object {
		$tmp = Get-SPRSExtension -Identity $_.id -Name $entensionName -ExtensionType Data
		if(-not $tmp) {
			New-SPRSExtension -Identity $_.id -Name $entensionName -ExtensionType Data -TypeName ("CData.SSRS.MongoDBConnection, " + $asm.FullName)
		}
	}
	Write-Output "CData.MongoDB Data Extension added successfully."
} else {
	Write-Error "No SPRS Service Application."
}

Write-Output "Install SPRS successfully."