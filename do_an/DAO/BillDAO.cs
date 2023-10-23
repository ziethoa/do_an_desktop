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
            string query = "SELECT* FROM Bill WHERE idTable = " + id + " AND tinhtrang = 0" ;
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID1;
            }
            return -1;
        }
        public List<BillDTO> GetListBillByTableID(int id)//id cua bill
        {
            List<BillDTO> listBill = new List<BillDTO>();

            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT* FROM Bill WHERE id = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillDTO info = new BillDTO(item);
                listBill.Add(info);
            }

            return listBill;
        }
        //thanh cong : bill id - that bai: -1

        public void checkout(int id, int discount, string TotalPrice)
        {
            string query = "UPDATE Bill SET ngayragiora = GETDATE() , tinhtrang = 1 " + " , giamgia = " + discount + " , tonggia = " + TotalPrice + " WHERE id = " + id;
            Dataprovider.Instance.ExecuteNonQuery(query);//ddang lam cho nay
        }

        public void InsertBill(int id)
        {
            Dataprovider.Instance.ExecuteQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime CheckIn, DateTime CheckOut)
        {
           return Dataprovider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkin , @checkout", new object[] { CheckIn , CheckOut});
        }
        public int GetMaxIdBill()
        {
            try
            {
                return (int)Dataprovider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
