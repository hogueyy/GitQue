using System;
using System.Data;
using System.Data.CData.MongoDB;

public partial class _Default : System.Web.UI.Page {
  private String Query = "SELECT * FROM ";
  private MongoDBConnection conn = null;
  protected void Page_Load(object sender, EventArgs e) {
    lblconnecterror.Text = null;
    lblexecuteerror.Text = null;
    if (!IsPostBack) {

    }
  }

  protected void ddl_SelectedIndexChanged(object sender, EventArgs e) {
    Update_Query();
  }

  protected void butexe_Click(object sender, EventArgs e) {
    string connstr = (string)Session["connstr"];
    if (string.IsNullOrEmpty(connstr)) {
      connstr = GetConnectionString();
    }
    string sql = txtQuery.Text;
    try {
      if (conn == null) conn = new MongoDBConnection(connstr);
      if (conn.State == ConnectionState.Closed) conn.Open();
      MongoDBCommand command = new MongoDBCommand(sql, conn);
      DataTable table = new DataTable();
      if (sql.ToUpper().TrimStart().StartsWith("SELECT")) {
        MongoDBDataAdapter adapter = new MongoDBDataAdapter(command);
        adapter.Fill(table);
        if (table.Rows.Count == 0) {
          table.Rows.Add(table.NewRow());
        }
      } else {
        int rowsAffected = command.ExecuteNonQuery();
        table.Columns.Add("Rows Affected");
        DataRow row = table.NewRow();
        row[0] = rowsAffected;
        table.Rows.Add(row);
      }
      gv.DataSource = table;
      gv.DataBind();
      lblexecuteerror.Text = null;
    }
    catch (Exception ex) {
      lblexecuteerror.Text = "<font color=red><b>" + ex.Message + "</b></font>";
    }
    
  }

  protected bool ddl_bind(DataTable schema) {
    if (schema == null) 
      return false;
    ddl.Items.Clear();
    ddl.DataTextField = schema.Columns[2].ToString();
    ddl.DataSource = schema;
    ddl.DataBind();
    Update_Query();
    if(ddl.Items.Count <= 0)
      return false;
    return true;
  }

  protected String GetConnectionString() {
    string connstr = "";

    Session["connstr"] = connstr;
    return connstr;
  }

  protected void bntconnect_Click(object sender, EventArgs e) {
    conn = new MongoDBConnection();
    string connstr = GetConnectionString();
    try {
      conn.ConnectionString = connstr;
      conn.Open();
      DataTable schema = conn.GetSchema("Tables");
      if (!ddl_bind(schema)) {
        throw new Exception("No tables available.");
      }
      conn.TestConnection();
      lblconnecterror.Text = null;
    } catch (Exception ex) {
      lblconnecterror.Text = "<font color=red><b>" + ex.Message + "</b></font>";
    }
  }

  protected void ddl_TextChanged(object sender, EventArgs e) {
    Update_Query();
  }

  protected void Update_Query() {
    txtQuery.Text = Query;
    string table = ddl.Text;
    string limit = txtlimit.Text;
    if(!string.IsNullOrEmpty(table))
      txtQuery.Text += ("[" + ddl.Text + "] ");
    if(!string.IsNullOrEmpty(limit))
      txtQuery.Text += ("LIMIT " + txtlimit.Text);
  }
}