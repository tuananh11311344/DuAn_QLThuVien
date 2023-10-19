using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Menu
{
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void hiendl()
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuNhap", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void hienncc()
        {
            SqlCommand cmd = new SqlCommand("select *from NhaCungCap", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbNhaCC.DataSource = dt;
            cbNhaCC.DisplayMember = "TenNhaCC";
            cbNhaCC.ValueMember = "MaNhaCC";
        }
        public void hiennv()
        {
            SqlCommand cmd = new SqlCommand("select *from NhanVien", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";
        }
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            hiendl();
            hienncc();
            hiennv();
        }

        private void PhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into PhieuNhap(MaPhieuNhap,NgayLap,MaNhaCC,MaNV) values(@MaPhieuNhap,@NgayLap,@MaNhaCC,@MaNV)", con);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", txtMaPhieu.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@MaNhaCC", cbNhaCC.SelectedValue);
                cmd.Parameters.AddWithValue("@MaNV", cbMaNV.SelectedValue);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Chuyển qua Form phiếu nhập sách để hoàn thành việc nhập sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PhieuNhap_Sach pns = new PhieuNhap_Sach();
                    pns.Show();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã phiếu trong hệ thống.Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            txtMaPhieu.Text = dataGridView1.Rows[dongchon].Cells["MaPhieuNhap"].Value.ToString();
            dtpNgayLap.Value = Convert.ToDateTime(dataGridView1.Rows[dongchon].Cells["NgayLap"].Value);
            cbNhaCC.SelectedValue = dataGridView1.Rows[dongchon].Cells["MaNhaCC"].Value.ToString();
            cbMaNV.SelectedValue = dataGridView1.Rows[dongchon].Cells["MaNV"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update PhieuNhap set MaPhieuNhap=@MaPhieuNhap,NgayLap=@NgayLap,MaNhaCC=@MaNhaCC,MaNV=@MaNV where MaPhieuNhap=@MaPhieuNhapcu", con);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", txtMaPhieu.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@MaNhaCC", cbNhaCC.SelectedValue);
                cmd.Parameters.AddWithValue("@MaNV", cbMaNV.SelectedValue);
                cmd.Parameters.AddWithValue("@MaPhieuNhapcu", dataGridView1.Rows[dongchon].Cells["MaPhieuNhap"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thông tin phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin phiếu nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã phiếu trong hệ thống.Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("delete from PhieuNhap where MaPhieuNhap=@MaPhieuNhap", con);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", dataGridView1.Rows[dongchon].Cells["MaPhieuNhap"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thông tin phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thông tin phiếu nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Việc nhập sách chưa hoàn thành nên chưa thể xóa phiếu nhập này ra khỏi hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hiendl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuNhap where MaPhieuNhap like N'%" + txtTimKiem.Text + "%'" +
                "or MaNhaCC like N'" + txtTimKiem.Text + "%'" +
                "or MaNV like N'%" + txtTimKiem.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            PhieuNhap_Load(sender, e);
        }
    }
}
