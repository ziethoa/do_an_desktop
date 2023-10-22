using do_an.DAO;
using do_an.DTO;
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
        BindingSource FoodList = new BindingSource();//cách sửa trường hợp nhấm nút xem thì không binding đc
        BindingSource AccountList = new BindingSource();
        public AccountDTO loginAccount;
        public Admin()
        {
            InitializeComponent();
            Load();
        }

        new void Load()
        {
            dtgvFood.DataSource = FoodList;
            dtgvAccount.DataSource = AccountList;

            LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePicker();
            LoadListFoD();
            LoadAccount();
            LoadCatagory(cbFoodCatagory);
            AddFoDBinding();
            AddAccountBinding();
            
        }
        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);//tip xác định ngày tháng
        }
        void LoadListViewByDate(DateTime CheckIn, DateTime CheckOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(CheckIn, CheckOut);

        }
        void AddFoDBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            //từ cái txtFoodName hãy thay đổi giá trị text(thuộc tính của text) bằng cái giá trị name(thuộc tính của name) nằm trong cái datasource
            //true: formating enabled true có nghĩa là nó chấp nhận khác kiểu và tự động ép kiểu
            // DataSourceUpdateMode: có 3 kiểu là never: kh thay đổi ; onProperty changed: thay đổi giá trị là thay đổi liền, kh cần load; onValidation: mặc định, khi sửa xong load sẽ thay đổi giá tị của cả 2 bên
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmrFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadListFoD()
        {
            FoodList.DataSource = FoDDAO.Instance.GetListFoD();
        }
        //sử dụng binding: khi 2 thằng binding lẫn nhau thì thằng này thay đổi thằng kia thay đổi theo tuỳ theo mode tạo ra
        void LoadCatagory(ComboBox cb)
        {
            cb.DataSource = CatagoryDAO.Instance.GetListCatagory();
            cb.DisplayMember = "Name";
        }
        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Displayname", true, DataSourceUpdateMode.Never));
            nmrAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
       



        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFoD();
        }

        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IdCatagory"].Value;//cách lấy ra 1 cell bất kì trong dtgv
                    CatagoryDTO catagory = CatagoryDAO.Instance.GetCatagoryByID(id);
                    cbFoodCatagory.SelectedItem = catagory;
                    int index = -1;
                    int i = 0;
                    foreach (CatagoryDTO item in cbFoodCatagory.Items)
                    {
                        if (item.ID == catagory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCatagory.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string Name = txtFoodName.Text;
            int IDCatagory = (cbFoodCatagory.SelectedItem as CatagoryDTO).ID;
            float Price = (float)nmrFoodPrice.Value;

            if(FoDDAO.Instance.InsertFoD(Name, IDCatagory, Price))
            {
                MessageBox.Show("Thêm món thành công !!!");
                LoadListFoD();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món !!!");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int IDFoD = Convert.ToInt32(txtFoodID.Text);
            string Name = txtFoodName.Text;
            int IDCatagory = (cbFoodCatagory.SelectedItem as CatagoryDTO).ID;
            float Price = (float)nmrFoodPrice.Value;

            if (FoDDAO.Instance.UpdateFoD(IDFoD, Name, IDCatagory, Price))
            {
                MessageBox.Show("Cập nhật món thành công !!!");
                LoadListFoD();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật món !!!");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int IDFoD = Convert.ToInt32(txtFoodID.Text);
            if (FoDDAO.Instance.DeleteFoD(IDFoD))
            {
                MessageBox.Show("Xoá món thành công !!!");
                LoadListFoD();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xoá món !!!");
            }
        }

        List<FoDDTO> FindFoDByName(string Name)
        {
            List<FoDDTO> listfod = FoDDAO.Instance.FindFoD(Name);
            return listfod;
        }

        private void btnFindFood_Click(object sender, EventArgs e)
        {
            FoodList.DataSource = FindFoDByName(txtFindFodName.Text);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmrAccountType.Value;

            if (AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thành công !!!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại !!!");
            }
            LoadAccount();

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if (loginAccount.Username.Equals(username))
            {
                MessageBox.Show("Vui lòng đóng úng dụng khi muốn xoá tài khoản này !!!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xoá tài khoản thành công !!!");
            }
            else
            {
                MessageBox.Show("Xoá tài khoản thất bại !!!");
            }
            LoadAccount();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmrAccountType.Value;

            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công !!!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại !!!");
            }
            LoadAccount();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            if (AccountDAO.Instance.ResetPass(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công !!!");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại !!!");
            }
            LoadAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
