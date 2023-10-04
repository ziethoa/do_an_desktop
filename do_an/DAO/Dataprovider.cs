using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an.DAO
{
    class Dataprovider
    {
        private string connectionSTR = @"Data Source=MSI\HOA;Initial Catalog=QuanLyQuanBida;Integrated Security=True";//tạo kết nối database tới ai
        public DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);// connection là cầu nối từ client xuống server(hiểu được giản là từ sql server về code cs)

            connection.Open();//cần phải mở ra thì mới thực hiện lệnh fill bên dưới

            SqlCommand command = new SqlCommand(query, connection);//tạo 1 cái comment để chạy câu truy vấn.

            DataTable data = new DataTable();//tạo bảng chứa data từ database

            SqlDataAdapter adapter = new SqlDataAdapter(command);//adapter là thằng trung gian thực hiện câu truy vấn

            adapter.Fill(data);

            connection.Close();//mở ra phải đóng lại tránh trường hợp mở ra nhiều qua sẽ bị lỗi

            
        }
    }
}
