using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance 
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }

        public List<MenuDTO> GetListMenuByTable(int id)
        {
            List<MenuDTO> ListMenu = new List<MenuDTO>();

            string query = "SELECT Food.tenhienthi, BillInfo.countf, Food.gia, BillInfo.countf*Food.gia AS 'Tonggiaf', Drink.tenhienthi, BillInfo.countd, Drink.gia, BillInfo.countd*Drink.gia AS 'Tonggiad'  FROM BillInfo, Bill, Food, Drink WHERE BillInfo.idBill = Bill.id AND BillInfo.idFood = Food.id AND BillInfo.idDrink = Drink.id AND Bill.idTable = " + id;
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                ListMenu.Add(menu);
            }

            return ListMenu;
        }
    }
}
