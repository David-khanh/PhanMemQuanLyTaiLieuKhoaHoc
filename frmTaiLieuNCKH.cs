using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Collections;
using DocumentFormat.OpenXml.Office.Word;
using static SciDoc_Mgmt.frmDangNhap;
namespace SciDoc_Mgmt
{
    public partial class frmTaiLieuNCKH : Form
    {

        public frmTaiLieuNCKH()
        {
            InitializeComponent();
            LoadComboBoxNhaXuatBanKY();
            LoadComboBoxHoiNghiKY();
            LoadComboBoxMaTaiLieuKY();
            LoadComboBoxNhaKhoaHocKY();
            LoadComboBoxVaiTroKY();
            dropdownLoaiTaiLieu();
            ResetFormTaiLieu();
            LoadDatadtwBaiBao();
            dropdownTenVaiTro();
            dropdownTenNhaKhoaHoc();
            ClearDataBaiBao();
            LoadDatadtwDeTai();
            dropdownTenNhaKhoaHocDT();
            dropdownVaiTroNhaKhoaHocDT();
            dropdownCQCQDT();
            ClearDataDeTai();
            LoadDatadtwGiaoTrinh();
            dropdownMaTaiLieuDT();
            dropdownMaTaiLieuBB();
            LoadCoQuanChuQuanToComboBox();
            dropdownMaTaiLieuGT();
            LoadDataTaiLieu();
            LoadDataKyYeu();
            LoadDataTapChi();
            LoadComboBoxCQCQTC();
            LoadComboBoxMaTaiLieuTC();
            LoadComboBoxNhaKhoaHocTC();
            LoadComboBoxNhaXuatBanTC();
            LoadComboBoxVaiTroTC();
            ClearDataGiaoTrinh();
            dropdownTenNhaKhoaHocGT();

        }

        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        private void LoadDataTaiLieu()
        {

            // Câu truy vấn với điều kiện lọc theo ID_TaiKhoan
            string query = "SELECT ID_TaiLieu as 'Mã tài liệu', MoTa as 'Mô tả', NamXuatBan as 'Năm xuất bản', " +
                           "LoaiTaiLieu as 'Loại tài liệu', ChuyenNganh as 'Chuyên ngành', NoiDung as 'Nội dung' " +
                           "FROM TAILIEU WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Tạo SqlCommand và thêm tham số
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan); // Lấy ID_TaiKhoan từ session

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dgvTaiLieu.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dropdownMaTaiLieuBB()
        {
            string query = "SELECT MoTa FROM TAILIEU WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Kiểm tra nếu UserSession.ID_TaiKhoan không hợp lệ
                    if (UserSession.ID_TaiKhoan == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    // Truyền tham số ID_TaiKhoan từ UserSession
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    SqlDataReader reader = command.ExecuteReader();

                    cbxIDTaiLieuBB.Items.Clear(); // Xóa dữ liệu cũ trong dropdown
                    while (reader.Read())
                    {
                        cbxIDTaiLieuBB.Items.Add(reader["MoTa"].ToString());
                    }

                    // Chọn mục đầu tiên nếu có dữ liệu
                    if (cbxIDTaiLieuBB.Items.Count > 0)
                    {
                        cbxIDTaiLieuBB.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài liệu nào thuộc tài khoản hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dropdownCQCQDT()
        {
            // SQL query to get TenNhaKhoaHoc
            string query = "SELECT TenCoQuanChuQuan FROM COQUANCHUQUAN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command
                    SqlCommand command = new SqlCommand(query, connection);

                    // Execute the command and read data
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear the ComboBox before loading
                    cbxCQCQDT.Items.Clear();

                    // Loop through the results and add them to the ComboBox
                    while (reader.Read())
                    {
                        cbxCQCQDT.Items.Add(reader["TenCoQuanChuQuan"].ToString());
                    }

                    // Optional: Select the first item by default
                    if (cbxCQCQDT.Items.Count > 0)
                    {
                        cbxCQCQDT.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void dropdownVaiTroNhaKhoaHocDT()
        {
            // Define your database connection string


            // SQL query to get TenNhaKhoaHoc
            string query = "SELECT TenVaiTro FROM VAITRO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command
                    SqlCommand command = new SqlCommand(query, connection);

                    // Execute the command and read data
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear the ComboBox before loading
                    cbxVaiTroDT.Items.Clear();

                    // Loop through the results and add them to the ComboBox
                    while (reader.Read())
                    {
                        cbxVaiTroDT.Items.Add(reader["TenVaiTro"].ToString());
                    }

                    // Optional: Select the first item by default
                    if (cbxVaiTroDT.Items.Count > 0)
                    {
                        cbxVaiTroDT.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void dropdownTenNhaKhoaHocDT()
        {

            string query = "SELECT TenNhaKhoaHoc FROM NHAKHOAHOC WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Kiểm tra nếu UserSession.ID_TaiKhoan không hợp lệ
                    if (UserSession.ID_TaiKhoan == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Mở kết nối
                    connection.Open();

                    // Tạo câu lệnh SQL
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thêm tham số ID_TaiKhoan từ UserSession
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Thực thi lệnh SQL và đọc dữ liệu
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa dữ liệu cũ trong ComboBox trước khi thêm mới
                    cbxTenNKHDT.Items.Clear();

                    // Lặp qua kết quả và thêm vào ComboBox
                    while (reader.Read())
                    {
                        cbxTenNKHDT.Items.Add(reader["TenNhaKhoaHoc"].ToString());
                    }

                    // Tùy chọn: Chọn mục đầu tiên nếu có dữ liệu
                    if (cbxTenNKHDT.Items.Count > 0)
                    {
                        cbxTenNKHDT.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà khoa học nào thuộc tài khoản hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dropdownLoaiTaiLieu()
        {
            // Thêm các mục vào ComboBox

            cbxCapDeTai.Items.Add("Cấp khoa");
            cbxCapDeTai.Items.Add("Cấp trường");
            cbxCapDeTai.Items.Add("Cấp thành phố");
            cbxCapDeTai.Items.Add("Cấp trung ương");

            cbxChuyenNganh.Items.Add("Khoa học tự nhiên");
            cbxChuyenNganh.Items.Add("Khoa học kỹ thuật, công nghệ");
            cbxChuyenNganh.Items.Add("Khoa học y, dược");
            cbxChuyenNganh.Items.Add("Khoa học nông nghiệp");
            cbxChuyenNganh.Items.Add("Khoa học xã hội");
            cbxChuyenNganh.Items.Add("Khoa học nhân văn");

            cbxLoaiTaiLieu.Items.Add("Bài báo nghiên cứu khoa học");
            cbxLoaiTaiLieu.Items.Add("Đề tài nghiên cứu khoa học");
            cbxLoaiTaiLieu.Items.Add("Kỷ yếu");
            cbxLoaiTaiLieu.Items.Add("Giáo trình");
            cbxLoaiTaiLieu.Items.Add("Tạp chí");


        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtwTaiLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void dtwBaiBao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void LoadDatadtwDeTai()
        {
            try
            {
                // Truy vấn SQL
                string query = @"
                    WITH CTE AS (
                        SELECT 
                            D.ID_DeTaiNCKH AS IDDeTai,
                            D.TenDeTai AS TenDeTai,
                            D.CapDeTai AS CapDeTai,
                            D.LinhVucDeTai AS LinhVuc,
                            D.NoiDang AS NoiDang,
                            T.NamXuatBan AS NamXuatBan,
                            T.MoTa AS MoTa,
                            C.TenCoQuanChuQuan AS TenCoQuanChuQuan,
                            V.TenVaiTro AS VaiTro,
                            N.TenNhaKhoaHoc AS NhaKhoaHoc,
                            D.ID_TaiLieu AS IDTaiLieu,
                            CT.ID_CTTaiLieu AS IDCTTaiLieu,
                            ROW_NUMBER() OVER (
                                PARTITION BY CT.ID_CTTaiLieu 
                                ORDER BY CT.ID_CTTaiLieu
                            ) AS RowNum
                        FROM 
                            DETAINCKH D
                        LEFT JOIN 
                            TAILIEU T ON D.ID_TaiLieu = T.ID_TaiLieu
                        LEFT JOIN 
                            COQUANCHUQUAN C ON D.ID_CoQuanChuQuan = C.ID_CoQuanChuQuan
                        LEFT JOIN 
                            CHITIETTAILIEU CT ON T.ID_TaiLieu = CT.ID_TaiLieu
                        LEFT JOIN 
                            VAITRO V ON CT.ID_VaiTro = V.ID_VaiTro
                        LEFT JOIN 
                            NHAKHOAHOC N ON CT.ID_NKH = N.ID_NKH
                        WHERE 
                            T.ID_TaiKhoan = @ID_TaiKhoan -- Lọc theo UserSession.ID_TaiKhoan
                    )
                    SELECT 
                        IDDeTai AS 'Mã đề tài',
                        TenDeTai AS 'Tên đề tài',
                        CapDeTai AS 'Cấp đề tài',
                        LinhVuc AS 'Lĩnh vực',
                        NoiDang AS 'Nơi đăng',
                        NamXuatBan AS 'Năm xuất bản',
                        MoTa AS 'Mô tả tài liệu',
                        TenCoQuanChuQuan AS 'Cơ quan chủ quản',
                        VaiTro AS 'Vai trò',
                        NhaKhoaHoc AS 'Tên nhà khoa học',
                        IDTaiLieu AS 'Mã tài liệu',
                        IDCTTaiLieu AS 'Mã CT tài liệu'
                    FROM 
                        CTE
                    WHERE 
                        RowNum = 1
                    ORDER BY 
                        IDCTTaiLieu;
                ";

                // Kiểm tra nếu UserSession.ID_TaiKhoan không hợp lệ
                if (UserSession.ID_TaiKhoan == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kết nối tới cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo SqlCommand và thêm tham số
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Tạo SqlDataAdapter để thực thi truy vấn
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Đổ dữ liệu vào DataTable
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gắn DataSource cho DataGridView
                    dtwDeTai.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadDatadtwBaiBao()
        {
            try
            {
                // Truy vấn SQL có lọc dữ liệu theo UserSession
                string query = @"
                    WITH CTE AS (
                        SELECT 
                            BAIBAO.ID_BaiBao AS IDBaiBao,
                            BAIBAO.TenBaiBao AS TenBaiBao,
                            BAIBAO.NuocDangTai AS NuocDangTai,
                            BAIBAO.TomTat AS TomTat,
                            BAIBAO.TuKhoa AS TuKhoa,
                            BAIBAO.NoiDang AS NoiDang,
                            TAILIEU.ChuyenNganh AS ChuyenNganh,
                            TAILIEU.MoTa AS MoTaTaiLieu,
                            TAILIEU.NamXuatBan AS NamXuatBan,
                            NHAKHOAHOC.TenNhaKhoaHoc AS TenNhaKhoaHoc,
                            VAITRO.TenVaiTro AS TenVaiTro,
                            BAIBAO.ID_TaiLieu AS IDTaiLieu,
                            CHITIETTAILIEU.ID_CTTaiLieu AS IDCTTaiLieu,
                            ROW_NUMBER() OVER (
                                PARTITION BY CHITIETTAILIEU.ID_CTTaiLieu 
                                ORDER BY CHITIETTAILIEU.ID_CTTaiLieu
                            ) AS RowNumChiTiet
                        FROM 
                            BAIBAO
                        LEFT JOIN 
                            TAILIEU ON BAIBAO.ID_TaiLieu = TAILIEU.ID_TaiLieu
                        LEFT JOIN 
                            CHITIETTAILIEU ON TAILIEU.ID_TaiLieu = CHITIETTAILIEU.ID_TaiLieu
                        LEFT JOIN 
                            NHAKHOAHOC ON CHITIETTAILIEU.ID_NKH = NHAKHOAHOC.ID_NKH
                        LEFT JOIN 
                            VAITRO ON CHITIETTAILIEU.ID_VaiTro = VAITRO.ID_VaiTro
                        WHERE 
                            TAILIEU.ID_TaiKhoan = @ID_TaiKhoan -- Lọc theo ID_TaiKhoan
                    )
                    SELECT DISTINCT
                        IDBaiBao AS 'Mã bài báo',
                        TenBaiBao AS 'Tên bài báo',
                        NuocDangTai AS 'Nước đăng tải',
                        TomTat AS 'Tóm tắt',
                        TuKhoa AS 'Từ khóa',
                        NoiDang AS 'Nơi đăng',
                        ChuyenNganh AS 'Chuyên ngành',
                        MoTaTaiLieu AS 'Mô tả tài liệu',
                        NamXuatBan AS 'Năm xuất bản',
                        TenNhaKhoaHoc AS 'Tên nhà khoa học',
                        TenVaiTro AS 'Vai trò',
                        IDTaiLieu AS 'Mã tài liệu',
                        IDCTTaiLieu AS 'Mã CT tài liệu'
                    FROM 
                        CTE
                    WHERE 
                        RowNumChiTiet = 1
                    ORDER BY 
                        IDBaiBao;
                ";

                // Kiểm tra nếu UserSession không có ID_TaiKhoan hợp lệ
                if (UserSession.ID_TaiKhoan == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kết nối cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo SqlCommand và thêm tham số
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Sử dụng SqlDataAdapter để thực thi truy vấn
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Đổ dữ liệu vào DataTable
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dtwBaiBao.DataSource = dt;

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dropdownTenVaiTro()
        {
            try
            {
                // Chuỗi kết nối đến cơ sở dữ liệu


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn lấy ID_VaiTro và TenVaiTro từ bảng VAITRO
                    string query = "SELECT ID_VaiTro, TenVaiTro FROM VAITRO";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thực hiện lệnh SQL
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Tạo DataTable để chứa dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Gán DataTable làm nguồn dữ liệu cho ComboBox
                        cbxVaiTro.DataSource = dt;
                        cbxVaiTro.DisplayMember = "TenVaiTro"; // Hiển thị cột TenVaiTro
                        cbxVaiTro.ValueMember = "ID_VaiTro";

                        cbxVaiTroGT.DataSource = dt;
                        cbxVaiTroGT.DisplayMember = "TenVaiTro"; // Hiển thị cột TenVaiTro
                        cbxVaiTroGT.ValueMember = "ID_VaiTro";// Giá trị là cột ID_VaiTro
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void dropdownTenNhaKhoaHoc()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn lấy ID_NKH và TenNhaKhoaHoc từ bảng NHAKHOAHOC dựa trên UserSession
                    string query = @"
                        SELECT 
                            ID_NKH, TenNhaKhoaHoc 
                        FROM 
                            NHAKHOAHOC
                        WHERE 
                            ID_TaiKhoan = @ID_TaiKhoan"; // Lọc theo tài khoản người dùng

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số UserSession.ID_TaiKhoan
                        cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                        // Thực hiện truy vấn
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Tạo DataTable để chứa dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Gán DataTable làm nguồn dữ liệu cho ComboBox cbxNhaKhoaHoc
                        cbxNhaKhoaHoc.DataSource = dt;
                        cbxNhaKhoaHoc.DisplayMember = "TenNhaKhoaHoc"; // Hiển thị tên nhà khoa học
                        cbxNhaKhoaHoc.ValueMember = "ID_NKH"; // Giá trị là ID_NKH

                        
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Nhà Khoa Học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dropdownTenNhaKhoaHocGT()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn lấy ID_NKH và TenNhaKhoaHoc từ bảng NHAKHOAHOC dựa trên UserSession
                    string query = @"
                        SELECT 
                            TenNhaKhoaHoc 
                        FROM 
                            NHAKHOAHOC
            
                        WHERE 
                            ID_TaiKhoan = @ID_TaiKhoan"; // Lọc theo tài khoản người dùng

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số UserSession.ID_TaiKhoan
                        cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                        // Thực hiện truy vấn
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Tạo DataTable để chứa dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Gán DataTable làm nguồn dữ liệu cho ComboBox cbxNhaKhoaHoc
                       
                        // Gán DataTable cho ComboBox cbxTenNKHGT
                        cbxTenNKHGT.DataSource = dt;
                        cbxTenNKHGT.DisplayMember = "TenNhaKhoaHoc"; // Hiển thị tên nhà khoa học
                        cbxTenNKHGT.ValueMember = "TenNhaKhoaHoc"; // Giá trị là ID_NKH
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Nhà Khoa Học: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadCoQuanChuQuanToComboBox()
        {
            // Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenCoQuanChuQuan FROM COQUANCHUQUAN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxCQCQGT.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxCQCQGT.DisplayMember = "TenCoQuanChuQuan";   // Hiển thị cột TenCoQuanChuQuan
                    cbxCQCQGT.ValueMember = "TenCoQuanChuQuan";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetIDFromMoTa(string moTa, string connectionString)
        {
            string idTaiLieu = null;
            string query = "SELECT ID_TaiLieu FROM TAILIEU WHERE MoTa = @MoTa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    connection.Open();
                    idTaiLieu = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất ID_TaiLieu: " + ex.Message);
                }
            }

            return idTaiLieu;
        }
        private void btnThemBB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaBaiBao.Text) ||
                string.IsNullOrEmpty(txtTenBaiBao.Text) ||
                string.IsNullOrEmpty(txtNuocDang.Text) ||
                string.IsNullOrEmpty(txtTomTat.Text) ||
                string.IsNullOrEmpty(txtTuKhoa.Text) ||
                string.IsNullOrEmpty(txtCTTaiLieu.Text) || // Bổ sung kiểm tra txtCTTaiLieu
                cbxNhaKhoaHoc.SelectedValue == null ||
                cbxVaiTro.SelectedValue == null ||
                (!rbtTapChi.Checked && !rbtHoiNghi.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy dữ liệu từ form
                
                string moTa = cbxIDTaiLieuBB.SelectedItem?.ToString();
                string idTaiLieu = GetIDFromMoTa(moTa, connectionString);
                string maBaiBao = txtMaBaiBao.Text;
                string tieuDe = txtTenBaiBao.Text;
                string nuocDang = txtNuocDang.Text;
                string tomTat = txtTomTat.Text;
                string tuKhoa = txtTuKhoa.Text;
                string idCTTaiLieu = txtCTTaiLieu.Text;
                // Kiểm tra và chuyển đổi SelectedValue thành kiểu int
                if (!int.TryParse(cbxNhaKhoaHoc.SelectedValue?.ToString(), out int idNKH))
                {
                    MessageBox.Show("Nhà khoa học không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(cbxVaiTro.SelectedValue?.ToString(), out int idVaiTro))
                {
                    MessageBox.Show("Vai trò không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác định giá trị của NoiDang
                string noiDang = rbtTapChi.Checked ? "Tạp chí" : "Hội nghị";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Thêm dữ liệu vào bảng BAIBAO
                            string queryBaiBao = @"INSERT INTO BAIBAO (ID_BaiBao, TenBaiBao, NuocDangTai, TomTat, TuKhoa, ID_TaiLieu, NoiDang) 
                                       VALUES (@ID_BaiBao, @TenBaiBao, @NuocDangTai, @TomTat, @TuKhoa, @ID_TaiLieu, @NoiDang)";
                            using (SqlCommand cmdBaiBao = new SqlCommand(queryBaiBao, conn, transaction))
                            {
                                cmdBaiBao.Parameters.AddWithValue("@ID_BaiBao", maBaiBao);
                                cmdBaiBao.Parameters.AddWithValue("@TenBaiBao", tieuDe);
                                cmdBaiBao.Parameters.AddWithValue("@NuocDangTai", nuocDang);
                                cmdBaiBao.Parameters.AddWithValue("@TomTat", tomTat);
                                cmdBaiBao.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                                cmdBaiBao.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                                cmdBaiBao.Parameters.AddWithValue("@NoiDang", noiDang);
                                cmdBaiBao.ExecuteNonQuery();
                            }

                            // Thêm dữ liệu vào bảng CHITIETTAILIEU
                            string queryCTTaiLieu = @"INSERT INTO CHITIETTAILIEU (ID_CTTaiLieu, ID_TaiLieu, ID_NKH, ID_VaiTro) 
                                      VALUES (@ID_CTTaiLieu, @ID_TaiLieu, @ID_NKH, @ID_VaiTro)";
                            using (SqlCommand cmdCTTaiLieu = new SqlCommand(queryCTTaiLieu, conn, transaction))
                            {
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_NKH", idNKH); // Thêm chính xác tham số này
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);

                                int rowsAffected = cmdCTTaiLieu.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    throw new Exception("Không thể thêm dữ liệu vào bảng CHITIETTAILIEU.");
                                }
                            }

                            // Commit giao dịch
                            transaction.Commit();

                            // Tải lại dữ liệu vào DataGridView
                            LoadDatadtwBaiBao();

                            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            // Rollback nếu có lỗi
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtwBaiBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào một hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dtwBaiBao.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào TextBox
                txtMaBaiBao.Text = row.Cells["Mã Bài Báo"]?.Value?.ToString();
                txtTenBaiBao.Text = row.Cells["Tên Bài Báo"]?.Value?.ToString();
                txtNuocDang.Text = row.Cells["nước Đăng Tải"]?.Value?.ToString();
                txtTomTat.Text = row.Cells["Tóm Tắt"]?.Value?.ToString();
                txtTuKhoa.Text = row.Cells["Từ Khóa"]?.Value?.ToString();
                cbxIDTaiLieuBB.Text = row.Cells["Mô tả tài liệu"]?.Value?.ToString();
                txtCTTaiLieu.Text = row.Cells["Mã CT tài liệu" +
                    ""]?.Value?.ToString();


                // Hiển thị tên tác giả trong ComboBox
                cbxNhaKhoaHoc.Text = row.Cells["Tên Nhà Khoa Học"]?.Value?.ToString();

                // Hiển thị vai trò trong ComboBox
                cbxVaiTro.Text = row.Cells["Vai Trò"]?.Value?.ToString();

                // Xử lý RadioButton cho cột Nơi Đăng
                string noiDang = row.Cells["Nơi Đăng"]?.Value?.ToString();
                if (noiDang == "Tạp chí")
                {
                    rbtTapChi.Checked = true;
                }
                else if (noiDang == "Hội nghị")
                {
                    rbtHoiNghi.Checked = true;
                }
            }
        }

        private void btnSuaBB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaBaiBao.Text) ||
                string.IsNullOrEmpty(txtTenBaiBao.Text) ||
                string.IsNullOrEmpty(txtNuocDang.Text) ||
                string.IsNullOrEmpty(txtTomTat.Text) ||
                string.IsNullOrEmpty(txtTuKhoa.Text) ||
                string.IsNullOrEmpty(txtCTTaiLieu.Text) || // Bổ sung kiểm tra txtCTTaiLieu

                cbxNhaKhoaHoc.SelectedValue == null ||
                cbxVaiTro.SelectedValue == null ||
                (!rbtTapChi.Checked && !rbtHoiNghi.Checked))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            string moTa = cbxIDTaiLieuBB.SelectedItem?.ToString();
            string idTaiLieu = GetIDFromMoTa(moTa, connectionString);
            string maBaiBao = txtMaBaiBao.Text;
            string tieuDe = txtTenBaiBao.Text;
            string nuocDang = txtNuocDang.Text;
            string tomTat = txtTomTat.Text;
            string tuKhoa = txtTuKhoa.Text;
            string idCTTaiLieu = txtCTTaiLieu.Text; // Lấy giá trị từ txtCTTaiLieu
            int idNKH = Convert.ToInt32(cbxNhaKhoaHoc.SelectedValue);
            int idVaiTro = Convert.ToInt32(cbxVaiTro.SelectedValue);

            // Xác định giá trị của NoiDang
            string noiDang = rbtTapChi.Checked ? "Tạp chí" : "Hội nghị";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Cập nhật dữ liệu bảng BAIBAO
                    string queryUpdateBaiBao = @"UPDATE BAIBAO 
                                     SET TenBaiBao = @TenBaiBao, 
                                         NuocDangTai = @NuocDangTai, 
                                         TomTat = @TomTat, 
                                         TuKhoa = @TuKhoa, 
                                         ID_TaiLieu = @ID_TaiLieu, 
                                         NoiDang = @NoiDang 
                                     WHERE ID_BaiBao = @ID_BaiBao";

                    using (SqlCommand cmdUpdateBaiBao = new SqlCommand(queryUpdateBaiBao, conn, transaction))
                    {
                        cmdUpdateBaiBao.Parameters.AddWithValue("@ID_BaiBao", maBaiBao);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@TenBaiBao", tieuDe);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@NuocDangTai", nuocDang);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@TomTat", tomTat);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@TuKhoa", tuKhoa);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmdUpdateBaiBao.Parameters.AddWithValue("@NoiDang", noiDang);
                        cmdUpdateBaiBao.ExecuteNonQuery();
                    }

                    // Cập nhật dữ liệu bảng CHITIETTAILIEU
                    string queryUpdateCTTaiLieu = @"UPDATE CHITIETTAILIEU 
                                        SET ID_TaiLieu = @ID_TaiLieu, 
                                            ID_NKH = @ID_NKH, 
                                            ID_VaiTro = @ID_VaiTro 
                                        WHERE ID_CTTaiLieu = @ID_CTTaiLieu";

                    using (SqlCommand cmdUpdateCTTaiLieu = new SqlCommand(queryUpdateCTTaiLieu, conn, transaction))
                    {
                        cmdUpdateCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                        cmdUpdateCTTaiLieu.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmdUpdateCTTaiLieu.Parameters.AddWithValue("@ID_NKH", idNKH);
                        cmdUpdateCTTaiLieu.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);

                        // Thực thi lệnh cập nhật
                        int rowsAffected = cmdUpdateCTTaiLieu.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Không thể cập nhật dữ liệu vào CHITIETTAILIEU.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Xác nhận giao dịch
                    transaction.Commit();

                    // Tải lại dữ liệu vào DataGridView sau khi sửa
                    LoadDatadtwBaiBao();
                    ClearDataBaiBao();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback nếu xảy ra lỗi
                    if (transaction != null)
                        transaction.Rollback();

                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnXoaBB_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã chọn một bài báo để xóa
            if (string.IsNullOrEmpty(txtMaBaiBao.Text) || string.IsNullOrEmpty(txtCTTaiLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn bài báo cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã bài báo cần xóa
            string maBaiBao = txtMaBaiBao.Text;
            string idCTTaiLieu = txtCTTaiLieu.Text; // Lấy ID_CTTaiLieu từ form

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Xóa dữ liệu trong bảng CHITIETTAILIEU
                    string queryDeleteCTTaiLieu = @"DELETE FROM CHITIETTAILIEU WHERE ID_CTTaiLieu = @ID_CTTaiLieu";
                    SqlCommand cmdDeleteCTTaiLieu = new SqlCommand(queryDeleteCTTaiLieu, conn, transaction);
                    {
                        cmdDeleteCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                        cmdDeleteCTTaiLieu.ExecuteNonQuery();
                    }

                    // Xóa dữ liệu trong bảng BAIBAO
                    string queryDeleteBaiBao = @"DELETE FROM BAIBAO WHERE ID_BaiBao = @ID_BaiBao";
                    SqlCommand cmdDeleteBaiBao = new SqlCommand(queryDeleteBaiBao, conn, transaction);
                    {
                        cmdDeleteBaiBao.Parameters.AddWithValue("@ID_BaiBao", maBaiBao);
                        cmdDeleteBaiBao.ExecuteNonQuery();
                    }

                    // Xác nhận giao dịch
                    transaction.Commit();

                    // Tải lại dữ liệu sau khi xóa
                    LoadDatadtwBaiBao();
                    ClearDataBaiBao();
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    if (transaction != null)
                        transaction.Rollback();

                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ClearDataBaiBao()
        {
            // Clear các TextBox
            txtMaBaiBao.Clear();
            txtTenBaiBao.Clear();
            txtNuocDang.Clear();
            txtTomTat.Clear();
            txtTuKhoa.Clear();
            txtCTTaiLieu.Clear();


            // Đặt giá trị mặc định cho ComboBox
            cbxNhaKhoaHoc.SelectedIndex = -1;
            cbxVaiTro.SelectedIndex = -1;

            // Reset RadioButton
            rbtTapChi.Checked = false;
            rbtHoiNghi.Checked = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ giao diện
            string idDeTaiNCKH = txtMaDeTai.Text.Trim();
            string moTa = cbxTaiLieuDT.Text.Trim();
            string idTaiLieu = GetIDFromMoTa(moTa, connectionString);
            string tenDeTai = txtTenDeTai.Text.Trim();
            string capDeTai = cbxCapDeTai.SelectedItem?.ToString();
            string noiDang = rbtTapChiDT.Checked ? "Tạp chí" : "Hội nghị";
            
            string idCTTaiLieu = txtMaCTTaiLieuDT.Text.Trim();
            string tenNKH = cbxTenNKHDT.SelectedItem?.ToString();
            string tenVaiTro = cbxVaiTroDT.SelectedItem?.ToString();

            // Truy xuất ID_CoQuanChuQuan dựa theo TenCoQuanChuQuan trong ComboBox
            string tenCoQuanChuQuan = cbxCQCQDT.SelectedItem?.ToString();
            string idCoQuanChuQuan = GetIDFromCoQuanChuQuan(tenCoQuanChuQuan, connectionString);

            // Truy xuất LinhVucDeTai từ bảng TAILIEU dựa vào ID_TaiLieu
            string linhVucDeTai = GetLinhVucDeTaiFromTaiLieu(idTaiLieu, connectionString);

            // Truy xuất ID_NKH từ TenNhaKhoaHoc
            string idNKH = GetIDFromNhaKhoaHoc(tenNKH, connectionString);

            // Truy xuất ID_VaiTro từ TenVaiTro
            string idVaiTro = GetIDFromVaiTro(tenVaiTro, connectionString);

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(idDeTaiNCKH) || string.IsNullOrEmpty(idCoQuanChuQuan) ||
                string.IsNullOrEmpty(idTaiLieu) || string.IsNullOrEmpty(tenDeTai) ||
                string.IsNullOrEmpty(capDeTai) || string.IsNullOrEmpty(linhVucDeTai) ||
                string.IsNullOrEmpty(idCTTaiLieu) || string.IsNullOrEmpty(idNKH) || string.IsNullOrEmpty(idVaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                return;
            }

            // Thêm dữ liệu vào bảng DETAINCKH và CHITIETTAILIEU
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();

                    // Bắt đầu transaction
                    transaction = connection.BeginTransaction();

                    // Thêm dữ liệu vào bảng DETAINCKH
                    string queryDeTai = @"
                    INSERT INTO DETAINCKH 
                    (ID_DeTaiNCKH, ID_CoQuanChuQuan, ID_TaiLieu, TenDeTai, CapDeTai, LinhVucDeTai, NoiDang) 
                    VALUES 
                    (@ID_DeTaiNCKH, @ID_CoQuanChuQuan, @ID_TaiLieu, @TenDeTai, @CapDeTai, @LinhVucDeTai, @NoiDang)";
                    SqlCommand commandDeTai = new SqlCommand(queryDeTai, connection, transaction);

                    // Gắn tham số
                    commandDeTai.Parameters.AddWithValue("@ID_DeTaiNCKH", idDeTaiNCKH);
                    commandDeTai.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuanChuQuan);
                    commandDeTai.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                    commandDeTai.Parameters.AddWithValue("@TenDeTai", tenDeTai);
                    commandDeTai.Parameters.AddWithValue("@CapDeTai", capDeTai);
                    commandDeTai.Parameters.AddWithValue("@LinhVucDeTai", linhVucDeTai);
                    commandDeTai.Parameters.AddWithValue("@NoiDang", noiDang);

                    commandDeTai.ExecuteNonQuery();

                    // Thêm dữ liệu vào bảng CHITIETTAILIEU
                    string queryChiTiet = @"
                    INSERT INTO CHITIETTAILIEU 
                    (ID_CTTaiLieu, ID_TaiLieu, ID_NKH, ID_VaiTro) 
                    VALUES 
                    (@ID_CTTaiLieu, @ID_TaiLieu, @ID_NKH, @ID_VaiTro)";
                    SqlCommand commandChiTiet = new SqlCommand(queryChiTiet, connection, transaction);

                    // Gắn tham số
                    commandChiTiet.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                    commandChiTiet.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                    commandChiTiet.Parameters.AddWithValue("@ID_NKH", idNKH);
                    commandChiTiet.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);

                    commandChiTiet.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();

                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    LoadDatadtwDeTai();
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    transaction?.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
                }
            }
        }

        // Hàm lấy ID_NKH dựa theo TenNhaKhoaHoc
        private string GetIDFromNhaKhoaHoc(string tenNhaKhoaHoc, string connectionString)
        {
            string id = null;
            string query = "SELECT ID_NKH FROM NHAKHOAHOC WHERE TenNhaKhoaHoc = @TenNhaKhoaHoc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHoc);

                try
                {
                    connection.Open();
                    id = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất ID_NKH: " + ex.Message);
                }
            }

            return id;
        }
        private string GetIDFromNhaKhoaHocBB(string tenNhaKhoaHoc, string connectionString)
        {
            if (string.IsNullOrEmpty(tenNhaKhoaHoc))
            {
                MessageBox.Show("Tên nhà khoa học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string id = null;
            string query = "SELECT ID_NKH FROM NHAKHOAHOC WHERE TenNhaKhoaHoc = @TenNhaKhoaHoc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số bằng cách xác định rõ kiểu dữ liệu
                    command.Parameters.Add("@TenNhaKhoaHoc", SqlDbType.NVarChar).Value = tenNhaKhoaHoc;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        // Chỉ gán giá trị nếu không phải null
                        if (result != null)
                        {
                            id = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy nhà khoa học với tên '{tenNhaKhoaHoc}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi truy xuất ID_NKH: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return id;
        }

        // Hàm lấy ID_VaiTro dựa theo TenVaiTro
        private string GetIDFromVaiTro(string tenVaiTro, string connectionString)
        {
            string id = null;
            string query = "SELECT ID_VaiTro FROM VAITRO WHERE TenVaiTro = @TenVaiTro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenVaiTro", tenVaiTro);

                try
                {
                    connection.Open();
                    id = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất ID_VaiTro: " + ex.Message);
                }
            }

            return id;
        }
        private string GetIDFromVaiTroBB(string tenVaiTro, string connectionString)
        {
            string id = null;
            string query = "SELECT ID_VaiTro FROM VAITRO WHERE TenVaiTro = @TenVaiTro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenVaiTro", tenVaiTro);

                try
                {
                    connection.Open();
                    id = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất ID_VaiTro: " + ex.Message);
                }
            }

            return id;
        }
        private string GetLinhVucDeTaiFromTaiLieu(string idTaiLieu, string connectionString)
        {
            string linhVuc = null;
            string query = "SELECT ChuyenNganh FROM TAILIEU WHERE ID_TaiLieu = @ID_TaiLieu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);

                try
                {
                    connection.Open();
                    linhVuc = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving LinhVucDeTai: " + ex.Message);
                }
            }

            return linhVuc;
        }
        private string GetIDFromCoQuanChuQuan(string tenCoQuanChuQuan, string connectionString)
        {
            string id = null;
            string query = "SELECT ID_CoQuanChuQuan FROM COQUANCHUQUAN WHERE TenCoQuanChuQuan = @TenCoQuanChuQuan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenCoQuanChuQuan", tenCoQuanChuQuan);

                try
                {
                    connection.Open();
                    id = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving ID_CoQuanChuQuan: " + ex.Message);
                }
            }

            return id;
        }

        private void btnHuyDT_Click(object sender, EventArgs e)
        {
            // Lấy ID_DeTaiNCKH từ giao diện
            string idDeTaiNCKH = txtMaDeTai.Text.Trim();

            if (string.IsNullOrEmpty(idDeTaiNCKH))
            {
                MessageBox.Show("Vui lòng chọn một đề tài để xóa!", "Thông báo");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Xóa từ bảng CHITIETTAILIEU
                    string queryDeleteChiTiet = "DELETE FROM CHITIETTAILIEU WHERE ID_CTTaiLieu = (SELECT ID_TaiLieu FROM DETAINCKH WHERE ID_DeTaiNCKH = @ID_DeTaiNCKH)";
                    SqlCommand cmdDeleteChiTiet = new SqlCommand(queryDeleteChiTiet, connection, transaction);
                    cmdDeleteChiTiet.Parameters.AddWithValue("@ID_DeTaiNCKH", idDeTaiNCKH);
                    cmdDeleteChiTiet.ExecuteNonQuery();

                    // Xóa từ bảng DETAINCKH
                    string queryDeleteDeTai = "DELETE FROM DETAINCKH WHERE ID_DeTaiNCKH = @ID_DeTaiNCKH";
                    SqlCommand cmdDeleteDeTai = new SqlCommand(queryDeleteDeTai, connection, transaction);
                    cmdDeleteDeTai.Parameters.AddWithValue("@ID_DeTaiNCKH", idDeTaiNCKH);
                    cmdDeleteDeTai.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    LoadDatadtwDeTai();
                    ClearDataDeTai(); // Xóa dữ liệu hiển thị
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message, "Lỗi");
                }
            }
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ giao diện
            string idDeTaiNCKH = txtMaDeTai.Text.Trim();
            string moTa = cbxTaiLieuDT.Text.Trim();
            string idTaiLieu = GetIDFromMoTa(moTa, connectionString);
            string tenDeTai = txtTenDeTai.Text.Trim();
            string capDeTai = cbxCapDeTai.SelectedItem?.ToString();
            string noiDang = rbtTapChiDT.Checked ? "Tạp chí" : "Hội nghị";

            string idCTTaiLieu = txtMaCTTaiLieuDT.Text.Trim();
            string tenNKH = cbxTenNKHDT.SelectedItem?.ToString();
            string tenVaiTro = cbxVaiTroDT.SelectedItem?.ToString();

            // Truy xuất ID_CoQuanChuQuan và các thông tin khác
            string tenCoQuanChuQuan = cbxCQCQDT.SelectedItem?.ToString();
            string idCoQuanChuQuan = GetIDFromCoQuanChuQuan(tenCoQuanChuQuan, connectionString);
            string linhVucDeTai = GetLinhVucDeTaiFromTaiLieu(idTaiLieu, connectionString);
            string idNKH = GetIDFromNhaKhoaHoc(tenNKH, connectionString);
            string idVaiTro = GetIDFromVaiTro(tenVaiTro, connectionString);

            if (string.IsNullOrEmpty(idDeTaiNCKH) || string.IsNullOrEmpty(idCoQuanChuQuan) ||
                string.IsNullOrEmpty(idTaiLieu) || string.IsNullOrEmpty(tenDeTai) ||
                string.IsNullOrEmpty(capDeTai) || string.IsNullOrEmpty(linhVucDeTai) ||
                string.IsNullOrEmpty(idCTTaiLieu) || string.IsNullOrEmpty(idNKH) || string.IsNullOrEmpty(idVaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Cập nhật bảng DETAINCKH
                    string queryUpdateDeTai = @"
                    UPDATE DETAINCKH 
                    SET ID_CoQuanChuQuan = @ID_CoQuanChuQuan, 
                        ID_TaiLieu = @ID_TaiLieu, 
                        TenDeTai = @TenDeTai, 
                        CapDeTai = @CapDeTai, 
                        LinhVucDeTai = @LinhVucDeTai, 
                        NoiDang = @NoiDang 
                    WHERE ID_DeTaiNCKH = @ID_DeTaiNCKH";
                    SqlCommand cmdUpdateDeTai = new SqlCommand(queryUpdateDeTai, connection, transaction);

                    // Gắn tham số
                    cmdUpdateDeTai.Parameters.AddWithValue("@ID_DeTaiNCKH", idDeTaiNCKH);
                    cmdUpdateDeTai.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuanChuQuan);
                    cmdUpdateDeTai.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                    cmdUpdateDeTai.Parameters.AddWithValue("@TenDeTai", tenDeTai);
                    cmdUpdateDeTai.Parameters.AddWithValue("@CapDeTai", capDeTai);
                    cmdUpdateDeTai.Parameters.AddWithValue("@LinhVucDeTai", linhVucDeTai);
                    cmdUpdateDeTai.Parameters.AddWithValue("@NoiDang", noiDang);
                    cmdUpdateDeTai.ExecuteNonQuery();

                    // Cập nhật bảng CHITIETTAILIEU
                    string queryUpdateChiTiet = @"
                    UPDATE CHITIETTAILIEU 
                    SET ID_NKH = @ID_NKH, 
                        ID_VaiTro = @ID_VaiTro 
                    WHERE ID_CTTaiLieu = @ID_CTTaiLieu";
                    SqlCommand cmdUpdateChiTiet = new SqlCommand(queryUpdateChiTiet, connection, transaction);

                    // Gắn tham số
                    cmdUpdateChiTiet.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                    cmdUpdateChiTiet.Parameters.AddWithValue("@ID_NKH", idNKH);
                    cmdUpdateChiTiet.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);
                    cmdUpdateChiTiet.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    LoadDatadtwDeTai();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật: " + ex.Message, "Lỗi");
                }
            }
        }

        private void dtwDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtwDeTai.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên giao diện
                txtMaDeTai.Text = row.Cells["Mã đề tài"].Value.ToString();
                txtTenDeTai.Text = row.Cells["Tên đề tài"].Value.ToString();
                cbxCapDeTai.SelectedItem = row.Cells["Cấp đề tài"].Value.ToString();
                string noiDang = row.Cells["Nơi đăng"]?.Value?.ToString();
                if (noiDang == "Tạp chí")
                {
                    rbtTapChiDT.Checked = true;
                }
                else if (noiDang == "Hội nghị")
                {
                    rbtHoiNghiDT.Checked = true;
                }
                cbxTaiLieuDT.Text = row.Cells["Mô tả tài liệu"].Value.ToString();
                txtMaCTTaiLieuDT.Text = row.Cells["Mã CT tài liệu"].Value.ToString();
                // Các ComboBox khác
                cbxCQCQDT.SelectedItem = row.Cells["Cơ quan chủ quản"].Value.ToString();
                cbxTenNKHDT.SelectedItem = row.Cells["Tên nhà khoa học"].Value.ToString();
                cbxVaiTroDT.SelectedItem = row.Cells["Vai trò"].Value.ToString();
            }
        }
        private void ClearDataDeTai()
        {
            txtMaDeTai.Clear();
            cbxTaiLieuDT.SelectedIndex = -1;
            txtTenDeTai.Clear();
            cbxCapDeTai.SelectedIndex = -1;
            rbtTapChi.Checked = false;
            rbtHoiNghi.Checked = false;
            txtMaCTTaiLieuDT.Clear();
            cbxCQCQDT.SelectedIndex = -1;
            cbxTenNKHDT.SelectedIndex = -1;
            cbxVaiTroDT.SelectedIndex = -1;
        }

        private void dropdownMaTaiLieuDT()
        {
            string query = @"
                SELECT MoTa
                FROM TAILIEU
                WHERE ID_TaiKhoan = @ID_TaiKhoan"; // Lọc tài liệu theo tài khoản người dùng

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thêm tham số UserSession.ID_TaiKhoan
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa các mục trong ComboBox trước khi thêm mới
                    cbxTaiLieuDT.Items.Clear();

                    // Lặp qua kết quả và thêm vào ComboBox
                    while (reader.Read())
                    {
                        cbxTaiLieuDT.Items.Add(reader["MoTa"].ToString());
                    }

                    // Tùy chọn: Chọn mục đầu tiên mặc định
                    if (cbxTaiLieuDT.Items.Count > 0)
                    {
                        cbxTaiLieuDT.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dropdownMaTaiLieuGT()
        {
            string query = "SELECT ID_TaiLieu, MoTa FROM TAILIEU WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra nếu có dữ liệu
                    if (dataTable.Rows.Count > 0)
                    {
                        // Gắn dữ liệu vào ComboBox
                        cbxTaiLieuGT.DataSource = dataTable;                 // Gắn DataTable làm nguồn dữ liệu
                        cbxTaiLieuGT.DisplayMember = "MoTa";
                        cbxTaiLieuGT.ValueMember = "ID_TaiLieu";
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị trong ComboBox.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxTaiLieuGT.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void LoadDatadtwGiaoTrinh()
        {
            try
            {
                // Truy vấn SQL với điều kiện lọc theo UserSession
                string query = @"
                    WITH CTE AS (
                        SELECT 
                            GIAOTRINH.ID_GiaoTrinh AS IDGiaoTrinh,
                            GIAOTRINH.TenGiaoTrinh AS TenGiaoTrinh,
                            GIAOTRINH.NgayKyHopDong AS NgayKyHopDong,
                            GIAOTRINH.NgayKetThuc AS NgayKetThuc,
                            GIAOTRINH.NoiDang AS NoiDang,
                            COQUANCHUQUAN.TenCoQuanChuQuan AS TenCoQuanChuQuan,
                            TAILIEU.ChuyenNganh AS ChuyenNganh,
                            TAILIEU.MoTa AS MoTaTaiLieu,
                            TAILIEU.NamXuatBan AS NamXuatBan,
                            NHAKHOAHOC.TenNhaKhoaHoc AS TenNhaKhoaHoc,
                            VAITRO.TenVaiTro AS TenVaiTro,
                            CHITIETTAILIEU.ID_CTTaiLieu AS CTTaiLieu,
                            GIAOTRINH.ID_TaiLieu AS IDTaiLieu,
                            ROW_NUMBER() OVER (
                                PARTITION BY CHITIETTAILIEU.ID_CTTaiLieu 
                                ORDER BY CHITIETTAILIEU.ID_CTTaiLieu
                            ) AS RowNumChiTiet
                        FROM 
                            GIAOTRINH
                        LEFT JOIN 
                            TAILIEU ON GIAOTRINH.ID_TaiLieu = TAILIEU.ID_TaiLieu
                        LEFT JOIN 
                            CHITIETTAILIEU ON TAILIEU.ID_TaiLieu = CHITIETTAILIEU.ID_TaiLieu
                        LEFT JOIN 
                            NHAKHOAHOC ON CHITIETTAILIEU.ID_NKH = NHAKHOAHOC.ID_NKH
                        LEFT JOIN 
                            VAITRO ON CHITIETTAILIEU.ID_VaiTro = VAITRO.ID_VaiTro
                        LEFT JOIN 
                            COQUANCHUQUAN ON GIAOTRINH.ID_CoQuanChuQuan = COQUANCHUQUAN.ID_CoQuanChuQuan
                        WHERE 
                            TAILIEU.ID_TaiKhoan = @ID_TaiKhoan -- Lọc theo ID_TaiKhoan trong UserSession
                    )
                    SELECT 
                        IDGiaoTrinh AS 'Mã giáo trình',
                        TenGiaoTrinh AS 'Tên giáo trình',
                        NgayKyHopDong AS 'Ngày ký hợp đồng',
                        NgayKetThuc AS 'Ngày kết thúc',
                        NoiDang AS 'Nơi đăng',
                        TenCoQuanChuQuan AS 'Tên cơ quan chủ quản',
                        ChuyenNganh AS 'Chuyên ngành',
                        MoTaTaiLieu AS 'Mô tả tài liệu',
                        NamXuatBan AS 'Năm xuất bản',
                        TenNhaKhoaHoc AS 'Tên nhà khoa học',
                        TenVaiTro AS 'Vai trò',
                        IDTaiLieu AS 'Mã tài liệu',
                        CTTaiLieu AS 'Mã CT tài liệu'
                    FROM 
                        CTE
                    WHERE 
                        RowNumChiTiet = 1
                    ORDER BY 
                        IDGiaoTrinh;
                ";

                // Kết nối tới cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo SqlCommand
                    SqlCommand command = new SqlCommand(query, conn);

                    // Thêm tham số UserSession.ID_TaiKhoan vào truy vấn
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Thực thi truy vấn và đổ dữ liệu vào DataTable
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gắn DataSource cho DataGridView
                    dtwGiaoTrinh.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnThemGT_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị các tham số đầu vào
            string noiDang;
            if (rbtHoiNghiGT.Checked)
            {
                noiDang = "Hội nghị";
            }
            else if (rbtTapChiGT.Checked)
            {
                noiDang = "Tạp chí";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nơi đăng (Hội nghị hoặc Tạp chí)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Lấy dữ liệu từ giao diện
            string idGiaoTrinh = txtMaGiaoTrinh.Text.Trim();
            string moTa = cbxTaiLieuGT.Text.Trim();
            string idTaiLieu = GetIDFromMoTa(moTa, connectionString);
            string tenCoQuanChuQuan = cbxCQCQGT.Text.Trim();
        
            int idCoQuanChuQuan = Convert.ToInt32(GetIDCQCQGT(cbxCQCQGT.Text));
            string tenGiaoTrinh = txtTenGiaoTrinh.Text.Trim();
            DateTime ngayKyHopDong = dateKyHopDong.Value;
            DateTime ngayKetThuc = dateKetThuc.Value;

            string idCTTaiLieu = txtMaCTTaiLieuGT.Text.Trim();
            string tenNKH = cbxTenNKHGT.SelectedItem?.ToString();
            int idNKH = Convert.ToInt32(GetIDNKHGT(cbxTenNKHGT.Text));
            string tenVaiTro = cbxVaiTroGT.SelectedItem?.ToString();
            int idVaiTro = Convert.ToInt32(GetIDFromVaiTroGT(cbxVaiTroGT.Text));

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(idGiaoTrinh) || string.IsNullOrEmpty(idTaiLieu) || string.IsNullOrEmpty(tenCoQuanChuQuan) ||
                string.IsNullOrEmpty(tenGiaoTrinh) || string.IsNullOrEmpty(idCTTaiLieu) || string.IsNullOrEmpty(tenNKH) ||
                string.IsNullOrEmpty(tenVaiTro))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dữ liệu vào bảng GIAOTRINH và CHITIETTAILIEU
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Thêm dữ liệu vào bảng GIAOTRINH và CHITIETTAILIEU
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = @"
                            INSERT INTO GIAOTRINH (ID_GiaoTrinh, ID_TaiLieu, ID_CoQuanChuQuan, TenGiaoTrinh, NgayKyHopDong, NgayKetThuc, NoiDang) 
                            VALUES (@ID_GiaoTrinh, @ID_TaiLieu, @ID_CoQuanChuQuan, @TenGiaoTrinh, @NgayKyHopDong, @NgayKetThuc, @NoiDang);

                            INSERT INTO CHITIETTAILIEU (ID_CTTaiLieu, ID_TaiLieu, ID_NKH, ID_VaiTro) 
                            VALUES (@ID_CTTaiLieu, @ID_TaiLieu, @ID_NKH, @ID_VaiTro);";

                        // Gán tham số vào câu lệnh
                        cmd.Parameters.AddWithValue("@ID_GiaoTrinh", idGiaoTrinh);
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuanChuQuan); // Kiểm tra tham số này
                        cmd.Parameters.AddWithValue("@TenGiaoTrinh", tenGiaoTrinh);
                        cmd.Parameters.AddWithValue("@NgayKyHopDong", ngayKyHopDong);
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                        cmd.Parameters.AddWithValue("@NoiDang", noiDang);
                        cmd.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_NKH", idNKH);
                        cmd.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu lên DataGridView hoặc các thành phần liên quan
                    LoadDatadtwGiaoTrinh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private string GetIDTaiLieu(string moTa)
        {
            string idTaiLieu = string.Empty;
            string query = "SELECT ID_TaiLieu FROM TAILIEU WHERE MoTa = @MoTa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    connection.Open();
                    idTaiLieu = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_TaiLieu: " + ex.Message);
                }
            }

            return idTaiLieu;
        }
        private string GetIDCQCQGT(string tenCQCQGT)
        {
            string idCQCQGT = string.Empty;
            string query = "SELECT ID_CoQuanChuQuan FROM COQUANCHUQUAN WHERE TenCoQuanChuQuan = @TenCoQuanChuQuan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenCoQuanChuQuan", tenCQCQGT);

                try
                {
                    connection.Open();
                    idCQCQGT = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_CQCQ: " + ex.Message);
                }
            }

            return idCQCQGT;
        }

        private string GetIDNKHGT(string tenNKHGT)
        {
            string idNKHGT = string.Empty;
            string query = "SELECT ID_NKH FROM NHAKHOAHOC WHERE TenNhaKhoaHoc = @TenNhaKhoaHoc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNKHGT);

                try
                {
                    connection.Open();
                    idNKHGT = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NKH: " + ex.Message);
                }
            }

            return idNKHGT;
        }

        private string GetIDFromVaiTroGT(string tenVTGT)
        {
            string idVTGT = null;
            string query = "SELECT ID_VAITRO FROM VAITRO WHERE TenVaiTro = @TenVaiTro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenVaiTro", tenVTGT);

                try
                {
                    connection.Open();
                    idVTGT = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất TenVaiTro: " + ex.Message);
                }
            }

