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
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using static SciDoc_Mgmt.frmDangNhap;
namespace SciDoc_Mgmt
{
    public partial class frmThongKe : Form
    {
       
        public frmThongKe()
        {
            InitializeComponent();
            LoadDataToComboBox();
            dropdownLoaiThongKe();
        }
        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        private void dropdownLoaiThongKe()
        {
            // Thêm các mục vào ComboBox
            cbxLoaiThongKe.Items.Add("Loại tài liệu");
            cbxLoaiThongKe.Items.Add("Nhà khoa học");
        }
            
        private void LoadDataToComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Load dữ liệu vào cbxLoaiTaiLieu
                    if (cbxLoaiTaiLieu != null)
                    {
                        string queryLoaiTaiLieu = "SELECT DISTINCT LoaiTaiLieu FROM TAILIEU WHERE ID_TaiKhoan = @TaiKhoan";
                        DataTable dataTableLoaiTaiLieu = new DataTable();

                        using (SqlCommand command = new SqlCommand(queryLoaiTaiLieu, connection))
                        {
                            command.Parameters.AddWithValue("@TaiKhoan", UserSession.ID_TaiKhoan);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dataTableLoaiTaiLieu);
                            }
                        }

                        if (dataTableLoaiTaiLieu.Rows.Count > 0)
                        {
                            cbxLoaiTaiLieu.DataSource = dataTableLoaiTaiLieu;
                            cbxLoaiTaiLieu.DisplayMember = "LoaiTaiLieu";
                            cbxLoaiTaiLieu.ValueMember = "LoaiTaiLieu";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu loại tài liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    // Load dữ liệu vào cbxNhaKhoaHoc
                    if (cbxNhaKhoaHoc != null)
                    {
                        string queryNhaKhoaHoc = "SELECT TenNhaKhoaHoc FROM NHAKHOAHOC WHERE ID_TaiKhoan = @TaiKhoan";
                        DataTable dataTableNhaKhoaHoc = new DataTable();

                        using (SqlCommand command = new SqlCommand(queryNhaKhoaHoc, connection))
                        {
                            command.Parameters.AddWithValue("@TaiKhoan", UserSession.ID_TaiKhoan);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dataTableNhaKhoaHoc);
                            }
                        }

                        if (dataTableNhaKhoaHoc.Rows.Count > 0)
                        {
                            cbxNhaKhoaHoc.DataSource = dataTableNhaKhoaHoc;
                            cbxNhaKhoaHoc.DisplayMember = "TenNhaKhoaHoc";
                            cbxNhaKhoaHoc.ValueMember = "TenNhaKhoaHoc";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu nhà khoa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy loại thống kê từ ComboBox
            string loaiThongKe = cbxLoaiThongKe.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(loaiThongKe))
            {
                MessageBox.Show("Vui lòng chọn loại thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo câu truy vấn
            string query = "";
            SqlCommand queryCommand = new SqlCommand(); // Dùng để chuẩn bị tham số và câu truy vấn
            queryCommand.Parameters.AddWithValue("@ID_TaiKhoan", UserSession.ID_TaiKhoan); // Gắn ID_TaiKhoan từ UserSession

            // Trường hợp thống kê theo "Loại tài liệu"
            if (loaiThongKe == "Loại tài liệu")
            {
                string loaiTaiLieu = cbxLoaiTaiLieu.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(loaiTaiLieu))
                {
                    MessageBox.Show("Vui lòng chọn loại tài liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = @"
            SELECT 
                LoaiTaiLieu AS [Loại Tài Liệu], 
                COUNT(*) AS [Số Lượng Tài Liệu], 
                MoTa AS [Mô Tả], 
                NamXuatBan AS [Năm Xuất Bản], 
                ChuyenNganh AS [Chuyên Ngành]
            FROM 
                TAILIEU
            WHERE 
                LoaiTaiLieu = @LoaiTaiLieu AND ID_TaiKhoan = @ID_TaiKhoan
            GROUP BY 
                LoaiTaiLieu, MoTa, NamXuatBan, ChuyenNganh
        ";

                queryCommand.Parameters.AddWithValue("@LoaiTaiLieu", loaiTaiLieu);
            }
            // Trường hợp thống kê theo "Nhà khoa học"
            else if (loaiThongKe == "Nhà khoa học")
            {
                string tenNhaKhoaHoc = cbxNhaKhoaHoc.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(tenNhaKhoaHoc))
                {
                    MessageBox.Show("Vui lòng chọn nhà khoa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = @"
            SELECT 
                NKH.TenNhaKhoaHoc AS [Nhà Khoa Học], 
                COUNT(*) AS [Số Bài Đăng], 
                NKH.HocVi AS [Học Vị], 
                NKH.LinhVuc AS [Lĩnh Vực], 
                T.LoaiTaiLieu AS [Loại Tài Liệu],
                T.NamXuatBan AS [Năm Xuất Bản],
                T.ChuyenNganh AS [Chuyên Ngành], 
                VT.TenVaiTro AS [Vai Trò]
            FROM 
                CHITIETTAILIEU CTT
            INNER JOIN 
                NHAKHOAHOC NKH ON CTT.ID_NKH = NKH.ID_NKH
            INNER JOIN 
                TAILIEU T ON CTT.ID_TaiLieu = T.ID_TaiLieu
            INNER JOIN 
                VAITRO VT ON CTT.ID_VaiTro = VT.ID_VaiTro
            WHERE 
                NKH.TenNhaKhoaHoc = @TenNhaKhoaHoc AND NKH.ID_TaiKhoan = @ID_TaiKhoan
            GROUP BY 
                NKH.TenNhaKhoaHoc, 
                NKH.HocVi, 
                NKH.LinhVuc, 
                T.LoaiTaiLieu, 
                T.NamXuatBan,
                T.ChuyenNganh, 
                VT.TenVaiTro
        ";

                queryCommand.Parameters.AddWithValue("@TenNhaKhoaHoc", tenNhaKhoaHoc);
            }
            else
            {
                MessageBox.Show("Loại thống kê không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện truy vấn và hiển thị kết quả
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    queryCommand.Connection = connection;
                    queryCommand.CommandText = query;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryCommand))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Kiểm tra dữ liệu và gán vào DataGridView
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu. Vui lòng kiểm tra lại các điều kiện lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvThongKe.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxLoaiTaiLieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxLoaiTaiLieu_DropDown(object sender, EventArgs e)
        {

        }

        

       
        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Thống kê");

                        // Xuất tiêu đề cột
                        for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvThongKe.Columns[i].HeaderText;
                        }

                        // Xuất dữ liệu từ DataGridView
                        for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                            {
                                var cellValue = dgvThongKe.Rows[i].Cells[j].Value;

                                // Kiểm tra và chuyển kiểu cho cellValue trước khi gán
                                if (cellValue != null)
                                {
                                    if (cellValue is string)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = (string)cellValue;
                                    }
                                    else if (cellValue is int)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = (int)cellValue;
                                    }
                                    else if (cellValue is double)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = (double)cellValue;
                                    }
                                    else
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = cellValue.ToString();
                                    }
                                }
                                else
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = ""; // Nếu không có dữ liệu
                                }
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
