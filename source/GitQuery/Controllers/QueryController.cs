using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.CData.MongoDB;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitQuery.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult Index()
        {
            return View();
        }

        public static DbConnection getConnectionType(string connectionString, string dbType)
        {
            DbConnection result = null;
            switch(dbType)
            {
                case "MS SQL Server":
                    result = new SqlConnection(connectionString); break; // working
                case "Oracle":
                    result = new OracleConnection(connectionString); break;
                case "MySQL":
                    result = new MySqlConnection(connectionString); break;
                case "PostgreSQL":
                    result = new NpgsqlConnection(connectionString); break;
                    // FIX THISSSSSSSSSSSSSSSSSSS!
                //case "mongo":
                    //result = new MongoDBConnection(connectionString); break;
            }
            return result;
        }

        public static DbCommand getCommandType(DbConnection con, string dbType, string command)
        {
            DbCommand result = null;
            switch(dbType)
            {
                case "mssql":
                    result = new SqlCommand(command, (SqlConnection)con); break; // working
                case "oracle":
                    result = new OracleCommand(command, (OracleConnection)con); break;
                case "mysql":
                    result = new MySqlCommand(command, (MySqlConnection)con); break;
                case "pgsql":
                    result = new NpgsqlCommand(command, (NpgsqlConnection)con); break;
            }
            return result;
        }
    }
}