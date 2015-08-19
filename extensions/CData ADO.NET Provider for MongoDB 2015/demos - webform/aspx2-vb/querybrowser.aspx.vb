Imports System.Data
Imports System.Data.CData.MongoDB

Public Partial Class _Default
  Inherits System.Web.UI.Page
  Private Query As [String] = "SELECT * FROM "
  Private conn As MongoDBConnection = Nothing
	Protected Sub Page_Load(sender As Object, e As EventArgs)
  	lblconnecterror.Text = Nothing
	  lblexecuteerror.Text = Nothing
    If Not IsPostBack Then

    End If
	End Sub
  Protected Sub ddl_SelectedIndexChanged(sender As Object, e As EventArgs)
    Update_Query()
  End Sub

  Protected Sub butexe_Click(sender As Object, e As EventArgs)
    Dim connstr As String = DirectCast(Session("connstr"), String)
    If String.IsNullOrEmpty(connstr) Then
      connstr = GetConnectionString()
    End If
    Dim sql As String = txtQuery.Text
    Try
      If conn Is Nothing Then
        conn = New MongoDBConnection(connstr)
      End If
      Dim table As New DataTable()
      Dim command As New MongoDBCommand(sql, conn)
      If sql.ToUpper().TrimStart().StartsWith("SELECT") Then
        Dim adapter As New MongoDBDataAdapter(command)
        adapter.Fill(table)
        If table.Rows.Count = 0 Then
          table.Rows.Add(table.NewRow())
        End If
      Else
        Dim rowsAffected As Integer = command.ExecuteNonQuery() 
        table.Columns.Add("Rows Affected")
        Dim row As DataRow =  table.NewRow() 
        row(0) = rowsAffected
        table.Rows.Add(row)
      End If
      gv.DataSource = table
      gv.DataBind()
      lblexecuteerror.Text = Nothing
    Catch ex As Exception
      lblexecuteerror.Text = "<font color=red><b>" &ex.Message &"</b></font>"
    End Try
  End Sub

  Protected Function ddl_bind(schema As DataTable) As Boolean
    If schema Is Nothing Then
      Return False
    End If
    ddl.Items.Clear()
    ddl.DataTextField = schema.Columns(2).ToString()
    ddl.DataSource = schema
    ddl.DataBind()
    Update_Query()
    If ddl.Items.Count <= 0 Then
      Return False
    End If
    Return True
  End Function

  Protected Function GetConnectionString() As [String]
    Dim connstr As String = ""

    Session("connstr") = connstr
    Return connstr
  End Function

  Protected Sub bntconnect_Click(sender As Object, e As EventArgs)
    conn = New MongoDBConnection()
    Dim connstr As String = GetConnectionString()
    Try
      conn.ConnectionString = connstr
      conn.Open()
      Dim schema As DataTable = conn.GetSchema("Tables")
      If Not ddl_bind(schema) Then
        Throw New Exception("No tables available.")
      End If
      conn.TestConnection()
      lblconnecterror.Text = Nothing
    Catch ex As Exception
	   lblconnecterror.Text = "<font color=red><b>" &ex.Message &"</b></font>"
    End Try
  End Sub

  Protected Sub ddl_TextChanged(sender As Object, e As EventArgs)
    Update_Query()
  End Sub

  Protected Sub Update_Query()
    txtQuery.Text = Query
    Dim table As String = ddl.Text
    Dim limit As String = txtlimit.Text
    If Not String.IsNullOrEmpty(table) Then
      txtQuery.Text += ("[" + ddl.Text &"] ")
    End If
    If Not String.IsNullOrEmpty(limit) Then
      txtQuery.Text += ("LIMIT " + txtlimit.Text)
    End If
  End Sub
End Class
