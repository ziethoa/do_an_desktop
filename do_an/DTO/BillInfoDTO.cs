using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class BillInfoDTO
    {
        public BillInfoDTO(int id, int idbill, int idfoodordrink, int count)
        {
            this.ID = id;
            this.IDBill = idbill;
            this.IDFoodOrDrink = idfoodordrink;
            this.Count = count;
        }

        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBill = (int)row["idBill"];
            this.IDFoodOrDrink = (int)row["idFoodOrDrink"];
            this.Count = (int)row["count"];
        }

        private int iD;
        private int iDBill;
        private int iDFoodOrDrink;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFoodOrDrink { get => iDFoodOrDrink; set => iDFoodOrDrink = value; }
        public int Count { get => count; set => count = value; }
    }
}
