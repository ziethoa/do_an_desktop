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
        public DataTable GetListAccount()
        {
            return Dataprovider.Instance.ExecuteQuery("SELECT tenhienthi AS N'Displayname', tennguoidung AS N'Username', loaitaikhoan AS N'Type' FROM Account");
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

        public bool InsertAccount(string username, string displayname, int type)
        {
            string query = string.Format("INSERT INTO Account (tennguoidung, tenhienthi, loaitaikhoan ) VALUES ( N'{0}', N'{1}' , {2})", username, displayname, type);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("UPDATE Account SET tenhienthi = N'{1}', loaitaikhoan = {2} WHERE tennguoidung = N'{0}'", username, displayname, type);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("DELETE FROM Account WHERE tennguoidung = N'{0}'", username);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPass(string username)
        {
            string query = string.Format("UPDATE Account SET matkhau = N'0' WHERE tennguoidung = N'{0}'", username);
            int result = Dataprovider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
