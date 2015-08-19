Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Collections
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Threading
Imports System.Data.CData.MongoDB
Imports System.Resources

Namespace CData.MongoDB.Demo
  Public Class GenerationForm
    Inherits Form
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
        components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
      Dim resources = New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
      Me.components = New System.ComponentModel.Container()
      Me.addConnectionButton = New System.Windows.Forms.Button()
      Me.connectionMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.newQueryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.executeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.splitContainer = New System.Windows.Forms.SplitContainer()
      Me.connectionGroup = New System.Windows.Forms.GroupBox()
      Me.connectionView = New System.Windows.Forms.TreeView()
      Me.connectionImageList = New System.Windows.Forms.ImageList(Me.components)
      Me.editConnectionButton = New System.Windows.Forms.Button()
      Me.queryGroup = New System.Windows.Forms.GroupBox()
      Me.queryTabs = New System.Windows.Forms.TabControl()
      Me.queryViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.closeOthersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.connectionMenu.SuspendLayout()
      Me.splitContainer.Panel1.SuspendLayout()
      Me.splitContainer.Panel2.SuspendLayout()
      Me.splitContainer.SuspendLayout()
      Me.connectionGroup.SuspendLayout()
      Me.queryGroup.SuspendLayout()
      Me.queryViewMenu.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' addConnectionButton
      '  
      resources.ApplyResources(Me.addConnectionButton, "addConnectionButton")
      Me.addConnectionButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.addConnectionButton.Location = New System.Drawing.Point(6, 437)
      Me.addConnectionButton.Name = "addConnectionButton"
      Me.addConnectionButton.Size = New System.Drawing.Size(170, 23)
      Me.addConnectionButton.TabIndex = 3
      Me.addConnectionButton.UseVisualStyleBackColor = True
      AddHandler Me.addConnectionButton.Click, New System.EventHandler(AddressOf Me.OnAddConnectionButtonClick)

      ' 
      ' connectionMenu
      ' 
      Me.connectionMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newQueryMenuItem, Me.executeMenuItem, Me.toolStripSeparator, Me.refreshToolStripMenuItem})
      Me.connectionMenu.Name = "connectionMenu"
      Me.connectionMenu.Size = New System.Drawing.Size(134, 76)
      AddHandler Me.connectionMenu.Opening, New System.ComponentModel.CancelEventHandler(AddressOf Me.OnConnectionMenuOpening)
      ' 
      ' newQueryMenuItem
      ' 
      Me.newQueryMenuItem.Name = "newQueryMenuItem"
      Me.newQueryMenuItem.Size = New System.Drawing.Size(133, 22)
      AddHandler Me.newQueryMenuItem.Click, New System.EventHandler(AddressOf Me.OnNewQueryMenuItemClick)
      resources.ApplyResources(Me.newQueryMenuItem, "newQueryMenuItem")
      ' 
      ' executeMenuItem
      ' 
      Me.executeMenuItem.Name = "executeMenuItem"
      Me.executeMenuItem.Size = New System.Drawing.Size(133, 22)
      AddHandler Me.executeMenuItem.Click, New System.EventHandler(AddressOf Me.OnExecuteMenuItemClick)
      resources.ApplyResources(Me.executeMenuItem, "executeMenuItem")
      ' 
      ' toolStripSeparator
      ' 
      Me.toolStripSeparator.Name = "toolStripSeparator"
      Me.toolStripSeparator.Size = New System.Drawing.Size(130, 6)
      ' 
      ' refreshToolStripMenuItem
      ' 
      Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
      Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
      AddHandler Me.refreshToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.OnRefreshToolStripMenuItemClick)
      resources.ApplyResources(Me.refreshToolStripMenuItem, "refreshToolStripMenuItem")
      ' 
      ' splitContainer
      ' 
      Me.splitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.splitContainer.Location = New System.Drawing.Point(12, 12)
      Me.splitContainer.Name = "splitContainer"
      resources.ApplyResources(Me.splitContainer, "splitContainer")
      ' splitContainer.Panel1
      ' 
      Me.splitContainer.Panel1.Controls.Add(Me.connectionGroup)
      ' 
      ' splitContainer.Panel2
      ' 
      Me.splitContainer.Panel2.Controls.Add(Me.queryGroup)
      Me.splitContainer.Size = New System.Drawing.Size(638, 469)
      Me.splitContainer.SplitterDistance = 185
      Me.splitContainer.TabIndex = 0
      Me.splitContainer.TabStop = False
      ' 
      ' connectionGroup
      ' 
      Me.connectionGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.connectionGroup.Controls.Add(Me.connectionView)
      Me.connectionGroup.Controls.Add(Me.addConnectionButton)
      Me.connectionGroup.Controls.Add(Me.editConnectionButton)
      Me.connectionGroup.Location = New System.Drawing.Point(0, 3)
      Me.connectionGroup.Name = "connectionGroup"
      Me.connectionGroup.Size = New System.Drawing.Size(182, 466)
      Me.connectionGroup.TabIndex = 5
      Me.connectionGroup.TabStop = False
      resources.ApplyResources(Me.connectionGroup, "connectionGroup")
      ' connectionView
      ' 
      Me.connectionView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.connectionView.ContextMenuStrip = Me.connectionMenu
      Me.connectionView.ImageIndex = 0
      Me.connectionView.ImageList = Me.connectionImageList
      Me.connectionView.Location = New System.Drawing.Point(6, 19)
      Me.connectionView.Name = "connectionView"
      Me.connectionView.SelectedImageIndex = 0
      Me.connectionView.Size = New System.Drawing.Size(170, 383)
      Me.connectionView.TabIndex = 1
      AddHandler Me.connectionView.BeforeExpand, New System.Windows.Forms.TreeViewCancelEventHandler(AddressOf Me.OnConnectionViewExpanding)
      AddHandler Me.connectionView.AfterExpand, New System.Windows.Forms.TreeViewEventHandler(AddressOf Me.ConnectionViewAfterExpand)
      AddHandler Me.connectionView.AfterSelect, New System.Windows.Forms.TreeViewEventHandler(AddressOf Me.OnConnectionViewSelected)
      AddHandler Me.connectionView.NodeMouseClick, New System.Windows.Forms.TreeNodeMouseClickEventHandler(AddressOf Me.OnConnectionViewNodeMouseClick)
      resources.ApplyResources(Me.connectionView, "connectionView")
      ' 
      ' connectionImageList
      ' 
      Me.connectionImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
      Me.connectionImageList.ImageSize = New System.Drawing.Size(16, 16)
      Me.connectionImageList.TransparentColor = System.Drawing.Color.Transparent
      resources.ApplyResources(Me.connectionImageList, "connectionImageList")
      ' 
      ' editConnectionButton
      ' 
      Me.editConnectionButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.editConnectionButton.Enabled = False
      Me.editConnectionButton.Location = New System.Drawing.Point(6, 408)
      Me.editConnectionButton.Name = "editConnectionButton"
      Me.editConnectionButton.Size = New System.Drawing.Size(170, 23)
      Me.editConnectionButton.TabIndex = 2
      Me.editConnectionButton.UseVisualStyleBackColor = True
      AddHandler Me.editConnectionButton.Click, New System.EventHandler(AddressOf Me.OnEditConnectionButtonClick)
      resources.ApplyResources(Me.editConnectionButton, "editConnectionButton")
      ' 
      ' queryGroup
      ' 
      Me.queryGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.queryGroup.Controls.Add(Me.queryTabs)
      Me.queryGroup.Location = New System.Drawing.Point(3, 3)
      Me.queryGroup.Name = "queryGroup"
      Me.queryGroup.Size = New System.Drawing.Size(443, 466)
      Me.queryGroup.TabIndex = 13
      Me.queryGroup.TabStop = False
      resources.ApplyResources(Me.queryGroup, "queryGroup")
      ' 
      ' queryTabs
      ' 
      Me.queryTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.queryTabs.Location = New System.Drawing.Point(6, 19)
      Me.queryTabs.Name = "queryTabs"
      Me.queryTabs.SelectedIndex = 0
      Me.queryTabs.Size = New System.Drawing.Size(431, 441)
      Me.queryTabs.TabIndex = 4
      AddHandler Me.queryTabs.MouseClick, New System.Windows.Forms.MouseEventHandler(AddressOf Me.OnQueryTabsMouseClick)
      resources.ApplyResources(Me.queryTabs, "queryTabs")
      ' 
      ' queryViewMenu
      ' 
      Me.queryViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.closeToolStripMenuItem, Me.closeOthersToolStripMenuItem})
      Me.queryViewMenu.Name = "queryViewMenu"
      Me.queryViewMenu.Size = New System.Drawing.Size(104, 26)
      resources.ApplyResources(Me.queryViewMenu, "queryViewMenu")
      ' 
      ' closeToolStripMenuItem
      ' 
      Me.closeToolStripMenuItem.Name = "closeToolStripMenuItem"
      Me.closeToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
      Me.closeToolStripMenuItem.Text = "Close"
      AddHandler Me.closeToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.OnCloseClick)
      resources.ApplyResources(Me.closeToolStripMenuItem, "closeToolStripMenuItem")
      ' 
      ' closeToolothersStripMenuItem
      ' 
      Me.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem"
      Me.closeOthersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      AddHandler Me.closeOthersToolStripMenuItem.Click, New System.EventHandler(AddressOf Me.OncloseOthersClick)
      resources.ApplyResources(Me.closeOthersToolStripMenuItem, "closeOthersToolStripMenuItem")
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(662, 493)
      Me.Controls.Add(Me.splitContainer)
      Me.Name = "MainForm"
      Me.connectionMenu.ResumeLayout(False)
      Me.splitContainer.Panel1.ResumeLayout(False)
      Me.splitContainer.Panel2.ResumeLayout(False)
      Me.splitContainer.ResumeLayout(False)
      Me.connectionGroup.ResumeLayout(False)
      Me.queryGroup.ResumeLayout(False)
      Me.queryViewMenu.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.Text = resources.GetString("$this.Text")
      ERROR_NO_CONNECTION = resources.GetString("ERROR_NO_CONNECTION")
      TABPAGE_TITLE_FORMAT = resources.GetString("TABPAGE_TITLE_FORMAT")
      CONNECTION_NAME_FORMAT = resources.GetString("CONNECTION_NAME_FORMAT")
      DEFAULT_QUERY_FORMAT = "SELECT * FROM [{0}]"
      EXPANDING_TEXT = resources.GetString("EXPANDING_TEXT")
      REFRESH_TEXT = resources.GetString("REFRESH_TEXT")

    End Sub

