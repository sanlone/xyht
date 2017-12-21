using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NWR.BLL;
using NWR.Model;
namespace NWR.UI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SC_OrderDetailedArrangeBll bll = new SC_OrderDetailedArrangeBll();
            SC_OrderDetailedArrange model=new SC_OrderDetailedArrange();
            model.CreateDate = DateTime.Now;
            model.CreateUserID = "";
            model.DeleteDate = DateTime.Now;
            model.DeleteReason = "";
            model.DeleteUserID = "";
            model.OrderDetailedID = 1;
            model.ProduceTaskID = 1;
            bll.AddModel(model);
        }
    }
}