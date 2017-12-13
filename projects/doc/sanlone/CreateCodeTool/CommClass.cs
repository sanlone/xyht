using System;
using System.Collections.Generic;
using System.Text;

namespace CreateCodeTool
{
    public class Project
    {
        string _EntityNameSpace = "";
        string _DALNameSpace = "";
        string _DBNameSpace = "";
        public Project()
        { }
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
        public string DBNameSpace
        {
            get { return this._DBNameSpace; }
            set { this._DBNameSpace = value; }
        }
       
    }
    public static  class Comm
    {
        public static Project project;
    }
}
