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
    public partial class PhieuMuon_Sach : Form
    {
        public PhieuMuon_Sach()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void hiendl()
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuMuon_Sach", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void hienpm()
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuMuon", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaPhieu.DataSource = dt;
            cbMaPhieu.DisplayMember = "MaPhieuMuon";
            cbMaPhieu.ValueMember = "MaPhieuMuon";
        }
        public void hiensach()
        {
            SqlCommand cmd = new SqlCommand("select *from Sach", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbTenSach.DataSource = dt;
            cbTenSach.DisplayMember = "TenSach";
            cbTenSach.ValueMember = "MaSach";
        }
        private void PhieuMuon_Sach_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            hiendl();
            hienpm();
            hiensach();
        }

        private void PhieuMuon_Sach_FormClosed(object sender, FormClosedEventArgs e)
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
                SqlCommand cmd = new SqlCommand("insert into PhieuMuon_Sach(MaPhieuMuon,MaSach,SoLuong) values(@MaPhieuMuon,@MaSach,@SoLuong)", con);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", cbMaPhieu.SelectedValue);
                cmd.Parameters.AddWithValue("@MaSach", cbTenSach.SelectedValue);
                cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã hoàn thành việc mượn sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm phiếu mượn sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                hiendl();
            }
            catch
            {
                MessageBox.Show("Tên sách đã tồn tại trong phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            cbMaPhieu.SelectedValue = dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value;
            cbTenSach.SelectedValue = dataGridView1.Rows[dongchon].Cells["MaSach"].Value;
            txtSoLuong.Text = dataGridView1.Rows[dongchon].Cells["SoLuong"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update PhieuMuon_Sach set MaPhieuMuon=@MaPhieuMuon, MaSach=@MaSach,SoLuong=@SoLuong where MaPhieuMuon=@MaPhieuMuonCu", con);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", cbMaPhieu.SelectedValue);
                cmd.Parameters.AddWithValue("@MaSach", cbTenSach.SelectedValue);
                cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                cmd.Parameters.AddWithValue("@MaPhieuMuonCu", dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thông tin phiếu mượn sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin phiếu mượn sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tồn tại nhiều mã phiếu này nên không thể sửa thông tin một trong những mã phiếu được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            SqlCommand cmd = new SqlCommand("delete from PhieuMuon_Sach where MaPhieuMuon=@MaPhieuMuon", con);
            cmd.Parameters.AddWithValue("@MaPhieuMuon", dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xóa thông tin phiếu mượn sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa thông tin phiếu mượn sách thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            hiendl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuMuon_Sach where MaPhieuMuon like N'%" + txtTimKiem.Text + "%' or MaSach like N'" + txtTimKiem.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            PhieuMuon_Sach_Load(sender, e);
        }
    }
}
