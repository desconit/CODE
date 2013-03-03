using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using DESCONIT.DAL;
/// <summary>
/// Summary description for DBLink
/// </summary>
/// 
namespace DESCONIT.BLL
{
  public  class BLL
  {
    string TableName = "";
    string spNameForAdd = "";
    string spNameForDelete = "";
    string spNameForUpdate = "";
    string spNameForGetByID = "";
    string spNameForGetByCode = "";
    string spNameForSearch = "";
    string DBName = "";
    int UserID = 0;

    public BLL( string DB)
    {
      this.DBName = DB;
    }

    public BLL(string tableName, string DB)
    {
        this.TableName = tableName;
        this.DBName = DB;

        CreateSpNames();
    }

    public BLL(string tableName, string DB, int UserID)
    {
        
        this.DBName = DB;
        this.TableName = tableName;
        this.UserID = UserID;
        CreateSpNames();
    }

    private void CreateSpNames()
    {
        
        this.spNameForAdd = "usp_" + TableName + "Add";
        this.spNameForDelete = "usp_" + TableName + "Delete";
        this.spNameForUpdate = "usp_" + TableName + "Update";
        this.spNameForGetByID = "usp_" + TableName + "GetByID"; ;
        this.spNameForGetByCode = "usp_" + TableName + "GetByCode";
        this.spNameForSearch = "usp_" + TableName + "Search";
    }


    public DataSet GetByID(int ID)
    {
        DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSpGetByID_OR_Delete(spNameForGetByID, ID);
    }

    public DataSet GetByCode(string Code)
    {
        DataBase db = new DataBase(DBName, this.TableName);

        return db.ExecuteSpGetByCode(spNameForGetByCode, Code);
    }

    public DataSet Insert(DataRow drow)
    {
      DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSpInsertUpdate(spNameForAdd, drow, this.UserID, true);
    }

    public DataSet Insert(DataRow drow, string TableName)
    {
        DataBase db = new DataBase(DBName, TableName);

        return db.ExecuteSpInsertUpdate("usp_" + TableName + "Add", drow, this.UserID, true);
    }

    private DataSet InsertChild(DataRow drow)
    {
        DataBase db = new DataBase(DBName, this.TableName);

        return db.ExecuteSpInsertUpdate("usp_" + drow.Table.TableName + "Add", drow, this.UserID, true);
    }

    public DataSet Update(DataRow drow)
    {
      DataBase db = new DataBase(DBName,this.TableName);

      return db.ExecuteSpInsertUpdate(spNameForUpdate, drow, this.UserID, false);
    }


    public DataSet Update(DataRow drow, string TableName)
    {
        DataBase db = new DataBase(DBName, TableName);

        return db.ExecuteSpInsertUpdate("usp_" + TableName + "Update", drow, this.UserID, false);
    }

    private DataSet UpdateChild(DataRow drow)
    {
        DataBase db = new DataBase(DBName, this.TableName);
        
        return db.ExecuteSpInsertUpdate("usp_" + drow.Table.TableName + "Update", drow, this.UserID, false);
    }

    public DataSet Search()
    {
        DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSearchSP(spNameForSearch);
    }

    private DataSet DeleteChild(int ID, string ChildTableName)
    {
        DataBase db = new DataBase(DBName, this.TableName);

        return db.ExecuteSpGetByID_OR_Delete("usp_" + ChildTableName + "Delete", ID);
    }

    public DataSet Delete(int ID)
    {
        DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSpGetByID_OR_Delete(spNameForDelete, ID);
    }

    public DataSet ExecuteSP(string spName)
    {
        DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSP(spName);
    }

    public DataSet ExecuteSP(string spName, Hashtable ht)
    {
        DataBase db = new DataBase(DBName, this.TableName);

      return db.ExecuteSP(spName, ht);
    }

    public DataSet SaveAllSimple(DataSet dsSave)
    {
        DataSet ds;
        for (int i = 0; i < dsSave.Tables[0].Rows.Count; i++)
        {
            if (dsSave.Tables[0].Rows[i].RowState == DataRowState.Added)
            {
                ds = Insert(dsSave.Tables[0].Rows[i]);
                dsSave.Tables[0].Rows[i]["ID"] = ds.Tables[0].Rows[0]["ID"];
            }
            else if (dsSave.Tables[0].Rows[i].RowState == DataRowState.Modified)
            {
                ds = Update (dsSave.Tables[0].Rows[i]);
            }

            dsSave.Tables[0].Rows[i].AcceptChanges();
            
        }

        return dsSave;
    }