            return idVTGT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtMoTa.Text) ||
                string.IsNullOrEmpty(cbxLoaiTaiLieu.Text) ||
                string.IsNullOrEmpty(cbxChuyenNganh.Text) ||
                string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            string moTa = txtMoTa.Text.Trim();
            DateTime namXuatBan = dateNamXuatBan.Value;
            string loaiTaiLieu = cbxLoaiTaiLieu.Text.Trim();
            string chuyenNganh = cbxChuyenNganh.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            // Chuỗi kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Câu lệnh chèn dữ liệu
                    string queryTaiLieu = @"INSERT INTO TAILIEU (MoTa, NamXuatBan, LoaiTaiLieu, ChuyenNganh, NoiDung, ID_TaiKhoan) 
                        VALUES (@MoTa, @NamXuatBan, @LoaiTaiLieu, @ChuyenNganh, @NoiDung, @ID_TaiKhoan)";
                    using (SqlCommand cmdTaiLieu = new SqlCommand(queryTaiLieu, conn, transaction))
                    {
                        cmdTaiLieu.Parameters.AddWithValue("@MoTa", moTa);
                        cmdTaiLieu.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                        cmdTaiLieu.Parameters.AddWithValue("@LoaiTaiLieu", loaiTaiLieu);
                        cmdTaiLieu.Parameters.AddWithValue("@ChuyenNganh", chuyenNganh);
                        cmdTaiLieu.Parameters.AddWithValue("@NoiDung", noiDung);
                        cmdTaiLieu.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                        cmdTaiLieu.ExecuteNonQuery();
                    }

