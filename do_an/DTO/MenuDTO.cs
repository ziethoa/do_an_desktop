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
        public MenuDTO(string foodName, string drinkName, int countf, int countd,  float price, float totalPricef = 0, float totalPriced = 0)
        {
            this.FoodName = foodName;
            this.DrinkName = drinkName;
            this.Countf = countf;
            this.Countd = countd;
            this.Price = price;
            this.TotalPricef = totalPricef;
            this.TotalPriced = totalPriced;
        }
        public MenuDTO(DataRow row)
        {
            this.FoodName = row["Food.tenhienthi"].ToString();
            this.DrinkName = row["Drink.tenhienthi"].ToString();
            this.Countf = (int)row["countf"];
            this.Countd = (int)row["countd"];
            this.Price = (float)row["gia"];//thieu price f va d
            this.TotalPricef = (float)row["Tonggiaf"];
            this.TotalPriced = (float)row["Tonggiad"];
        }

        private float totalPriced;
        private float totalPricef;
        private float price;
        private int countf;
        private int countd;
        private string drinkName;
        private string foodName;

        public string FoodName { get => foodName; set => foodName = value; }
        public string DrinkName { get => drinkName; set => drinkName = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPricef { get => totalPricef; set => totalPricef = value; }
        public int Countf { get => countf; set => countf = value; }
        public int Countd { get => countd; set => countd = value; }
        public float TotalPriced { get => totalPriced; set => totalPriced = value; }
    }
}
