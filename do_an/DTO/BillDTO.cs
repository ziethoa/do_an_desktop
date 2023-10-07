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
        public BillDTO(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status)//chưa có total price
        {
            this.ID = id;
            this.DateCheckin = dateCheckin;
            this.DateCheckout = dateCheckout;
            this.Status = status;
        }

        public BillDTO(DataRow row)//chưa có total price
        {
            this.ID = (int)row["id"];
            this.DateCheckin = (DateTime?)row["dateCheckin"];//error
            this.DateCheckout = (DateTime?)row["dateCheckout"];
            this.Status = (int)row["status"];
        }

        private int ID;
        private DateTime? dateCheckin;
        private DateTime? dateCheckout;
        private int status;
        private int totalprice;

        public int ID1 { get => ID; set => ID = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckout { get => dateCheckout; set => dateCheckout = value; }
        public int Status { get => status; set => status = value; }
        public int Totalprice { get => totalprice; set => totalprice = value; }
    }
}
