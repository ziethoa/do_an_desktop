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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=MSI\HOA;Initial Catalog=QuanLyQuanBida;Integrated Security=True");
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();//sử dụng cách này thì kể cả bấm nút x màu đỏ nó vẫn hiện message box
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string username = txtUsername.Text;
            string user_password = txtPassword.Text;

            try
            {
                string query = "SELECT * FROM Account WHERE tennguoidung = '" + txtUsername.Text + "' AND matkhau = '" + txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, cnn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    user_password = txtPassword.Text;

                    TableManager f = new TableManager();
                    this.Hide();//ẩn form login
                    f.ShowDialog();
                    this.Show();//hiện file login
                } else
                {
                    MessageBox.Show("Sai ten dang nhap hoac mat khau", "Error", MessageBoxButtons.OK);
                    txtUsername.Clear();
                    txtPassword.Clear();

                    txtUsername.Focus();
                }
             
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                cnn.Close();
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
