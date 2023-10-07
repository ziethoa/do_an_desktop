using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get { if(instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { instance = value; }
        }
        private BillInfoDAO() { }

        public List<BillInfoDTO> GetListBillInfo(int id)//id cua bill
        {
            List<BillInfoDTO> listBillInfo = new List<BillInfoDTO>();

            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT* FROM BillInfo WHERE idBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                BillInfoDTO info = new BillInfoDTO(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
    }
}
