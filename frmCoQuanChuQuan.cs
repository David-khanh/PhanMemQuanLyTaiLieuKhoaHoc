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
    public partial class frmCoQuanChuQuan : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        public frmCoQuanChuQuan()
        {
            InitializeComponent();
            LoadDataCoQuan();
            ClearData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            
        if (string.IsNullOrEmpty(txtMaCoQuanChuQuan.Text) ||
            string.IsNullOrEmpty(txtTenCoQuanChuQuan.Text) ||
            string.IsNullOrEmpty(txtLoaiCoQuan.Text) ||
            string.IsNullOrEmpty(txtKhoaCoQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ TextBox
            int idCoQuan = int.Parse(txtMaCoQuanChuQuan.Text);
            string tenCoQuan = txtTenCoQuanChuQuan.Text;
            string loaiCoQuan = txtLoaiCoQuan.Text;
            string khoa = txtKhoaCoQuan.Text;

            // Thêm dữ liệu vào cơ sở dữ liệu
            string query = "INSERT INTO COQUANCHUQUAN (ID_CoQuanChuQuan, TenCoQuanChuQuan, LoaiCoQuan, Khoa) " +
                           "VALUES (@ID_CoQuanChuQuan, @TenCoQuanChuQuan, @LoaiCoQuan, @Khoa)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuan);
                        cmd.Parameters.AddWithValue("@TenCoQuanChuQuan", tenCoQuan);
                        cmd.Parameters.AddWithValue("@LoaiCoQuan", loaiCoQuan);
                        cmd.Parameters.AddWithValue("@Khoa", khoa);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm cơ quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm cơ quan: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load lại dữ liệu
            LoadDataCoQuan();
            ClearData();
        }

        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaCoQuanChuQuan.Text) ||
                string.IsNullOrEmpty(txtTenCoQuanChuQuan.Text) ||
                string.IsNullOrEmpty(txtLoaiCoQuan.Text) ||
                string.IsNullOrEmpty(txtKhoaCoQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ TextBox
            int idCoQuan = int.Parse(txtMaCoQuanChuQuan.Text);
            string tenCoQuan = txtTenCoQuanChuQuan.Text;
            string loaiCoQuan = txtLoaiCoQuan.Text;
            string khoa = txtKhoaCoQuan.Text;

            // Sửa dữ liệu trong cơ sở dữ liệu
            string query = "UPDATE COQUANCHUQUAN SET TenCoQuanChuQuan = @TenCoQuanChuQuan, LoaiCoQuan = @LoaiCoQuan, Khoa = @Khoa " +
                           "WHERE ID_CoQuanChuQuan = @ID_CoQuanChuQuan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuan);
                        cmd.Parameters.AddWithValue("@TenCoQuanChuQuan", tenCoQuan);
                        cmd.Parameters.AddWithValue("@LoaiCoQuan", loaiCoQuan);
                        cmd.Parameters.AddWithValue("@Khoa", khoa);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa cơ quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa cơ quan: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load lại dữ liệu
            LoadDataCoQuan();
            ClearData();
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaCoQuanChuQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập ID cơ quan cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID cơ quan từ TextBox
            int idCoQuan = int.Parse(txtMaCoQuanChuQuan.Text);

            // Xóa cơ quan trong cơ sở dữ liệu
            string query = "DELETE FROM COQUANCHUQUAN WHERE ID_CoQuanChuQuan = @ID_CoQuanChuQuan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CoQuanChuQuan", idCoQuan);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa cơ quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy cơ quan cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa cơ quan: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Load lại dữ liệu
            LoadDataCoQuan();
            ClearData();
        }
        private void LoadDataCoQuan()
        {
            string query = "SELECT * FROM COQUANCHUQUAN";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dtwCQCQ.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearData()
        {
            txtMaCoQuanChuQuan.Clear();
            txtTenCoQuanChuQuan.Clear();
            txtLoaiCoQuan.Clear();
            txtKhoaCoQuan.Clear();
        }

        private void dtwCQCQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ các ô của dòng đã chọn và điền vào các TextBox
                txtMaCoQuanChuQuan.Text = dtwCQCQ.Rows[e.RowIndex].Cells["ID_CoQuanChuQuan"].Value.ToString();
                txtTenCoQuanChuQuan.Text = dtwCQCQ.Rows[e.RowIndex].Cells["TenCoQuanChuQuan"].Value.ToString();
                txtLoaiCoQuan.Text = dtwCQCQ.Rows[e.RowIndex].Cells["LoaiCoQuan"].Value.ToString();
                txtKhoaCoQuan.Text = dtwCQCQ.Rows[e.RowIndex].Cells["Khoa"].Value.ToString();
            }
        }
    }
}
