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
        public Admin()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dtgvFood.DataSource = FoodList;

            LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePicker();
            LoadListFoD();
            LoadCatagory(cbFoodCatagory);
            AddFoDBinding();
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

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListViewByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        void LoadListFoD()
        {
            FoodList.DataSource = FoDDAO.Instance.GetListFoD();
        }
        //sử dụng binding: khi 2 thằng binding lẫn nhau thì thằng này thay đổi thằng kia thay đổi theo tuỳ theo mode tạo ra
        void AddFoDBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name"));//từ cái txtFoodName hãy thay đổi giá trị text(thuộc tính của text) bằng cái giá trị name(thuộc tính của name) nằm trong cái datasource
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID"));
            nmrFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price"));
        }
        void LoadCatagory(ComboBox cb)
        {
            cb.DataSource = CatagoryDAO.Instance.GetListCatagory();
            cb.DisplayMember = "Name";
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFoD();
        }

        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IdCatagory"].Value;//cách lấy ra 1 cell bất kì trong dtgv
                CatagoryDTO catagory = CatagoryDAO.Instance.GetCatagoryByID(id);
                cbFoodCatagory.SelectedItem = catagory;
                int index = -1;
                int i = 0;
                foreach (CatagoryDTO item in cbFoodCatagory.Items )
                {
                    if(item.ID == catagory.ID )
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodCatagory.SelectedIndex = index;
            }
        }
    }
}
