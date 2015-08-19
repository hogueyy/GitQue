using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Threading;
using System.Data.CData.MongoDB;
using System.Resources;

namespace CData.MongoDB.Demo {
  public class GenerationForm : Form {
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
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationForm));
    this.components = new System.ComponentModel.Container();
    this.addConnectionButton = new System.Windows.Forms.Button();
    this.connectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
    this.newQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.executeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
    this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.splitContainer = new System.Windows.Forms.SplitContainer();
    this.connectionGroup = new System.Windows.Forms.GroupBox();
    this.connectionView = new System.Windows.Forms.TreeView();
    this.connectionImageList = new System.Windows.Forms.ImageList(this.components);
    this.editConnectionButton = new System.Windows.Forms.Button();
    this.queryGroup = new System.Windows.Forms.GroupBox();
    this.queryTabs = new System.Windows.Forms.TabControl();
    this.queryViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
    this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.connectionMenu.SuspendLayout();
    this.splitContainer.Panel1.SuspendLayout();
    this.splitContainer.Panel2.SuspendLayout();
    this.splitContainer.SuspendLayout();
    this.connectionGroup.SuspendLayout();
    this.queryGroup.SuspendLayout();
    this.queryViewMenu.SuspendLayout();
    this.SuspendLayout();
    // 
    // addConnectionButton
    // 
    this.addConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));
    this.addConnectionButton.Location = new System.Drawing.Point(6, 437);
    this.addConnectionButton.Name = "addConnectionButton";
    this.addConnectionButton.Size = new System.Drawing.Size(170, 23);
    this.addConnectionButton.TabIndex = 3;
    this.addConnectionButton.UseVisualStyleBackColor = true;
    this.addConnectionButton.Click += new System.EventHandler(this.OnAddConnectionButtonClick);
    resources.ApplyResources(this.addConnectionButton, "addConnectionButton");
    // 
    // connectionMenu
    // 
    this.connectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
         this.newQueryMenuItem,
    this.executeMenuItem,
    this.toolStripSeparator,this.refreshToolStripMenuItem});
    this.connectionMenu.Name = "connectionMenu";
    this.connectionMenu.Size = new System.Drawing.Size(134, 76);
    resources.ApplyResources(this.connectionMenu, "connectionMenu");
    this.connectionMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnConnectionMenuOpening);
    // 
    // newQueryMenuItem
    // 
    this.newQueryMenuItem.Name = "newQueryMenuItem";
    this.newQueryMenuItem.Size = new System.Drawing.Size(133, 22);
    this.newQueryMenuItem.Click += new System.EventHandler(this.OnNewQueryMenuItemClick);
    resources.ApplyResources(this.newQueryMenuItem, "newQueryMenuItem");
    // 
    // executeMenuItem
    // 
    this.executeMenuItem.Name = "executeMenuItem";
    resources.ApplyResources(this.executeMenuItem, "executeMenuItem");
    this.executeMenuItem.Click += new System.EventHandler(this.OnExecuteMenuItemClick);
    // 
    // toolStripSeparator
    // 
    this.toolStripSeparator.Name = "toolStripSeparator";
    this.toolStripSeparator.Size = new System.Drawing.Size(130, 6);
    resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
    // 
    // refreshToolStripMenuItem
    // 
    this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
    this.refreshToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
    this.refreshToolStripMenuItem.Click += new System.EventHandler(this.OnRefreshToolStripMenuItemClick);
    resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
    // 
    // splitContainer
    // 
    this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
    this.splitContainer.Location = new System.Drawing.Point(12, 12);
    this.splitContainer.Name = "splitContainer";
      resources.ApplyResources(this.splitContainer, "splitContainer");
    // 
    // splitContainer.Panel1
    // 
    this.splitContainer.Panel1.Controls.Add(this.connectionGroup);
    // 
    // splitContainer.Panel2
    // 
    this.splitContainer.Panel2.Controls.Add(this.queryGroup);
    this.splitContainer.Size = new System.Drawing.Size(638, 469);
    this.splitContainer.SplitterDistance = 185;
    this.splitContainer.TabIndex = 0;
    this.splitContainer.TabStop = false;
    // 
    // connectionGroup
    // 
    this.connectionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.connectionGroup.Controls.Add(this.connectionView);
    this.connectionGroup.Controls.Add(this.addConnectionButton);
    this.connectionGroup.Controls.Add(this.editConnectionButton);
    this.connectionGroup.Location = new System.Drawing.Point(0, 3);
    this.connectionGroup.Name = "connectionGroup";
    this.connectionGroup.Size = new System.Drawing.Size(182, 466);
    this.connectionGroup.TabIndex = 5;
    this.connectionGroup.TabStop = false;
    resources.ApplyResources(this.connectionGroup, "connectionGroup");
    // 
    // connectionView
    // 
    this.connectionView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    resources.ApplyResources(this.connectionView, "connectionView");
    this.connectionView.ContextMenuStrip = this.connectionMenu;
    this.connectionView.ImageIndex = 0;
    this.connectionView.ImageList = this.connectionImageList;
    this.connectionView.Location = new System.Drawing.Point(6, 19);
    this.connectionView.Name = "connectionView";
    this.connectionView.SelectedImageIndex = 0;
    this.connectionView.Size = new System.Drawing.Size(170, 383);
    this.connectionView.TabIndex = 1;
    this.connectionView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnConnectionViewExpanding);
    this.connectionView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ConnectionViewAfterExpand);
    this.connectionView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnConnectionViewSelected);
    this.connectionView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnConnectionViewNodeMouseClick);
    // 
    // connectionImageList
    // 
    this.connectionImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
    this.connectionImageList.ImageSize = new System.Drawing.Size(16, 16);
    this.connectionImageList.TransparentColor = System.Drawing.Color.Transparent;
    resources.ApplyResources(this.connectionImageList, "connectionImageList");
    // 
    // editConnectionButton
    // 
    this.editConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));
    this.editConnectionButton.Enabled = false;
    this.editConnectionButton.Location = new System.Drawing.Point(6, 408);
    this.editConnectionButton.Name = "editConnectionButton";
    this.editConnectionButton.Size = new System.Drawing.Size(170, 23);
    this.editConnectionButton.TabIndex = 2;
    this.editConnectionButton.UseVisualStyleBackColor = true;
    this.editConnectionButton.Click += new System.EventHandler(this.OnEditConnectionButtonClick);
    resources.ApplyResources(this.editConnectionButton, "editConnectionButton");
    // 
    // queryGroup
    // 
    this.queryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.queryGroup.Controls.Add(this.queryTabs);
    this.queryGroup.Location = new System.Drawing.Point(3, 3);
    this.queryGroup.Name = "queryGroup";
    this.queryGroup.Size = new System.Drawing.Size(443, 466);
    this.queryGroup.TabIndex = 13;
    this.queryGroup.TabStop = false;
    resources.ApplyResources(this.queryGroup, "queryGroup");
    // 
    // queryTabs
    // 
    this.queryTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
      resources.ApplyResources(this.queryTabs, "queryTabs");
    this.queryTabs.Location = new System.Drawing.Point(6, 19);
    this.queryTabs.Name = "queryTabs";
    this.queryTabs.SelectedIndex = 0;
    this.queryTabs.Size = new System.Drawing.Size(431, 441);
    this.queryTabs.TabIndex = 4;
    this.queryTabs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnQueryTabsMouseClick);
    // 
    // queryViewMenu
    // 
    this.queryViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeToolStripMenuItem,this.closeOthersToolStripMenuItem});
    this.queryViewMenu.Name = "queryViewMenu";
    this.queryViewMenu.Size = new System.Drawing.Size(104, 26);
    resources.ApplyResources(this.queryViewMenu, "queryViewMenu");
    // 
    // closeToolStripMenuItem
    // 
    this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
    this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
    this.closeToolStripMenuItem.Text = "&Close";
    this.closeToolStripMenuItem.Click += new System.EventHandler(this.OnCloseClick);
    resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
    // 
    // closeOthersToolStripMenuItem
    // 
    this.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem";
    this.closeOthersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
    this.closeOthersToolStripMenuItem.Text = "&Close Others";
    this.closeOthersToolStripMenuItem.Click += new System.EventHandler(this.OnCloseOthersClick);
    resources.ApplyResources(this.closeOthersToolStripMenuItem, "closeOthersToolStripMenuItem");
    // 
    // MainForm
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(662, 493);
    this.Controls.Add(this.splitContainer);
    this.Name = "MainForm";
    this.connectionMenu.ResumeLayout(false);
    this.splitContainer.Panel1.ResumeLayout(false);
    this.splitContainer.Panel2.ResumeLayout(false);
    this.splitContainer.ResumeLayout(false);
    this.connectionGroup.ResumeLayout(false);
    this.queryGroup.ResumeLayout(false);
    this.queryViewMenu.ResumeLayout(false);
    this.ResumeLayout(false);
    resources.ApplyResources(this, "$this");
    ERROR_NO_CONNECTION = resources.GetString("ERROR_NO_CONNECTION");
    TABPAGE_TITLE_FORMAT = resources.GetString("TABPAGE_TITLE_FORMAT");
    CONNECTION_NAME_FORMAT = resources.GetString("CONNECTION_NAME_FORMAT");
    DEFAULT_QUERY_FORMAT = "SELECT * FROM [{0}]";
    EXPANDING_TEXT = resources.GetString("EXPANDING_TEXT");
    REFRESH_TEXT = resources.GetString("REFRESH_TEXT");
  }

    #endregion

    private System.Windows.Forms.Button addConnectionButton;
    private List<QueryData> _dataList = new List<QueryData>();
    private List<ConnectionNode> _connectionList = new List<ConnectionNode>();
    private string ERROR_NO_CONNECTION;
    private string TABPAGE_TITLE_FORMAT;
    private string CONNECTION_NAME_FORMAT;
    private string DEFAULT_QUERY_FORMAT;
    private string EXPANDING_TEXT;
    private string REFRESH_TEXT;
    private ContextMenuStrip connectionMenu;
    private ToolStripMenuItem newQueryMenuItem;
    private ToolStripMenuItem executeMenuItem;
    private SplitContainer splitContainer;
    private TabControl queryTabs;
    private TreeView connectionView;
    private Button editConnectionButton;
    private GroupBox connectionGroup;
    private ProcedureTabPage procedurePage;
    private ImageList connectionImageList;
    private ContextMenuStrip queryViewMenu;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem closeOthersToolStripMenuItem;
    private ToolStripMenuItem refreshToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator;
    private GroupBox queryGroup;
    private delegate void ClearTableDeletgate(ComboBox control);
    private delegate void AddTableDeletgate(ComboBox control, string[] tableName);

    public GenerationForm() {
      InitializeComponent();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationForm));
      this.procedurePage = new ProcedureTabPage();
      this.procedurePage.Location = new System.Drawing.Point(4, 22);
      this.procedurePage.Name = "procedurePage";
      this.procedurePage.ProcedureName = null;
      this.procedurePage.Size = new System.Drawing.Size(423, 368);
      this.procedurePage.TabIndex = 0;
      this.procedurePage.UseVisualStyleBackColor = true;
      resources.ApplyResources(this.procedurePage, "procedurePage");
      LoadImage();
    }

    private ConnectionNode GetSelectedConnection() {
      TreeNode selectedNode = this.connectionView.SelectedNode;
      if (selectedNode != null) {
        if (selectedNode is ColumnNode) {
          return ((ColumnNode)selectedNode).Table.Connection;
        } else if (selectedNode is ParameterNode) {
          return ((ParameterNode)selectedNode).Procedure.Connection;
        } else if (selectedNode is TableNode) {
          return ((TableNode)selectedNode).Connection;
        } else if (selectedNode is FolderNode) {
          return ((FolderNode)selectedNode).Connection;
        } else if (selectedNode is ConnectionNode) {
          return (ConnectionNode)selectedNode;
        }
      }
      return null;
    }

    private void LoadImage() {
      ResourceManager resourceMan = new ResourceManager(typeof(Resource));
      this.connectionImageList.Images.Add("connection.ico", (Icon)resourceMan.GetObject("connection"));
      this.connectionImageList.Images.Add("table.ico", (Icon)resourceMan.GetObject("table"));
      this.connectionImageList.Images.Add("column.ico", (Icon)resourceMan.GetObject("column"));
      this.connectionImageList.Images.Add("folder.ico", (Icon)resourceMan.GetObject("folder"));
      this.connectionImageList.Images.Add("key.ico", (Icon)resourceMan.GetObject("key"));
      this.refreshToolStripMenuItem.Image = ((Icon)resourceMan.GetObject("refresh")).ToBitmap();
    }

    private void AddTabPage(FolderType type, string table) {
      Boolean have=false;
      ConnectionNode connection = GetSelectedConnection();
      if (connection != null) {
        string title = string.Format(TABPAGE_TITLE_FORMAT, this.queryTabs.Controls.Count + 1);
        string sql = "";
        if (!string.IsNullOrEmpty(table)) {
          sql = string.Format(DEFAULT_QUERY_FORMAT, table);
        }
        TabPage newPage = null;
        if (type == FolderType.TABLE) {
          newPage = new TableTabPage(connection, title, sql, this.components);
        } else if (type == FolderType.VIEW) {
          newPage = new ViewTabPage(connection, title, sql, this.components);
        } else {
          this.procedurePage.ProcedureName = table;
          this.procedurePage.Connection = connection;
          newPage = this.procedurePage;
        }
        if (!this.queryTabs.Controls.Contains(newPage)) {
          if (this.queryTabs.TabPages.Count == 0) {
            this.queryTabs.Controls.Add(newPage);
            this.queryTabs.TabPages[0].Tag = table;
            this.queryTabs.SelectedTab = newPage;
          } else {
            for(int i=0;i<this.queryTabs.TabPages.Count;i++) {
              if (this.queryTabs.TabPages[i].Tag == table) {
                have = true;
                this.queryTabs.SelectedTab = this.queryTabs.TabPages[i];
                break;
              }
            }
            if (have != true) {
              this.queryTabs.Controls.Add(newPage);
              this.queryTabs.TabPages[this.queryTabs.TabPages.Count-1].Tag = table;
              this.queryTabs.SelectedTab = newPage;
            }
          }
        }
      } else {
        MessageBox.Show(ERROR_NO_CONNECTION, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void OnAddConnectionButtonClick(object sender, EventArgs e) {
      ConnectionStringForm settingFrom = new ConnectionStringForm(null, string.Format(CONNECTION_NAME_FORMAT, this.connectionView.Nodes.Count + 1));
      if (settingFrom.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        this.connectionView.Nodes.Add(new ConnectionNode(settingFrom.connectionString, settingFrom.connectionName));
      }
    }

   private void OnEditConnectionButtonClick(object sender, EventArgs e) {
      ConnectionNode selectedConnection = GetSelectedConnection();
      ConnectionStringForm settingFrom = new ConnectionStringForm(selectedConnection.ConnectionString, selectedConnection.ConnectionName);
      if (settingFrom.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        foreach (TabPage page in this.queryTabs.TabPages) {
          if (page is ViewTabPage && ((ViewTabPage)page).ConnectionName.Equals(selectedConnection.ConnectionName)) {
            ((ViewTabPage)page).ConnectionName = settingFrom.connectionName;
            ((ViewTabPage)page).ConnectionString = settingFrom.connectionString;
          }
        }
        selectedConnection.ConnectionName = settingFrom.connectionName;
        selectedConnection.ConnectionString = settingFrom.connectionString;
      }
    }

    private void OnConnectionViewSelected(object sender, TreeViewEventArgs e) {
      if (e.Node.Index >= 0) {
        this.editConnectionButton.Enabled = true;
      } else {
        this.editConnectionButton.Enabled = false;
      }
    }

    private void OnConnectionViewExpanding(object sender, TreeViewCancelEventArgs e) {
      try{
        if (e.Node is FolderNode && !((FolderNode)e.Node).IsListedTable) {
          ((FolderNode)e.Node).FillNode(EXPANDING_TEXT);
        } else if (e.Node is TableNode && !((TableNode)e.Node).IsListedColumn) {
          ((TableNode)e.Node).FillNode(EXPANDING_TEXT);
        }
      }catch(Exception ex){
        MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
      }
    }

    private void ConnectionViewAfterExpand(object sender, TreeViewEventArgs e){
      if (e.Node is FolderNode && !(((FolderNode) e.Node).IsListedTable) && (((FolderNode)e.Node).IsExpanded)){
        ((FolderNode) e.Node).Collapse();
      }
    }

    private void OnNewQueryMenuItemClick(object sender, EventArgs e) {
      if (this.connectionView.SelectedNode is TableNode) {
        TableNode selectedTable = (TableNode)this.connectionView.SelectedNode;
        AddTabPage(selectedTable.Folder.Type, selectedTable.TableName);
      } else if (this.connectionView.SelectedNode is ColumnNode) {
        TableNode selectedTable = ((ColumnNode)this.connectionView.SelectedNode).Table;
        AddTabPage(selectedTable.Folder.Type, selectedTable.TableName);
      } else {
        AddTabPage(FolderType.TABLE, null);
      }
    }

    private void OnExecuteMenuItemClick(object sender, EventArgs e) {
      TableNode selectedTable = null;
      if (this.connectionView.SelectedNode != null) {
        if (this.connectionView.SelectedNode is TableNode
            && ((TableNode)this.connectionView.SelectedNode).Folder.Type == FolderType.PRODUCERE) {
          selectedTable = (TableNode)this.connectionView.SelectedNode;
        } else if (this.connectionView.SelectedNode is ParameterNode) {
          selectedTable = ((ParameterNode)this.connectionView.SelectedNode).Procedure;
        }
      }
      if (selectedTable != null) {
        if (!selectedTable.IsListedColumn) {
          selectedTable.FillNode(null);
        }
        ParameterForm dialog = new ParameterForm(selectedTable.TableName, selectedTable.Nodes);
        if (dialog.ShowDialog() == DialogResult.OK) {
          AddTabPage(FolderType.PRODUCERE, selectedTable.TableName);
          this.procedurePage.Execute(dialog.parameterView);
        }
      }
    }


    private void OnConnectionMenuOpening(object sender, CancelEventArgs e) {
      this.newQueryMenuItem.Visible = false;
      this.executeMenuItem.Visible = false;
      this.toolStripSeparator.Visible = true;
      if (this.connectionView.SelectedNode is TableNode
          && ((TableNode)this.connectionView.SelectedNode).Folder.Type == FolderType.PRODUCERE) {
        this.executeMenuItem.Visible = true;
      } else if (this.connectionView.SelectedNode is ParameterNode) {
        this.executeMenuItem.Visible = true;
      } else if (this.connectionView.SelectedNode is FolderNode
                 && ((FolderNode)this.connectionView.SelectedNode).Type == FolderType.PRODUCERE) {
        this.toolStripSeparator.Visible = false;
      }else {
        this.newQueryMenuItem.Visible = true;
      }
    }


    private void OnConnectionViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
      this.connectionView.SelectedNode = e.Node;
       if (this.connectionView.SelectedNode is TableNode) {
          if (e.Button == MouseButtons.Left) {
            TableNode selectedTable = (TableNode)this.connectionView.SelectedNode;
            if (this.connectionView.SelectedNode != null) {
              if (selectedTable is TableNode) {
                AddTabPage(selectedTable.Folder.Type, selectedTable.TableName);
              }
            }
          }
       } 
    } 


     private void OnQueryTabsMouseClick(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        for (int i = 0; i < queryTabs.TabPages.Count; i++) {
          TabPage tp = queryTabs.TabPages[i];
          if (queryTabs.GetTabRect(i).Contains(new Point(e.X, e.Y))) {
            queryTabs.SelectedTab = tp;
            break;
          }
        }
        this.queryViewMenu.Show(this.queryTabs, e.Location);
      } else if (e.Button == MouseButtons.Middle) {
        this.queryTabs.TabPages.Remove(this.queryTabs.SelectedTab);
      }
    }

    private void OnCloseClick(object sender, EventArgs e) {
      this.queryTabs.TabPages.Remove(this.queryTabs.SelectedTab);
    }

    private void OnCloseOthersClick(object sender, EventArgs e) {
      for (int i = 0; i < this.queryTabs.TabCount; i++) {
        if (i != queryTabs.SelectedIndex) {
          queryTabs.TabPages.RemoveAt(i--);
        }
      }
    }

    private void OnRefreshToolStripMenuItemClick(object sender, EventArgs e) {
      TreeNode selectedNode = this.connectionView.SelectedNode;
      if (selectedNode != null) {
        if (selectedNode is ConnectionNode && selectedNode.IsExpanded) {
        foreach (TreeNode node in selectedNode.Nodes) {
          if (node is FolderNode && node.IsExpanded) {
            ((FolderNode)node).FillNode(REFRESH_TEXT);
          }
        }
        } else if (selectedNode is FolderNode && selectedNode.IsExpanded) {
           ((FolderNode)selectedNode).FillNode(REFRESH_TEXT);
        } else if (selectedNode is TableNode && selectedNode.IsExpanded) {
           ((TableNode)selectedNode).FillNode(REFRESH_TEXT);
        } else if (selectedNode is ColumnNode) {
           ((ColumnNode)selectedNode).Table.FillNode(REFRESH_TEXT);
        } else if (selectedNode is ParameterNode) {
           ((ParameterNode)selectedNode).Procedure.FillNode(REFRESH_TEXT);
      }
      }
    }
  }

