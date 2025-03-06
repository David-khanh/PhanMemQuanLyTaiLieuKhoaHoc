using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciDoc_Mgmt
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static class UserSession
        {
            public static int ID_TaiKhoan; // Biến lưu ID_TaiKhoan của người dùng đã đăng nhập
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True";
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID_TaiKhoan FROM TAIKHOAN WHERE TenTaiKhoan = @TenTaiKhoan AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Lưu ID_TaiKhoan vào biến toàn cục
                    UserSession.ID_TaiKhoan = reader.GetInt32(0);
                    MessageBox.Show("Đăng nhập thành công!");

                    // Mở giao diện quản lý tài liệu
                    frmMain formMain = new frmMain();
                    formMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
