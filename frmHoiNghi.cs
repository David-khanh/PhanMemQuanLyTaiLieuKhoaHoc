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
    public partial class frmHoiNghi : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=QL_TAILIEUKH;Integrated Security=True;";
        public frmHoiNghi()
        {
            InitializeComponent();
            LoadDataHoiNghi();
            ClearData();
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaHoiNghi.Text) ||
                string.IsNullOrEmpty(txtTenHoiNghi.Text) ||
                string.IsNullOrEmpty(txtCapHoiNghi.Text) ||
                string.IsNullOrEmpty(txtDiaDiem.Text) ||
                string.IsNullOrEmpty(dateNgayToChuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            int idHoiNghi = int.Parse(txtMaHoiNghi.Text);  // ID hội nghị do người dùng nhập vào
            string tenHoiNghi = txtTenHoiNghi.Text;
            DateTime ngayToChuc = DateTime.Parse(dateNgayToChuc.Text);
            string capHoiNghi = txtCapHoiNghi.Text;
            string diaDiem = txtDiaDiem.Text;

            // Chuỗi kết nối cơ sở dữ liệu
            string query = @"INSERT INTO HOINGHI (ID_HoiNghi, TenHoiNghi, NgayToChuc, CapHoiNghi, DiaDiem) 
                     VALUES (@ID_HoiNghi, @TenHoiNghi, @NgayToChuc, @CapHoiNghi, @DiaDiem)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_HoiNghi", idHoiNghi);
                        cmd.Parameters.AddWithValue("@TenHoiNghi", tenHoiNghi);
                        cmd.Parameters.AddWithValue("@NgayToChuc", ngayToChuc);
                        cmd.Parameters.AddWithValue("@CapHoiNghi", capHoiNghi);
                        cmd.Parameters.AddWithValue("@DiaDiem", diaDiem);

                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh thêm
                    }

                    MessageBox.Show("Thêm hội nghị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataHoiNghi(); // Cập nhật lại DataGridView
                    ClearData(); // Xóa dữ liệu trong các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hội nghị: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện nhập liệu
            if (string.IsNullOrEmpty(txtMaHoiNghi.Text) ||
                string.IsNullOrEmpty(txtTenHoiNghi.Text) ||
                string.IsNullOrEmpty(txtCapHoiNghi.Text) ||
                string.IsNullOrEmpty(txtDiaDiem.Text) ||
                string.IsNullOrEmpty(dateNgayToChuc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            int idHoiNghi = int.Parse(txtMaHoiNghi.Text); // ID hội nghị do người dùng nhập vào
            string tenHoiNghi = txtTenHoiNghi.Text;
            DateTime ngayToChuc = DateTime.Parse(dateNgayToChuc.Text);
            string capHoiNghi = txtCapHoiNghi.Text;
            string diaDiem = txtDiaDiem.Text;

            // Chuỗi kết nối cơ sở dữ liệu
            string query = @"UPDATE HOINGHI 
                     SET TenHoiNghi = @TenHoiNghi, NgayToChuc = @NgayToChuc, 
                         CapHoiNghi = @CapHoiNghi, DiaDiem = @DiaDiem
                     WHERE ID_HoiNghi = @ID_HoiNghi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_HoiNghi", idHoiNghi);
                        cmd.Parameters.AddWithValue("@TenHoiNghi", tenHoiNghi);
                        cmd.Parameters.AddWithValue("@NgayToChuc", ngayToChuc);
                        cmd.Parameters.AddWithValue("@CapHoiNghi", capHoiNghi);
                        cmd.Parameters.AddWithValue("@DiaDiem", diaDiem);
                        // ID hội nghị cần sửa

                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh sửa
                    }

                    MessageBox.Show("Sửa hội nghị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataHoiNghi(); // Cập nhật lại DataGridView
                    ClearData(); // Xóa dữ liệu trong các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa hội nghị: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaNXB_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn dòng nào
            if (string.IsNullOrEmpty(txtMaHoiNghi.Text))
            {
                MessageBox.Show("Vui lòng chọn hội nghị để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idHoiNghi = int.Parse(txtMaHoiNghi.Text); // ID hội nghị cần xóa

            // Chuỗi kết nối cơ sở dữ liệu
            string query = @"DELETE FROM HOINGHI WHERE ID_HoiNghi = @ID_HoiNghi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_HoiNghi", idHoiNghi); // ID hội nghị cần xóa

                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh xóa
                    }

                    MessageBox.Show("Xóa hội nghị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataHoiNghi(); // Cập nhật lại DataGridView
                    ClearData(); // Xóa dữ liệu trong các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hội nghị: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataHoiNghi()
        {
            // Lấy dữ liệu từ cơ sở dữ liệu và hiển thị vào DataGridView
            string query = "SELECT * FROM HOINGHI";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dtwHoiNghi.DataSource = dataTable;
            }
        }
        private void ClearData()
        {
            txtMaHoiNghi.Clear();
            txtTenHoiNghi.Clear();
            txtCapHoiNghi.Clear();
            txtDiaDiem.Clear();
            dateNgayToChuc.Value = DateTime.Now;
        }

        private void dtwHoiNghi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ các ô của dòng đã chọn và điền vào các TextBox
                txtMaHoiNghi.Text = dtwHoiNghi.Rows[e.RowIndex].Cells["ID_HoiNghi"].Value.ToString();
                txtTenHoiNghi.Text = dtwHoiNghi.Rows[e.RowIndex].Cells["TenHoiNghi"].Value.ToString();

                // Cập nhật giá trị trong DateTimePicker
                dateNgayToChuc.Value = Convert.ToDateTime(dtwHoiNghi.Rows[e.RowIndex].Cells["NgayToChuc"].Value);

                txtCapHoiNghi.Text = dtwHoiNghi.Rows[e.RowIndex].Cells["CapHoiNghi"].Value.ToString();
                txtDiaDiem.Text = dtwHoiNghi.Rows[e.RowIndex].Cells["DiaDiem"].Value.ToString();
            }
        }

        private void dtwHoiNghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
