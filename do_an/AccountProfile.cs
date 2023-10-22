using do_an.DAO;
using do_an.DTO;
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
    public partial class AccountProfile : Form
    {
        private AccountDTO loginAccount;
        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount); }//ứng dụng tính đóng gói của lập trình hướng đối tượng
        }
        public AccountProfile(AccountDTO Acc)
        {
            InitializeComponent();
            LoginAccount = Acc;
        }
        void ChangeAccount(AccountDTO Acc)
        {
            txtUsername.Text = LoginAccount.Username;
            txtDisplayName.Text = LoginAccount.Displayname;
        }
        void UpdateAccount()
        {
            string Username = txtUsername.Text;
            string DisplayName = txtDisplayName.Text;
            string Password = txtPassword.Text;
            string NewPass = txtNewPass.Text;

            if(NewPass.Equals(txtReEnterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu trùng với mật khẩu mới !!!");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(Username, DisplayName, Password, NewPass))
                {
                    MessageBox.Show("Cập nhật thành công !!!");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }    
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
