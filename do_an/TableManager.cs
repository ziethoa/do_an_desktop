using do_an.DAO;
using do_an.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace do_an
{
    public partial class TableManager : Form
    {
        private AccountDTO loginAccount;
        public AccountDTO LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }//ứng dụng tính đóng gói của lập trình hướng đối tượng
        }
        public TableManager(AccountDTO Acc)
        {
            InitializeComponent();
            this.LoginAccount = Acc;
            LoadTable();
            LoadCatagory();
        }
        private Stopwatch stopwatch = new Stopwatch();

        void ChangeAccount(int Type)
        {
            adminToolStripMenuItem.Enabled = Type == 1;
        }

        void LoadCatagory()
        {
            List<CatagoryDTO> ListCatagory = CatagoryDAO.Instance.GetListCatagory();
            cbCatagoryFoodOrDrink.DataSource = ListCatagory;
            cbCatagoryFoodOrDrink.DisplayMember = "Name";//phần Name bên DTO : cho biết rõ nó cần hiển thị trường nào trong database, nếu kh nó chỉ hiện tên của cả cái bảng
        }
        void LoadFoDListByCatagory(int id) 
        {
            List<FoDDTO> ListFoD = FoDDAO.Instance.GetFoodOrDrinkByCatagoryID(id);
            cbFoodOrDrink.DataSource = ListFoD;
            cbFoodOrDrink.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<TableDTO> TableList = TableDAO.Instance.LoadTableList();

            foreach(TableDTO item in TableList)
            {
                Button btn = new Button() {Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    btn.BackColor = Color.LightSalmon;
                }
                btn.ForeColor = Color.Black;    
                flpTable.Controls.Add(btn);
                
            }
        }
        void ShowBill(int id)
        {
            lsvBills.Items.Clear();
            List<MenuDTO> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            int TotalPriceAll = 0;
            foreach(MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodOrDrinkName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                TotalPriceAll += item.TotalPrice;
                lsvBills.Items.Add(lsvItem);
            }
            txtTotalPriceAll.Text = TotalPriceAll.ToString("c");
        }
        void resetForm()
        {
            cbCatagoryFoodOrDrink.Text = "-None-";
            cbFoodOrDrink.Text = "-None-";
            FoodAndDrinkCount.Value = 1;
            txtTimeStart.Text = " ";
            txtTimeFinish.Text = " ";
            numDiscount.Value = 0;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as TableDTO).ID;
            lsvBills.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }
        private void btnTimeStart_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            DateTime cutime = DateTime.Now;
            txtTimeStart.Text = cutime.ToString();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile f = new AccountProfile(LoginAccount);
            f.ShowDialog();
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin f = new Admin();
            f.loginAccount = loginAccount;
            f.ShowDialog();
        }

        private void cbCatagoryFoodOrDrink_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CatagoryDTO selected = cb.SelectedItem as CatagoryDTO;
            id = selected.ID;
            LoadFoDListByCatagory( id);
        }

        private void btnAddFoodOrDrink_Click(object sender, EventArgs e)
        {
            TableDTO table = lsvBills.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int idFood = (cbFoodOrDrink.SelectedItem as FoDDTO).ID;
            int count = (int)FoodAndDrinkCount.Value;
            if(idBill == -1)//bill chua ton tai, them bill
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), idFood, count);
            }
            else//bill da ton tai
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }
        private void btnAbate_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            float elapsedSeconds = (float)stopwatch.Elapsed.TotalSeconds;
            float elapsedHours = elapsedSeconds / 3600;

            DateTime cutime = DateTime.Now;
            txtTimeFinish.Text = cutime.ToString();

            TableDTO table = lsvBills.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)numDiscount.Value;

            float tableprice = elapsedHours * 70000;
            float totalPrice = Convert.ToSingle(txtTotalPriceAll.Text.Split(',')[0]);
            float finalTotalPrice = (tableprice - (tableprice/100 * discount)) + totalPrice;
            string text = finalTotalPrice.ToString();
            if (text.Contains(","))
            {
                text = text.Replace(",", ".");
                finalTotalPrice = float.Parse(text);
            }

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán cho {0}\nSố giờ: {5}\n( Tiền bàn - (Tiền bàn / 100) x giảm giá ) + Tiền đồ ăn\n==> ( {4} - ( {4} / 100) x {2} ) + {1} = {3} ", table.Name, totalPrice, discount, text, tableprice, elapsedHours), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.checkout(idBill, discount, text);
                    ShowBill(table.ID);

                    LoadTable();
                    resetForm();
                }
            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {

        }
    }
}
