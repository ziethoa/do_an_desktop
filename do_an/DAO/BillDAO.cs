using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if(instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { instance = value; } 
        }
        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT* FROM Bill WHERE idTable = " + id +" AND tinhtrang = 1");
            if(data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID1;
            }
            return -1;
        }
        //thanh cong : bill id - that bai: -1
    }
}
