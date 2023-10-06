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
        private static Dataprovider instance;
        internal static Dataprovider Instance
        {
            get { if (instance == null) instance = new Dataprovider(); return Dataprovider.instance; }
            private set { Dataprovider.instance = value; }//chỉ nội bộ trong class đc set

        }

        private Dataprovider() {}

        private string connectionSTR = @"Data Source=MSI\HOA;Initial Catalog=QuanLyQuanBida;Integrated Security=True";//tạo kết nối database tới ai

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();//tạo bảng chứa data từ database
            using (SqlConnection connection = new SqlConnection(connectionSTR))// connection là cầu nối từ client xuống server(hiểu được giản là từ sql server về code cs)
            {
                connection.Open();//cần phải mở ra thì mới thực hiện lệnh fill bên dưới

                SqlCommand command = new SqlCommand(query, connection);//tạo 1 cái comment để chạy câu truy vấn.

                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);//adapter là thằng trung gian thực hiện câu truy vấn

                adapter.Fill(data);

                connection.Close();//mở ra phải đóng lại tránh trường hợp mở ra nhiều qua sẽ bị lỗi
                //sử dụng using cho dù vấn đề gì xảy ra thì các dữ liệu đc khai báo sẽ đc giải phóng
            } 
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)//số dòng thành công khi insert dữ liệu vào
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))// connection là cầu nối từ client xuống server(hiểu được giản là từ sql server về code cs)
            {
                connection.Open();//cần phải mở ra thì mới thực hiện lệnh fill bên dưới

                SqlCommand command = new SqlCommand(query, connection);//tạo 1 cái comment để chạy câu truy vấn.

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();

                connection.Close();//mở ra phải đóng lại tránh trường hợp mở ra nhiều qua sẽ bị lỗi
                //sử dụng using cho dù vấn đề gì xảy ra thì các dữ liệu đc khai báo sẽ đc giải phóng
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)//đếm số lượng dòng thành công
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))// connection là cầu nối từ client xuống server(hiểu được giản là từ sql server về code cs)
            {
                connection.Open();//cần phải mở ra thì mới thực hiện lệnh fill bên dưới

                SqlCommand command = new SqlCommand(query, connection);//tạo 1 cái comment để chạy câu truy vấn.

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();

                connection.Close();//mở ra phải đóng lại tránh trường hợp mở ra nhiều qua sẽ bị lỗi
                //sử dụng using cho dù vấn đề gì xảy ra thì các dữ liệu đc khai báo sẽ đc giải phóng
            }
            return data;
        }
    }
}
