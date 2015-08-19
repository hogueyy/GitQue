Imports System.Collections.Generic
Imports System.ComponentModel1
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports System.Resources

Namespace CData.MongoDB.Demo
  Public Partial Class ParameterForm
    Inherits Form
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Private resources As ResourceManager = Nothing
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
	  Dim resources = New System.ComponentModel.ComponentResourceManager(GetType(ParameterForm))
      Me.titleLabel = New System.Windows.Forms.Label()
      Me.parameterView = New System.Windows.Forms.DataGridView()
      Me.valueComboBox = New System.Windows.Forms.ComboBox()
      Me.okButton = New System.Windows.Forms.Button()
      Me.cancelButton = New System.Windows.Forms.Button()
      Me.typeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.directionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.valueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      DirectCast(Me.parameterView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.parameterView.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' titleLabel
      ' 
      Me.titleLabel.AutoSize = True
      Me.titleLabel.Location = New System.Drawing.Point(9, 22)
      Me.titleLabel.Name = "titleLabel"
      Me.titleLabel.Size = New System.Drawing.Size(269, 13)
      Me.titleLabel.TabIndex = 0
      Me.titleLabel.Text = resources.GetString("TitleLabel_Text")
      ' 
      ' parameterView
      ' 
      Me.parameterView.AllowUserToAddRows = False
      Me.parameterView.AllowUserToDeleteRows = False
      Me.parameterView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.parameterView.BackgroundColor = System.Drawing.SystemColors.Window
      Me.parameterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.parameterView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.typeColumn, Me.directionColumn, Me.nameColumn, Me.valueColumn})
      Me.parameterView.Controls.Add(Me.valueComboBox)
      Me.parameterView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
      Me.parameterView.Location = New System.Drawing.Point(12, 59)
      Me.parameterView.Name = "parameterView"
      Me.parameterView.RowHeadersVisible = False
      Me.parameterView.Size = New System.Drawing.Size(535, 213)
      Me.parameterView.TabIndex = 1
      AddHandler Me.parameterView.Scroll, New System.Windows.Forms.ScrollEventHandler(AddressOf Me.OnParameterViewScroll)
      AddHandler Me.parameterView.CellLeave, New System.Windows.Forms.DataGridViewCellEventHandler(AddressOf Me.OnParameterViewCellLeave)
      AddHandler Me.parameterView.EditingControlShowing, New System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(AddressOf Me.OnParameterViewEditingControlShowing)
      AddHandler Me.parameterView.ColumnWidthChanged, New System.Windows.Forms.DataGridViewColumnEventHandler(AddressOf Me.OnParameterViewColumnWidthChanged)
      ' 
      ' valueComboBox
      ' 
      Me.valueComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.valueComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
      Me.valueComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.valueComboBox.FormattingEnabled = True
      Me.valueComboBox.Location = New System.Drawing.Point(710, 80)
      Me.valueComboBox.Name = "valueComboBox"
      Me.valueComboBox.Size = New System.Drawing.Size(132, 21)
      Me.valueComboBox.TabIndex = 4
      AddHandler Me.valueComboBox.Leave, New System.EventHandler(AddressOf Me.OnValueComboBoxLeave)
      ' 
      ' okButton
      ' 
      Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.okButton.Location = New System.Drawing.Point(391, 292)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(75, 23)
      Me.okButton.TabIndex = 2
      Me.okButton.Text = "OK"
      Me.okButton.UseVisualStyleBackColor = True
      ' 
      ' cancelButton
      ' 
      Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cancelButton.Location = New System.Drawing.Point(472, 292)
      Me.cancelButton.Name = "cancelButton"
      Me.cancelButton.Size = New System.Drawing.Size(75, 23)
      Me.cancelButton.TabIndex = 3
      Me.cancelButton.UseVisualStyleBackColor = True
      Me.cancelButton.Text = resources.GetString("CancelButton_Text")
      ' 
      ' typeColumn
      ' 
      Me.typeColumn.HeaderText = "Type"
      Me.typeColumn.Name = "typeColumn"
      Me.typeColumn.[ReadOnly] = True
      Me.typeColumn.Width = 134
      ' 
      ' directionColumn
      ' 
      Me.directionColumn.HeaderText = "Direction"
      Me.directionColumn.Name = "directionColumn"
      Me.directionColumn.[ReadOnly] = True
      Me.directionColumn.Width = 134
      ' 
      ' nameColumn
      ' 
      Me.nameColumn.HeaderText = "Name"
      Me.nameColumn.Name = "nameColumn"
      Me.nameColumn.[ReadOnly] = True
      Me.nameColumn.Width = 134
      ' 
      ' valueColumn
      ' 
      Me.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.valueColumn.HeaderText = "Value"
      Me.valueColumn.Name = "valueColumn"
      ' 
      ' ParameterDialog
      ' 
      Me.AcceptButton = Me.okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.cancelButton
      Me.ClientSize = New System.Drawing.Size(559, 327)
      Me.Controls.Add(Me.cancelButton)
      Me.Controls.Add(Me.okButton)
      Me.Controls.Add(Me.titleLabel)
      Me.Controls.Add(Me.parameterView)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ParameterDialog"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      DirectCast(Me.parameterView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.parameterView.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
      Me.Text = resources.GetString("ParameterForm_Text")
    End Sub

    #End Region

    Private titleLabel As System.Windows.Forms.Label
    Public parameterView As System.Windows.Forms.DataGridView
    Private okButton As System.Windows.Forms.Button
    Private cancelButton As System.Windows.Forms.Button
    Private valueComboBox As ComboBox
    Private _procedureName As String = Nothing
    Public Shared ReadOnly COMBOBOX_VALUE_DEFAULT As String = "<DEFAULT>"
    Private typeColumn As DataGridViewTextBoxColumn
    Private directionColumn As DataGridViewTextBoxColumn
    Private nameColumn As DataGridViewTextBoxColumn
    Private valueColumn As DataGridViewTextBoxColumn
    Public Shared ReadOnly COMBOBOX_VALUE_NULL As String = "<NULL>"

    Public Sub New(name As String, paramNodes As TreeNodeCollection)
      Me._procedureName = name
      InitializeComponent()
      FillParameterTable(paramNodes)
    End Sub

    Public Property ProcedureName() As String
      Get
        Return Me._procedureName
      End Get
      Set
        Me._procedureName = value
      End Set
    End Property

    Private Sub FillParameterTable(paramNodes As TreeNodeCollection)
      For Each node As TreeNode In paramNodes
        If TypeOf node Is ParameterNode Then
          Dim idx As Integer = Me.parameterView.Rows.Add()
          Me.parameterView.Rows(idx).Cells(0).Value = DirectCast(node, ParameterNode).ParameterType
          Me.parameterView.Rows(idx).Cells(1).Value = DirectCast(node, ParameterNode).Mode.ToString()
          Me.parameterView.Rows(idx).Cells(2).Value = DirectCast(node, ParameterNode).ParameterName
          Me.parameterView.Rows(idx).Cells(3).Value = COMBOBOX_VALUE_DEFAULT
        End If
      Next
    End Sub

    Private Sub InitValueComboBox()
      Me.valueComboBox.Items.Clear()
      Me.valueComboBox.Items.AddRange(New String() {COMBOBOX_VALUE_DEFAULT, COMBOBOX_VALUE_NULL})
      Dim currentValue As String = DirectCast(Me.parameterView.CurrentCell.Value, String)
      If Not String.IsNullOrEmpty(currentValue) AndAlso Not currentValue.Equals(COMBOBOX_VALUE_DEFAULT, StringComparison.CurrentCultureIgnoreCase) AndAlso Not currentValue.Equals(COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase) Then
        Me.valueComboBox.Items.Add(currentValue)
        Me.valueComboBox.SelectedItem = currentValue
      Else
        If currentValue.Equals(COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase) Then
          Me.valueComboBox.SelectedItem = COMBOBOX_VALUE_NULL
        Else
          Me.valueComboBox.SelectedItem = COMBOBOX_VALUE_DEFAULT
        End If
      End If
    End Sub

    Private Sub OnParameterViewCellLeave(sender As Object, e As DataGridViewCellEventArgs)
      If e.ColumnIndex = Me.valueColumn.DisplayIndex Then
        Me.parameterView.CurrentCell.Value = Me.valueComboBox.Text
        Me.valueComboBox.Visible = False
      End If
    End Sub

    Private Sub OnValueComboBoxLeave(sender As Object, e As EventArgs)
      Me.valueComboBox.Visible = False
    End Sub

    Private Sub OnParameterViewColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs)
      Me.valueComboBox.Visible = False
    End Sub

    Private Sub OnParameterViewScroll(sender As Object, e As ScrollEventArgs)
      Me.valueComboBox.Visible = False
    End Sub

    Private Sub OnParameterViewEditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
      Dim cell As DataGridViewCell = Me.parameterView.CurrentCell
      If cell IsNot Nothing AndAlso cell.ColumnIndex = Me.valueColumn.DisplayIndex Then
        Dim rect As Rectangle = Me.parameterView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, True)
        Me.valueComboBox.Location = rect.Location
        Me.valueComboBox.Size = rect.Size
        InitValueComboBox()
        Me.valueComboBox.Focus()
        Me.valueComboBox.Visible = True
      End If
    End Sub
  End Class
End Namespace