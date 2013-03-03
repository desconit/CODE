
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

public class User
{
    private int _UserId;
    //private int _RoleId;
    private string _UserName;
    private string _Email;
    private string _Phone;
    private string _CurrDB;
    private string _Password;
    private bool _isAdmin = true;
   private int _CompanyID;
   private int _BranchID;
   private string _BranchName;
   private string _CompanyName;
   private string _AttachmentPath;
   private string _homeCountryName;
   private int _homeCountryID;
    //private string _AttachPath;
    //private bool _CanAdd;
    //private bool _CanView;
    //private bool _CanEdit;
    //private bool _CanDelete;

    private string _CurrTheme;


    public User()
    {
    }



    public int UserID
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    
    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }


    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public string CurrentTheme
    {
        get { return _CurrTheme; }
        set { _CurrTheme = value; }
    }

    public string CurrentDB
    {
        get { return _CurrDB; }
        set { _CurrDB = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    public bool isAdmin
    {
        get { return _isAdmin; }
        set { _isAdmin = value; }
    }

    public int BranchID
    {
        get { return _BranchID; }
        set { _BranchID = value; }
    }

    public int CompanyID
    {
        get { return _CompanyID; }
        set { _CompanyID = value; }
    }

    public string CompanyName
    {
        get { return _CompanyName; }
        set { _CompanyName = value; }
    }

    public string BranchName
    {
        get { return _BranchName; }
        set { _BranchName = value; }
    }

    public string AttachmentPath
    {
        get { return _AttachmentPath; }
        set { _AttachmentPath = value; }
    }

    public int HomeCountryID
    {
        get { return _homeCountryID; }
        set { _homeCountryID = value; }
    }

    public string HomeCountryName
    {
        get { return _homeCountryName; }
        set { _homeCountryName = value; }
    }

    //public bool CanView
    //{
    //    get { return _CanView; }
    //    set { _CanView = value; }
    //}

    //public bool CanAdd
    //{
    //    get { return _CanAdd; }
    //    set { _CanAdd = value; }
    //}

    //public bool CanEdit
    //{
    //    get { return _CanEdit; }
    //    set { _CanEdit = value; }
    //}

    //public bool CanDelete
    //{
    //    get { return _CanDelete; }
    //    set { _CanDelete = value; }
    //}
}

