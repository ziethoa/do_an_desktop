using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace do_an
{
    public partial class TableManager : Form
    {
        public TableManager()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime StartAt = DateTime.Now;
            txtTimeStart.Text = StartAt.ToString(" hh:mm tt");
        }

        private void btnTimeFinish_Click(object sender, EventArgs e)
        {
            DateTime EndAt = DateTime.Now;
            txtTimeFinish.Text = EndAt.ToString(" hh:mm tt");
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile f = new AccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin f = new Admin();
            f.ShowDialog();
        }
    }
}
