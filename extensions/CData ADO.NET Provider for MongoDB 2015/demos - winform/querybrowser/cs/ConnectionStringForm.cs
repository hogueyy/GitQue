using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Data.CData.MongoDB;
using System.Data.Common;
using System.Threading;
using System.Reflection;

namespace CData.MongoDB.Demo {
  public class ConnectionStringForm : Form {
      /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private string CONNECTED_SUCCESSFULLY;
    private string CONNECTION_NAME_EMPTY;

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

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>     
    /// 
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionStringForm));
      this.connectionSettingLabel = new System.Windows.Forms.Label();
      this.settingPropertyGrid = new System.Windows.Forms.PropertyGrid();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.testbutton = new System.Windows.Forms.Button();
      this.connectionNameLabel = new System.Windows.Forms.Label();
      this.connectionNameText = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // connectionSettingLabel
      // 
      this.connectionSettingLabel.AutoSize = true;
      this.connectionSettingLabel.Location = new System.Drawing.Point(12, 9);
      this.connectionSettingLabel.Name = "connectionSettingLabel";
      this.connectionSettingLabel.Size = new System.Drawing.Size(191, 13);
      this.connectionSettingLabel.TabIndex = 17;
      this.connectionSettingLabel.Text = resources.GetString("ConnectionSettingLabel_Text");
      // 
      // settingPropertyGrid
      // 
      this.settingPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.settingPropertyGrid.Location = new System.Drawing.Point(15, 77);
      this.settingPropertyGrid.Name = "settingPropertyGrid";
      this.settingPropertyGrid.Size = new System.Drawing.Size(405, 366);
      this.settingPropertyGrid.TabIndex = 2;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(345, 449);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 5;
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Text = resources.GetString("CancelButton_Text");
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.Location = new System.Drawing.Point(264, 449);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 4;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OnOkButtonClick);
      // 
      // testbutton
      // 
      this.testbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.testbutton.Location = new System.Drawing.Point(15, 449);
      this.testbutton.Name = "testbutton";
      this.testbutton.Size = new System.Drawing.Size(103, 23);
      this.testbutton.TabIndex = 3;
      this.testbutton.UseVisualStyleBackColor = true;
      this.testbutton.Click += new System.EventHandler(this.OnTestButtonClick);
      this.testbutton.Text = resources.GetString("Testbutton_Text");
      // 
      // connectionNameLabel
      // 
      this.connectionNameLabel.AutoSize = true;
      this.connectionNameLabel.Location = new System.Drawing.Point(12, 34);
      this.connectionNameLabel.Name = "connectionNameLabel";
      this.connectionNameLabel.Size = new System.Drawing.Size(95, 13);
      this.connectionNameLabel.TabIndex = 22;
      this.connectionNameLabel.Text = resources.GetString("ConnectionNameLabel_Text");
      // 
      // connectionNameText
      // 
      this.connectionNameText.Location = new System.Drawing.Point(15, 51);
      this.connectionNameText.Name = "connectionNameText";
      this.connectionNameText.Size = new System.Drawing.Size(405, 20);
      this.connectionNameText.TabIndex = 1;
      // 
      // ConnectionStringForm
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(432, 484);
      this.Controls.Add(this.connectionNameText);
      this.Controls.Add(this.connectionNameLabel);
      this.Controls.Add(this.testbutton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.settingPropertyGrid);
      this.Controls.Add(this.connectionSettingLabel);
      this.DoubleBuffered = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionStringForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Load += new System.EventHandler(this.OnSettingsFormLoad);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnSettingsFormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();
      this.Text = resources.GetString("ConnectionStringForm_Text");

      CONNECTED_SUCCESSFULLY = resources.GetString("CONNECTED_SUCCESSFULLY");
      CONNECTION_NAME_EMPTY = resources.GetString("CONNECTION_NAME_EMPTY");
    }

    private System.Windows.Forms.Label connectionSettingLabel;
    private System.Windows.Forms.PropertyGrid settingPropertyGrid;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button testbutton;
   
    private MongoDBConnectionStringBuilder _builder = null;
    private Thread _testConnectionTread = null;
    public string connectionString = null;
    public string connectionName = null;
    private Label connectionNameLabel;
    private TextBox connectionNameText;
    private bool _aborted = false;
    private delegate void EnableControlDeletgate(Control control, bool enable);
    private delegate void SetCursorDelegate(Form form, Cursor cursor);

    public ConnectionStringForm(string connectionString, string name) {
      InitializeComponent();
      this._builder = new MyConnectionStringBuilder();
      this.connectionString = connectionString;
      this.connectionName = name;
    }

    private void TestConnection() {
      this.Invoke(new EnableControlDeletgate(DoEnableControl), this.settingPropertyGrid, false);
      this.Invoke(new EnableControlDeletgate(DoEnableControl), this.okButton, false);
      this.Invoke(new EnableControlDeletgate(DoEnableControl), this.testbutton, false);
      this.Invoke(new SetCursorDelegate(DoSetCursor), this, Cursors.WaitCursor);
      try {
        MongoDBConnection _conn = new MongoDBConnection(_builder.ConnectionString);
        if (_conn.State == ConnectionState.Closed) {
          _conn.Open();
        }
        _conn.TestConnection();
        _conn.Close();
        MessageBox.Show(CONNECTED_SUCCESSFULLY, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
      } catch (Exception ex) {
        if (!this._aborted) {
          MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        return;
      } finally {
        if (!this._aborted) {
          this.Invoke(new EnableControlDeletgate(DoEnableControl), this.settingPropertyGrid, true);
          this.Invoke(new EnableControlDeletgate(DoEnableControl), this.okButton, true);
          this.Invoke(new EnableControlDeletgate(DoEnableControl), this.testbutton, true);
          this.Invoke(new SetCursorDelegate(DoSetCursor), this, Cursors.Default);
        }
      }
      return;
    }

    private void DoEnableControl(Control control, bool enable) {
      control.Enabled = enable;
    }

    private void DoSetCursor(Form form, Cursor cursor) {
      form.Cursor = cursor;
    }

    private void OnSettingsFormLoad(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(this.connectionString)) {
        try {
          this._builder.ConnectionString = this.connectionString;
        } catch {
          this._builder.ConnectionString = string.Empty;
        }
      }
      if (!string.IsNullOrEmpty(this.connectionName)) {
        this.connectionNameText.Text = this.connectionName;
      }
      this.settingPropertyGrid.SelectedObject = _builder;
    }

    private void OnTestButtonClick(object sender, EventArgs e) {
      if (this._testConnectionTread != null && this._testConnectionTread.ThreadState == ThreadState.Running) {
        this._testConnectionTread.Abort();
      }
      this._testConnectionTread = new Thread(this.TestConnection);
      this._testConnectionTread.Start();
    }

    private void OnOkButtonClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this.connectionNameText.Text)) {
        MessageBox.Show(CONNECTION_NAME_EMPTY, null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
      } else {
        this.connectionString = _builder.ConnectionString;
        this.connectionName = this.connectionNameText.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void OnSettingsFormClosed(object sender, FormClosedEventArgs e) {
      if (this._testConnectionTread != null) {
        this._testConnectionTread.Abort();
        this._aborted = true;
      }
    }
  }

  [DefaultPropertyAttribute(null)]
  internal class MyConnectionStringBuilder : MongoDBConnectionStringBuilder {

  }
}