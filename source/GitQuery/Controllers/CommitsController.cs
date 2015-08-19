using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GitQuery.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO.Compression;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace GitQuery.Controllers
{
    public class CommitsController : Controller
    {

        private ApplicationDbContext Userdb;
        private UserManager<ApplicationUser> manager;

        // Constants used for custom errors in the New and Undo actions
        public const String SyntaxError = "Error: Please check the syntax of your query statement.";
        public const String QueryTypeError = "Error: We're sorry, at this time we only support SQL UPDATE statements.";
        public const String LoginError = "Error: There was a problem processing this query. Please make sure you have entered the correct information, have permission to update this database, and have enabled the server to accecpt remote connections.";
        public const String illegalSQL = "SELECT INSERT DELETE CREATE DROP ALTER";

        private ApplicationDbContext db = new ApplicationDbContext();

        public CommitsController()
        {
            Userdb = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Userdb));
        }

        //GET
        public async Task<ActionResult> Undo()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            ViewBag.Success = false;
            ViewBag.Method = "get";
            return View(currentUser.commits);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /* POST
        | Reconcile data, then create an 'updates.txt' file that contains the SQL UPDATE statements that will undo the changes of the
        | selected query */
        public async Task<ActionResult> Undo(int id, String username, String pass)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            Commit commit = db.Commits.Find(id);
            commit.uid = username;
            commit.password = pass;
            List<String> updates = reconcile(commit);   // returns list of SQL UPDATE statements

            // Create 'updates.txt' file, where each line is a String from the above List
            String datafile = Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name + "/updates.txt");
            FileStream fs = new FileStream(datafile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach(String s in updates)
            {
                sw.WriteLine(s);
            }
            sw.Close();

            ViewBag.numChanged = countChanged(updates);
            ViewBag.Commit = commit;
            ViewBag.Method = "post";
            commit.db.badCommit = commit.ID;
            db.Entry(commit).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return View(currentUser.commits);

        }

        public async Task<ActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            return View(currentUser.commits);
        }

        // GET: Commits
        public ActionResult New()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Method = "get";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET
        // Parse query and check for errors, connect to database and count the number of rows that will be affected by the query
        public async Task<ActionResult> New([Bind(Include = "ID,name,sqlQuery,uid,password")] Commit commit)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                ViewBag.Method = "post";
                // If there is an error, set ViewBag.Error equal to message
                string[] words = commit.sqlQuery.Split(' ');
                if (illegalSQL.Contains(words[0])) { ViewBag.Error = true; ViewBag.Message = QueryTypeError; }
                else if (words.Length < 4) { ViewBag.Error = true; ViewBag.Message = SyntaxError; }

                // Else, count the number of rows that will be changed by the query
                else
                {
                    Dbase curDB = Userdb.Bases.Find(currentUser.currentID);
                    ViewBag.Message = countRowsAffected(commit, curDB);
                    if (ViewBag.Message[0] == 'E') { ViewBag.Error = true; }
                    else { ViewBag.Error = false; }
                    ViewBag.Table = getTableName(commit.sqlQuery);
                    ViewBag.DB = curDB.name;
                }
            }
            ViewBag.key = commit.key;  // First field in the db table that is a table key. Used as the unique identifier for each afftected row
            return View(commit);
        }

        // GET: Commits/Details/5
        public ActionResult Details(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commit commit = db.Commits.Find(id);
            if (commit == null)
            {
                return HttpNotFound();
            }
            return View(commit);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commit commit = db.Commits.Find(id);
            if (commit == null)
            {
                return HttpNotFound();
            }
            return View(commit);
        }

        // GET: Commits/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Commits/Create
        // Store the old data affected by the query, execute the query, store the new data from the fields affected by query
        // 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,name,sqlQuery,uid,password,key")] Commit commit)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
            DataTable table;
            if (ModelState.IsValid)
            {
                commit.User = currentUser;
                table = resultSetTable(commit); // datatable filled with old data affected by query
                String path = "~/App_Data/" + commit.User.Email + "/" + commit.name + "/" + commit.name + ".txt";
                createFile(table, commit, path); // serialize the table to folder ~/App_Data/commit.User.Email/commit.name

                // save these fields of commit and add to database
                commit.table = getTableName(commit.sqlQuery);
                commit.numRows = table.Rows.Count;
                commit.created_at = DateTime.Now;
                commit.db = Userdb.Bases.Find(currentUser.currentID);
                Userdb.Commits.Add(commit);
                currentUser.commits.Add(commit);

                executeQuery(commit);
                List<int> ids = getUniques(table);  // get unique identifiers for the rows affected by the query
                storeNewData(table, commit, ids);    // store the new data from the rows affected by query
                commit.uid = "*";
                commit.password = "*";
                await Userdb.SaveChangesAsync();
                return View();
            }
            return RedirectToAction("New");
        }

        // GET: Commits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commit commit = db.Commits.Find(id);
            if (commit == null)
            {
                return HttpNotFound();
            }
            return View(commit);
        }

        // POST: Commits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,unique_commit_id,unique_base_id,created_at")] Commit commit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commit);
        }

        // GET: Commits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commit commit = db.Commits.Find(id);
            if (commit == null)
            {
                return HttpNotFound();
            }
            return View(commit);
        }

        // POST
        // Undo the chnages from the query, delete all associated data, remove the commit object from GitQuery database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, bool unchanged)
        {
            Commit commit = Userdb.Commits.Find(id);
            Dbase curDB = Userdb.Bases.Find(commit.User.currentID);
            undoQuery(commit, unchanged);
            Directory.Delete(Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name), true);
            Userdb.Commits.Remove(commit);
            curDB.commits.Remove(commit);
            curDB.badCommit = -1;
            Userdb.SaveChanges();
            return RedirectToAction("Index", "Dbases");
        }

        [ValidateAntiForgeryToken]
        public ActionResult GotoIndex()
        {
            return RedirectToAction("Index", "Dbases");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///     Executes a query on the current database
        /// </summary>
        /// <param name="commit">Query object to be executed</param>
        ///
        public void executeQuery(Commit commit)
        {
                string connectionString =
                "Data Source=" + commit.db.server +
                ";Initial Catalog=" + commit.db.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";

                using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
                {
                    DbCommand command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);
                    // Open the connection  
                    try
                    {
                        connection.Open();
                        ViewBag.RowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
        }

        // Copied from http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        // Copied from http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        /// <summary>
        ///     Using pre-built SQL UPDATE statements, undo the changes made by a query
        /// </summary>
        /// <param name="commit">The query object to be undone</param>
        /// <param name="unchanged">
        ///     if false: the rows in the database have not changed since this query was made
        ///     if true: at least one row has changed, reonciliation is needed
        /// </param>
        public void undoQuery(Commit commit, bool unchanged)
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name + "/updates.txt"));
            string connectionString =
                "Data Source=" + commit.db.server +
                ";Initial Catalog=" + commit.db.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";
            using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
            {
                DbCommand command;
                // Open the connection  
                try
                {
                    String temp;
                    connection.Open();
                        // run all update SQL comands
                    if(!unchanged)
                    {
                        while(!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp.Contains("False")) { command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery); }
                            else { command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery); }
                            command.ExecuteNonQuery();
                        }
                    }
                    // run only if the String is preceeded by 'false' i.e. the record has not been changed
                    else
                    {
                        while (!sr.EndOfStream)
                        {
                            temp = sr.ReadLine();
                            if (temp.Contains("False"))
                            {
                                command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            sr.Close();
        }

        /// <summary>
        ///     Counts the number of rows in the database that have changed since a query was made
        /// </summary>
        /// <param name="updates">List of SQL UPDATE statements prepended with 'true' for has changed and 'false for hasn't changed</param>
        /// <returns></returns>
        public int countChanged(List<String> updates)
        {
            int count = 0;
            foreach (String t in updates)
            {
                if (t.Contains("True")) { count += 1; }
            }
            return count;
        }

        /// <summary>
        ///     Store the new data of the rows that were just affected by the query.
        /// </summary>
        /// <param name="table">table with the old data (see 'Create' post action)</param>
        /// <param name="commit"></param>
        /// <param name="ids"></param>
        public void storeNewData(DataTable table, Commit commit, List<int> ids)
        {
            // start creating a SELECT SQL statement from the column names of 'table'
            table.Rows.Clear();
            String fields = "";
            foreach(DataColumn col in table.Columns)
            {
                fields += "," + col.ColumnName;
            }
            String select = "SELECT " + fields.Substring(1) + " FROM " + commit.table;

            // execute the SELECT statements on the current database
            String query = "";
            string connectionString =
                "Data Source=" + commit.db.server +
                ";Initial Catalog=" + commit.db.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";
            using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
            {
                DbCommand command;
                // Open the connection  
                try
                {
                    connection.Open();
                    DbDataReader reader;
                    DataRow row;
                    // finiish creating SELECT statements using the unique row identifies from 'ids'
                    foreach (int i in ids)
                    {
                        query = select + " WHERE " + commit.key +"='" + i + "';";
                        command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);
                        reader = command.ExecuteReader();
                        reader.Read();
                        row = table.NewRow();
                        for (int j = 0; j < table.Columns.Count; j += 1)
                        {
                            row[j] = reader[j];
                        }
                        table.Rows.Add(row);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            String path = "~/App_Data/" + commit.User.Email + "/" + commit.name + "/R" + commit.name + ".txt";
            createFile(table, commit, path);    // store the new data in the same folder as the old data
        }

        /// <summary>
        ///     Return a list of unique identifiers for the rows affected by a query
        /// </summary>
        /// <param name="table">table with data from original query</param>
        /// <returns></returns>
        public List<int> getUniques(DataTable table)
        {
            List<int> ids = new List<int>();
            foreach(DataRow row in table.Rows)
            {
                ids.Add(Convert.ToInt32(row[0].ToString())); // the first row of the table will always be the chosen unique identifier
            }
            return ids;
        }

        /// <summary>
        ///     Decrypt and decompress old data and the data saved after the query was made. 
        ///     Compare data saved after query to the most recent data. Create SQL UPDATE statements that will return current data to old data and
        ///     save these statements in 'updates.txt'. If the data has changed, prepend the UPDATE with 'TRUE', else prepend with 'FALSE'.
        /// </summary>
        /// <param name="commit">The query object that is being undone</param>
        /// <returns></returns>
        public List<String> reconcile(Commit commit)
        {
            List<String> updates = new List<String>();
            StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name + "/" + commit.name + ".txt"));

            // Decrypt old data
            byte[] bytesToBeDecrypted = Convert.FromBase64String(sr.ReadToEnd());
            byte[] passwordBytes = Encoding.UTF8.GetBytes(commit.password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            string json = Unzip(Encoding.UTF8.GetString(bytesDecrypted));   // Unzip the compressed data

            JArray old = JArray.Parse(json);
            sr.Close();
            sr = new StreamReader(Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name + "/R" + commit.name + ".txt"));

            // Decrypt reconciled data
            bytesToBeDecrypted = Convert.FromBase64String(sr.ReadToEnd());
            bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            json = Unzip(Encoding.UTF8.GetString(bytesDecrypted));  // Unzip the compressed data

            JArray recs = JArray.Parse(json);
            sr.Close();
            Dbase curDB = commit.db;
            string connectionString =
                "Data Source=" + curDB.server +
                ";Initial Catalog=" + curDB.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";

            String start = "SELECT ";
            String selfields = "";
            String where = "";
            String query = "";

            // creates the fields that the T-SQL will select
            foreach (JProperty p in old.Children<JObject>().First().Properties())
            {
                selfields += "," + p.Name;
            }

            using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
            {
                DbCommand command;
                DbDataReader reader;
                // Open the connection  
                try
                {
                    connection.Open();
                    String key = commit.key;
                    bool changed;
                    int count = 0;
                    String fields = "";
                    foreach (JObject o in recs.Children<JObject>())
                    {
                        JObject oldRecord = old.Children<JObject>().ElementAt(count);
                        where = " WHERE " + key + "=" + o.Property(key).Value;
                        query = start + selfields.Substring(1) + " FROM " + commit.table + where + ";";
                        command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);
                        reader = command.ExecuteReader();
                        reader.Read();
                        fields = "";
                        changed = false;
                        foreach (JProperty p in o.Properties())
                        {
                            if (p.Value.ToString() != reader[p.Name].ToString()) { changed = true; }
                            
                            if (p.Name == key) { where = " WHERE " + key + "=" + p.Value + ";"; }
                            else { fields += "," + p.Name + "='" + oldRecord.Property(p.Name).Value + "'"; }
                        }
                        reader.Close();
                        query = "UPDATE " + commit.table + " SET " + fields.Substring(1) + where;
                        updates.Add(changed.ToString() + query);
                        count += 1;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return updates;
        }

        /// <summary>
        ///     Count the # of rows that will be affected by this query by changing UPDATE statement to a SELECT statement
        /// </summary>
        /// <param name="commit"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public String countRowsAffected(Commit commit, Dbase curDB)
        {
            String init = commit.sqlQuery;
            string[] words = init.Split(' ');
            string connectionString =
                "Data Source=" + curDB.server +
                ";Initial Catalog=" + curDB.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";
            int count = 0;
            String query = updateToSelectAll(init, words); // changes the UPDATE statement to a SELECT statement
            using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
            {
                DbCommand command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);
                // Open the connection  
                try
                {
                    connection.Open();
                    DbDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                    commit.key = getTableKey(reader);
                    while (reader.Read())
                    {
                        count += 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return LoginError;
                }
            }
            return count.ToString();
        }

        /// <summary>
        ///     Return the name of the first field in the table that is a table key
        /// </summary>
        /// <param name="reader">Object used to find the schema of the target table</param>
        /// <returns></returns>
        public String getTableKey(DbDataReader reader)
        {
            DataTable table = reader.GetSchemaTable();
            foreach (DataRow r in table.Rows)
            {
                if ((bool)r["IsKey"]) { return r["ColumnName"].ToString(); }
            }
            return "";
        }

        /// <summary>
        ///     Returns a DataTable that contains the result set of the query after transforming it from and UPDATE to a SELECT
        /// </summary>
        /// <param name="commit">Query object of the DML being executed</param>
        /// <returns></returns>
        public DataTable resultSetTable(Commit commit)
        {
            String init = commit.sqlQuery;
            string[] words = init.Split(' ');
            Dbase curDB = Userdb.Bases.Find(commit.User.currentID);
            string connectionString =
                "Data Source=" + curDB.server +
                ";Initial Catalog=" + curDB.name +
                ";User Id=" + commit.uid +
                ";Password=" + commit.password + ";";

            String query = updateToSelectChanging(init, words,commit); // changes the UPDATE statement to a SELECT statement
            DataTable table = new DataTable("query");
            using (DbConnection connection = QueryController.getConnectionType(connectionString, commit.db.dbType))
            {
                DbCommand command = QueryController.getCommandType(connection, commit.db.dbType, commit.sqlQuery);

                // Open the connection  
                try
                {
                    connection.Open();
                    DbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // Define schema of table
                        reader.Read();
                        for (int i = 0; i < reader.FieldCount; i += 1)
                        {
                            table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                        }
                        // Fill table with the result set of the query
                        DataRow row;
                        do
                        {
                            row = table.NewRow();
                            for (int j = 0; j < reader.FieldCount; j += 1)
                            {
                                row[j] = reader[j];
                            }
                            table.Rows.Add(row);
                        }
                        while (reader.Read());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ViewBag.Message = LoginError;
                }
                return table;
            }
        }

        /// <summary>
        ///     Converts a SQL UPDATE to a SELECT. The returned query will select ALL table fields.
        /// </summary>
        /// <param name="init">the original query</param>
        /// <param name="words">the original query as an array of words seperated by a space</param>
        /// <returns></returns>
        public String updateToSelectAll(String init, string[] words)
        {
            String query = "SELECT *" + " FROM " + words[1]; ;
            if (init.Contains("WHERE"))
            {
                query += " " + init.Substring(init.IndexOf("WHERE"));
            }
            return query;
        }

        /// <summary>
        ///     Converts a SQL UPDATE to a SELECT. The returned query will select only the table fields that are being affected by the query.
        /// </summary>
        /// <param name="init">the original query</param>
        /// <param name="words">the original query as an array of words seperated by a space</param>
        /// <param name="commit">query object</param>
        /// <returns></returns>
        public String updateToSelectChanging(String init, string[] words, Commit commit)
        {
            String query = "SELECT " + commit.key;
            String cols = "";
            bool contains = init.Contains("WHERE");
            int start = init.IndexOf("SET") + 4;
            int end;
            if (contains) { end = init.IndexOf("WHERE") - 1; }
            else { end = init.Length - 1; }
            string[] sub = init.Substring(start, end - start).Split(',');
            foreach(String s in sub)
            {
                start = 0;
                while (s[start] == ' ') { start += 1; }
                end = s.IndexOf("=");
                cols += "," + s.Substring(start, end - start);
            }

            query += cols + " FROM " + words[1];
            if (init.Contains("WHERE"))
            {
                query += " " + init.Substring(init.IndexOf("WHERE"));
            }
            return query;
        }

        /// <summary>
        ///     Creates a file in the specified path. Serializes a DataTable to a JSON string, compresses it, encrypts it, stores it in file.
        /// </summary>
        /// <param name="table">table with query data to store</param>
        /// <param name="commit">current query object</param>
        /// <param name="path">the path in User's directory to store 'table'</param>
        public void createFile(DataTable table, Commit commit, String path)
        {
            // If directory exists, create a path. If not, create a new directory and a path
            String folder = Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // Serialize the DataTable to a string using JSON format
            StringBuilder sb = new StringBuilder();
            StringWriter s = new StringWriter(sb);
            using(JsonTextWriter writer = new JsonTextWriter(s))
            {
                writer.QuoteChar = '\'';
                JsonSerializer ser = new JsonSerializer();
                ser.Serialize(writer, table);
            }
            string compress = sb.ToString();

            // Read back JSON string and encrpt using AES
            String encrypt = Zip(compress);   // Compress the data stored in the file
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(encrypt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(commit.password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes); // Hash the password with SHA256
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
            encrypt = Convert.ToBase64String(bytesEncrypted);

            // Store the encrpted string in a file
            string datafile = Server.MapPath("~/App_Data/" + commit.User.Email + "/" + commit.name + "/" + Path.GetFileName(path));
            FileStream fs = new FileStream(datafile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(encrypt);
            sw.Flush();
            fs.Close();
        }

        // returns the table (second word of query) being affected
        public String getTableName(String query)
        {
            string[] words = query.Split(' ');
            return words[1];
        }

        /*--------------------------------------------------------------
         * 
         * This code is copied from a StackOverflow post: http://stackoverflow.com/questions/7343465/compression-decompression-string-with-c-sharp
         * Used to Zip and Unzip a string
         * 
         * */

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static string Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msIn = new MemoryStream(bytes))
            using (var msOut = new MemoryStream())
            {
                using (var gs = new GZipStream(msOut, CompressionMode.Compress))
                {
                    CopyTo(msIn, gs);
                }
                return Convert.ToBase64String(msOut.ToArray());
            }
        }

        public static string Unzip(string temp)
        {
            byte[] bytes = Convert.FromBase64String(temp);
            using (var msIn = new MemoryStream(bytes))
            using (var msOut = new MemoryStream())
            {
                using (var gs = new GZipStream(msIn, CompressionMode.Decompress))
                {
                    CopyTo(gs, msOut);
                }
                return Encoding.UTF8.GetString(msOut.ToArray());
            }
        }

    }
}