                    // Xác nhận giao dịch
                    transaction.Commit();

                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form sau khi thêm
                    ResetFormTaiLieu();
                    LoadDataTaiLieu();
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ResetFormTaiLieu()
        {
            txtMaTaiLieu.Clear();
            txtMoTa.Clear();
            txtNoiDung.Clear();
            cbxLoaiTaiLieu.SelectedIndex = -1; // Xóa lựa chọn
            cbxChuyenNganh.SelectedIndex = -1;
            dateNamXuatBan.Value = DateTime.Now;
        }
        private void LoadDataKyYeu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Truy vấn kết hợp các bảng với điều kiện UserSession
                    string query = @"
            WITH CTE AS (
                SELECT 
                    KYYEU.ID_KyYeu AS IDKyYeu,
                    KYYEU.TenKyYeu AS TenKyYeu,
                    NHAXUATBAN.TenNhaXuatBan AS NhaXuatBan,
                    HOINGHI.TenHoiNghi AS HoiNghi,
                    TAILIEU.ChuyenNganh AS ChuyenNganh,
                    TAILIEU.NamXuatBan AS NamXuatBan,
                    TAILIEU.MoTa AS MoTa,
                    NHAKHOAHOC.TenNhaKhoaHoc AS NhaKhoaHoc,
                    VAITRO.TenVaiTro AS VaiTro,
                    CHITIETTAILIEU.ID_CTTaiLieu AS IDCTTaiLieu,
                    KYYEU.ID_TaiLieu AS IDTaiLieu,
                    ROW_NUMBER() OVER (
                        PARTITION BY CHITIETTAILIEU.ID_CTTaiLieu 
                        ORDER BY CHITIETTAILIEU.ID_CTTaiLieu
                    ) AS RowNum
                FROM 
                    KYYEU
                LEFT JOIN NHAXUATBAN ON KYYEU.ID_NhaXuatBan = NHAXUATBAN.ID_NhaXuatBan
                LEFT JOIN HOINGHI ON KYYEU.ID_HoiNghi = HOINGHI.ID_HoiNghi
                LEFT JOIN TAILIEU ON KYYEU.ID_TaiLieu = TAILIEU.ID_TaiLieu
                LEFT JOIN CHITIETTAILIEU ON TAILIEU.ID_TaiLieu = CHITIETTAILIEU.ID_TaiLieu
                LEFT JOIN NHAKHOAHOC ON CHITIETTAILIEU.ID_NKH = NHAKHOAHOC.ID_NKH
                LEFT JOIN VAITRO ON CHITIETTAILIEU.ID_VaiTro = VAITRO.ID_VaiTro
                WHERE 
                    TAILIEU.ID_TaiKhoan = @ID_TaiKhoan -- Điều kiện lọc theo UserSession
            )
            SELECT DISTINCT
                IDKyYeu AS 'Mã kỷ yếu',
                TenKyYeu AS 'Tên kỷ yếu',
                NhaXuatBan AS 'Nhà xuất bản',
                HoiNghi AS 'Hội nghị',
                ChuyenNganh AS 'Chuyên ngành',
                NamXuatBan AS 'Năm xuất bản',
                MoTa AS 'Mô tả tài liệu',
                NhaKhoaHoc AS 'Nhà khoa học',
                VaiTro AS 'Vai trò',
                IDTaiLieu AS 'Mã tài liệu',
                IDCTTaiLieu AS 'Mã CT tài liệu'
            FROM 
                CTE
            WHERE 
                RowNum = 1
            ORDER BY 
                IDKyYeu;
        ";

