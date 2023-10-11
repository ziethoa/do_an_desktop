using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class MenuDTO
    {
        public MenuDTO(string foodanddrinkname, int count, int price, int totalprice = 0)
        {
            this.FoodOrDrinkName = foodanddrinkname;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }
        public MenuDTO(DataRow row)
        {
            this.FoodOrDrinkName = row["tenhienthi"].ToString();
            this.Count = (int)row["count"];
            this.Price = (int)row["gia"];
            this.TotalPrice = (int)row["Tonggia"];
        }

        private string foodOrDrinkName;
        private int count;
        private int price;
        private int totalPrice;
        public string FoodOrDrinkName { get => foodOrDrinkName; set => foodOrDrinkName = value; }
        public int Count { get => count; set => count = value; }
        public int Price { get => price; set => price = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
