using System;
using System.Collections.Generic;
using System.Text;
using System.Data.CData.MongoDB;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;

namespace CData.MongoDB.Demo {

  class QueryData {
    private string _sql;
    private ConnectionNode _connection = null;
    private MongoDBDataAdapter _adapter = null;
    private MongoDBCommandBuilder _updateCommandBuilder = null;
    private MongoDBConnection _conn = null;
    public QueryData(ConnectionNode connection, string sql) {
    this._connection = connection;
    this._sql = sql;
  }

    public DataTable GetData() {
      MongoDBConnection conn = _connection.Connection;
      MongoDBCommand cmd = conn.CreateCommand();
      cmd.CommandText = this._sql;
      cmd.CommandType = CommandType.Text;
      this._adapter = new MongoDBDataAdapter(cmd);
      this._updateCommandBuilder = new MongoDBCommandBuilder(this._adapter);
      DataTable result = new DataTable();
      if (_sql.ToUpper().TrimStart().StartsWith("SELECT")) {
        this._adapter.Fill(result);
      } else {
        int rowsAffected = cmd.ExecuteNonQuery();
        result.Columns.Add("Rows Affected");
        DataRow row = result.NewRow();
        row[0] = rowsAffected;
        result.Rows.Add(row);
      }
      return result;
    }

    public DataTable ExecSP(Hashtable input, Hashtable output, Hashtable inputOutput, Hashtable returnValue) {
      MongoDBConnection conn = _connection.Connection;
      MongoDBCommand cmd = conn.CreateCommand();
      cmd.CommandText = this._sql;
      cmd.CommandType = CommandType.StoredProcedure;
      SetParameters(cmd, input, output, inputOutput, returnValue);
      this._adapter = new MongoDBDataAdapter(cmd);
      DataTable result = new DataTable(this._sql);
      this._adapter.Fill(result);
      GetOutput(cmd, output, inputOutput, returnValue);
      return result;
    }

    public void Update(DataTable data) {
      this._adapter.InsertCommand = this._updateCommandBuilder.GetInsertCommand();
      this._adapter.UpdateCommand = this._updateCommandBuilder.GetUpdateCommand();
      this._adapter.DeleteCommand = this._updateCommandBuilder.GetDeleteCommand();
      this._adapter.Update(data);
    }

    private void SetParameters(MongoDBCommand cmd, Hashtable input, Hashtable output, Hashtable inputOutput, Hashtable returnValue) {
      foreach (object key in input.Keys) {
        MongoDBParameter param = cmd.Parameters.Add(key.ToString());
        param.Value = input[key];
        param.Direction = ParameterDirection.Input;
      }
      foreach (object key in output.Keys) {
        MongoDBParameter param = cmd.Parameters.Add(key.ToString());
        param.Value = output[key];
        param.Direction = ParameterDirection.Output;
      }
      foreach (object key in inputOutput.Keys) {
        MongoDBParameter param = cmd.Parameters.Add(key.ToString());
        param.Value = inputOutput[key];
        param.Direction = ParameterDirection.InputOutput;
      }
      foreach (object key in returnValue.Keys) {
        MongoDBParameter param = cmd.Parameters.Add(key.ToString());
        param.Value = returnValue[key];
        param.Direction = ParameterDirection.ReturnValue;
      }
    }

    private void GetOutput(MongoDBCommand cmd, Hashtable output, Hashtable inputOutput, Hashtable returnValue) {
      foreach (MongoDBParameter param in cmd.Parameters) {
        if (param.Direction == ParameterDirection.Output) {
          output[param.ParameterName] = param.Value;
        } else if (param.Direction == ParameterDirection.InputOutput) {
          inputOutput[param.ParameterName] = param.Value;
        } else if (param.Direction == ParameterDirection.ReturnValue) {
          returnValue[param.ParameterName] = param.Value;
        }
      }
    }
  }
}