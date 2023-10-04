using do_an.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace do_an
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadAccountList();
        }

        void LoadAccountList()
        {
            string query = "EXEC USP_GetAccountByUserName @userName , @userName";//chạy câu query để truy vấn
            Dataprovider provider = new Dataprovider();
            dtgvAccount.DataSource = provider.ExecuteQuery(query, new object[] { "admin" , "dat"}); 
        }
    }
}
