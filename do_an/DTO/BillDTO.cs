using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class BillDTO
    {
        public BillDTO(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status, float totalprice, int discount)//chưa có total price
        {
            this.ID = id;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = dateCheckout;
            this.Status = status;
            this.TotalPrice = totalprice;
            this.Discount = discount;
        }

        public BillDTO(DataRow row)//chưa có total price
        {
            this.ID = (int)row["id"];
            this.DateCheckin = (DateTime?)row["ngayvaogiovao"];//error
            this.DateCheckout = string.IsNullOrEmpty(row["ngayragiora"].ToString()) ? (DateTime?)null : DateTime.Parse(row["ngayragiora"].ToString());//dấu ? là cho phép null
            this.Status = (int)row["tinhtrang"];
            this.TotalPrice =  float.Parse(row["tonggia"].ToString());
            this.Discount = (int)row["giamgia"];
        }

        private int ID;
        private DateTime? dateCheckin;  
        private DateTime? dateCheckout;
        private int status;
        private int discount;
        private float totalPrice;

        public int ID1 { get => ID; set => ID = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckout { get => dateCheckout; set => dateCheckout = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