    public DataTable SaveAllSimple(DataTable dtSave)
    {
        DataSet ds;
        for (int i = 0; i < dtSave.Rows.Count; i++)
        {
            if (dtSave.Rows[i].RowState == DataRowState.Added)
            {
                ds = Insert(dtSave.Rows[i]);
                dtSave.Rows[i]["ID"] = ds.Tables[0].Rows[0]["ID"];
            }
            else if (dtSave.Rows[i].RowState == DataRowState.Modified)
            {
                ds = Update(dtSave.Rows[i]);
            }

            dtSave.Rows[i].AcceptChanges();

        }

        return dtSave;
    }


    public DataTable SaveAllSimple(DataTable dtSave, string TableName)
    {
        DataSet ds;
        for (int i = 0; i < dtSave.Rows.Count; i++)
        {
            if (dtSave.Rows[i].RowState == DataRowState.Added)
            {
                ds = Insert(dtSave.Rows[i], TableName);
                dtSave.Rows[i]["ID"] = ds.Tables[0].Rows[0]["ID"];
            }
            else if (dtSave.Rows[i].RowState == DataRowState.Modified)
            {
                ds = Update(dtSave.Rows[i], TableName);
            }

            dtSave.Rows[i].AcceptChanges();

        }

        return dtSave;
    }

    public DataSet SaveComplex(DataSet dsSave,bool isEdit)
    {
        int ParentID = 0;
        DataSet ds;
        string ParentTblName;
        string ParentColName;
        string ChildTblName;
        string ChildColName;

        if (isEdit)
        {
            ds = Update(dsSave.Tables[0].Rows[0]);
            
        }
        else
        {
            ds = Insert(dsSave.Tables[0].Rows[0]);
        }

        ParentID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
        

        for (int iRel = 0; iRel < dsSave.Relations.Count; iRel++)
        {
            ParentTblName = dsSave.Relations[iRel].ParentTable.TableName;
            ParentColName = dsSave.Relations[iRel].ParentColumns[0].ColumnName;

            ChildTblName = dsSave.Relations[iRel].ChildTable.TableName;
            ChildColName = dsSave.Relations[iRel].ChildColumns[0].ColumnName;

            for (int i = 0; i < dsSave.Tables[ChildTblName].Rows.Count; i++)
            {
                if (dsSave.Tables[ChildTblName].Rows[i].RowState == DataRowState.Added)
                {
                    //dsSave.Tables[ChildTblName].Rows[i]["CreatedBy"] = this.UserID;
                    dsSave.Tables[ParentTblName].Rows[0]["ID"] = ParentID;
                    //dsSave.Tables[ChildTblName].Rows[i][ParentColName] = ParentID;
                    dsSave.Tables[ChildTblName].Rows[i][ChildColName] = ParentID;
                    ds = InsertChild(dsSave.Tables[ChildTblName].Rows[i]);
                    dsSave.Tables[ChildTblName].Rows[i]["ID"] = ds.Tables[0].Rows[0]["ID"];
                    
                }
                else if (dsSave.Tables[ChildTblName].Rows[i].RowState == DataRowState.Modified)
                {
                    //dsSave.Tables[ChildTblName].Rows[i]["LastModifiedBy"] = this.UserID;
                    ds = UpdateChild(dsSave.Tables[ChildTblName].Rows[i]);
                }
                else if (dsSave.Tables[ChildTblName].Rows[i].RowState == DataRowState.Deleted)
                {
                   // dsSave.Tables[ChildTblName].Rows[i].AcceptChanges();
                    dsSave.Tables[ChildTblName].Rows[i].RejectChanges();
                    DeleteChild(Convert.ToInt32(dsSave.Tables[ChildTblName].Rows[i]["ID"]), ChildTblName);
                }

                dsSave.Tables[ChildTblName].Rows[i].AcceptChanges();

            }
 
        }
        return dsSave = GetByID(ParentID);
    }

  }
}