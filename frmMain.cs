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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            LoadDataTaiLieu();
            LoadDataTimKiem();
            dropdownChuyenNganh();
            LoadDataPhanLoai();
            dropdownNhaKhoaHoc();
            dropdownLoaiTaiLieu();
        }
        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        private Form currentChildForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnTaiLieuNCKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaiLieuNCKH());
        }

        private void btnNhaKhoaHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaKhoaHoc());
        }

        private void btnNhaXuatBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaXuatBan());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
        }

        private void btnHoiNghi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoiNghi());
        }

        private void btnCQCQ_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCoQuanChuQuan());
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            panelHeader.Hide();
            OpenChildForm(new frmMain());
        }
        private void LoadDataTaiLieu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra nếu UserSession.ID_TaiKhoan không hợp lệ
                    if (UserSession.ID_TaiKhoan == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy giá trị năm từ DateTimePicker
                    int selectedYear = dateSapXep.Value.Year;

                    // Câu lệnh SQL lọc theo năm và ID_TaiKhoan
                    string query = @"SELECT ID_TaiLieu as 'Mã tài liệu', 
                                MoTa as 'Mô tả', 
                                NamXuatBan as 'Năm xuất bản', 
                                LoaiTaiLieu as 'Loại tài liệu', 
                                ChuyenNganh as 'Chuyên ngành', 
                                NoiDung as 'Nội dung'  
                         FROM TAILIEU 
                         WHERE YEAR(NamXuatBan) = @NamXuatBan 
                           AND ID_TaiKhoan = @ID_TaiKhoan";

                    // Tạo SqlDataAdapter với tham số
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@NamXuatBan", selectedYear);
                    adapter.SelectCommand.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị dữ liệu trong DataGridView
                    dtwSapXep.DataSource = dt;

               
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dateSapXep_ValueChanged(object sender, EventArgs e)
            {
   
                LoadDataTaiLieu();
            }
        private void LoadDataTimKiem()
        {

            if (UserSession.ID_TaiKhoan == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Câu truy vấn có điều kiện dựa trên ID_TaiKhoan
            string query = @"SELECT ID_TaiLieu as 'Mã tài liệu', 
                            MoTa as 'Mô tả', 
                            NamXuatBan as 'Năm xuất bản', 
                            LoaiTaiLieu as 'Loại tài liệu', 
                            ChuyenNganh as 'Chuyên ngành', 
                            NoiDung as 'Nội dung' 
                     FROM TAILIEU 
                     WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Sử dụng SqlDataAdapter với tham số
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dtwTimKiem.DataSource = dt;

                    // Kiểm tra nếu không có dữ liệu
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có tài liệu nào phù hợp với tài khoản hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dropdownChuyenNganh()
        {
            // SQL query to get ChuyenNganh
            string query = "SELECT DISTINCT ChuyenNganh FROM TAILIEU";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a DataTable to hold the data
                    DataTable dt = new DataTable();

                    // Fill the DataTable with ChuyenNganh data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);

                    // Set the ComboBox DataSource
                    cbxChuyenNganh.DataSource = dt;
                    cbxChuyenNganh.DisplayMember = "ChuyenNganh"; // Cột hiển thị
                    cbxChuyenNganh.ValueMember = "ChuyenNganh";   // Giá trị cột

                    cbxChuyenNganhPL.DataSource = dt;
                    cbxChuyenNganhPL.DisplayMember = "ChuyenNganh"; // Cột hiển thị
                    cbxChuyenNganhPL.ValueMember = "ChuyenNganh";

                    // Optional: Select the first item by default
                    if (cbxChuyenNganh.Items.Count > 0)
                    {
                        cbxChuyenNganh.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void dropdownNhaKhoaHoc()
        {
            // SQL query to get TenNhaKhoaHoc based on ID_NKH in CHITIETTAILIEU
            string query = @"
        SELECT DISTINCT NHAKHOAHOC.TenNhaKhoaHoc
        FROM NHAKHOAHOC
        INNER JOIN CHITIETTAILIEU ON NHAKHOAHOC.ID_NKH = CHITIETTAILIEU.ID_NKH";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a DataTable to hold the data
                    DataTable dt = new DataTable();

                    // Fill the DataTable with filtered TenNhaKhoaHoc data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);

                    // Set the ComboBox DataSource
                    cbxNhaKhoaHocPL.DataSource = dt;
                    cbxNhaKhoaHocPL.DisplayMember = "TenNhaKhoaHoc"; // Cột hiển thị
                    cbxNhaKhoaHocPL.ValueMember = "TenNhaKhoaHoc";   // Giá trị cột

                    // Optional: Select the first item by default
                    if (cbxNhaKhoaHocPL.Items.Count > 0)
                    {
                        cbxNhaKhoaHocPL.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dropdownLoaiTaiLieu()
        {
            // SQL query to get ChuyenNganh
            string query = "SELECT DISTINCT LoaiTaiLieu FROM TAILIEU";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a DataTable to hold the data
                    DataTable dt = new DataTable();

                    // Fill the DataTable with ChuyenNganh data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);

                    // Set the ComboBox DataSource
                    cbxLoaiTaiLieuPL.DataSource = dt;
                    cbxLoaiTaiLieuPL.DisplayMember = "LoaiTaiLieu"; // Cột hiển thị
                    cbxLoaiTaiLieuPL.ValueMember = "LoaiTaiLieu";   // Giá trị cột



                    // Optional: Select the first item by default
                    if (cbxLoaiTaiLieuPL.Items.Count > 0)
                    {
                        cbxLoaiTaiLieuPL.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chưa chọn chuyên ngành
            if (cbxChuyenNganh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị chuyên ngành từ ComboBox
            string chuyenNganh = cbxChuyenNganh.SelectedValue.ToString();

            // Gọi hàm tìm kiếm
            SearchByChuyenNganh(chuyenNganh);
        }
        private void SearchByChuyenNganh(string chuyenNganh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra nếu UserSession.ID_TaiKhoan không hợp lệ
                    if (UserSession.ID_TaiKhoan == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Câu lệnh SQL tìm kiếm theo chuyên ngành và ID_TaiKhoan
                    string query = "SELECT * FROM TAILIEU WHERE ChuyenNganh = @ChuyenNganh AND ID_TaiKhoan = @ID_TaiKhoan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Thêm tham số vào câu lệnh SQL
                    adapter.SelectCommand.Parameters.AddWithValue("@ChuyenNganh", chuyenNganh);
                    adapter.SelectCommand.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu tìm kiếm vào DataGridView
                    dtwTimKiem.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài liệu nào thuộc chuyên ngành này cho tài khoản hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataPhanLoai()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Khởi tạo câu truy vấn SQL cơ bản
                    string query = @"
                SELECT 
                    TAILIEU.ID_TaiLieu,
                    TAILIEU.MoTa,
                    TAILIEU.NamXuatBan,
                    TAILIEU.LoaiTaiLieu,
                    TAILIEU.ChuyenNganh,
                    TAILIEU.NoiDung,
                    NHAKHOAHOC.TenNhaKhoaHoc,
                    VAITRO.TenVaiTro
                FROM 
                    CHITIETTAILIEU
                INNER JOIN TAILIEU ON CHITIETTAILIEU.ID_TaiLieu = TAILIEU.ID_TaiLieu
                INNER JOIN NHAKHOAHOC ON CHITIETTAILIEU.ID_NKH = NHAKHOAHOC.ID_NKH
                INNER JOIN VAITRO ON CHITIETTAILIEU.ID_VaiTro = VAITRO.ID_VaiTro
                WHERE 1=1"; // Điều kiện "WHERE 1=1" để dễ dàng thêm các điều kiện sau

                    // Thêm điều kiện vào câu truy vấn dựa trên giá trị chọn từ các ComboBox
                    if (cbxChuyenNganh.SelectedValue != null && !string.IsNullOrEmpty(cbxChuyenNganh.SelectedValue.ToString()))
                    {
                        query += " AND TAILIEU.ChuyenNganh = @ChuyenNganh";
                    }

                    if (cbxNhaKhoaHocPL.SelectedValue != null && !string.IsNullOrEmpty(cbxNhaKhoaHocPL.SelectedValue.ToString()))
                    {
                        query += " AND NHAKHOAHOC.TenNhaKhoaHoc = @TenNhaKhoaHoc";
                    }

                    if (cbxLoaiTaiLieuPL.SelectedValue != null && !string.IsNullOrEmpty(cbxLoaiTaiLieuPL.SelectedValue.ToString()))
                    {
                        query += " AND TAILIEU.LoaiTaiLieu = @LoaiTaiLieu";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Thêm các tham số vào câu truy vấn
                    if (cbxChuyenNganh.SelectedValue != null && !string.IsNullOrEmpty(cbxChuyenNganh.SelectedValue.ToString()))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@ChuyenNganh", cbxChuyenNganh.SelectedValue.ToString());
                    }

                    if (cbxNhaKhoaHocPL.SelectedValue != null && !string.IsNullOrEmpty(cbxNhaKhoaHocPL.SelectedValue.ToString()))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@TenNhaKhoaHoc", cbxNhaKhoaHocPL.SelectedValue.ToString());
                    }

                    if (cbxLoaiTaiLieuPL.SelectedValue != null && !string.IsNullOrEmpty(cbxLoaiTaiLieuPL.SelectedValue.ToString()))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@LoaiTaiLieu", cbxLoaiTaiLieuPL.SelectedValue.ToString());
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gắn dữ liệu vào DataGridView
                    dtwPhanLoai.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtwPhanLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ComboBox có giá trị hợp lệ hay không
            if (cbxChuyenNganh.SelectedValue == null || string.IsNullOrEmpty(cbxChuyenNganh.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành để phân loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxNhaKhoaHocPL.SelectedValue == null || string.IsNullOrEmpty(cbxNhaKhoaHocPL.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn nhà khoa học để phân loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxLoaiTaiLieuPL.SelectedValue == null || string.IsNullOrEmpty(cbxLoaiTaiLieuPL.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại tài liệu để phân loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức phân loại và tải dữ liệu
            LoadDataPhanLoai();
        }
        
    }
}
