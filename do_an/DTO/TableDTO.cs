using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class TableDTO
    {
        private int iD;
        private string name;
        private string status;
        private int price;

        public TableDTO(int id, string name, string status, int price)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Price = price;
        }

        public TableDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["ten"].ToString();
            this.Status = row["tinhtrang"].ToString();
            this.Price = (int)row["gia"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int Price { get => price; set => price = value; }
    }
}
