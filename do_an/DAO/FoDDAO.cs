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
        public bool InsertFoD(string name, int idcata, float price)
        {
            string query = string.Format("INSERT INTO FoodAndDrink (tenhienthi, idCatagory, gia) VALUES ( N'{0}', {1} , {2})", name, idcata, price);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFoD(int idFoD, string name, int idcata, float price)
        {
            string query = string.Format("UPDATE FoodAndDrink SET tenhienthi = N'{0}', idCatagory = {1}, gia = {2} WHERE id = {3}", name, idcata, price, idFoD);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFoD(int idFoD)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFoD);
            string query = string.Format("DELETE FROM FoodAndDrink WHERE id = {0}", idFoD);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<FoDDTO> FindFoD(string name)
        {
            List<FoDDTO> list = new List<FoDDTO>();
            string query = string.Format("SELECT* FROM FoodAndDrink WHERE tenhienthi like N'%{0}%'", name );
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
