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
using static SciDoc_Mgmt.frmDangNhap;

namespace SciDoc_Mgmt
{
    public partial class frmNhaKhoaHoc : Form
    {
        public frmNhaKhoaHoc()
        {
            InitializeComponent();
            LoadDatadtwVaiTro();
            ClearDataVaiTro();
            dropdownNhaKhoaHoc();
            LoadDataNhaKhoaHoc();
            ClearDataNhaKhoaHoc();
        }
        private void LoadDataNhaKhoaHoc()
        {
            try
            {
                // Chuỗi kết nối cơ sở dữ liệu
                string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";

                // Câu truy vấn với tham số
                string query = @"SELECT * FROM NHAKHOAHOC WHERE ID_TaiKhoan = @ID_TaiKhoan";

                // Kiểm tra giá trị của UserSession.ID_TaiKhoan
                if (UserSession.ID_TaiKhoan == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin ID_TaiKhoan. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo SqlCommand
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan); // Truyền giá trị tham số

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dtwNKH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dropdownNhaKhoaHoc()
        {
            // Thêm các mục vào ComboBox
            cbxLinhVuc.Items.Add("Khoa học tự nhiên");
            cbxLinhVuc.Items.Add("Khoa học kỹ thuật và công nghệ");
            cbxLinhVuc.Items.Add("Khoa học y, dược");
            cbxLinhVuc.Items.Add("Khoa học nông nghiệp");
            cbxLinhVuc.Items.Add("Khoa học xã hội");
            cbxLinhVuc.Items.Add("Khoa học nhân văn");

            cbxHocVi.Items.Add("Tiến sĩ");
            cbxHocVi.Items.Add("Thạc sĩ");
            cbxHocVi.Items.Add("Cử nhân");
            cbxHocVi.Items.Add("Kỹ sư");
            cbxHocVi.Items.Add("Bác sĩ");
        }
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void ClearDataVaiTro()
        {
            // Xóa dữ liệu trong các TextBox
            txtMaVaiTro.Clear();
            txtTenVaiTro.Clear();



            // Nếu có DateTimePicker, reset về giá trị mặc định (ngày hiện tại hoặc ngày mặc địn

            // Nếu có DataGridView, có thể bỏ lựa chọn (nếu đang chọn dòng)
            if (dtwVaiTro.SelectedRows.Count > 0)
            {
                dtwVaiTro.ClearSelection();
            }
        }
        private void LoadDatadtwVaiTro()
        {
            string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
            string query = "SELECT * FROM VAITRO";  // Câu truy vấn lấy tất cả dữ liệu từ bảng VAITRO

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Đổi tên cột trong DataTable
                dt.Columns["ID_VaiTro"].ColumnName = "Mã vai trò";
                dt.Columns["TenVaiTro"].ColumnName = "Tên vai trò";

                // Hiển thị dữ liệu vào DataGridView
                dtwVaiTro.DataSource = dt;
            }
        }

        private void btnThemVaiTro_Click(object sender, EventArgs e)
        {
            string maVaiTro = txtMaVaiTro.Text;
            string tenVaiTro = txtTenVaiTro.Text;

            if (string.IsNullOrEmpty(maVaiTro) || string.IsNullOrEmpty(tenVaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
            string query = "INSERT INTO VAITRO (ID_VaiTro, TenVaiTro) VALUES (@ID_VaiTro, @TenVaiTro)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_VaiTro", maVaiTro);
                    cmd.Parameters.AddWithValue("@TenVaiTro", tenVaiTro);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh
                    conn.Close();

                    MessageBox.Show("Thêm vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatadtwVaiTro();
                    ClearDataVaiTro();// Cập nhật lại DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaVaiTro_Click(object sender, EventArgs e)
        {
            string maVaiTro = txtMaVaiTro.Text;

            if (string.IsNullOrEmpty(maVaiTro))
            {
                MessageBox.Show("Vui lòng nhập mã vai trò cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
            string query = "DELETE FROM VAITRO WHERE ID_VaiTro = @ID_VaiTro";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_VaiTro", maVaiTro);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatadtwVaiTro();
                        ClearDataVaiTro();// Cập nhật lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy vai trò để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaVaiTro_Click(object sender, EventArgs e)
        {
            string maVaiTro = txtMaVaiTro.Text;
            string tenVaiTro = txtTenVaiTro.Text;

            if (string.IsNullOrEmpty(maVaiTro) || string.IsNullOrEmpty(tenVaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
            string query = "UPDATE VAITRO SET TenVaiTro = @TenVaiTro WHERE ID_VaiTro = @ID_VaiTro";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_VaiTro", maVaiTro);
                    cmd.Parameters.AddWithValue("@TenVaiTro", tenVaiTro);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatadtwVaiTro();
                        ClearDataVaiTro();// Cập nhật lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy vai trò để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtwVaiTro_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu là dòng hợp lệ
            {
                txtMaVaiTro.Text = dtwVaiTro.Rows[e.RowIndex].Cells["Mã vai trò"].Value.ToString();
                txtTenVaiTro.Text = dtwVaiTro.Rows[e.RowIndex].Cells["Tên vai trò"].Value.ToString();
            }
        }

        private void dtwVaiTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmNhaKhoaHoc_Load(object sender, EventArgs e)
        {

        }
        
        private void btnThemNKH_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển
                string maNhaKhoaHoc = txtMaNhaKhoaHoc.Text.Trim();
                string tenNhaKhoaHoc = txtTenNhaKhoaHoc.Text.Trim();
                string linhVuc = cbxLinhVuc.SelectedItem?.ToString(); // Lấy giá trị đã chọn trong ComboBox LinhVuc
                string hocVi = cbxHocVi.SelectedItem?.ToString();
                // Lấy giá trị đã chọn trong ComboBox VaiTro

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNhaKhoaHoc) || string.IsNullOrEmpty(tenNhaKhoaHoc) ||
                    string.IsNullOrEmpty(linhVuc) || string.IsNullOrEmpty(hocVi))
                // Kiểm tra xem TenVaiTro có được chọn không
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi kết nối cơ sở dữ liệu
                string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";

                // Câu truy vấn để thêm dữ liệu vào bảng NHAKHOAHOC
                string query = @"INSERT INTO NHAKHOAHOC (ID_NKH,  TenNhaKhoaHoc, HocVi, LinhVuc, ID_TaiKhoan)
                     VALUES (@ID_NhaKhoaHoc, @TenNhaKhoaHoc, @HocVi, @LinhVuc, @ID_TaiKhoan)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        cmd.Parameters.AddWithValue("@ID_NhaKhoaHoc", maNhaKhoaHoc);
                        // Lưu TenVaiTro vào bảng NHAKHOAHOC
                        cmd.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHoc);
                        cmd.Parameters.AddWithValue("@HocVi", hocVi);
                        cmd.Parameters.AddWithValue("@LinhVuc", linhVuc);
                        cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        // Kiểm tra kết quả
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nhà khoa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Gọi phương thức load lại dữ liệu nếu có DataGridView
                            LoadDataNhaKhoaHoc();
                            ClearDataNhaKhoaHoc();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm nhà khoa học. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSuaNKH_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các điều khiển
                string maNhaKhoaHoc = txtMaNhaKhoaHoc.Text.Trim();
                string tenNhaKhoaHoc = txtTenNhaKhoaHoc.Text.Trim();
                string linhVuc = cbxLinhVuc.SelectedItem?.ToString();
                string hocVi = cbxHocVi.SelectedItem?.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNhaKhoaHoc) || string.IsNullOrEmpty(tenNhaKhoaHoc) ||
                    string.IsNullOrEmpty(linhVuc) || string.IsNullOrEmpty(hocVi))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi kết nối cơ sở dữ liệu
                string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";

                // Câu truy vấn để sửa dữ liệu vào bảng NHAKHOAHOC
                string query = @"UPDATE NHAKHOAHOC
                         SET TenNhaKhoaHoc = @TenNhaKhoaHoc, HocVi = @HocVi, LinhVuc = @LinhVuc
                         WHERE ID_NKH = @ID_NKH";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        cmd.Parameters.AddWithValue("@ID_NKH", maNhaKhoaHoc);
                        cmd.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHoc);
                        cmd.Parameters.AddWithValue("@HocVi", hocVi);
                        cmd.Parameters.AddWithValue("@LinhVuc", linhVuc);

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        // Kiểm tra kết quả
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật nhà khoa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataNhaKhoaHoc(); 
                            // Tải lại dữ liệu sau khi sửa
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật nhà khoa học. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaNKH_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã nhà khoa học từ textbox
                string maNhaKhoaHoc = txtMaNhaKhoaHoc.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maNhaKhoaHoc))
                {
                    MessageBox.Show("Vui lòng chọn nhà khoa học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuỗi kết nối cơ sở dữ liệu
                string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";

                // Câu truy vấn để xóa dữ liệu vào bảng NHAKHOAHOC
                string query = @"DELETE FROM NHAKHOAHOC WHERE ID_NKH = @ID_NKH";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        cmd.Parameters.AddWithValue("@ID_NKH", maNhaKhoaHoc);

                        // Mở kết nối và thực thi câu lệnh
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        // Kiểm tra kết quả
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa nhà khoa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataNhaKhoaHoc();
                            ClearDataNhaKhoaHoc();// Tải lại dữ liệu sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa nhà khoa học. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ClearDataNhaKhoaHoc()
        {
            txtMaNhaKhoaHoc.Clear();
            txtTenNhaKhoaHoc.Clear();
            cbxLinhVuc.SelectedItem = null;
            cbxHocVi.SelectedItem = null;
        }

        private void dtwNKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtwNKH.Rows[e.RowIndex];

                // Điền dữ liệu vào các điều khiển khi người dùng chọn 1 dòng trong DataGridView
                txtMaNhaKhoaHoc.Text = row.Cells["ID_NKH"].Value.ToString();
                txtTenNhaKhoaHoc.Text = row.Cells["TenNhaKhoaHoc"].Value.ToString();
                cbxHocVi.SelectedItem = row.Cells["HocVi"].Value.ToString();
                cbxLinhVuc.SelectedItem = row.Cells["LinhVuc"].Value.ToString();
            }
        }
    }
}