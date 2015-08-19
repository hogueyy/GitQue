Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.CData.MongoDB
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections
Imports System.ComponentModel

Namespace CData.MongoDB.Demo
 
  Class QueryData
    Private _connection As ConnectionNode
    Private _sql As String
    Private _adapter As MongoDBDataAdapter = Nothing
    Private _updateCommandBuilder As MongoDBCommandBuilder = Nothing
    Private _conn As MongoDBConnection = Nothing
    Public Sub New(connection As ConnectionNode, sql As String)
      Me._connection = connection
      Me._sql = sql
    End Sub

    Public Function GetData() As DataTable
      Dim conn As MongoDBConnection = _connection.Connection
      Dim cmd As MongoDBCommand = conn.CreateCommand()
      cmd.CommandText = Me._sql
      cmd.CommandType = CommandType.Text
      Me._adapter = New MongoDBDataAdapter(cmd)
      Me._updateCommandBuilder = New MongoDBCommandBuilder(Me._adapter)
      Dim result As New DataTable()
      If Me._sql.ToUpper().TrimStart().StartsWith("SELECT") Then
        Me._adapter.Fill(result)
      Else
        Dim rowsAffected As Integer = cmd.ExecuteNonQuery() 
        result.Columns.Add("Rows Affected")
        Dim row As DataRow =  result.NewRow() 
        row(0) = rowsAffected
        result.Rows.Add(row)
      End If
      Return result
    End Function

    Public Function ExecSP(input As Hashtable, output As Hashtable, inputOutput As Hashtable, returnValue As Hashtable) As DataTable
      Dim conn As MongoDBConnection = _connection.Connection
      Dim cmd As MongoDBCommand = conn.CreateCommand()
      cmd.CommandText = Me._sql
      cmd.CommandType = CommandType.StoredProcedure
      SetParameters(cmd, input, output, inputOutput, returnValue)
      Me._adapter = New MongoDBDataAdapter(cmd)
      Dim result As New DataTable(Me._sql)
      Me._adapter.Fill(result)
      GetOutput(cmd, output, inputOutput, returnValue)
      Return result
    End Function

    Public Sub Update(data As DataTable)
      Me._adapter.InsertCommand = Me._updateCommandBuilder.GetInsertCommand()
      Me._adapter.UpdateCommand = Me._updateCommandBuilder.GetUpdateCommand()
      Me._adapter.DeleteCommand = Me._updateCommandBuilder.GetDeleteCommand()
      Me._adapter.Update(data)
    End Sub

    Private Sub SetParameters(cmd As MongoDBCommand, input As Hashtable, output As Hashtable, inputOutput As Hashtable, returnValue As Hashtable)
      For Each key As Object In input.Keys
        Dim param As MongoDBParameter = cmd.Parameters.Add(key.ToString())
        param.Value = input(key)
        param.Direction = ParameterDirection.Input
      Next
      For Each key As Object In output.Keys
        Dim param As MongoDBParameter = cmd.Parameters.Add(key.ToString())
        param.Value = output(key)
        param.Direction = ParameterDirection.Output
      Next
      For Each key As Object In inputOutput.Keys
        Dim param As MongoDBParameter = cmd.Parameters.Add(key.ToString())
        param.Value = inputOutput(key)
        param.Direction = ParameterDirection.InputOutput
      Next
      For Each key As Object In returnValue.Keys
        Dim param As MongoDBParameter = cmd.Parameters.Add(key.ToString())
        param.Value = returnValue(key)
        param.Direction = ParameterDirection.ReturnValue
      Next
    End Sub

    Private Sub GetOutput(cmd As MongoDBCommand, output As Hashtable, inputOutput As Hashtable, returnValue As Hashtable)
      For Each param As MongoDBParameter In cmd.Parameters
        If param.Direction = ParameterDirection.Output Then
          output(param.ParameterName) = param.Value
        ElseIf param.Direction = ParameterDirection.InputOutput Then
          inputOutput(param.ParameterName) = param.Value
        ElseIf param.Direction = ParameterDirection.ReturnValue Then
          returnValue(param.ParameterName) = param.Value
        End If
      Next
    End Sub
  End Class
End Namespace