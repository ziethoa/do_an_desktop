using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class CatagoryDAO
    {
        private static CatagoryDAO instance;

        public static CatagoryDAO Instance 
        {
            get { if (instance == null) instance = new CatagoryDAO(); return CatagoryDAO.instance; }
            private set { instance = value; } 
        }

        private CatagoryDAO() { }
        public List<CatagoryDTO> GetListCatagory()
        {
            List<CatagoryDTO> list = new List<CatagoryDTO>();

            string query = "USP_Catagory";//chua proc
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                CatagoryDTO catagory = new CatagoryDTO(item);
                list.Add(catagory);
            }

            return list;
        }
    }
}
