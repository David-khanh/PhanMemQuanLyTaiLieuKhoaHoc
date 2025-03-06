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
    public partial class frmNhaXuatBan : Form
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
            ClearData();
            LoadDataNXB();
        }
        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtMaNhaXuatBan.Text) || string.IsNullOrEmpty(txtTenNhaXuatBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ TextBox
            string maNXB = txtMaNhaXuatBan.Text;
            string tenNXB = txtTenNhaXuatBan.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn thêm dữ liệu
                    string query = "INSERT INTO NHAXUATBAN (ID_NhaXuatBan, TenNhaXuatBan) VALUES (@ID_NhaXuatBan, @TenNhaXuatBan)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_NhaXuatBan", maNXB);
                        cmd.Parameters.AddWithValue("@TenNhaXuatBan", tenNXB);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData(); // Clear form sau khi thêm
                        LoadDataNXB(); // Load lại dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtMaNhaXuatBan.Text) || string.IsNullOrEmpty(txtTenNhaXuatBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ TextBox
            string maNXB = txtMaNhaXuatBan.Text;
            string tenNXB = txtTenNhaXuatBan.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn sửa dữ liệu
                    string query = "UPDATE NHAXUATBAN SET TenNhaXuatBan = @TenNhaXuatBan WHERE ID_NhaXuatBan = @ID_NhaXuatBan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_NhaXuatBan", maNXB);
                        cmd.Parameters.AddWithValue("@TenNhaXuatBan", tenNXB);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearData();
                            LoadDataNXB();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhà xuất bản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtMaNhaXuatBan.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhà xuất bản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ TextBox
            string maNXB = txtMaNhaXuatBan.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn xóa dữ liệu
                    string query = "DELETE FROM NHAXUATBAN WHERE ID_NhaXuatBan = @ID_NhaXuatBan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_NhaXuatBan", maNXB);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearData();
                            LoadDataNXB();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhà xuất bản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataNXB()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn lấy dữ liệu
                    string query = "SELECT ID_NhaXuatBan AS 'Mã Nhà Xuất Bản', TenNhaXuatBan AS 'Tên Nhà Xuất Bản' FROM NHAXUATBAN";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dtwNXB.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearData()
        {
            txtMaNhaXuatBan.Clear();
            txtTenNhaXuatBan.Clear();
        }

        private void dtwNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem có phải click vào một hàng hợp lệ không
                if (e.RowIndex >= 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow row = dtwNXB.Rows[e.RowIndex];

                    // Gán dữ liệu vào TextBox
                    txtMaNhaXuatBan.Text = row.Cells["Mã Nhà Xuất Bản"].Value.ToString();
                    txtTenNhaXuatBan.Text = row.Cells["Tên Nhà Xuất Bản"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
