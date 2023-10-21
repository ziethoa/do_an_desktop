using do_an.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if(instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; } 
        }

        private AccountDAO() { }

        public bool login(string username, string password)
        {
            string query = "EXEC USP_Login @userName , @passWord";
            DataTable result = Dataprovider.Instance.ExecuteQuery(query, new object[] { username, password});

            return result.Rows.Count > 0 ;
        }
        public bool UpdateAccount(string username, string displayname, string pass, string newpass)
        {
            int result = Dataprovider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @username , @displayname , @password , @newpassword ", new object[] { username, displayname, pass, newpass });
            return result > 0; //vì nó thực hiện update nên phải dùng int 
        }

        public AccountDTO GetAccountByUserName(string Username)
        {
            DataTable data = Dataprovider.Instance.ExecuteQuery("SELECT* FROM Account WHERE tennguoidung = '" + Username + "'");

            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }
            return null;
        }
    }
}
