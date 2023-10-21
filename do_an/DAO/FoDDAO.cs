using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class FoDDAO
    {
        private static FoDDAO instance;

        public static FoDDAO Instance 
        {
            get { if (instance == null) instance = new FoDDAO(); return FoDDAO.instance; }
            private set { instance = value; }
        }
        private FoDDAO() { }

        public List<FoDDTO> GetFoodOrDrinkByCatagoryID (int id)
        {
            List<FoDDTO> list = new List<FoDDTO>();
            string query = "EXEC USP_FoD @idcatagory = " + id;
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                FoDDTO FoD = new FoDDTO(item);
                list.Add(FoD);
            }

            return list;
        }

        public List<FoDDTO> GetListFoD()
        {
            List<FoDDTO> list = new List<FoDDTO>();
            string query = "SELECT* FROM FoodAndDrink";
            DataTable data = Dataprovider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoDDTO FoD = new FoDDTO(item);
                list.Add(FoD);
            }

            return list;
        }
    }
}
