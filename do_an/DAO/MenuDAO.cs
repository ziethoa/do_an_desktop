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

            string query = "EXEC USP_BillInfos @IdTable  ";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query, new object[] { id});
            foreach (DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                ListMenu.Add(menu);
            }

            return ListMenu;
        }
    }
}
