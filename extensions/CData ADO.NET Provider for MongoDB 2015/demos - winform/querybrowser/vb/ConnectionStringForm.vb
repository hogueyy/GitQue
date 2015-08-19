Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.CData.MongoDB
Imports System.Data.Common
Imports System.Resources
Imports System.Threading
Imports System.Reflection
Imports System.ComponentModel
Namespace CData.MongoDB.Demo
  Public Class ConnectionStringForm
    Inherits Form
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Private CONNECTED_SUCCESSFULLY As String = Nothing
    Private CONNECTION_NAME_EMPTY As String = Nothing
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

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>     
    ''' 
    Private Sub InitializeComponent()
      Dim resources = New System.ComponentModel.ComponentResourceManager(GetType(ConnectionStringForm))
      Me.connectionSettingLabel = New System.Windows.Forms.Label()
      Me.settingPropertyGrid = New System.Windows.Forms.PropertyGrid()
      Me.cancelButton = New System.Windows.Forms.Button()
      Me.okButton = New System.Windows.Forms.Button()
      Me.testbutton = New System.Windows.Forms.Button()
      Me.connectionNameLabel = New System.Windows.Forms.Label()
      Me.connectionNameText = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      ' 
      ' connectionSettingLabel
      ' 
      Me.connectionSettingLabel.AutoSize = True
      Me.connectionSettingLabel.Location = New System.Drawing.Point(12, 9)
      Me.connectionSettingLabel.Name = "connectionSettingLabel"
      Me.connectionSettingLabel.Size = New System.Drawing.Size(185, 13)
      Me.connectionSettingLabel.TabIndex = 17
      Me.connectionSettingLabel.Text = resources.GetString("ConnectionSettingLabel_Text")
      ' 
      ' settingPropertyGrid
      ' 
      Me.settingPropertyGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.settingPropertyGrid.Location = New System.Drawing.Point(15, 77)
      Me.settingPropertyGrid.Name = "settingPropertyGrid"
      Me.settingPropertyGrid.Size = New System.Drawing.Size(405, 366)
      Me.settingPropertyGrid.TabIndex = 2
      ' 
      ' cancelButton
      ' 
      Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cancelButton.Location = New System.Drawing.Point(345, 449)
      Me.cancelButton.Name = "cancelButton"
      Me.cancelButton.Size = New System.Drawing.Size(76, 23)
      Me.cancelButton.TabIndex = 5
      Me.cancelButton.UseVisualStyleBackColor = True
      Me.cancelButton.Text = resources.GetString("CancelButton_Text")
      ' 
      ' okButton
      ' 
      Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.okButton.Location = New System.Drawing.Point(264, 449)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(76, 23)
      Me.okButton.TabIndex = 4
      Me.okButton.Text = "OK"
      Me.okButton.UseVisualStyleBackColor = True
      AddHandler Me.okButton.Click, New System.EventHandler(AddressOf Me.OnOkButtonClick)
      ' 
      ' testbutton
      ' 
      Me.testbutton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.testbutton.Location = New System.Drawing.Point(15, 449)
      Me.testbutton.Name = "testbutton"
      Me.testbutton.Size = New System.Drawing.Size(103, 23)
      Me.testbutton.TabIndex = 3
      Me.testbutton.UseVisualStyleBackColor = True
      AddHandler Me.testbutton.Click, New System.EventHandler(AddressOf Me.OnTestButtonClick)
      Me.testbutton.Text = resources.GetString("Testbutton_Text")
      ' 
      ' connectionNameLabel
      ' 
      Me.connectionNameLabel.AutoSize = True
      Me.connectionNameLabel.Location = New System.Drawing.Point(12, 34)
      Me.connectionNameLabel.Name = "connectionNameLabel"
      Me.connectionNameLabel.Size = New System.Drawing.Size(95, 13)
      Me.connectionNameLabel.TabIndex = 22
      Me.connectionNameLabel.Text = resources.GetString("ConnectionNameLabel_Text")
      ' 
      ' connectionNameText
      ' 
      Me.connectionNameText.Location = New System.Drawing.Point(15, 51)
      Me.connectionNameText.Name = "connectionNameText"
      Me.connectionNameText.Size = New System.Drawing.Size(405, 20)
      Me.connectionNameText.TabIndex = 1
      ' 
      ' ConnectionStringForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(432, 484)
      Me.Controls.Add(Me.connectionNameText)
      Me.Controls.Add(Me.connectionNameLabel)
      Me.Controls.Add(Me.testbutton)
      Me.Controls.Add(Me.okButton)
      Me.Controls.Add(Me.cancelButton)
      Me.Controls.Add(Me.settingPropertyGrid)
      Me.Controls.Add(Me.connectionSettingLabel)
      Me.DoubleBuffered = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ConnectionStringForm"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.OnSettingsFormClosed)
      AddHandler Me.Load, New System.EventHandler(AddressOf Me.OnSettingsFormLoad)
      Me.ResumeLayout(False)
      Me.PerformLayout()
      Me.Text = resources.GetString("ConnectionStringForm_Text")
      Me.CONNECTED_SUCCESSFULLY = resources.GetString("CONNECTED_SUCCESSFULLY")
      Me.CONNECTION_NAME_EMPTY = resources.GetString("CONNECTION_NAME_EMPTY")
    End Sub
    Private connectionSettingLabel As System.Windows.Forms.Label
    Private settingPropertyGrid As System.Windows.Forms.PropertyGrid
    Private cancelButton As System.Windows.Forms.Button
    Private okButton As System.Windows.Forms.Button
    Private testbutton As System.Windows.Forms.Button

    Private _builder As MongoDBConnectionStringBuilder = Nothing
    Private _testConnectionTread As Thread = Nothing
    Public connectionString As String = Nothing
    Public connectionName As String = Nothing
    Private connectionNameLabel As Label
    Private connectionNameText As TextBox
    Private _aborted As Boolean = False
    Private Delegate Sub EnableControlDeletgate(control As Control, enable As Boolean)
    Private Delegate Sub SetCursorDelegate(form As Form, cursor As Cursor)

    Public Sub New(connectionString As String, name As String)
      InitializeComponent()
      Me._builder = New MyConnectionStringBuilder()
      Me.connectionString = connectionString
      Me.connectionName = name
    End Sub

    Private Sub TestConnection()
      Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.settingPropertyGrid, False)
      Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.okButton, False)
      Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.testbutton, False)
      Me.Invoke(New SetCursorDelegate(AddressOf DoSetCursor), Me, Cursors.WaitCursor)
      Try
        Dim _conn As New MongoDBConnection(_builder.ConnectionString)
        If _conn.State = ConnectionState.Closed Then
          _conn.Open()
        End If
        _conn.TestConnection()
        _conn.Close()
        MessageBox.Show(CONNECTED_SUCCESSFULLY, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
      Catch ex As Exception
        If Not Me._aborted Then
          MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1)
        End If
        Return
      Finally
        If Not Me._aborted Then
          Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.settingPropertyGrid, True)
          Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.okButton, True)
          Me.Invoke(New EnableControlDeletgate(AddressOf DoEnableControl), Me.testbutton, True)
          Me.Invoke(New SetCursorDelegate(AddressOf DoSetCursor), Me, Cursors.[Default])
        End If
      End Try
      Return
    End Sub

    Private Sub DoEnableControl(control As Control, enable As Boolean)
      control.Enabled = enable
    End Sub

    Private Sub DoSetCursor(form As Form, cursor As Cursor)
      form.Cursor = cursor
    End Sub

    Private Sub OnSettingsFormLoad(sender As Object, e As EventArgs)
      If Not String.IsNullOrEmpty(Me.connectionString) Then
        Try
          Me._builder.ConnectionString = Me.connectionString
        Catch
          Me._builder.ConnectionString = String.Empty
        End Try
      End If
      If Not String.IsNullOrEmpty(Me.connectionName) Then
        Me.connectionNameText.Text = Me.connectionName
      End If
      Me.settingPropertyGrid.SelectedObject = _builder
    End Sub

    Private Sub OnTestButtonClick(sender As Object, e As EventArgs)
      If Me._testConnectionTread IsNot Nothing AndAlso Me._testConnectionTread.ThreadState = ThreadState.Running Then
        Me._testConnectionTread.Abort()
      End If
      Me._testConnectionTread = New Thread(AddressOf Me.TestConnection)
      Me._testConnectionTread.Start()
    End Sub

    Private Sub OnOkButtonClick(sender As Object, e As EventArgs)
      If String.IsNullOrEmpty(Me.connectionNameText.Text) Then
        MessageBox.Show(CONNECTION_NAME_EMPTY, Nothing, MessageBoxButtons.OK, MessageBoxIcon.[Error], MessageBoxDefaultButton.Button1)
      Else
        Me.connectionString = _builder.ConnectionString
        Me.connectionName = Me.connectionNameText.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
      End If
    End Sub

    Private Sub OnSettingsFormClosed(sender As Object, e As FormClosedEventArgs)
      If Me._testConnectionTread IsNot Nothing Then
        Me._testConnectionTread.Abort()
        Me._aborted = True
      End If
    End Sub
  End Class

  <DefaultPropertyAttribute(Nothing)> _
  Friend Class MyConnectionStringBuilder
    Inherits MongoDBConnectionStringBuilder

  End Class
End Namespace