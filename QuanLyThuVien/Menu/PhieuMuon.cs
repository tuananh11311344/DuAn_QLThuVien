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
    public partial class PhieuMuon : Form
    {
        public PhieuMuon()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void hiendl()
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuMuon", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            hiendl();

            SqlCommand cmd = new SqlCommand("select *from BanDoc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaBanDoc.DataSource = dt;
            cbMaBanDoc.DisplayMember = "MaBanDoc";
            cbMaBanDoc.ValueMember = "MaBanDoc";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into PhieuMuon(MaPhieuMuon,MaBanDoc,NgayMuon,NgayTra) values(@MaPhieuMuon,@MaBanDoc,@NgayMuon,@NgayTra)", con);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", txtMaPhieu.Text);
                cmd.Parameters.AddWithValue("@MaBanDoc", cbMaBanDoc.SelectedValue);
                cmd.Parameters.AddWithValue("NgayMuon", dtpNgayMuon.Value);
                cmd.Parameters.AddWithValue("NgayTra", dtpNgayTra.Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Chuyển qua Form Mượn sách để hoàn thành việc mượn sách","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    PhieuMuon_Sach pms = new PhieuMuon_Sach();
                    pms.Show();
                }
                else
                {
                    MessageBox.Show("Việc mượn sách đã xảy ra gián đoạn vui lòng kiểm tra lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã phiếu mượn.Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void PhieuMuon_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            txtMaPhieu.Text = dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value.ToString();
            cbMaBanDoc.SelectedValue = dataGridView1.Rows[dongchon].Cells["MaBanDoc"].Value;
            dtpNgayMuon.Value = Convert.ToDateTime(dataGridView1.Rows[dongchon].Cells["NgayMuon"].Value);
            dtpNgayTra.Value = Convert.ToDateTime(dataGridView1.Rows[dongchon].Cells["NgayTra"].Value);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update PhieuMuon set MaPhieuMuon=@MaPhieuMuon,MaBanDoc=@MaBanDoc,NgayMuon=@NgayMuon,NgayTra=@NgayTra where MaPhieuMuon=@MaPhieuMuonCu", con);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", txtMaPhieu.Text);
                cmd.Parameters.AddWithValue("@MaBanDoc", cbMaBanDoc.SelectedValue);
                cmd.Parameters.AddWithValue("NgayMuon", dtpNgayMuon.Value);
                cmd.Parameters.AddWithValue("NgayTra", dtpNgayTra.Value);
                cmd.Parameters.AddWithValue("@MaPhieuMuonCu", dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thông tin phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin phiếu mượn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bạn đọc đang cầm sách có mã phiếu này nên không được phép sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("delete from PhieuMuon where MaPhieuMuon=@MaPhieuMuon", con);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thông tin phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thông tin phiếu mượn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                string maPhieu = dataGridView1.Rows[dongchon].Cells["MaPhieuMuon"].Value.ToString();
                MessageBox.Show("Bạn đọc có mã " + maPhieu.Trim() + " chưa hoàn thành việc trả sách nên chưa thể xóa khỏi hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hiendl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from PhieuMuon where MaPhieuMuon like N'%" + txtTimKiem.Text + "%' or MaBanDoc like N'%" + txtTimKiem.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtTimKiem.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            PhieuMuon_Load(sender, e);
        }
    }
}
