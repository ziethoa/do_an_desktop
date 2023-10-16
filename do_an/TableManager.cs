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
    public partial class TableManager : Form
    {
        public TableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCatagory();
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
                    btn.BackColor = Color.LightPink;
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
        private void btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as TableDTO).ID;
            lsvBills.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            TableDTO table = lsvBills.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)numDiscount.Value;
            if(idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán cho " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {//sửa tiếp + thêm phần giá tiền cho bàn
                    BillDAO.Instance.checkout(idBill, discount);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }
        }

       
    }
}
