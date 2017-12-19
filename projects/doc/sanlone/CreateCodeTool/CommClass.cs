using System;
using System.Collections.Generic;
using System.Text;

namespace CreateCodeTool
{
    public class Project
    {
        string _DBName = "";
        string _EntityNameSpace = "";
        string _DALNameSpace = "";
        string _BLLNameSpace = "";
        public Project()
        { }
        public string DBName
        {
            get { return this._DBName; }
            set { this._DBName = value; }
        }
        public string EntityNameSpace
        {
            get { return this._EntityNameSpace; }
            set { this._EntityNameSpace = value; }
        }
        public string DALNameSpace
        {
            get { return this._DALNameSpace; }
            set { this._DALNameSpace = value; }
        }
        public string BLLNameSpace
        {
            get { return this._BLLNameSpace; }
            set { this._BLLNameSpace = value; }
        }
       
    }
    public static  class Comm
    {
        public static string ConnString = "";
        public static string connStringFormat = "Data Source={0};Initial Catalog=master;User ID={1};password={2}";
        public static Project project;
        public static string msg = "";
        public static string FilePath = "";
    }

}