                    // Tạo SqlCommand
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền tham số ID_TaiKhoan từ UserSession
                    cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                    // Tạo adapter để thực thi truy vấn
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gắn dữ liệu vào DataGridView
                    dtwKyYeu.DataSource = dt;
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu xảy ra vấn đề
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtMaTaiLieu.Text) ||
                string.IsNullOrEmpty(txtMoTa.Text) ||
                string.IsNullOrEmpty(cbxLoaiTaiLieu.Text) ||
                string.IsNullOrEmpty(cbxChuyenNganh.Text) ||
                string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            string idTaiLieu = txtMaTaiLieu.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            DateTime namXuatBan = dateNamXuatBan.Value;
            string loaiTaiLieu = cbxLoaiTaiLieu.Text.Trim();
            string chuyenNganh = cbxChuyenNganh.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Câu lệnh cập nhật dữ liệu
                    string querySua = @"UPDATE TAILIEU 
                                SET MoTa = @MoTa, 
                                    NamXuatBan = @NamXuatBan, 
                                    LoaiTaiLieu = @LoaiTaiLieu, 
                                    ChuyenNganh = @ChuyenNganh, 
                                    NoiDung = @NoiDung
                                WHERE ID_TaiLieu = @ID_TaiLieu";
                    using (SqlCommand cmdSua = new SqlCommand(querySua, conn, transaction))
                    {
                        cmdSua.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmdSua.Parameters.AddWithValue("@MoTa", moTa);
                        cmdSua.Parameters.AddWithValue("@NamXuatBan", namXuatBan);
                        cmdSua.Parameters.AddWithValue("@LoaiTaiLieu", loaiTaiLieu);
                        cmdSua.Parameters.AddWithValue("@ChuyenNganh", chuyenNganh);
                        cmdSua.Parameters.AddWithValue("@NoiDung", noiDung);

                        int rowsAffected = cmdSua.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reset form sau khi sửa
                            ResetFormTaiLieu();
                            LoadDataTaiLieu();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Không tìm thấy mã tài liệu cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã tài liệu không được chọn
            if (string.IsNullOrEmpty(txtMaTaiLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID_TaiLieu từ TextBox
            string idTaiLieu = txtMaTaiLieu.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Câu lệnh xóa dữ liệu
                    string queryXoa = "DELETE FROM TAILIEU WHERE ID_TaiLieu = @ID_TaiLieu";
                    using (SqlCommand cmdXoa = new SqlCommand(queryXoa, conn, transaction))
                    {
                        cmdXoa.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);

                        int rowsAffected = cmdXoa.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reset form sau khi xóa
                            ResetFormTaiLieu();
                            LoadDataTaiLieu();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Không tìm thấy mã tài liệu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số dòng hợp lệ
            {
                DataGridViewRow row = dgvTaiLieu.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox
                txtMaTaiLieu.Text = row.Cells["Mã tài liệu"]?.Value?.ToString();
                txtMoTa.Text = row.Cells["Mô tả"]?.Value?.ToString();
                dateNamXuatBan.Value = row.Cells["Năm xuất bản"]?.Value != null
                    ? Convert.ToDateTime(row.Cells["Năm xuất bản"].Value)
                    : DateTime.Now;
                cbxLoaiTaiLieu.Text = row.Cells["Loại tài liệu"]?.Value?.ToString();
                cbxChuyenNganh.Text = row.Cells["Chuyên ngành"]?.Value?.ToString();

                // Lấy đường dẫn từ cột FilePath
                string noiDung = row.Cells["Nội dung"]?.Value?.ToString();

                // Kiểm tra nếu đường dẫn không rỗng
                if (!string.IsNullOrEmpty(noiDung))
                {
                    txtNoiDung.Text = noiDung;

                    // Kiểm tra và mở file
                    if (File.Exists(noiDung))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(noiDung);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không thể mở file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File không tồn tại hoặc đường dẫn không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không có đường dẫn file để mở.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LoadComboBoxNhaXuatBanKY()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenNhaXuatBan FROM NHAXUATBAN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxNXBKY.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxNXBKY.DisplayMember = "TenNhaXuatBan";   // Hiển thị cột TenCoQuanChuQuan
                    cbxNXBKY.ValueMember = "TenNhaXuatBan";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxHoiNghiKY()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenHoiNghi FROM HOINGHI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxHoiNghiKY.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxHoiNghiKY.DisplayMember = "TenHoiNghi";   // Hiển thị cột TenCoQuanChuQuan
                    cbxHoiNghiKY.ValueMember = "TenHoiNghi";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxMaTaiLieuKY()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT ID_TaiLieu, MoTa FROM TAILIEU WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra nếu có dữ liệu
                    if (dataTable.Rows.Count > 0)
                    {
                        // Gắn dữ liệu vào ComboBox
                        cbxTaiLieuKY.DataSource = dataTable;                 // Gắn DataTable làm nguồn dữ liệu
                        cbxTaiLieuKY.DisplayMember = "MoTa";      
                        cbxTaiLieuKY.ValueMember = "ID_TaiLieu";                
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị trong ComboBox.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxTaiLieuKY.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxNhaKhoaHocKY()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT ID_NKH, TenNhaKhoaHoc FROM NHAKHOAHOC WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan); 
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra nếu có dữ liệu
                    if (dataTable.Rows.Count > 0)
                    {
                        // Gắn dữ liệu vào ComboBox
                        cbxNKHKY.DataSource = dataTable;                 // Gắn DataTable làm nguồn dữ liệu
                        cbxNKHKY.DisplayMember = "TenNhaKhoaHoc";        // Hiển thị cột tên nhà khoa học
                        cbxNKHKY.ValueMember = "TenNhaKhoaHoc";                // Giá trị là ID_NKH
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị trong ComboBox.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxNKHKY.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void LoadComboBoxVaiTroKY()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenVaiTro FROM VAITRO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxVaiTroKY.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxVaiTroKY.DisplayMember = "TenVaiTro";   // Hiển thị cột TenCoQuanChuQuan
                    cbxVaiTroKY.ValueMember = "TenVaiTro";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ResetFormKyYeu()
        {
            txtMaKyYeu.Clear();
            txtTenKyYeu.Clear();
            txtMaCTTaiLieuKY.Clear();
            cbxNXBKY.SelectedIndex = -1;
            cbxHoiNghiKY.SelectedIndex = -1;
            cbxTaiLieuKY.SelectedIndex = -1;
            cbxNKHKY.SelectedIndex = -1;
            cbxVaiTroKY.SelectedIndex = -1;
        }
        private string GetIDHoiNghi(string tenHoiNghi)
        {
            string idHoiNghi = string.Empty;
            string query = "SELECT ID_HoiNghi FROM HOINGHI WHERE TenHoiNghi = @TenHoiNghi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenHoiNghi", tenHoiNghi);

                try
                {
                    connection.Open();
                    idHoiNghi = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_HoiNghi: " + ex.Message);
                }
            }

            return idHoiNghi;
        }
        private string GetIDNhaXuatBan(string tenNhaXuatBan)
        {
            string idNhaXuatBan = string.Empty;
            string query = "SELECT ID_NhaXuatBan FROM NHAXUATBAN WHERE TenNhaXuatBan = @TenNhaXuatBan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaXuatBan", tenNhaXuatBan);

                try
                {
                    connection.Open();
                    idNhaXuatBan = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NhaXuatBan: " + ex.Message);
                }
            }

            return idNhaXuatBan;
        }
        private string GetIDVaiTro(string tenVaiTro)
        {
            string idVaiTro = string.Empty;
            string query = "SELECT ID_VaiTro FROM VAITRO WHERE TenVaiTro = @TenVaiTro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenVaiTro", tenVaiTro);

                try
                {
                    connection.Open();
                    idVaiTro = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_VaiTro: " + ex.Message);
                }
            }

            return idVaiTro;
        }
        private string GetIDNKH(string tenNhaKhoaHoc)
        {
            string idNKH = string.Empty;
            string query = "SELECT ID_NKH FROM NHAKHOAHOC WHERE TenNhaKhoaHoc = @TenNhaKhoaHoc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHoc);

                try
                {
                    connection.Open();
                    idNKH = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NKH: " + ex.Message);
                }
            }

            return idNKH;
        }
        private string GetIDTaiLieuKY(string moTa, string connectionString)
        {
            string idTaiLieu = null;
            string query = "SELECT ID_TaiLieu FROM TAILIEU WHERE MoTa = @MoTa";

            using (SqlConnection connection = new SqlConnection(connectionString))  // connectionString đã có sẵn
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    connection.Open();
                    idTaiLieu = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy xuất ID_TaiLieu: " + ex.Message);
                }
            }

            return idTaiLieu;
        }

        private void btnThemKY_Click(object sender, EventArgs e)
        {
        
     
            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(txtMaKyYeu.Text) ||
                string.IsNullOrEmpty(txtTenKyYeu.Text) ||
                cbxNXBKY.SelectedValue == null ||
                cbxHoiNghiKY.SelectedValue == null ||
                string.IsNullOrEmpty(txtMaCTTaiLieuKY.Text) ||
                cbxNKHKY.SelectedValue == null ||
                cbxVaiTroKY.SelectedValue == null ||
                cbxTaiLieuKY.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            string idKyYeu = txtMaKyYeu.Text.Trim();
            string tenKyYeu = txtTenKyYeu.Text.Trim();
            string idNhaXuatBan = GetIDNhaXuatBan(cbxNXBKY.SelectedValue?.ToString());
            string idHoiNghi = GetIDHoiNghi(cbxHoiNghiKY.SelectedValue?.ToString());
            string moTa = cbxTaiLieuKY.Text.Trim();
            string idTaiLieu = GetIDTaiLieuKY(moTa, connectionString);
            string idCTTaiLieu = txtMaCTTaiLieuKY.Text.Trim();
            string idNKH = GetIDNKH(cbxNKHKY.SelectedValue?.ToString());
            string idVaiTro = GetIDVaiTro(cbxVaiTroKY.SelectedValue?.ToString());

            try
            {
                if (string.IsNullOrEmpty(idNhaXuatBan) ||
                    string.IsNullOrEmpty(idHoiNghi) ||
                    string.IsNullOrEmpty(idTaiLieu) ||
                    string.IsNullOrEmpty(idNKH) ||
                    string.IsNullOrEmpty(idVaiTro))
                {
                    MessageBox.Show("Vui lòng kiểm tra lại các trường dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Thêm dữ liệu vào bảng KYYEU
                            string queryKYYEU = @"INSERT INTO KYYEU (ID_KyYeu, TenKyYeu, ID_NhaXuatBan, ID_HoiNghi, ID_TaiLieu) 
                              VALUES (@ID_KyYeu, @TenKyYeu, @ID_NhaXuatBan, @ID_HoiNghi, @ID_TaiLieu)";
                            using (SqlCommand cmdKyYeu = new SqlCommand(queryKYYEU, conn, transaction))
                            {
                                cmdKyYeu.Parameters.AddWithValue("@ID_KyYeu", idKyYeu);
                                cmdKyYeu.Parameters.AddWithValue("@TenKyYeu", tenKyYeu);
                                cmdKyYeu.Parameters.AddWithValue("@ID_NhaXuatBan", idNhaXuatBan);
                                cmdKyYeu.Parameters.AddWithValue("@ID_HoiNghi", idHoiNghi);
                                cmdKyYeu.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                                cmdKyYeu.ExecuteNonQuery();
                            }

                            // Thêm dữ liệu vào bảng CHITIETTAILIEU
                            string queryCTTAILIEU = @"INSERT INTO CHITIETTAILIEU (ID_CTTaiLieu, ID_TaiLieu, ID_NKH, ID_VaiTro) 
                                  VALUES (@ID_CTTaiLieu, @ID_TaiLieu, @ID_NKH, @ID_VaiTro)";
                            using (SqlCommand cmdCTTaiLieu = new SqlCommand(queryCTTAILIEU, conn, transaction))
                            {
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_NKH", idNKH);
                                cmdCTTaiLieu.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);
                                cmdCTTaiLieu.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataKyYeu();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi thêm dữ liệu vào cơ sở dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSuaKY_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(txtMaKyYeu.Text) ||
                string.IsNullOrEmpty(txtTenKyYeu.Text) ||
                cbxNXBKY.SelectedValue == null ||
                cbxHoiNghiKY.SelectedValue == null ||
                cbxTaiLieuKY.SelectedValue == null ||
                string.IsNullOrEmpty(txtMaCTTaiLieuKY.Text) ||
                cbxNKHKY.SelectedValue == null ||
                cbxVaiTroKY.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            string idKyYeu = txtMaKyYeu.Text.Trim();
            string tenKyYeu = txtTenKyYeu.Text.Trim();

            // Lấy ID từ các ComboBox
            string idNhaXuatBan = GetIDNhaXuatBan(cbxNXBKY.SelectedValue.ToString());
            string idHoiNghi = GetIDHoiNghi(cbxHoiNghiKY.SelectedValue.ToString());
            string moTa = cbxTaiLieuKY.Text.Trim();
            string idTaiLieu = GetIDTaiLieuKY(moTa, connectionString);
            string idCTTaiLieu = txtMaCTTaiLieuKY.Text.Trim();
            string idNKH = GetIDNKH(cbxNKHKY.SelectedValue.ToString());
            string idVaiTro = GetIDVaiTro(cbxVaiTroKY.SelectedValue.ToString());

            // Chuỗi kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Cập nhật dữ liệu vào bảng KYYEU
                    string queryKYYEU = @"UPDATE KYYEU 
                                  SET TenKyYeu = @TenKyYeu, ID_NhaXuatBan = @ID_NhaXuatBan, ID_HoiNghi = @ID_HoiNghi, ID_TaiLieu = @ID_TaiLieu 
                                  WHERE ID_KyYeu = @ID_KyYeu";
                    using (SqlCommand cmdKyYeu = new SqlCommand(queryKYYEU, conn, transaction))
                    {
                        cmdKyYeu.Parameters.AddWithValue("@ID_KyYeu", idKyYeu);
                        cmdKyYeu.Parameters.AddWithValue("@TenKyYeu", tenKyYeu);
                        cmdKyYeu.Parameters.AddWithValue("@ID_NhaXuatBan", idNhaXuatBan);
                        cmdKyYeu.Parameters.AddWithValue("@ID_HoiNghi", idHoiNghi);
                        cmdKyYeu.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);

                        cmdKyYeu.ExecuteNonQuery();
                    }

                    // Cập nhật dữ liệu vào bảng CHITIETTAILIEU
                    string queryCTTAILIEU = @"UPDATE CHITIETTAILIEU 
                                      SET ID_NKH = @ID_NKH, ID_VaiTro = @ID_VaiTro 
                                      WHERE ID_CTTaiLieu = @ID_CTTaiLieu";
                    using (SqlCommand cmdCTTaiLieu = new SqlCommand(queryCTTAILIEU, conn, transaction))
                    {
                        cmdCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", idCTTaiLieu);
                        cmdCTTaiLieu.Parameters.AddWithValue("@ID_NKH", idNKH);
                        cmdCTTaiLieu.Parameters.AddWithValue("@ID_VaiTro", idVaiTro);

                        cmdCTTaiLieu.ExecuteNonQuery();
                    }

                    // Xác nhận giao dịch
                    transaction.Commit();

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form và cập nhật dữ liệu
                    ResetFormKyYeu();
                    LoadDataKyYeu();
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaKY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKyYeu.Text))
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idKyYeu = txtMaKyYeu.Text.Trim();

            // Chuỗi kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // Xóa dữ liệu khỏi bảng CHITIETTAILIEU
                    string queryCTTAILIEU = @"DELETE FROM CHITIETTAILIEU WHERE ID_CTTaiLieu = @ID_CTTaiLieu";
                    using (SqlCommand cmdCTTaiLieu = new SqlCommand(queryCTTAILIEU, conn, transaction))
                    {
                        cmdCTTaiLieu.Parameters.AddWithValue("@ID_CTTaiLieu", txtMaCTTaiLieuKY.Text.Trim());
                        cmdCTTaiLieu.ExecuteNonQuery();
                    }

                    // Xóa dữ liệu khỏi bảng KYYEU
                    string queryKYYEU = @"DELETE FROM KYYEU WHERE ID_KyYeu = @ID_KyYeu";
                    using (SqlCommand cmdKyYeu = new SqlCommand(queryKYYEU, conn, transaction))
                    {
                        cmdKyYeu.Parameters.AddWithValue("@ID_KyYeu", idKyYeu);
                        cmdKyYeu.ExecuteNonQuery();
                    }

                    // Xác nhận giao dịch
                    transaction.Commit();

                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form và cập nhật dữ liệu
                    ResetFormKyYeu();
                    LoadDataKyYeu();
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction?.Rollback();
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtwKyYeu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào một hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dtwKyYeu.Rows[e.RowIndex];

                // Gán giá trị từ các cột vào TextBox
                txtMaKyYeu.Text = row.Cells["Mã kỷ yếu"]?.Value?.ToString();
                txtTenKyYeu.Text = row.Cells["Tên kỷ yếu"]?.Value?.ToString();
                cbxNXBKY.Text = row.Cells["Nhà xuất bản"]?.Value?.ToString();
                cbxHoiNghiKY.Text = row.Cells["Hội nghị"]?.Value?.ToString();
                cbxTaiLieuKY.Text = row.Cells["Mô tả tài liệu"]?.Value?.ToString();
                txtMaCTTaiLieuKY.Text = row.Cells["Mã CT tài liệu" + ""]?.Value?.ToString();


                // Hiển thị tên tác giả trong ComboBox
                cbxNKHKY.Text = row.Cells["Nhà khoa học"]?.Value?.ToString();

                // Hiển thị vai trò trong ComboBox
                cbxVaiTroKY.Text = row.Cells["Vai trò"]?.Value?.ToString();

               
            }
        }
        private void LoadDataTapChi()
        {
            try
            {
                // Truy vấn SQL với điều kiện lọc UserSession
                string query = @"
                    WITH CTE AS (
                        SELECT 
                            TAPCHI.ID_TapChi,
                            TAILIEU.ID_TaiLieu,
                            CHITIETTAILIEU.ID_CTTaiLieu,
                            TAPCHI.TenTapChi,
                            TAPCHI.KyDang,
                            TAILIEU.NoiDung,
                            TAILIEU.ChuyenNganh,
                            TAILIEU.MoTa,
                            NHAXUATBAN.TenNhaXuatBan,  -- Lấy tên nhà xuất bản từ bảng NHAXUATBAN
                            CHITIETXUATBAN.ID_CTXUATBAN,  -- Lấy ID từ bảng CHITIETXUATBAN
                            CHITIETXUATBAN.SoLuongXuatBan,  -- Lấy số lượng xuất bản từ bảng CHITIETXUATBAN
                            COQUANCHUQUAN.TenCoQuanChuQuan,
                            NHAKHOAHOC.TenNhaKhoaHoc,
                            VAITRO.TenVaiTro,
                            ROW_NUMBER() OVER (PARTITION BY CHITIETTAILIEU.ID_CTTaiLieu ORDER BY CHITIETTAILIEU.ID_CTTaiLieu) AS RowNumCTTaiLieu
                        FROM 
                            TAPCHI
                        LEFT JOIN TAILIEU ON TAPCHI.ID_TaiLieu = TAILIEU.ID_TaiLieu
                        LEFT JOIN CHITIETXUATBAN ON TAPCHI.ID_TapChi = CHITIETXUATBAN.ID_TapChi  -- JOIN bảng CHITIETXUATBAN
                        LEFT JOIN NHAXUATBAN ON NHAXUATBAN.ID_NhaXuatBan = CHITIETXUATBAN.ID_NhaXuatBan  -- JOIN bảng NHAXUATBAN
                        LEFT JOIN COQUANCHUQUAN ON TAPCHI.ID_CoQuanChuQuan = COQUANCHUQUAN.ID_CoQuanChuQuan
                        LEFT JOIN CHITIETTAILIEU ON TAILIEU.ID_TaiLieu = CHITIETTAILIEU.ID_TaiLieu
                        LEFT JOIN NHAKHOAHOC ON CHITIETTAILIEU.ID_NKH = NHAKHOAHOC.ID_NKH
                        LEFT JOIN VAITRO ON CHITIETTAILIEU.ID_VaiTro = VAITRO.ID_VaiTro
                        WHERE 
                            TAILIEU.ID_TaiKhoan = @ID_TaiKhoan -- Điều kiện lọc theo UserSession
                    )
                    SELECT 
                        ID_TapChi,
                        TenTapChi,
                        KyDang,
                        NoiDung,
                        ChuyenNganh,
                        MoTa,
                        TenNhaXuatBan,  -- Hiển thị tên nhà xuất bản
                        SoLuongXuatBan,
                        TenCoQuanChuQuan,
                        TenNhaKhoaHoc,
                        TenVaiTro,
                        ID_TaiLieu,
                        ID_CTTaiLieu,
                        ID_CTXUATBAN
                    FROM 
                        CTE
                    WHERE 
                        RowNumCTTaiLieu = 1
                    ORDER BY 
                        ID_TapChi;

                                    ";      

                // Sử dụng kết nối SQL
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Khởi tạo SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số ID_TaiKhoan từ UserSession
                        cmd.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);

                        // Sử dụng SqlDataAdapter để lấy dữ liệu
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Tạo DataTable và đổ dữ liệu vào
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Hiển thị dữ liệu lên DataGridView
                            dtwTapChi.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Xử lý lỗi liên quan đến SQL
                MessageBox.Show("Lỗi truy vấn cơ sở dữ liệu: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void LoadComboBoxMaTaiLieuTC()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT ID_TaiLieu, MoTa FROM TAILIEU WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
         

                    // Truyền tham số ID_TaiKhoan từ UserSession
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxTaiLieuTC.DataSource = dataTable;          
                    cbxTaiLieuTC.DisplayMember = "MoTa";  
                    cbxTaiLieuTC.ValueMember = "ID_TaiLieu";    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxNhaKhoaHocTC()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenNhaKhoaHoc FROM NHAKHOAHOC WHERE ID_TaiKhoan = @ID_TaiKhoan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    

                    // Truyền tham số ID_TaiKhoan từ UserSession
                    command.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxNKHTapChi.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxNKHTapChi.DisplayMember = "TenNhaKhoaHoc";   // Hiển thị cột TenCoQuanChuQuan
                    cbxNKHTapChi.ValueMember = "TenNhaKhoaHoc";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxVaiTroTC()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenVaiTro FROM VAITRO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxVaiTroTC.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxVaiTroTC.DisplayMember = "TenVaiTro";   // Hiển thị cột TenCoQuanChuQuan
                    cbxVaiTroTC.ValueMember = "TenVaiTro";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxNhaXuatBanTC()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            try
            {
                // Chuỗi kết nối đến cơ sở dữ liệu


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn lấy ID_VaiTro và TenVaiTro từ bảng VAITRO
                    string query = "SELECT ID_NhaXuatban, TenNhaXuatBan FROM NHAXUATBAN";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thực hiện lệnh SQL
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Tạo DataTable để chứa dữ liệu
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Gán DataTable làm nguồn dữ liệu cho ComboBox
                        cbxNhaXuatBan.DataSource = dt;
                        cbxNhaXuatBan.DisplayMember = "TenNhaXuatBan"; // Hiển thị cột TenVaiTro
                        cbxNhaXuatBan.ValueMember = "ID_NhaXuatban";

                     
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }
        private void LoadComboBoxCQCQTC()
        {// Truy vấn để lấy dữ liệu từ bảng COQUANCHUQUAN
            string query = "SELECT TenCoQuanChuQuan FROM COQUANCHUQUAN";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlCommand và SqlDataAdapter để thực thi truy vấn
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gắn dữ liệu vào ComboBox
                    cbxCQCQTC.DataSource = dataTable;               // Gắn DataTable làm nguồn dữ liệu
                    cbxCQCQTC.DisplayMember = "TenCoQuanChuQuan";   // Hiển thị cột TenCoQuanChuQuan
                    cbxCQCQTC.ValueMember = "TenCoQuanChuQuan";     // Lấy giá trị là TenCoQuanChuQuan (hoặc có thể là ID nếu cần)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu vào ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetIDNXBTC(string tenNhaXuatBanTC)
        {
            string idNXBTC = null;
            string query = "SELECT ID_NhaXuatBan FROM NHAXUATBAN WHERE TenNhaXuatBan = @TenNhaXuatBan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaXuatBan", tenNhaXuatBanTC);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    idNXBTC = result != null ? result.ToString() : null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NXB: " + ex.Message);
                }
            }

            return idNXBTC;
        }

        private string GetIDCQCQTC(string tenCoQuanChuQuanTC)
        {
            string idCQCQTC = string.Empty;
            string query = "SELECT ID_CoQuanChuQuan FROM COQUANCHUQUAN WHERE TenCoQuanChuQuan = @TenCoQuanChuQuan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenCoQuanChuQuan", tenCoQuanChuQuanTC);

                try
                {
                    connection.Open();
                    idCQCQTC = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_CQCQ: " + ex.Message);
                }
            }

            return idCQCQTC;
        }
        private string GetIDNKHTC(string tenNhaKhoaHocTC)
        {
            string idNKHTC = string.Empty;
            string query = "SELECT ID_NKH FROM NHAKHOAHOC WHERE TenNhaKhoaHoc = @TenNhaKhoaHoc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHocTC);

                try
                {
                    connection.Open();
                    idNKHTC = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NKH: " + ex.Message);
                }
            }

            return idNKHTC;
        }
        private string GetIDVTTC(string tenVaiTroTC)
        {
            string idVTTC = string.Empty;
            string query = "SELECT ID_VaiTro FROM VAITRO WHERE TenVaiTro = @TenVaiTro";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenVaiTro", tenVaiTroTC);

                try
                {
                    connection.Open();
                    idVTTC = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_NKH: " + ex.Message);
                }
            }

            return idVTTC;
        }
        private string GetIDTaiLieuTC(string moTa)
        {
            string idTaiLieu = string.Empty;
            string query = "SELECT ID_TaiLieu FROM TAILIEU WHERE MoTa = @MoTa";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    connection.Open();
                    idTaiLieu = command.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID_TaiLieu: " + ex.Message);
                }
            }

            return idTaiLieu;
        }
        private void btnThemTC_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các điều khiển trên giao diện
                int idTapChi = Convert.ToInt32(txtMaTapChi.Text);  // ID_TapChi từ txtMaTapChi
                int idCQCQTC = Convert.ToInt32(GetIDCQCQTC(cbxCQCQTC.Text));  // ID_CoQuanChuQuan từ ComboBox
               
                int idTaiLieu = Convert.ToInt32(GetIDTaiLieuTC(cbxTaiLieuTC.Text));  // ID_TaiLieu từ ComboBox
                string tenTapChi = txtTenTapChi.Text;  // TenTapChi từ txtTenTapChi
                DateTime kyDang = dateKyDang.Value;  // KyDang từ DateTimePicker
                int idCtxuAtBan = Convert.ToInt32(txtMaNXBTC.Text);  // ID_CTXUATBAN từ txtMaNXBTC
                int soLuongXuatBan = Convert.ToInt32(txtSoLuongXuatBan.Text);  // SoLuongXuatBan từ txtSoLuongXuatBan
                int idNXBTC = Convert.ToInt32(GetIDNXBTC(cbxNhaXuatBan.Text));  // ID_NhaXuatBan từ ComboBox
                int idNKHTC = Convert.ToInt32(GetIDNKHTC(cbxNKHTapChi.Text));  // ID_NKH từ ComboBox
                int idVTTC = Convert.ToInt32(GetIDVTTC(cbxVaiTroTC.Text));  // ID_VaiTro từ ComboBox
                int idCtTaiLieu = Convert.ToInt32(txtMaCTTaiLieuTC.Text);  // ID_CTTaiLieu từ txtMaCTTaiLieuTC

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Thực thi câu lệnh INSERT vào bảng TAPCHI
                    string queryTapChi = @"
                    INSERT INTO TAPCHI (ID_TapChi, TenTapChi, KyDang, ID_CoQuanChuQuan, ID_TaiLieu)
                    VALUES (@ID_TapChi, @TenTapChi, @KyDang, @ID_CoQuanChuQuan, @ID_TaiLieu)";

                    using (SqlCommand cmd = new SqlCommand(queryTapChi, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.Parameters.AddWithValue("@TenTapChi", tenTapChi);
                        cmd.Parameters.AddWithValue("@KyDang", kyDang);
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCQCQTC);
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmd.ExecuteNonQuery();
                    }

                    // Thực thi câu lệnh INSERT vào bảng CHITIETNHAXUATBAN
                    string queryChiTietNXB = @"
                    INSERT INTO CHITIETXUATBAN (ID_CTXUATBAN, SoLuongXuatBan, ID_NhaXuatBan, ID_TapChi)
                    VALUES (@ID_CTXUATBAN, @SoLuongXuatBan, @ID_NhaXuatBan, @ID_TapChi)";

                    using (SqlCommand cmd = new SqlCommand(queryChiTietNXB, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CTXUATBAN", idCtxuAtBan);
                        cmd.Parameters.AddWithValue("@SoLuongXuatBan", soLuongXuatBan);
                        cmd.Parameters.AddWithValue("@ID_NhaXuatBan", idNXBTC);
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.ExecuteNonQuery();
                    }

                    // Thực thi câu lệnh INSERT vào bảng CHITIETTAILIEU
                    string queryChiTietTaiLieu = @"
                    INSERT INTO CHITIETTAILIEU (ID_CTTaiLieu, ID_TaiLieu, ID_NKH, ID_VaiTro)
                    VALUES (@ID_CTTaiLieu, @ID_TaiLieu, @ID_NKH, @ID_VaiTro)";

                    using (SqlCommand cmd = new SqlCommand(queryChiTietTaiLieu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CTTaiLieu", idCtTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_NKH", idNKHTC);
                        cmd.Parameters.AddWithValue("@ID_VaiTro", idVTTC);
                        cmd.ExecuteNonQuery();
                    }

                    // Đóng kết nối
                    conn.Close();
                }
                LoadDataTapChi();
                // Thông báo thành công
                MessageBox.Show("Dữ liệu đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }

        private void btnSuaTC_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                int idTapChi = Convert.ToInt32(txtMaTapChi.Text);  // ID_TapChi từ txtMaTapChi
                string tenTapChi = txtTenTapChi.Text;  // Tên mới của tạp chí
                DateTime kyDang = dateKyDang.Value;  // Kỳ đăng mới
                int idCQCQTC = Convert.ToInt32(GetIDCQCQTC(cbxCQCQTC.Text));  // ID CoQuanChuQuan mới
                int idTaiLieu = Convert.ToInt32(GetIDTaiLieuTC(cbxTaiLieuTC.Text));  // ID TaiLieu mới

                int idCtxuAtBan = Convert.ToInt32(txtMaNXBTC.Text);  // ID_CTXUATBAN
                int soLuongXuatBan = Convert.ToInt32(txtSoLuongXuatBan.Text);  // Số lượng xuất bản mới
                int idNXBTC = Convert.ToInt32(GetIDNXBTC(cbxNhaXuatBan.Text));  // ID NXB mới

                int idNKHTC = Convert.ToInt32(GetIDNKHTC(cbxNKHTapChi.Text));  // ID Nhà khoa học mới
                int idVTTC = Convert.ToInt32(GetIDVTTC(cbxVaiTroTC.Text));  // ID Vai trò mới
                int idCtTaiLieu = Convert.ToInt32(txtMaCTTaiLieuTC.Text);  // ID_CTTaiLieu

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Cập nhật bảng TAPCHI
                    string querySuaTapChi = @"
                    UPDATE TAPCHI
                    SET TenTapChi = @TenTapChi, KyDang = @KyDang, ID_CoQuanChuQuan = @ID_CoQuanChuQuan, ID_TaiLieu = @ID_TaiLieu
                    WHERE ID_TapChi = @ID_TapChi";
                    using (SqlCommand cmd = new SqlCommand(querySuaTapChi, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenTapChi", tenTapChi);
                        cmd.Parameters.AddWithValue("@KyDang", kyDang);
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCQCQTC);
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật bảng CHITIETNHAXUATBAN
                    string querySuaChiTietXuatBan = @"
                    UPDATE CHITIETXUATBAN
                    SET SoLuongXuatBan = @SoLuongXuatBan, ID_NhaXuatBan = @ID_NhaXuatBan
                    WHERE ID_CTXUATBAN = @ID_CTXUATBAN";
                    using (SqlCommand cmd = new SqlCommand(querySuaChiTietXuatBan, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoLuongXuatBan", soLuongXuatBan);
                        cmd.Parameters.AddWithValue("@ID_NhaXuatBan", idNXBTC);
                        cmd.Parameters.AddWithValue("@ID_CTXUATBAN", idCtxuAtBan);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật bảng CHITIETTAILIEU
                    string querySuaChiTietTaiLieu = @"
                    UPDATE CHITIETTAILIEU
                    SET ID_TaiLieu = @ID_TaiLieu, ID_NKH = @ID_NKH, ID_VaiTro = @ID_VaiTro
                    WHERE ID_CTTaiLieu = @ID_CTTaiLieu";
                    using (SqlCommand cmd = new SqlCommand(querySuaChiTietTaiLieu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", idTaiLieu);
                        cmd.Parameters.AddWithValue("@ID_NKH", idNKHTC);
                        cmd.Parameters.AddWithValue("@ID_VaiTro", idVTTC);
                        cmd.Parameters.AddWithValue("@ID_CTTaiLieu", idCtTaiLieu);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                LoadDataTapChi();
                MessageBox.Show("Sửa dữ liệu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
        }

        private void btnXoaTC_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID cần xóa từ TextBox hoặc một ComboBox
                int idTapChi = Convert.ToInt32(txtMaTapChi.Text);  // ID_TapChi từ txtMaTapChi

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Xóa dữ liệu trong bảng CHITIETNHAXUATBAN trước
                    string queryXoaChiTietXuatBan = "DELETE FROM CHITIETXUATBAN WHERE ID_TapChi = @ID_TapChi";
                    using (SqlCommand cmd = new SqlCommand(queryXoaChiTietXuatBan, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa dữ liệu trong bảng CHITIETTAILIEU trước
                    string queryXoaChiTietTaiLieu = "DELETE FROM CHITIETTAILIEU WHERE ID_TaiLieu IN (SELECT ID_TaiLieu FROM TAPCHI WHERE ID_TapChi = @ID_TapChi)";
                    using (SqlCommand cmd = new SqlCommand(queryXoaChiTietTaiLieu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.ExecuteNonQuery();
                    }

                    // Sau cùng xóa trong bảng TAPCHI
                    string queryXoaTapChi = "DELETE FROM TAPCHI WHERE ID_TapChi = @ID_TapChi";
                    using (SqlCommand cmd = new SqlCommand(queryXoaTapChi, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_TapChi", idTapChi);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                LoadDataTapChi();
                MessageBox.Show("Xóa dữ liệu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }

        private void dtwTapChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra xem hàng được chọn có hợp lệ không
                if (e.RowIndex >= 0)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow row = dtwTapChi.Rows[e.RowIndex];
                    cbxTaiLieuTC.Text = row.Cells["MoTa"].Value.ToString();
                    txtMaCTTaiLieuTC.Text = row.Cells["ID_CTTaiLieu"].Value.ToString();

                    txtMaNXBTC.Text = row.Cells["ID_CTXUATBAN"].Value.ToString();
                    // Gán dữ liệu vào các điều khiển
                    txtMaTapChi.Text = row.Cells["ID_TapChi"].Value?.ToString();  // ID_TapChi
                    txtTenTapChi.Text = row.Cells["TenTapChi"].Value?.ToString();  // TenTapChi
                    dateKyDang.Value = Convert.ToDateTime(row.Cells["KyDang"].Value);  // KyDang
                    cbxCQCQTC.Text = row.Cells["TenCoQuanChuQuan"].Value?.ToString();  // Tên cơ quan chủ quản


                    txtSoLuongXuatBan.Text = row.Cells["SoLuongXuatBan"].Value?.ToString();  // Số lượng xuất bản
                    cbxNhaXuatBan.Text = row.Cells["TenNhaXuatBan"].Value?.ToString();  // Tên nhà xuất bản
                    cbxNKHTapChi.Text = row.Cells["TenNhaKhoaHoc"].Value?.ToString();  // Tên nhà khoa học
                    cbxVaiTroTC.Text = row.Cells["TenVaiTro"].Value?.ToString();  // Vai trò

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message);
            }
        }

        private void btnSuaGT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGiaoTrinh.Text))
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = @"
                        UPDATE GIAOTRINH 
                        SET ID_TaiLieu = @ID_TaiLieu, ID_CoQuanChuQuan = @ID_CoQuanChuQuan, TenGiaoTrinh = @TenGiaoTrinh, 
                            NgayKyHopDong = @NgayKyHopDong, NgayKetThuc = @NgayKetThuc, NoiDang = @NoiDang
                        WHERE ID_GiaoTrinh = @ID_GiaoTrinh;

                        UPDATE CHITIETTAILIEU 
                        SET ID_NKH = @ID_NKH, ID_VaiTro = @ID_VaiTro
                        WHERE ID_CTTaiLieu = @ID_CTTaiLieu;";
                       
                        cmd.Parameters.AddWithValue("@ID_GiaoTrinh", txtMaGiaoTrinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ID_TaiLieu", Convert.ToInt32(GetIDTaiLieu(cbxTaiLieuGT.Text)));
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", Convert.ToInt32(GetIDCQCQGT(cbxCQCQGT.Text)));
                        cmd.Parameters.AddWithValue("@TenGiaoTrinh", txtTenGiaoTrinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgayKyHopDong", dateKyHopDong.Value);
                        cmd.Parameters.AddWithValue("@NgayKetThuc", dateKetThuc.Value);
                        cmd.Parameters.AddWithValue("@NoiDang", rbtHoiNghiGT.Checked ? "Hội nghị" : "Tạp chí");
                        cmd.Parameters.AddWithValue("@ID_CTTaiLieu", txtMaCTTaiLieuGT.Text.Trim());
                        cmd.Parameters.AddWithValue("@ID_NKH", Convert.ToInt32(GetIDNKHGT(cbxTenNKHGT.Text)));
                        cmd.Parameters.AddWithValue("@ID_VaiTro", Convert.ToInt32(GetIDFromVaiTroGT(cbxVaiTroGT.Text)));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDatadtwGiaoTrinh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaGT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGiaoTrinh.Text))
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = connection;
                            cmd.CommandText = @"
                        DELETE FROM CHITIETTAILIEU WHERE ID_CTTaiLieu = @ID_CTTaiLieu;
                        DELETE FROM GIAOTRINH WHERE ID_GiaoTrinh = @ID_GiaoTrinh;";

                            cmd.Parameters.AddWithValue("@ID_GiaoTrinh", txtMaGiaoTrinh.Text.Trim());
                            cmd.Parameters.AddWithValue("@ID_CTTaiLieu", txtMaCTTaiLieuGT.Text.Trim());

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatadtwGiaoTrinh();
                        ClearDataGiaoTrinh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtwGiaoTrinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtwGiaoTrinh.Rows[e.RowIndex];

                txtMaGiaoTrinh.Text = row.Cells["Mã giáo trình"].Value?.ToString();
             
                cbxCQCQGT.Text = row.Cells["Tên cơ quan chủ quản"].Value?.ToString();
                txtTenGiaoTrinh.Text = row.Cells["Tên giáo trình"].Value?.ToString();
                dateKyHopDong.Value = Convert.ToDateTime(row.Cells["Ngày ký hợp đồng"].Value);
                dateKetThuc.Value = Convert.ToDateTime(row.Cells["Ngày kết thúc"].Value);
            
                cbxTenNKHGT.Text = row.Cells["Tên nhà khoa học"].Value?.ToString();
                cbxVaiTroGT.Text = row.Cells["Vai trò"].Value?.ToString();
                cbxTaiLieuGT.Text = row.Cells["Mô tả tài liệu"].Value?.ToString();
                txtMaCTTaiLieuGT.Text = row.Cells["Mã CT tài liệu"].Value?.ToString();
                if (row.Cells["Nơi đăng"].Value?.ToString() == "Hội nghị")
                {
                    rbtHoiNghiGT.Checked = true;
                }
                else if (row.Cells["Nơi đăng"].Value?.ToString() == "Tạp chí")
                {
                    rbtTapChiGT.Checked = true;
                }
            }
        }
        private void ClearDataGiaoTrinh()
        {
            txtMaGiaoTrinh.Clear();
            txtTenGiaoTrinh.Clear();
            txtMaCTTaiLieuGT.Clear();
            cbxTaiLieuGT.SelectedIndex = -1;
            cbxCQCQGT.SelectedIndex = -1;
            cbxTenNKHGT.SelectedIndex = -1;
            cbxVaiTroGT.SelectedIndex = -1;
            rbtHoiNghiGT.Checked = false;
            rbtTapChiGT.Checked = false;
            dateKyHopDong.Value = DateTime.Now;
            dateKetThuc.Value = DateTime.Now;
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn một file",
                Filter = "Tất cả các file (*.*)|*.*", // Bộ lọc file
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            // Kiểm tra xem người dùng đã chọn file hay chưa
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file được chọn và hiển thị trong textbox1
                txtNoiDung.Text = openFileDialog.FileName;
            }
        }

        private void cbxTaiLieuTC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