class ViewTabPage : TabPage {
    private ConnectionNode _connection = null;
    private string _queryString = null;
    private string _title = null;
    protected QueryData _data = null;
    private TextBox _queryTextBox = null;
    private Button _executeButton = null;
    protected DataGridView _dataView = null;
    private ToolStripMenuItem _deleteDataMenuItem = null;
    private ContextMenuStrip _dataMenu = null;
    protected static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationForm));
    protected static readonly string ERROR_NO_CONNECTION = resources.GetString("ERROR_NO_CONNECTION");
    protected static readonly string ERROR_NO_QUERY = resources.GetString("ERROR_NO_QUERY");
    protected static readonly string INFO_NO_CHANGEDDATA = resources.GetString("ERROR_NO_QUERY");

    public ViewTabPage(ConnectionNode connection, string title, string sql, IContainer components) {
      this._connection = connection;
      this._queryString = sql;
      this._title = title;
      InitializeComponent(components);
      UpdateTitle();
    }

    public string QueryString {
      get {
        return this._queryString;
      }
      set {
        this._queryString = value;
      }
    }

    public string Title {
      get {
        return this._title;
      }
      set {
        this._title = value;
        UpdateTitle();
      }
    }

    public ConnectionNode Connection {
      get {
        return _connection;
      }
      set {
        this._connection = value;
      }
    }

    public string ConnectionString {
      get {
        return this._connection.ConnectionString;
      }
      set {
        this._connection.ConnectionString = value;
      }
    }

    public string ConnectionName {
      get {
        return this._connection.ConnectionName;
      }
      set {
        this._connection.ConnectionName = value;
        UpdateTitle();
      }
    }

    private void InitializeComponent(IContainer components) {
      //
      // queryTextBox
      //
      _queryTextBox = new TextBox();
      this._queryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._queryTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
      this._queryTextBox.Location = new System.Drawing.Point(1, 6);
      this._queryTextBox.Name = "queryText";
      this._queryTextBox.Size = new System.Drawing.Size(103, 20);
      this._queryTextBox.Text = this.QueryString;
      this._queryTextBox.TabIndex = 5;
      // 
      // executeButton
      // 
      _executeButton = new Button();
      resources.ApplyResources(this._executeButton, "_executeButton");
      this._executeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._executeButton.Location = new System.Drawing.Point(110, 4);
      this._executeButton.Name = "executeButton";
      this._executeButton.Size = new System.Drawing.Size(88, 23);
      this._executeButton.TabIndex = 6;
      this._executeButton.UseVisualStyleBackColor = true;
      this._executeButton.Click += new System.EventHandler(this.OnExecuteButtonClick);
      // 
      // deleteToolStripMenuItem
      // 
      _deleteDataMenuItem = new ToolStripMenuItem();
      resources.ApplyResources(this._deleteDataMenuItem, "_deleteDataMenuItem");
      this._deleteDataMenuItem.Name = "deleteToolStripMenuItem";
      this._deleteDataMenuItem.Size = new System.Drawing.Size(61, 4);
      this._deleteDataMenuItem.Click += new System.EventHandler(this.OnDeleteDataMenuItemClick);
      // 
      // dataMenu
      // 
      _dataMenu = new ContextMenuStrip();
      this._dataMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteDataMenuItem});
      this._dataMenu.Name = "resultMenu";
      this._dataMenu.Size = new System.Drawing.Size(32, 19);
      // 
      // dataView
      // 
      _dataView = new DataGridView();
      this._dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this._dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this._dataView.ContextMenuStrip = this._dataMenu;
      this._dataView.TabIndex = 7;
      this._dataView.BorderStyle = BorderStyle.Fixed3D;
      this._dataView.BackgroundColor = System.Drawing.SystemColors.Window;
      this._dataView.Location = new System.Drawing.Point(1, 33);
      this._dataView.Name = "resultView";
      this._dataView.Size = new System.Drawing.Size(196, 36);
      this._dataView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGradViewError);
      //
      // Tabpage
      //
      this.Controls.Add(this._queryTextBox);
      this.Controls.Add(this._dataView);
      this.Controls.Add(this._executeButton);
      this.Location = new System.Drawing.Point(0, 0);
      this.Padding = new System.Windows.Forms.Padding(3);
      this.Size = new System.Drawing.Size(423, 368);
      this.TabIndex = 0;
      this.UseVisualStyleBackColor = true;
    }

    private static void ShowMessage(string message, MessageBoxIcon icon) {
      MessageBox.Show(message, null, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
    }

    protected static void ShowInfo(string info) {
      ShowMessage(info, MessageBoxIcon.Information);
    }

    protected static void ShowError(string error) {
      ShowMessage(error, MessageBoxIcon.Error);
    }

    private void DataGradViewError(object sender, DataGridViewDataErrorEventArgs e) {
      ShowMessage(e.Exception.Message, MessageBoxIcon.Error);
    }

    private void UpdateTitle() {
      this.Text = this.Title + "(" + this.ConnectionName + ")";
    }

    private void OnExecuteButtonClick(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(this._queryTextBox.Text)) {
        ShowError(ERROR_NO_QUERY);
        return;
      }
      try {
        this._executeButton.Enabled = false;
        this.QueryString = this._queryTextBox.Text;
        this._data = new QueryData(this._connection, this.QueryString);
        this._dataView.DataSource = this._data.GetData();
      } catch (Exception ex) {
        ShowError(ex.Message);
      } finally {
        this._executeButton.Enabled = true;
      }
    }

    private void OnDeleteDataMenuItemClick(object sender, EventArgs e) {
      if (this._dataView.CurrentRow != null) {
        this._dataView.Rows.Remove(this._dataView.CurrentRow);
      }
    }
  }

  class TableTabPage : ViewTabPage {
    private Button _saveButton = null;

    public TableTabPage(ConnectionNode connection, string title, string sql, IContainer components)
      : base(connection, title, sql, components) {
      InitializeComponent();
    }

    private void InitializeComponent() {
      // 
      // saveButton
      // 
      _saveButton = new Button();
      resources.ApplyResources(this._saveButton, "_saveButton");
      this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._saveButton.Location = new System.Drawing.Point(330, 340);
      this._saveButton.Name = "saveButton";
      this._saveButton.Size = new System.Drawing.Size(88, 23);
      this._saveButton.TabIndex = 8;
      this._saveButton.UseVisualStyleBackColor = true;
      this._saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
      //
      // TableTabPage
      //
      this.Controls.Add(this._saveButton);
    }

    private void OnSaveButtonClick(object sender, EventArgs e) {
      if (this._dataView.DataSource == null) {
        ShowInfo(INFO_NO_CHANGEDDATA);
        return;
      }
      try {
        this._saveButton.Enabled = false;
        this._data.Update((DataTable)this._dataView.DataSource);
      } catch (Exception ex) {
        ShowError(ex.Message);
      } finally {
        this._saveButton.Enabled = true;
      }
    }
  }

  class ProcedureTabPage : TabPage {
    private ConnectionNode _connection;
    private TextBox _outputTextBox;
    private string _procedureName = null;
    private QueryData _data = null;
    private static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationForm));
    private static readonly string EXECUTING_MESSAGE_FORMAT = resources.GetString("EXECUTING_MESSAGE_FORMAT");
    private static readonly string FINISHED_MESSAGE_FORMAT = resources.GetString("FINISHED_MESSAGE_FORMAT");
    private static readonly string ERROR_MESSAGE_FORMAT = resources.GetString("ERROR_MESSAGE_FORMAT");
    private static readonly string NULL_VALUE = "NULL";

    public ProcedureTabPage()
      : base() {
      InitializeComponent();
    }

    public ConnectionNode Connection {
      get {
        return this._connection;
      } set {
        this._connection = value;
      }
    }

    public string ProcedureName {
      get {
        return this._procedureName;
      }
      set {
        this._procedureName = value;
      }
    }

    private void InitializeComponent() {
      this._outputTextBox = new System.Windows.Forms.TextBox();
      // 
      // procedurePage
      // 
      resources.ApplyResources(this, "procedurePage");
      this.Controls.Add(this._outputTextBox);
      this.Location = new System.Drawing.Point(4, 22);
      this.Name = "procedurePage";
      this.Size = new System.Drawing.Size(423, 368);
      this.TabIndex = 0;
      this.UseVisualStyleBackColor = true;
      // 
      // outputTextBox
      // 
      this._outputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
      this._outputTextBox.BackColor = System.Drawing.SystemColors.Window;
      this._outputTextBox.Location = new System.Drawing.Point(3, 3);
      this._outputTextBox.Multiline = true;
      this._outputTextBox.ScrollBars = ScrollBars.Both;
      this._outputTextBox.WordWrap = false;
      this._outputTextBox.Name = "outputTextBox";
      this._outputTextBox.ReadOnly = true;
      this._outputTextBox.Size = new System.Drawing.Size(417, 362);
      this._outputTextBox.TabIndex = 0;
    }

    public void AppendOutput(string output) {
      if (!string.IsNullOrEmpty(output)) {
        this._outputTextBox.AppendText(output);
      }
      this._outputTextBox.AppendText(Environment.NewLine);
      this._outputTextBox.ScrollToCaret();
    }

    public void Execute(DataGridView paramters) {
      Hashtable input = GetParameter(paramters, ParameterDirection.Input);
      Hashtable output = GetParameter(paramters, ParameterDirection.Output);
      Hashtable inOut = GetParameter(paramters, ParameterDirection.InputOutput);
      Hashtable returned = GetParameter(paramters, ParameterDirection.ReturnValue);

      AppendOutput(string.Format(EXECUTING_MESSAGE_FORMAT, this.ProcedureName));
      try {
        this._data = new QueryData(this._connection, this.ProcedureName);
        DataTable result = this._data.ExecSP(input, output, inOut, returned);
        AppendOutput(FormatResult(result));
        AppendOutput(string.Format(FINISHED_MESSAGE_FORMAT, result.Rows.Count));
      } catch (Exception ex) {
        AppendOutput(string.Format(ERROR_MESSAGE_FORMAT, this.ProcedureName, ex.Message));
      }
    }

    private string FormatResult(DataTable result) {
      StringBuilder columnRowBuilder = new StringBuilder();
      for (int i = 0; i < result.Columns.Count; i++) {
        columnRowBuilder.AppendLine(result.Columns[i].ColumnName);
        for (int j = 0; j < result.Rows.Count; j++) {
          columnRowBuilder.AppendLine(result.Rows[j].ItemArray[i].ToString());
        }
        columnRowBuilder.AppendLine();
      }
      return columnRowBuilder.ToString();
    }

    private Hashtable GetParameter(DataGridView paramters, ParameterDirection direction) {
      if (paramters != null && direction != null) {
        Hashtable result = new Hashtable();
        foreach (DataGridViewRow row in paramters.Rows) {
          if (direction.ToString().Equals((string)row.Cells["directionColumn"].Value, StringComparison.CurrentCultureIgnoreCase)) {
            string name = (string)row.Cells["nameColumn"].Value;
            if (!string.IsNullOrEmpty(name)) {
              string value = (string)row.Cells["valueColumn"].Value;
              if (!string.IsNullOrEmpty(value)) {
                if (value.Equals(ParameterForm.COMBOBOX_VALUE_DEFAULT, StringComparison.CurrentCultureIgnoreCase)) {
                  continue;// Don't set this parameter.
                } else if (value.Equals(ParameterForm.COMBOBOX_VALUE_NULL, StringComparison.CurrentCultureIgnoreCase)) {
                  value = NULL_VALUE;
                }
              }
              result.Add(name, value);
            }
          }
        }
        return result;
      }
      return null;
    }
  }

  enum FolderType { TABLE, VIEW, PRODUCERE }

  class FolderNode : TreeNode {
    private static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerationForm));
    private ConnectionNode _connection = null;
    private FolderType _type = FolderType.TABLE;
    private bool _listedTable = false;
    private string _name = null;
    private static readonly string TABLE_TEXT = resources.GetString("TABLE_TEXT");
    private static readonly string VIEW_TEXT = resources.GetString("VIEW_TEXT");
    private static readonly string PROCEDURE_TEXT = resources.GetString("PROCEDURE_TEXT");
    private static readonly string CONNECTION_ERROR = resources.GetString("CONNECTION_ERROR");

    public FolderNode(ConnectionNode conn, FolderType type) {
      this._connection = conn;
      this._type = type;
      if (type == FolderType.TABLE) {
        this._name = TABLE_TEXT;
      } else if (type == FolderType.VIEW) {
        this._name = VIEW_TEXT;
      } else {
        this._name = PROCEDURE_TEXT;
      }
      this.Text = this._name;
      this.ImageKey = "folder.ico";
      this.SelectedImageKey = this.ImageKey;
      this.Nodes.Add("");// Add a empty node to show the expand icon.
    }

    public ConnectionNode Connection {
      get {
        return this._connection;
      }
    }

    public FolderType Type {
      get {
        return this._type;
      }
    }

    public bool IsListedTable {
      get {
        return this._listedTable;
      }
      set {
        this._listedTable = value;
      }
    }

    public void FillNode(string status) {
      if (!string.IsNullOrEmpty(status)) {
        this.Text = this.Text + status;
        this.TreeView.Update();
      }
      try {
        string[] tablesname = null;
        try{
          if (this.Type == FolderType.TABLE) {
            tablesname = GetTablesName("BASE TABLE");
          } else if (this.Type == FolderType.VIEW) {
            tablesname = GetTablesName("VIEW");
          } else {
            tablesname = GetProcuderesName();
          }
        }catch (Exception ex){
          throw new Exception(CONNECTION_ERROR + ex.Message);
        }
        this.Nodes.Clear();
        foreach (string name in tablesname) {
          this.Nodes.Add(new TableNode(this.Connection, this, name));
        }
        this.IsListedTable = true;
      } catch (Exception ex) {
        this.IsListedTable = false;
        throw ex;
      } finally {
        this.Text = this._name;
        this.TreeView.Update();
      }
    }

    private string[] GetTablesName(string type) {
      MongoDBConnection conn = new MongoDBConnection(this._connection.ConnectionString);
      conn.Open();
      DataTable schema = conn.GetSchema("TABLES", null);
      DataRow[] tables = schema.Select("TABLE_TYPE='" + type + "'");
      int index = schema.Columns.IndexOf("TABLE_NAME");
      string[] tablesname = new string[tables.Length];
      for (int i = 0; i < tables.Length; i++) {
        tablesname[i] = (string)tables[i].ItemArray[index];
      }
      return tablesname;
    }

    private string[] GetProcuderesName() {
      MongoDBConnection conn = new MongoDBConnection(this._connection.ConnectionString);
      conn.Open();
      DataTable schema = conn.GetSchema("PROCEDURES", null);
      DataRow[] tables = schema.Select();
      int index = schema.Columns.IndexOf("PROCEDURE_NAME");
      string[] tablesname = new string[tables.Length];
      for (int i = 0; i < tables.Length; i++) {
        tablesname[i] = (string)tables[i].ItemArray[index];
      }
      return tablesname;
    }
  }

  class TableNode : TreeNode {
    private string _name = null;
    private ConnectionNode _connection = null;
    private FolderNode _folder = null;
    private bool _listedColumn = false;

    public TableNode(ConnectionNode conn, FolderNode folder, string tablename) {
      this._name = tablename;
      this._connection = conn;
      this._folder = folder;
      this.Text = tablename;
      this.ImageKey = "table.ico";
      this.SelectedImageKey = this.ImageKey;
      this.Nodes.Add("");// Add a empty node to show the expand icon.
    }

    public string TableName {
      get {
        return this._name;
      }
    }

    public ConnectionNode Connection {
      get {
        return this._connection;
      }
    }

    public FolderNode Folder {
      get {
        return this._folder;
      }
    }

    public bool IsListedColumn {
      get {
        return this._listedColumn;
      }
      set {
        this._listedColumn = value;
      }
    }

    public void FillNode(string status) {
      if (!string.IsNullOrEmpty(status)) {
        this.Text = this.Text + status;
        this.TreeView.Update();
      }
      try {
        MongoDBConnection conn = new MongoDBConnection(this._connection.ConnectionString);
        conn.Open();
        if (this.Folder.Type == FolderType.PRODUCERE) {
          DataTable parameterTable = conn.GetSchema("ProcedureParameters", new string[] { this.TableName });
          this.Nodes.Clear();
          foreach (DataRow row in parameterTable.Rows) {
            this.Nodes.Add(new ParameterNode(row["ParameterName"].ToString(), ParameterNode.GetTypeString(row["DataType"].ToString()), this, ParameterNode.ParseMode(row["Mode"].ToString())));
          }
        } else {
          DataTable columnTable = conn.GetSchema("Columns", new string[] { this.TableName });
          this.Nodes.Clear();
          foreach (DataRow row in columnTable.Rows) {
            this.Nodes.Add(new ColumnNode(row["ColumnName"].ToString(), Boolean.Parse(row["IsKey"].ToString()), this));
          }
        }
      } catch (Exception ex) {
        throw ex;
      } finally {
        this.Text = this.TableName;
        this.TreeView.Update();
        this.IsListedColumn = true;
      }
    }
  }

  class ColumnNode : TreeNode {
    private bool _iskey = false;
    private string _columnName = null;
    private TableNode _table = null;

    public ColumnNode(string name, bool iskey, TableNode table) {
      this._columnName = name;
      this._iskey = iskey;
      this._table = table;
      this.Text = this.ColumnName;
      if (this.IsKey) {
        this.ImageKey = "key.ico";
      } else {
        this.ImageKey = "column.ico";
      }
      this.SelectedImageKey = this.ImageKey;
    }

    public string ColumnName {
      get {
        return this._columnName;
      }
      set {
        this._columnName = value;
      }
    }

    public bool IsKey {
      get {
        return this._iskey;
      }
      set {
        this._iskey = value;
      }
    }

    public TableNode Table {
      get {
        return this._table;
      }
      set {
        this._table = value;
      }
    }
  }

  class ParameterNode : TreeNode {
    public static string IN_MODE_TEXT = "IN";
    public static string INOUT_MODE_TEXT = "IN/OUT";
    public static string OUT_MODE_TEXT = "OUT";
    public static string RETURN_MODE_TEXT = "RETURN";
    private static readonly string NAME_FORMAT = "{0} ({1}, {2})";
    private string _parameterName = null;
    private string _parameterType = null;
    private TableNode _procedure = null;
    private ParameterDirection _mode = ParameterDirection.Input;

    public ParameterNode(string name, string type, TableNode procedure, ParameterDirection mode) {
      this._parameterName = name;
      this._parameterType = type;
      this._procedure = procedure;
      this._mode = mode;
      UpdateName();
      this.ImageKey = "column.ico";
      this.SelectedImageKey = this.ImageKey;
    }

    public string ParameterName {
      get {
        return this._parameterName;
      }
      set {
        this._parameterName = value;
      }
    }

    public string ParameterType {
      get {
        return this._parameterType;
      }
      set {
        this._parameterType = value;
      }
    }

    public TableNode Procedure {
      get {
        return this._procedure;
      }
      set {
        this._procedure = value;
      }
    }

    public ParameterDirection Mode {
      get {
        return this._mode;
      }
      set {
        this._mode = value;
      }
    }

    private void UpdateName() {
      this.Text = string.Format(NAME_FORMAT, this.ParameterName, this.ParameterType, this.Mode.ToString());
    }

    public static ParameterDirection ParseMode(string modeString) {
      if (IN_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase)) {
        return ParameterDirection.Input;
      } else if (INOUT_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase)) {
        return ParameterDirection.InputOutput;
      } else if (OUT_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase)) {
        return ParameterDirection.Output;
      } else if (RETURN_MODE_TEXT.Equals(modeString, StringComparison.CurrentCultureIgnoreCase)) {
        return ParameterDirection.ReturnValue;
      } else {
        return ParameterDirection.Input;
      }
    }

    public static string GetTypeString(string type) {
      if (type != null) {
        int idx = type.LastIndexOf('.');
        if (idx > 0 && idx < type.Length - 1) {
          return type.Substring(idx + 1);
        }
      }
      return null;
    }
  }

  class ConnectionNode : TreeNode {
    private string _connectionString = null;
    private string _connectionName = null;
    private MongoDBConnection _connection = null;

    public ConnectionNode(string connection, string name) {
      this._connectionString = connection;
      this._connectionName = name;
      this.Text = this._connectionName;
      this.ImageKey = "connection.ico";
      this.SelectedImageKey = this.ImageKey;
      this.Nodes.Add(new FolderNode(this, FolderType.TABLE));
      this.Nodes.Add(new FolderNode(this, FolderType.VIEW));
      this.Nodes.Add(new FolderNode(this, FolderType.PRODUCERE));
    }

    public string ConnectionString {
      get {
        return this._connectionString;
      }
      set {
        this._connectionString = value;
        _connection = null;
      }
    }

    public string ConnectionName {
      get {
        return this._connectionName;
      }
      set {
        this._connectionName = value;
        this.Text = value;
      }
    }

    public MongoDBConnection Connection { 
      get {
        if (_connection == null) {
          _connection = new MongoDBConnection(this._connectionString);
        }
        if (_connection.State == ConnectionState.Closed) {
          _connection.Open();
        }
        return _connection;
      }
    }
  }
}