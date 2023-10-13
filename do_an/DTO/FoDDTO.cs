using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class FoDDTO
    {
        public FoDDTO(int id, string name, int idcatagory, int price)
        {
            this.ID = id;
            this.Name = name;
            this.IdCatagory = idcatagory;
            this.Price = price;
        }
        public FoDDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["tenhienthi"].ToString();
            this.IdCatagory = (int)row["idCatagory"];
            this.Price = (int)row["gia"];
        }

        private int iD;
        private string name;
        private int idCatagory;
        private int price;


        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IdCatagory { get => idCatagory; set => idCatagory = value; }
        public int Price { get => price; set => price = value; }
    }
}
