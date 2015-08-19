<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="querybrowser.aspx.cs" Inherits="_Default"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link href="stylesheet.css" type="text/css" rel="stylesheet" />
  <style type="text/css">
    .control
    {
      vertical-align : middle;
    }
    .style1
    {
        width: 128px;
    }
    .auto-style1 {
        width: 97px;
    }
  </style></head>
<body>
  <div id="content">
    <h1>CData ADO.NET Provider for MongoDB - <asp:localize ID="Localize1" runat="server" Text="<%$ Resources:Resource, QueryBrowserDemo %>"/></h1>
    <h2><asp:localize ID="Localize2" runat="server" Text="<%$ Resources:Resource, QueryBrowserDesc%>"/></h2>
    <p>
      <asp:localize ID="Localize3" runat="server" Text="<%$ Resources:Resource, QueryBrowserDesc1%>"/>
    </p>
    <hr size="1" />
      <form id="form1" runat="server">
        <div>
          <fieldset class="login">
            <legend>Connection String</legend>
              <table style="width:100%; margin-left: 0px;" dir="ltr" frame="lhs">

                  <tr>
                    <td class="style1" dir="ltr" width="10px">
                    </td>
                    <td style="text-align: left;">
                    <asp:Button ID="bntconnect" runat="server" onclick="bntconnect_Click" 
                            Text="<%$ Resources:Resource, ButtonConnect %>" Width="93px" />
                        <asp:Label ID="lblconnecterror" runat="server"></asp:Label>
                    </td>
                  </tr>
              </table>
            </fieldset>
          <hr size="1" />
          <fieldset class="Query">
          <legend><asp:localize ID="Localize5" runat="server" Text="<%$ Resources:Resource, QueryTitle%>"/></legend>
            <table style="width:100%; margin-left: 0px;" dir="ltr" frame="lhs">
              <tr>
                <td class="style1" dir="ltr" rowspan="1" style="text-align: center;">
                  <asp:Label ID="lbltable" runat="server" AssociatedControlID="ddl" 
                        Text="<%$ Resources:Resource, Tables %>" />
                </td>
                <td width="300px">
                  <asp:DropDownList ID="ddl" runat="server" 
                      Width="198px" AutoPostBack="True" 
                      onselectedindexchanged="ddl_SelectedIndexChanged" Height="22px">
                  </asp:DropDownList>
                </td>
                <td class="style1" style="text-align: right;" width="125px">
                    <asp:Label ID="lbllimit" runat="server" Text="<%$ Resources:Resource, MaxRows %>"
                        AssociatedControlID="txtlimit"></asp:Label>     
                </td>
                <td>
                    <asp:TextBox ID="txtlimit" runat="server" AutoPostBack="True" 
                        ontextchanged="ddl_SelectedIndexChanged">10</asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="style1" dir="ltr" style="text-align: center;">
                    <asp:Label ID="lblquery" runat="server" AssociatedControlID="txtQuery" 
                        EnableTheming="False" Text="<%$ Resources:Resource, Query %>"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtQuery" runat="server" Width="394px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td class="style1" dir="ltr" style="text-align: center;">
                </td>
                <td colspan="3">
                    <asp:Button ID="butexe" runat="server" Text="<%$ Resources:Resource, ExecuteQuery %>" Width="109px" 
                        onclick="butexe_Click" text-align = "center" CssClass="style1"/>
                    <asp:Label ID="lblexecuteerror" runat="server"></asp:Label>
                </td>
              </tr>
            </table>
          </fieldset>
          <hr size="1" />
          <fieldset class="Results">
            <legend>Results</legend>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="True" 
                EnableModelValidation="True" EnableSortingAndPagingCallbacks="True"/>
          </fieldset>
        </div>
        <hr size="1" />
        <p>
          <asp:localize ID="Localize4" runat="server" Text="<%$ Resources:Resource, Note%>"/>
        </p>
        <hr size="1" />
      </form>
  </div></body></html>