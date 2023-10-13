using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class CatagoryDTO
    {
        public CatagoryDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["tenhienthi"].ToString();
        }
        public CatagoryDTO(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
