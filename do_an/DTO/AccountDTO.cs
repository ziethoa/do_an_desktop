using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string username, string displayname, string password, int type)
        {
            this.Username = username;
            this.Displayname = displayname;
            this.Password = password;
            this.Type = type;
        }
        public AccountDTO(DataRow row)
        {
            this.Username = row["tennguoidung"].ToString();
            this.Displayname = row["tenhienthi"].ToString();
            this.Password = row["matkhau"].ToString();
            this.Type = (int)row["loaitaikhoan"];
        }

        private string username;
        private string displayname;
        private string password;
        private int type;

        public string Username { get => username; set => username = value; }
        public string Displayname { get => displayname; set => displayname = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}
