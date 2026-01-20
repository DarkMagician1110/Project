using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Quanlithuvien
{
    public partial class BorrowAndReturn : UserControl
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter myAdapter;
        private DataSet ds;
        private DataTable dt;

        public BorrowAndReturn()
        {
            InitializeComponent();
        }

        private void BorrowAndReturn_Load(object sender, EventArgs e)
        {
            cboOption.SelectedIndex = 0;
            LoadData("SELECT * FROM PHIEUMUON");
        }

        private void LoadData(string query)
        {
            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                myAdapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "PHIEUMUON");
                dt = ds.Tables["PHIEUMUON"];
                dgvBorrow_Return.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

            dgvBorrow_Return.ClearSelection();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearchName.Text;
            string query = "";

            switch (cboOption.SelectedItem.ToString())
            {
                case "AccessionNo":
                    query = "SELECT * FROM PHIEUMUON WHERE AccessionNo LIKE '%" + key + "%'";
                    break;
                case "MaKH":
                    query = "SELECT * FROM PHIEUMUON WHERE MaKH LIKE '%" + key + "%'";
                    break;
                case "IDNV":
                    query = "SELECT * FROM PHIEUMUON WHERE IDNV LIKE '%" + key + "%'";
                    break;
            }

            LoadData(query);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string key = txtSearchName.Text;
            string query = "";

            switch (cboOption.SelectedItem.ToString())
            {
                case "AccessionNo":
                    query = "SELECT * FROM PHIEUMUON WHERE AccessionNo LIKE '%" + key + "%'";
                    break;
                case "MaKH":
                    query = "SELECT * FROM PHIEUMUON WHERE MaKH LIKE '%" + key + "%'";
                    break;
                case "IDNV":
                    query = "SELECT * FROM PHIEUMUON WHERE IDNV LIKE '%" + key + "%'";
                    break;
            }

            LoadData(query);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            string idBook = txtIDBook.Text.Trim();

            if (idBook == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách!");
                return;
            }

            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                // 1. Kiểm tra sách có sẵn
                string queryCheck =
                    "SELECT COUNT(*) FROM SACH WHERE AccessionNo = @idBook AND TinhTrang = 0";
                cmd = new SqlCommand(queryCheck, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count <= 0)
                {
                    MessageBox.Show("Sách không thể mượn được.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Sách có thể mượn. Bạn có chắc muốn mượn không?",
                    "Xác nhận mượn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                //3. Kiểm tra nhân viên có còn lam việc không
                string queryNV =
                    "SELECT COUNT(*) FROM THUTHU WHERE MaNV = @MaNV AND TrangThai = 1";
                cmd = new SqlCommand(queryNV, conn);
                cmd.Parameters.AddWithValue("@MaNV", txtIDEmployee.Text);
                int countNV = Convert.ToInt32(cmd.ExecuteScalar());
                if (countNV <= 0)
                {
                    MessageBox.Show("Nhân viên không còn làm việc.");
                    return;
                }

                // KIỂM TRA KHÁC HÀNG CÓ CÒN HOẠT ĐỘNG KHÔNG
                string queryKH =
                    "SELECT COUNT(*) FROM DOCGIA WHERE MaKH = @MaKH AND TrangThai = 1";
                cmd = new SqlCommand(queryKH, conn);
                cmd.Parameters.AddWithValue("@MaKH", txtIDReader.Text);
                int countKH = Convert.ToInt32(cmd.ExecuteScalar());
                if (countKH <= 0)
                {
                    MessageBox.Show("Khách hàng không còn hoạt động.");
                    return;
                }

                // 2. Cập nhật trạng thái sách
                string updateSach =
                    "UPDATE SACH SET TinhTrang = 1 WHERE AccessionNo = @idBook";
                cmd = new SqlCommand(updateSach, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);
                cmd.ExecuteNonQuery();

                // 4. Thêm phiếu mượn
                string insertPhieuMuon =
                    @"INSERT INTO PHIEUMUON (AccessionNo, MaKH, IDNV, NgayMuon)
              VALUES (@idBook, @maKH, @idNV, @ngayMuon)";
                cmd = new SqlCommand(insertPhieuMuon, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);
                cmd.Parameters.AddWithValue("@maKH", txtIDReader.Text);
                cmd.Parameters.AddWithValue("@idNV", txtIDEmployee.Text);
                cmd.Parameters.AddWithValue("@ngayMuon", DateTime.Now);

                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Mượn sách thành công.");
                    LoadData("SELECT * FROM PHIEUMUON");
                    GeneralMethod.ResetText(new List<Control>
            {
                txtIDBook,
                txtIDReader,
                txtIDEmployee
            });
                }
                else
                {
                    MessageBox.Show("Mượn sách thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mượn sách: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string idBook = txtIDBook.Text.Trim();

            if (idBook == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách!");
                return;
            }

            try
            {
                DBConnect dbConnect = new DBConnect();
                conn = dbConnect.GetConnection();
                conn.Open();

                // 1. Kiểm tra tình trạng sách
                string queryTinhTrang =
                    "SELECT TinhTrang FROM SACH WHERE AccessionNo = @idBook";
                cmd = new SqlCommand(queryTinhTrang, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);

                object resultTinhTrang = cmd.ExecuteScalar();
                if (resultTinhTrang == null)
                {
                    MessageBox.Show("Không tìm thấy sách.");
                    return;
                }

                int tinhTrang = Convert.ToInt32(resultTinhTrang);
                if (tinhTrang == 0)
                {
                    MessageBox.Show("Sách đang sẵn sàng, không thể trả.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn trả sách không?",
                    "Xác nhận trả",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No) return;

                // 2. Cập nhật sách
                string updateSach =
                    "UPDATE SACH SET TinhTrang = 0 WHERE AccessionNo = @idBook";
                cmd = new SqlCommand(updateSach, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);
                cmd.ExecuteNonQuery();

                // 3. Cập nhật phiếu mượn
                string updatePhieuMuon =
                    @"UPDATE PHIEUMUON
              SET NgayTra = @ngayTra
              WHERE AccessionNo = @idBook AND NgayTra IS NULL";
                cmd = new SqlCommand(updatePhieuMuon, conn);
                cmd.Parameters.AddWithValue("@idBook", idBook);
                cmd.Parameters.AddWithValue("@ngayTra", DateTime.Now);

                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    MessageBox.Show("Trả sách thành công.");
                    LoadData("SELECT * FROM PHIEUMUON");
                    GeneralMethod.ResetText(new System.Collections.Generic.List<Control>
            {
                txtIDBook,
                txtIDReader,
                txtIDEmployee
            });
                }
                else
                {
                    MessageBox.Show("Trả sách thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trả sách: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dgvBorrow_Return_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBorrow_Return.Rows[e.RowIndex];
                txtIDBook.Text = row.Cells["AccessionNo"].Value.ToString();
                txtIDReader.Text = row.Cells["MaKH"].Value.ToString();
                txtIDEmployee.Text = row.Cells["IDNV"].Value.ToString();
            }
        }
    }
}
