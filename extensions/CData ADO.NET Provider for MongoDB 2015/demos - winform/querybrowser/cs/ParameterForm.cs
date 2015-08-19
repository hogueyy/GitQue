using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CData.MongoDB.Demo {
  public partial class ParameterForm : Form {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
      this.titleLabel = new System.Windows.Forms.Label();
      this.parameterView = new System.Windows.Forms.DataGridView();
      this.valueComboBox = new System.Windows.Forms.ComboBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.typeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.directionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.parameterView)).BeginInit();
      this.parameterView.SuspendLayout();
      this.SuspendLayout();
      // 
      // titleLabel
      // 
      this.titleLabel.AutoSize = true;
      this.titleLabel.Location = new System.Drawing.Point(9, 22);
      this.titleLabel.Name = "titleLabel";
      this.titleLabel.Size = new System.Drawing.Size(269, 13);
      this.titleLabel.TabIndex = 0;
      this.titleLabel.Text = resources.GetString("TitleLabel_Text");
      // 
      // parameterView
      // 
      this.parameterView.AllowUserToAddRows = false;
      this.parameterView.AllowUserToDeleteRows = false;
      this.parameterView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.parameterView.BackgroundColor = System.Drawing.SystemColors.Window;
      this.parameterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.parameterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeColumn,
            this.directionColumn,
            this.nameColumn,
            this.valueColumn});
      this.parameterView.Controls.Add(this.valueComboBox);
      this.parameterView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.parameterView.Location = new System.Drawing.Point(12, 59);
      this.parameterView.Name = "parameterView";
      this.parameterView.RowHeadersVisible = false;
      this.parameterView.Size = new System.Drawing.Size(535, 213);
      this.parameterView.TabIndex = 1;
      this.parameterView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnParameterViewScroll);
      this.parameterView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnParameterViewCellLeave);
      this.parameterView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.OnParameterViewEditingControlShowing);
      this.parameterView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.OnParameterViewColumnWidthChanged);
      // 
      // valueComboBox
      // 
      this.valueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.valueComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.valueComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.valueComboBox.FormattingEnabled = true;
      this.valueComboBox.Location = new System.Drawing.Point(710, 80);
      this.valueComboBox.Name = "valueComboBox";
      this.valueComboBox.Size = new System.Drawing.Size(132, 21);
      this.valueComboBox.TabIndex = 4;
      this.valueComboBox.Leave += new System.EventHandler(this.OnValueComboBoxLeave);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.Location = new System.Drawing.Point(391, 292);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 2;
      this.okButton.Text = "&OK";
      this.okButton.UseVisualStyleBackColor = true;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(472, 292);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Text = resources.GetString("CancelButton_Text");
      // 
      // typeColumn
      // 
      this.typeColumn.HeaderText = "Type";
      this.typeColumn.Name = "typeColumn";
      this.typeColumn.ReadOnly = true;
      this.typeColumn.Width = 134;
      // 
      // directionColumn
      // 
      this.directionColumn.HeaderText = "Direction";
      this.directionColumn.Name = "directionColumn";
      this.directionColumn.ReadOnly = true;
      this.directionColumn.Width = 134;
      // 
      // nameColumn
      // 
      this.nameColumn.HeaderText = "Name";
      this.nameColumn.Name = "nameColumn";
      this.nameColumn.ReadOnly = true;
      this.nameColumn.Width = 134;
      // 
      // valueColumn
      // 
      this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.valueColumn.HeaderText = "Value";
      this.valueColumn.Name = "valueColumn";
      // 
      // ParameterDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(559, 327);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.titleLabel);
      this.Controls.Add(this.parameterView);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ParameterDialog";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.parameterView)).EndInit();
      this.parameterView.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
      this.Text = resources.GetString("ParameterForm_Text");
    }

    #endregion

    private System.Windows.Forms.Label titleLabel;
    public System.Windows.Forms.DataGridView parameterView;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private ComboBox valueComboBox;
    private string _procedureName = null;
    public static readonly string COMBOBOX_VALUE_DEFAULT = "<DEFAULT>";
    private DataGridViewTextBoxColumn typeColumn;
    private DataGridViewTextBoxColumn directionColumn;
    private DataGridViewTextBoxColumn nameColumn;
    private DataGridViewTextBoxColumn valueColumn;
    public static readonly string COMBOBOX_VALUE_NULL = "<NULL>";

    public ParameterForm(string name, TreeNodeCollection paramNodes) {
      this._procedureName = name;
      InitializeComponent();
      FillParameterTable(paramNodes);
    }

    public string ProcedureName {
      get {
        return this._procedureName;
      }
      set {
        this._procedureName = value;
      }
    }

    private void FillParameterTable(TreeNodeCollection paramNodes) {
      foreach (TreeNode node in paramNodes) {
        if (node is ParameterNode) {
          int idx = this.parameterView.Rows.Add();
          this.parameterView.Rows[idx].Cells[0].Value = ((ParameterNode)node).ParameterType;
          this.parameterView.Rows[idx].Cells[1].Value = ((ParameterNode)node).Mode.ToString();
          this.parameterView.Rows[idx].Cells[2].Value = ((ParameterNode)node).ParameterName;
          this.parameterView.Rows[idx].Cells[3].Value = COMBOBOX_VALUE_DEFAULT;
        }
      }
    }

    private void InitValueComboBox() {
      this.valueComboBox.Items.Clear();
      this.valueComboBox.Items.AddRange(new string[] { COMBOBOX_VALUE_DEFAULT, COMBOBOX_VALUE_NULL });
      string currentValue = (string)this.parameterView.CurrentCell.Value;
      if (!string.IsNullOrEmpty(currentValue) && !currentValue.Equals(COMBOBOX_VALUE_DEFAULT, StringComparison.CurrentCultureIgnoreCase)  & !currentValue.Equals(COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase)) {
        this.valueComboBox.Items.Add(currentValue);
        this.valueComboBox.SelectedItem = currentValue;
      } else {
        if (currentValue.Equals(COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase)){
          this.valueComboBox.SelectedItem = COMBOBOX_VALUE_NULL;
        }else {
          this.valueComboBox.SelectedItem = COMBOBOX_VALUE_DEFAULT;
        }
      }
    }

    private void OnParameterViewCellLeave(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == this.valueColumn.DisplayIndex) {
        this.parameterView.CurrentCell.Value = this.valueComboBox.Text;
        this.valueComboBox.Visible = false;
      }
    }

    private void OnValueComboBoxLeave(object sender, EventArgs e) {
      this.valueComboBox.Visible = false;
    }

    private void OnParameterViewColumnWidthChanged(object sender, DataGridViewColumnEventArgs e) {
      this.valueComboBox.Visible = false;
    }

    private void OnParameterViewScroll(object sender, ScrollEventArgs e) {
      this.valueComboBox.Visible = false;
    }

    private void OnParameterViewEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
      DataGridViewCell cell = this.parameterView.CurrentCell;
      if (cell != null && cell.ColumnIndex == this.valueColumn.DisplayIndex) {
        Rectangle rect = this.parameterView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
        this.valueComboBox.Location = rect.Location;
        this.valueComboBox.Size = rect.Size;
        InitValueComboBox();
        this.valueComboBox.Focus();
        this.valueComboBox.Visible = true;
      }
    }
  }
}