#End Region

    Private addConnectionButton As System.Windows.Forms.Button
    Private _dataList As New List(Of QueryData)()
    Private _connectionList As New List(Of ConnectionNode)()
    Private ERROR_NO_CONNECTION As String = Nothing
    Private TABPAGE_TITLE_FORMAT As String = Nothing
    Private CONNECTION_NAME_FORMAT As String = Nothing
    Private DEFAULT_QUERY_FORMAT As String = Nothing
    Private EXPANDING_TEXT As String = Nothing
    Private REFRESH_TEXT As String = Nothing
    Private connectionMenu As ContextMenuStrip
    Private newQueryMenuItem As ToolStripMenuItem
    Private executeMenuItem As ToolStripMenuItem
    Private splitContainer As SplitContainer
    Private queryTabs As TabControl
    Private connectionView As TreeView
    Private editConnectionButton As Button
    Private connectionGroup As GroupBox
    Private procedurePage As ProcedureTabPage
    Private connectionImageList As ImageList
    Private queryViewMenu As ContextMenuStrip
    Private closeToolStripMenuItem As ToolStripMenuItem
    Private closeOthersToolStripMenuItem As ToolStripMenuItem
    Private refreshToolStripMenuItem As ToolStripMenuItem
    Private toolStripSeparator As ToolStripSeparator
    Private queryGroup As GroupBox
    Private Delegate Sub ClearTableDeletgate(control As ComboBox)
    Private Delegate Sub AddTableDeletgate(control As ComboBox, tableName As String())

    Public Sub New()
      InitializeComponent()
      LoadImage()
	  Dim resources = New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
	  Me.procedurePage = New ProcedureTabPage()
	  Me.procedurePage.Location = New System.Drawing.Point(4, 22)
      Me.procedurePage.Name = "procedurePage"
      Me.procedurePage.ProcedureName = Nothing
      Me.procedurePage.Size = New System.Drawing.Size(423, 368)
      Me.procedurePage.TabIndex = 0
      Me.procedurePage.UseVisualStyleBackColor = True
	  resources.ApplyResources(Me.procedurePage, "procedurePage")
    End Sub

    Private Function GetSelectedConnection() As ConnectionNode
      Dim selectedNode As TreeNode = Me.connectionView.SelectedNode
      If selectedNode IsNot Nothing Then
        If TypeOf selectedNode Is ColumnNode Then
          Return DirectCast(selectedNode, ColumnNode).Table.Connection
        ElseIf TypeOf selectedNode Is ParameterNode Then
          Return DirectCast(selectedNode, ParameterNode).Procedure.Connection
        ElseIf TypeOf selectedNode Is TableNode Then
          Return DirectCast(selectedNode, TableNode).Connection
        ElseIf TypeOf selectedNode Is FolderNode Then
          Return DirectCast(selectedNode, FolderNode).Connection
        ElseIf TypeOf selectedNode Is ConnectionNode Then
          Return DirectCast(selectedNode, ConnectionNode)
        End If
      End If
      Return Nothing
    End Function

    Private Sub LoadImage()
      Dim resourceMan As New ResourceManager("Resource", GetType(Resource).Assembly)
      Me.connectionImageList.Images.Add("connection.ico", DirectCast(resourceMan.GetObject("connection"), Icon))
      Me.connectionImageList.Images.Add("table.ico", DirectCast(resourceMan.GetObject("table"), Icon))
      Me.connectionImageList.Images.Add("column.ico", DirectCast(resourceMan.GetObject("column"), Icon))
      Me.connectionImageList.Images.Add("folder.ico", DirectCast(resourceMan.GetObject("folder"), Icon))
      Me.connectionImageList.Images.Add("key.ico", DirectCast(resourceMan.GetObject("key"), Icon))
      Me.refreshToolStripMenuItem.Image = DirectCast(resourceMan.GetObject("refresh"), Icon).ToBitmap()
    End Sub

    Private Sub AddTabPage(type As FolderType, table As String)
      Dim connection As ConnectionNode = GetSelectedConnection()
      Dim have As Boolean = False
      If connection IsNot Nothing Then
        Dim title As String = String.Format(TABPAGE_TITLE_FORMAT, Me.queryTabs.Controls.Count + 1)
        Dim sql As String = ""
        If Not String.IsNullOrEmpty(table) Then
          sql = String.Format(DEFAULT_QUERY_FORMAT, table)
        End If
        Dim newPage As TabPage = Nothing
        If type = FolderType.TABLE Then
          newPage = New TableTabPage(connection, title, sql, Me.components)
        ElseIf type = FolderType.VIEW Then
          newPage = New ViewTabPage(connection, title, sql, Me.components)
        Else
          Me.procedurePage.ProcedureName = table
          Me.procedurePage.Connection = connection
          newPage = Me.procedurePage
        End If
        If Not Me.queryTabs.Controls.Contains(newPage) Then
          If Me.queryTabs.TabPages.Count = 0 Then
            Me.queryTabs.Controls.Add(newPage)
            Me.queryTabs.TabPages(0).Tag = table
			Me.queryTabs.SelectedTab = newPage
          Else
            For I = 0 To Me.queryTabs.TabPages.Count - 1
              If Me.queryTabs.TabPages(I).Tag = table Then
                have = True
				Me.queryTabs.SelectedTab = Me.queryTabs.TabPages(I)
                Exit For
              End If
            Next
            If have <> True Then
              Me.queryTabs.Controls.Add(newPage)
              Me.queryTabs.TabPages(Me.queryTabs.TabPages.Count - 1).Tag = table
			  Me.queryTabs.SelectedTab = newPage
            End If
          End If
        End If
      Else
        MessageBox.Show(ERROR_NO_CONNECTION, Nothing, MessageBoxButtons.OK, MessageBoxIcon.[Error])
      End If
    End Sub

    Private Sub OnAddConnectionButtonClick(sender As Object, e As EventArgs)
      Dim settingFrom As New ConnectionStringForm(Nothing, String.Format(CONNECTION_NAME_FORMAT, Me.connectionView.Nodes.Count + 1))
      If settingFrom.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Me.connectionView.Nodes.Add(New ConnectionNode(settingFrom.connectionString, settingFrom.connectionName))
      End If
    End Sub

    Private Sub OnEditConnectionButtonClick(sender As Object, e As EventArgs)
      Dim selectedConnection As ConnectionNode = GetSelectedConnection()
      Dim settingFrom As New ConnectionStringForm(selectedConnection.ConnectionString, selectedConnection.ConnectionName)
      If settingFrom.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        For Each page As TabPage In Me.queryTabs.TabPages
          If TypeOf page Is ViewTabPage AndAlso DirectCast(page, ViewTabPage).ConnectionName.Equals(selectedConnection.ConnectionName) Then
            DirectCast(page, ViewTabPage).ConnectionName = settingFrom.connectionName
            DirectCast(page, ViewTabPage).ConnectionString = settingFrom.connectionString
          End If
        Next
        selectedConnection.ConnectionName = settingFrom.connectionName
        selectedConnection.ConnectionString = settingFrom.connectionString
      End If
    End Sub

    Private Sub OnConnectionViewSelected(sender As Object, e As TreeViewEventArgs)
      If e.Node.Index >= 0 Then
        Me.editConnectionButton.Enabled = True
      Else
        Me.editConnectionButton.Enabled = False
      End If
    End Sub

    Private Sub OnConnectionViewExpanding(sender As Object, e As TreeViewCancelEventArgs)
      Try
        If TypeOf e.Node Is FolderNode AndAlso Not DirectCast(e.Node, FolderNode).IsListedTable Then
          DirectCast(e.Node, FolderNode).FillNode(EXPANDING_TEXT)
        ElseIf TypeOf e.Node Is TableNode AndAlso Not DirectCast(e.Node, TableNode).IsListedColumn Then
          DirectCast(e.Node, TableNode).FillNode(EXPANDING_TEXT)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1)
      End Try
    End Sub

    Private Sub ConnectionViewAfterExpand(sender As Object, e As TreeViewEventArgs)
      If TypeOf e.Node Is FolderNode AndAlso Not DirectCast(e.Node, FolderNode).IsListedTable AndAlso DirectCast(e.Node, FolderNode).IsExpanded Then
        DirectCast(e.Node, FolderNode).Collapse()
      End If
    End Sub

    Private Sub OnNewQueryMenuItemClick(sender As Object, e As EventArgs)
      If TypeOf Me.connectionView.SelectedNode Is TableNode Then
        Dim selectedTable As TableNode = DirectCast(Me.connectionView.SelectedNode, TableNode)
        AddTabPage(selectedTable.Folder.Type, selectedTable.TableName)
      ElseIf TypeOf Me.connectionView.SelectedNode Is ColumnNode Then
        Dim selectedTable As TableNode = DirectCast(Me.connectionView.SelectedNode, ColumnNode).Table
        AddTabPage(selectedTable.Folder.Type, selectedTable.TableName)
      Else
        AddTabPage(FolderType.TABLE, Nothing)
      End If
    End Sub

    Private Sub OnExecuteMenuItemClick(sender As Object, e As EventArgs)
      Dim selectedTable As TableNode = Nothing
      If Me.connectionView.SelectedNode IsNot Nothing Then
        If TypeOf Me.connectionView.SelectedNode Is TableNode AndAlso DirectCast(Me.connectionView.SelectedNode, TableNode).Folder.Type = FolderType.PRODUCERE Then
          selectedTable = DirectCast(Me.connectionView.SelectedNode, TableNode)
        ElseIf TypeOf Me.connectionView.SelectedNode Is ParameterNode Then
          selectedTable = DirectCast(Me.connectionView.SelectedNode, ParameterNode).Procedure
        End If
      End If
      If selectedTable IsNot Nothing Then
        If Not selectedTable.IsListedColumn Then
          selectedTable.FillNode(Nothing)
        End If
        Dim dialog As New ParameterForm(selectedTable.TableName, selectedTable.Nodes)
        If dialog.ShowDialog() = DialogResult.OK Then
          AddTabPage(FolderType.PRODUCERE, selectedTable.TableName)
          Me.procedurePage.Execute(dialog.parameterView)
        End If
      End If
    End Sub

    Private Sub OnConnectionMenuOpening(sender As Object, e As CancelEventArgs)
      Me.newQueryMenuItem.Visible = False
      Me.executeMenuItem.Visible = False
      Me.toolStripSeparator.Visible = True
      If TypeOf Me.connectionView.SelectedNode Is TableNode AndAlso DirectCast(Me.connectionView.SelectedNode, TableNode).Folder.Type = FolderType.PRODUCERE Then
        Me.executeMenuItem.Visible = True
      ElseIf TypeOf Me.connectionView.SelectedNode Is ParameterNode Then
        Me.executeMenuItem.Visible = True
      ElseIf TypeOf Me.connectionView.SelectedNode Is FolderNode AndAlso DirectCast(Me.connectionView.SelectedNode, FolderNode).Type = FolderType.PRODUCERE Then
        Me.toolStripSeparator.Visible = False
      Else
        Me.newQueryMenuItem.Visible = True
      End If
    End Sub

    Private Sub OnConnectionViewNodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs)
      Me.connectionView.SelectedNode = e.Node
      Dim selectedNode As TreeNode = Me.connectionView.SelectedNode
      If TypeOf Me.connectionView.SelectedNode Is TableNode Then
        If e.Button = MouseButtons.Left Then
          Dim selectedTable As TableNode = DirectCast(Me.connectionView.SelectedNode, TableNode)
          If Me.connectionView.SelectedNode IsNot Nothing Then
            AddTabPage(selectedTable.Folder.Type, selectedTable.TableName)
          End If
        End If
      End If
    End Sub

    Private Sub OnQueryTabsMouseClick(sender As Object, e As MouseEventArgs)
      If e.Button = MouseButtons.Right Then
        Me.queryViewMenu.Show(Me.queryTabs, e.Location)
        Dim i As Integer
        For i = 0 To queryTabs.TabPages.Count
          Dim tp As TabPage
          tp = queryTabs.TabPages(i)
          If queryTabs.GetTabRect(i).Contains(New Point(e.X, e.Y)) Then
            queryTabs.SelectedTab = tp
            Exit For
          End If
        Next i
      ElseIf e.Button = MouseButtons.Middle Then
        Me.queryTabs.TabPages.Remove(Me.queryTabs.SelectedTab)
      End If
    End Sub

    Private Sub OnCloseClick(sender As Object, e As EventArgs)
      Me.queryTabs.TabPages.Remove(Me.queryTabs.SelectedTab)
    End Sub

    Private Sub OncloseOthersClick(sender As Object, e As EventArgs)
      Dim I As Integer
      Dim CurrentTabName As String = Me.queryTabs.SelectedTab.Name()
      Dim TabsCount As Integer = Me.queryTabs.TabPages.Count
      For I = TabsCount - 1 To 0 Step -1
        If Me.queryTabs.SelectedIndex <> I Then
          Me.queryTabs.TabPages.RemoveAt(I)
        End If
      Next
    End Sub

    Private Sub OnRefreshToolStripMenuItemClick(sender As Object, e As EventArgs)
      Dim selectedNode As TreeNode = Me.connectionView.SelectedNode
      If selectedNode IsNot Nothing Then
        If TypeOf selectedNode Is ConnectionNode AndAlso selectedNode.IsExpanded Then
          For Each node As TreeNode In selectedNode.Nodes
            If TypeOf node Is FolderNode AndAlso node.IsExpanded Then
              DirectCast(node, FolderNode).FillNode(REFRESH_TEXT)
            End If
          Next
        ElseIf TypeOf selectedNode Is FolderNode AndAlso selectedNode.IsExpanded Then
          DirectCast(selectedNode, FolderNode).FillNode(REFRESH_TEXT)
        ElseIf TypeOf selectedNode Is TableNode AndAlso selectedNode.IsExpanded Then
          DirectCast(selectedNode, TableNode).FillNode(REFRESH_TEXT)
        ElseIf TypeOf selectedNode Is ColumnNode Then
          DirectCast(selectedNode, ColumnNode).Table.FillNode(REFRESH_TEXT)
        ElseIf TypeOf selectedNode Is ParameterNode Then
          DirectCast(selectedNode, ParameterNode).Procedure.FillNode(REFRESH_TEXT)
        End If
      End If
    End Sub
  End Class
  Class ViewTabPage
    Inherits TabPage
    Private _connection As ConnectionNode = Nothing
    Private _queryString As String = Nothing
    Private _title As String = Nothing
    Protected _data As QueryData = Nothing
    Private _queryTextBox As TextBox = Nothing
    Private _executeButton As Button = Nothing
    Protected _dataView As DataGridView = Nothing
    Private _deleteDataMenuItem As ToolStripMenuItem = Nothing
    Private _dataMenu As ContextMenuStrip = Nothing
    Protected Shared resources As New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
    Protected Shared ReadOnly ERROR_NO_CONNECTION As String = resources.GetString("ERROR_NO_CONNECTION")
    Protected Shared ReadOnly ERROR_NO_QUERY As String = resources.GetString("ERROR_NO_QUERY")
    Protected Shared ReadOnly INFO_NO_CHANGEDDATA As String = resources.GetString("INFO_NO_CHANGEDDATA")

    Public Sub New(connection As ConnectionNode, title As String, sql As String, components As IContainer)
      Me._connection = connection
      Me._queryString = sql
      Me._title = title
      InitializeComponent(components)
      UpdateTitle()
    End Sub

    Public Property QueryString() As String
      Get
        Return Me._queryString
      End Get
      Set
        Me._queryString = value
      End Set
    End Property

    Public Property Title() As String
      Get
        Return Me._title
      End Get
      Set
        Me._title = value
        UpdateTitle()
      End Set
    End Property

    Public Property Connection As ConnectionNode
      Get
        Return Me._connection
      End Get
      Set
        Me._connection = value
      End Set
    End Property

    Public Property ConnectionString() As String
      Get
        Return Me._connection.ConnectionString
      End Get
      Set
        Me._connection.ConnectionString = Value
      End Set
    End Property

    Public Property ConnectionName() As String
      Get
        Return Me._connection.ConnectionName
      End Get
      Set
        Me._connection.ConnectionName = Value
        UpdateTitle()
      End Set
    End Property

    Private Sub InitializeComponent(components As IContainer)
      '
      ' queryTextBox
      '
      _queryTextBox = New TextBox()
      Me._queryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._queryTextBox.ForeColor = System.Drawing.SystemColors.WindowText
      Me._queryTextBox.Location = New System.Drawing.Point(1, 6)
      Me._queryTextBox.Name = "queryText"
      Me._queryTextBox.Size = New System.Drawing.Size(103, 20)
      Me._queryTextBox.Text = Me.QueryString
      Me._queryTextBox.TabIndex = 5
      ' 
      ' executeButton
      ' 
      _executeButton = New Button()
      resources.ApplyResources(Me._executeButton, "_executeButton")
      Me._executeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._executeButton.Location = New System.Drawing.Point(110, 4)
      Me._executeButton.Name = "executeButton"
      Me._executeButton.Size = New System.Drawing.Size(88, 23)
      Me._executeButton.TabIndex = 6
      Me._executeButton.UseVisualStyleBackColor = True
      AddHandler Me._executeButton.Click, New System.EventHandler(AddressOf Me.OnExecuteButtonClick)
      ' 
      ' deleteToolStripMenuItem
      ' 
      _deleteDataMenuItem = New ToolStripMenuItem()
      resources.ApplyResources(Me._deleteDataMenuItem, "_deleteDataMenuItem")
      Me._deleteDataMenuItem.Name = "deleteToolStripMenuItem"
      Me._deleteDataMenuItem.Size = New System.Drawing.Size(61, 4)
      AddHandler Me._deleteDataMenuItem.Click, New System.EventHandler(AddressOf Me.OnDeleteDataMenuItemClick)
      ' 
      ' dataMenu
      ' 
      _dataMenu = New ContextMenuStrip()
      Me._dataMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._deleteDataMenuItem})
      Me._dataMenu.Name = "resultMenu"
      Me._dataMenu.Size = New System.Drawing.Size(32, 19)
      ' 
      ' dataView
      ' 
      _dataView = New DataGridView()
      Me._dataView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me._dataView.ContextMenuStrip = Me._dataMenu
      Me._dataView.TabIndex = 7
      Me._dataView.BorderStyle = BorderStyle.Fixed3D
      Me._dataView.BackgroundColor = System.Drawing.SystemColors.Window
      Me._dataView.Location = New System.Drawing.Point(1, 33)
      Me._dataView.Name = "resultView"
      Me._dataView.Size = New System.Drawing.Size(196, 36)
      AddHandler Me._dataView.DataError, New System.Windows.Forms.DataGridViewDataErrorEventHandler(AddressOf Me.DataGradViewError)
      '
      ' Tabpage
      '
      Me.Controls.Add(Me._queryTextBox)
      Me.Controls.Add(Me._dataView)
      Me.Controls.Add(Me._executeButton)
      Me.Location = New System.Drawing.Point(0, 0)
      Me.Padding = New System.Windows.Forms.Padding(3)
      Me.Size = New System.Drawing.Size(423, 368)
      Me.TabIndex = 0
      Me.UseVisualStyleBackColor = True
    End Sub

    Private Shared Sub ShowMessage(message As String, icon As MessageBoxIcon)
      MessageBox.Show(message, Nothing, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1)
    End Sub

    Protected Shared Sub ShowInfo(info As String)
      ShowMessage(info, MessageBoxIcon.Information)
    End Sub

    Protected Shared Sub ShowError([error] As String)
      ShowMessage([error], MessageBoxIcon.[Error])
    End Sub

    Private Shared Sub DataGradViewError(sendor As Object, e As DataGridViewDataErrorEventArgs)
      ShowMessage(e.Exception.Message, MessageBoxIcon.[Error])
    End Sub
    
    Private Sub UpdateTitle()
      Me.Text = Me.Title &"(" &Me.ConnectionName &")"
    End Sub

    Private Sub OnExecuteButtonClick(sender As Object, e As EventArgs)
      If String.IsNullOrEmpty(Me._queryTextBox.Text) Then
        ShowError(ERROR_NO_QUERY)
        Return
      End If
      Try
        Me._executeButton.Enabled = False
        Me.QueryString = Me._queryTextBox.Text
        Me._data = New QueryData(Me._connection, Me.QueryString)
        Me._dataView.DataSource = Me._data.GetData()
      Catch ex As Exception
        ShowError(ex.Message)
      Finally
        Me._executeButton.Enabled = True
      End Try
    End Sub

    Private Sub OnDeleteDataMenuItemClick(sender As Object, e As EventArgs)
      If Me._dataView.CurrentRow IsNot Nothing Then
        Me._dataView.Rows.Remove(Me._dataView.CurrentRow)
      End If
    End Sub
  End Class

  Class TableTabPage
    Inherits ViewTabPage
    Private _saveButton As Button = Nothing

    Public Sub New(connection As ConnectionNode, title As String, sql As String, components As IContainer)
      MyBase.New(connection, title, sql, components)
      InitializeComponent()
    End Sub

    Private Overloads Sub InitializeComponent()
      ' 
      ' saveButton
      ' 
      _saveButton = New Button()
      resources.ApplyResources(Me._saveButton, "_saveButton")
      Me._saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._saveButton.Location = New System.Drawing.Point(330, 340)
      Me._saveButton.Name = "saveButton"
      Me._saveButton.Size = New System.Drawing.Size(88, 23)
      Me._saveButton.TabIndex = 8
      Me._saveButton.UseVisualStyleBackColor = True
      AddHandler Me._saveButton.Click, New System.EventHandler(AddressOf Me.OnSaveButtonClick)
      '
      ' TableTabPage
      '
      Me.Controls.Add(Me._saveButton)
    End Sub

    Private Sub OnSaveButtonClick(sender As Object, e As EventArgs)
      If Me._dataView.DataSource Is Nothing Then
        ShowInfo(INFO_NO_CHANGEDDATA)
        Return
      End If
      Try
        Me._saveButton.Enabled = False
        Me._data.Update(DirectCast(Me._dataView.DataSource, DataTable))
      Catch ex As Exception
        ShowError(ex.Message)
      Finally
        Me._saveButton.Enabled = True
      End Try
    End Sub
  End Class

  Class ProcedureTabPage
    Inherits TabPage
    Private _outputTextBox As TextBox
    Private _connection As ConnectionNode = Nothing
    Private _procedureName As String = Nothing
    Private _data As QueryData = Nothing
    Protected Shared resources As New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
    Private Shared ReadOnly EXECUTING_MESSAGE_FORMAT As String = resources.GetString("EXECUTING_MESSAGE_FORMAT")
    Private Shared ReadOnly FINISHED_MESSAGE_FORMAT As String = resources.GetString("FINISHED_MESSAGE_FORMAT")
    Private Shared ReadOnly ERROR_MESSAGE_FORMAT As String = resources.GetString("ERROR_MESSAGE_FORMAT")
    Private Shared ReadOnly NULL_VALUE As String = "NULL"

    Public Sub New()
      MyBase.New()
      InitializeComponent()
    End Sub

    Public Property Connection() As ConnectionNode
      Get
        Return Me._connection
      End Get
      Set
        Me._connection = value
      End Set
    End Property

    Public Property ProcedureName() As String
      Get
        Return Me._procedureName
      End Get
      Set
        Me._procedureName = value
      End Set
    End Property

    Private Sub InitializeComponent()
      Me._outputTextBox = New System.Windows.Forms.TextBox()
      ' 
      ' procedurePage
      ' 
      resources.ApplyResources(Me, "procedurePage")
      Me.Controls.Add(Me._outputTextBox)
      Me.Location = New System.Drawing.Point(4, 22)
      Me.Name = "procedurePage"
      Me.Size = New System.Drawing.Size(423, 368)
      Me.TabIndex = 0
      Me.UseVisualStyleBackColor = True
      ' 
      ' outputTextBox
      ' 
      Me._outputTextBox.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
      Me._outputTextBox.BackColor = System.Drawing.SystemColors.Window
      Me._outputTextBox.Location = New System.Drawing.Point(3, 3)
      Me._outputTextBox.Multiline = True
      Me._outputTextBox.ScrollBars = ScrollBars.Both
      Me._outputTextBox.WordWrap = False
      Me._outputTextBox.Name = "outputTextBox"
      Me._outputTextBox.[ReadOnly] = True
      Me._outputTextBox.Size = New System.Drawing.Size(417, 362)
      Me._outputTextBox.TabIndex = 0
    End Sub

    Public Sub AppendOutput(output As String)
      If Not String.IsNullOrEmpty(output) Then
        Me._outputTextBox.AppendText(output)
      End If
      Me._outputTextBox.AppendText(Environment.NewLine)
      Me._outputTextBox.ScrollToCaret()
    End Sub

    Public Sub Execute(paramters As DataGridView)
      Dim input As Hashtable = GetParameter(paramters, ParameterDirection.Input)
      Dim output As Hashtable = GetParameter(paramters, ParameterDirection.Output)
      Dim inOut As Hashtable = GetParameter(paramters, ParameterDirection.InputOutput)
      Dim returned As Hashtable = GetParameter(paramters, ParameterDirection.ReturnValue)

      AppendOutput(String.Format(EXECUTING_MESSAGE_FORMAT, Me.ProcedureName))
      Try
        Me._data = New QueryData(Me._connection, Me.ProcedureName)
        Dim result As DataTable = Me._data.ExecSP(input, output, inOut, returned)
        AppendOutput(FormatResult(result))
        AppendOutput(String.Format(FINISHED_MESSAGE_FORMAT, result.Rows.Count))
      Catch ex As Exception
        AppendOutput(String.Format(ERROR_MESSAGE_FORMAT, Me.ProcedureName, ex.Message))
      End Try
    End Sub

    Private Function FormatResult(result As DataTable) As String
      Dim columnRowBuilder As New StringBuilder()
      For i As Integer = 0 To result.Columns.Count - 1
        columnRowBuilder.AppendLine(result.Columns(i).ColumnName)
        For j As Integer = 0 To result.Rows.Count - 1
          columnRowBuilder.AppendLine(result.Rows(j).ItemArray(i).ToString())
        Next
        columnRowBuilder.AppendLine()
      Next
      Return columnRowBuilder.ToString()
    End Function

    Private Function GetParameter(paramters As DataGridView, direction As ParameterDirection) As Hashtable
      If paramters IsNot Nothing Then 'AndAlso direction IsNot Nothing Then
        Dim result As New Hashtable()
        For Each row As DataGridViewRow In paramters.Rows
          If direction.ToString().Equals(DirectCast(row.Cells("directionColumn").Value, String), StringComparison.CurrentCultureIgnoreCase) Then
            Dim name As String = DirectCast(row.Cells("nameColumn").Value, String)
            If Not String.IsNullOrEmpty(name) Then
              Dim value As String = DirectCast(row.Cells("valueColumn").Value, String)
              If Not String.IsNullOrEmpty(value) Then
                If value.Equals(ParameterForm.COMBOBOX_VALUE_DEFAULT, StringComparison.CurrentCultureIgnoreCase) Then
                  ' Don't set this parameter.
                  Continue For
                ElseIf value.Equals(ParameterForm.COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase) Then
                  value = NULL_VALUE
                End If
              End If
              result.Add(name, value)
            End If
          End If
        Next
        Return result
      End If
      Return Nothing
    End Function
  End Class

  Enum FolderType
    TABLE
    VIEW
    PRODUCERE
  End Enum

  Class FolderNode
    Inherits TreeNode
    Private _connection As ConnectionNode = Nothing
    Private _type As FolderType = FolderType.TABLE
    Private _listedTable As Boolean = False
    Private _name As String = Nothing
    Private Shared resources As New System.ComponentModel.ComponentResourceManager(GetType(GenerationForm))
    Private Shared ReadOnly TABLE_TEXT As String = resources.GetString("TABLE_TEXT")
    Private Shared ReadOnly VIEW_TEXT As String = resources.GetString("VIEW_TEXT")
    Private Shared ReadOnly PROCEDURE_TEXT As String = resources.GetString("PROCEDURE_TEXT")
    Private Shared ReadOnly CONNECTION_ERROR As String = resources.GetString("CONNECTION_ERROR")

    Public Sub New(conn As ConnectionNode, type As FolderType)
      Me._connection = conn
      Me._type = type
      If type = FolderType.TABLE Then
        Me._name = TABLE_TEXT
      ElseIf type = FolderType.VIEW Then
        Me._name = VIEW_TEXT
      Else
        Me._name = PROCEDURE_TEXT
      End If
      Me.Text = Me._name
      Me.ImageKey = "folder.ico"
      Me.SelectedImageKey = Me.ImageKey
        ' Add a empty node to show the expand icon.
      Me.Nodes.Add("")
    End Sub

    Public ReadOnly Property Connection() As ConnectionNode
      Get
        Return Me._connection
      End Get
    End Property

    Public ReadOnly Property Type() As FolderType
      Get
        Return Me._type
      End Get
    End Property

    Public Property IsListedTable() As Boolean
      Get
        Return Me._listedTable
      End Get
      Set
        Me._listedTable = value
      End Set
    End Property

    Public Sub FillNode(status As String)
      If Not String.IsNullOrEmpty(status) Then
        Me.Text = Me.Text &status
        Me.TreeView.Update()
      End If
      Try
        Dim tablesname As String() = Nothing
        Try
          If Me.Type = FolderType.TABLE Then
            tablesname = GetTablesName("BASE TABLE")
          ElseIf Me.Type = FolderType.VIEW Then
            tablesname = GetTablesName("VIEW")
          Else
            tablesname = GetProcuderesName()
          End If
        Catch ex As Exception
          Throw New Exception(CONNECTION_ERROR &vbLf + ex.Message)
        End Try
        Me.Nodes.Clear()
        For Each name As String In tablesname
          Me.Nodes.Add(New TableNode(Me.Connection, Me, name))
        Next
        Me.IsListedTable = True
      Catch ex As Exception
        Me.IsListedTable = False
        Throw ex
      Finally
        Me.Text = Me._name
        Me.TreeView.Update()
      End Try
    End Sub

    Private Function GetTablesName(type As String) As String()
      Dim conn As New MongoDBConnection(Me._connection.ConnectionString)
      conn.Open()
      Dim schema As DataTable = conn.GetSchema("TABLES", Nothing)
      Dim tables As DataRow() = schema.[Select]("TABLE_TYPE='" &type &"'")
      Dim index As Integer = schema.Columns.IndexOf("TABLE_NAME")
      Dim tablesname As String() = New String(tables.Length - 1) {}
      For i As Integer = 0 To tables.Length - 1
        tablesname(i) = DirectCast(tables(i).ItemArray(index), String)
      Next
      Return tablesname
    End Function

    Private Function GetProcuderesName() As String()
      Dim conn As New MongoDBConnection(Me._connection.ConnectionString)
      conn.Open()
      Dim schema As DataTable = conn.GetSchema("PROCEDURES", Nothing)
      Dim tables As DataRow() = schema.[Select]()
      Dim index As Integer = schema.Columns.IndexOf("PROCEDURE_NAME")
      Dim tablesname As String() = New String(tables.Length - 1) {}
      For i As Integer = 0 To tables.Length - 1
        tablesname(i) = DirectCast(tables(i).ItemArray(index), String)
      Next
      Return tablesname
    End Function
  End Class

  Class TableNode
    Inherits TreeNode
    Private _name As String = Nothing
    Private _connection As ConnectionNode = Nothing
    Private _folder As FolderNode = Nothing
    Private _listedColumn As Boolean = False

    Public Sub New(conn As ConnectionNode, folder As FolderNode, tablename As String)
      Me._name = tablename
      Me._connection = conn
      Me._folder = folder
      Me.Text = tablename
      Me.ImageKey = "table.ico"
      Me.SelectedImageKey = Me.ImageKey
        ' Add a empty node to show the expand icon.
      Me.Nodes.Add("")
    End Sub

    Public ReadOnly Property TableName() As String
      Get
        Return Me._name
      End Get
    End Property

    Public ReadOnly Property Connection() As ConnectionNode
      Get
        Return Me._connection
      End Get
    End Property

    Public ReadOnly Property Folder() As FolderNode
      Get
        Return Me._folder
      End Get
    End Property

    Public Property IsListedColumn() As Boolean
      Get
        Return Me._listedColumn
      End Get
      Set
        Me._listedColumn = value
      End Set
    End Property

    Public Sub FillNode(status As String)
      If Not String.IsNullOrEmpty(status) Then
        Me.Text = Me.Text &status
        Me.TreeView.Update()
      End If
      Try
        Dim conn As New MongoDBConnection(Me._connection.ConnectionString)
        conn.Open()
        If Me.Folder.Type = FolderType.PRODUCERE Then
          Dim parameterTable As DataTable = conn.GetSchema("ProcedureParameters", New String() {Me.TableName})
          Me.Nodes.Clear()
          For Each row As DataRow In parameterTable.Rows
            Me.Nodes.Add(New ParameterNode(row("ParameterName").ToString(), ParameterNode.GetTypeString(row("DataType").ToString()), Me, ParameterNode.ParseMode(row("Mode").ToString())))
          Next
        Else
          Dim columnTable As DataTable = conn.GetSchema("Columns", New String() {Me.TableName})
          Me.Nodes.Clear()
          For Each row As DataRow In columnTable.Rows
            Me.Nodes.Add(New ColumnNode(row("ColumnName").ToString(), [Boolean].Parse(row("IsKey").ToString()), Me))
          Next
        End If
      Catch ex As Exception
        Throw ex
      Finally
        Me.Text = Me.TableName
        Me.TreeView.Update()
        Me.IsListedColumn = True
      End Try
    End Sub
  End Class

  Class ColumnNode
    Inherits TreeNode
    Private _iskey As Boolean = False
    Private _columnName As String = Nothing
    Private _table As TableNode = Nothing

    Public Sub New(name As String, iskey As Boolean, table As TableNode)
      Me._columnName = name
      Me._iskey = iskey
      Me._table = table
      Me.Text = Me.ColumnName
      If Me.IsKey Then
        Me.ImageKey = "key.ico"
      Else
        Me.ImageKey = "column.ico"
      End If
      Me.SelectedImageKey = Me.ImageKey
    End Sub

    Public Property ColumnName() As String
      Get
        Return Me._columnName
      End Get
      Set
        Me._columnName = value
      End Set
    End Property

    Public Property IsKey() As Boolean
      Get
        Return Me._iskey
      End Get
      Set
        Me._iskey = value
      End Set
    End Property

    Public Property Table() As TableNode
      Get
        Return Me._table
      End Get
      Set
        Me._table = value
      End Set
    End Property
  End Class

  Class ParameterNode
    Inherits TreeNode
    Public Shared IN_MODE_TEXT As String = "IN"
    Public Shared INOUT_MODE_TEXT As String = "IN/OUT"
    Public Shared OUT_MODE_TEXT As String = "OUT"
    Public Shared RETURN_MODE_TEXT As String = "RETURN"
    Private Shared ReadOnly NAME_FORMAT As String = "{0} ({1}, {2})"
    Private _parameterName As String = Nothing
    Private _parameterType As String = Nothing
    Private _procedure As TableNode = Nothing
    Private _mode As ParameterDirection = ParameterDirection.Input

    Public Sub New(name As String, type As String, procedure As TableNode, mode As ParameterDirection)
      Me._parameterName = name
      Me._parameterType = type
      Me._procedure = procedure
      Me._mode = mode
      UpdateName()
      Me.ImageKey = "column.ico"
      Me.SelectedImageKey = Me.ImageKey
    End Sub

    Public Property ParameterName() As String
      Get
        Return Me._parameterName
      End Get
      Set
        Me._parameterName = value
      End Set
    End Property

    Public Property ParameterType() As String
      Get
        Return Me._parameterType
      End Get
      Set
        Me._parameterType = value
      End Set
    End Property

    Public Property Procedure() As TableNode
      Get
        Return Me._procedure
      End Get
      Set
        Me._procedure = value
      End Set
    End Property

    Public Property Mode() As ParameterDirection
      Get
        Return Me._mode
      End Get
      Set
        Me._mode = value
      End Set
    End Property

    Private Sub UpdateName()
      Me.Text = String.Format(NAME_FORMAT, Me.ParameterName, Me.ParameterType, Me.Mode.ToString())
    End Sub

    Public Shared Function ParseMode(modeString As String) As ParameterDirection
      If IN_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase) Then
        Return ParameterDirection.Input
      ElseIf INOUT_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase) Then
        Return ParameterDirection.InputOutput
      ElseIf OUT_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase) Then
        Return ParameterDirection.Output
      ElseIf RETURN_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase) Then
        Return ParameterDirection.ReturnValue
      Else
        Return ParameterDirection.Input
      End If
    End Function

    Public Shared Function GetTypeString(type As String) As String
      If type IsNot Nothing Then
        Dim idx As Integer = type.LastIndexOf("."C)
        If idx > 0 AndAlso idx < type.Length - 1 Then
          Return type.Substring(idx + 1)
        End If
      End If
      Return Nothing
    End Function
  End Class

  Class ConnectionNode
    Inherits TreeNode
    Private _connectionString As String = Nothing
    Private _connectionName As String = Nothing
    Private _connection As MongoDBConnection = Nothing

    Public Sub New(connection As String, name As String)
      Me._connectionString = connection
      Me._connectionName = name
      Me.Text = Me._connectionName
      Me.ImageKey = "connection.ico"
      Me.SelectedImageKey = Me.ImageKey
      Me.Nodes.Add(New FolderNode(Me, FolderType.TABLE))
      Me.Nodes.Add(New FolderNode(Me, FolderType.VIEW))
      Me.Nodes.Add(New FolderNode(Me, FolderType.PRODUCERE))
    End Sub

    Public Property ConnectionString() As String
      Get
        Return Me._connectionString
      End Get
      Set
        Me._connectionString = value
        _connection = Nothing
      End Set
    End Property

    Public Property ConnectionName() As String
      Get
        Return Me._connectionName
      End Get
      Set
        Me._connectionName = value
        Me.Text = value
      End Set
    End Property

    Public ReadOnly Property Connection() As MongoDBConnection
      Get
        If _connection Is Nothing Then
          _connection = New MongoDBConnection(Me._connectionString)
        End If
        If _connection.State = ConnectionState.Closed Then
          _connection.Open()
        End If
        Return _connection
      End Get
    End Property
  End Class
End Namespace