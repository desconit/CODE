using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Collections;
using RSys;

/// <summary>
/// Summary description for DataBase
/// </summary>
/// 
namespace DESCONIT.DAL
{

  class DataBase
  {
    string connectionString;
    string CurrDB;
    string TableName;
    public DataBase(string CurrentDB, string TableName)
    {
      CurrDB = CurrentDB;
      connectionString = ConfigurationManager.ConnectionStrings[CurrentDB].ConnectionString;
      this.TableName = TableName;
    }


    private SqlConnection connection = new SqlConnection();


    private SqlCommand GetCommand()
    {
      SqlCommand command = new SqlCommand();
      command.CommandType = CommandType.StoredProcedure;
      command.Connection = GetConnection();
      return command;

    }
    

    public DataSet ExecuteSpInsertUpdate(string spName, DataRow dr, int UserId, bool isInsert)
    {
      DataSet ds = new DataSet();
      SqlCommand command = GetCommand();
      command.CommandText = spName;
      string paramName = "";
      SqlCommandBuilder.DeriveParameters(command);

     if(isInsert)
         dr["CreatedBy"] = Program.clsuser.UserID;
     else
         dr["LastModifiedBy"] = Program.clsuser.UserID;

    if(dr.Table.Columns.Contains("CompanyID"))
        dr["CompanyID"] = Program.clsuser.CompanyID;
    if (dr.Table.Columns.Contains("BranchesID") &&  dr["BranchesID"].Equals(DBNull.Value))
         dr["BranchesID"] = Program.clsuser.BranchID;
    if (dr.Table.Columns.Contains("TableName"))
        dr["TableName"] = dr.Table.TableName;

      foreach (SqlParameter parameter in command.Parameters)
      {
        if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
        {
          paramName = parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1);
          if (dr.Table.Columns.Contains(paramName))
          {
            if (isInsert && parameter.ParameterName != "ID")
              parameter.Value = dr[paramName];
            else
              parameter.Value = dr[paramName];

          }
        }
      }


      SqlDataAdapter da = new SqlDataAdapter(command);
      da.Fill(ds);
      CloseConnection();
      return ds;
    }

    public DataSet ExecuteSpGetByID_OR_Delete(string spName, int ID)
    {
      DataSet ds = new DataSet();
      SqlCommand command = GetCommand();
      command.CommandText = spName;
      SqlCommandBuilder.DeriveParameters(command);


      if (command.Parameters.Contains("@ID"))
          command.Parameters["@ID"].Value = ID;
      else
          command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
      
      command = PopulateCompFields(command);
      SqlDataAdapter da = new SqlDataAdapter(command);
      da.Fill(ds);
      CloseConnection();
      return ds;


    }

    private SqlCommand PopulateCompFields(SqlCommand command)
    {
        if (command.Parameters.Contains("@BranchesID"))
            command.Parameters["@BranchesID"].Value = Program.clsuser.BranchID;

        if (command.Parameters.Contains("@CompanyID"))
            command.Parameters["@CompanyID"].Value  = Program.clsuser.CompanyID;

        if (command.Parameters.Contains("@TableName"))
            command.Parameters["@TableName"].Value  = this.TableName;
        return command;
    }

    public DataSet ExecuteSpGetByCode(string spName, string Code)
    {
        DataSet ds = new DataSet();
        SqlCommand command = GetCommand();
        command.CommandText = spName;
        
        command.Parameters.Add("@Code", SqlDbType.NVarChar).Value = Code;
        PopulateCompFields(command);
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        CloseConnection();
        return ds;


    }

    public DataSet ExecuteSearchSP(string spName)
    {
        this.TableName = spName.Replace("usp_", "").Replace("Search", "");
      DataSet ds = new DataSet();
      SqlCommand command = GetCommand();
      command.CommandText = spName;
      SqlCommandBuilder.DeriveParameters(command);

      SqlDataAdapter da = new SqlDataAdapter(command);
       command = PopulateCompFields(command);
      da.Fill(ds);
      CloseConnection();
      return ds;

    }

    public DataSet ExecuteSP(string spName)
    {
      DataSet ds = new DataSet();
      SqlCommand command = GetCommand();
      command.CommandText = spName;

      SqlCommandBuilder.DeriveParameters(command);

      SqlDataAdapter da = new SqlDataAdapter(command);
      PopulateCompFields(command);
      da.Fill(ds);
      CloseConnection();
      return ds;

    }

    public DataSet ExecuteSP(string spName, Hashtable ht)
    {
      DataSet ds = new DataSet();
      SqlCommand command = GetCommand();
      command.CommandText = spName;
      string paramName = "";
      SqlCommandBuilder.DeriveParameters(command);


      if (ht.ContainsKey("BranchesID"))
          ht["BranchesID"] = Program.clsuser.BranchID;
      else
          ht.Add("BranchesID", Program.clsuser.BranchID);

      if (ht.ContainsKey("CompanyID"))
          ht["CompanyID"] = Program.clsuser.CompanyID;
      else
          ht.Add("CompanyID", Program.clsuser.CompanyID);

      if (ht.ContainsKey("TableName"))
          ht["TableName"] = this.TableName;
      else
          ht.Add("TableName", this.TableName);

        
      foreach (SqlParameter parameter in command.Parameters)
      {
        if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
        {
          paramName = parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1);
          if (ht.Contains(paramName))
          {
            parameter.Value = ht[paramName];

          }
        }
      }

      SqlDataAdapter da = new SqlDataAdapter(command);
      da.Fill(ds);
      CloseConnection();
      return ds;

    }

    public SqlConnection GetConnection()
    {

      if (connection.State != ConnectionState.Open)
      {
        connection.ConnectionString = connectionString;
        connection.Open();
      }

      return connection;


    }//

    public void CloseConnection()
    {
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
        connection.Dispose();
      }

    }//


  }
}