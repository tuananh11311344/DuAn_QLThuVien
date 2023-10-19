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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void hiendl()
        {
            SqlCommand cmd = new SqlCommand("select *from NhanVien", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            hiendl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into NhanVien(MaNV,TenNV) values(@MaNV,@TenNV)", con);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã nhân viên trong hệ thống. Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            txtMaNV.Text = dataGridView1.Rows[dongchon].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dataGridView1.Rows[dongchon].Cells["TenNV"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update NhanVien set MaNV=@MaNV,TenNV=@TenNV where MaNV=@MaNVcu", con);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@MaNVcu", dataGridView1.Rows[dongchon].Cells["MaNV"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhân viên này đang quản lý việc nhập sách nên không thể sửa đổi thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("delete from NhanVien where MaNV=@MaNV", con);
                cmd.Parameters.AddWithValue("@MaNV", dataGridView1.Rows[dongchon].Cells["MaNV"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thông tin nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nhân viên này đang quản lý việc nhập sách nên không thể xóa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from NhanVien where MaNV like '%" + txtTimKiem.Text + "%' or TenNV like N'%" + txtTimKiem.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            NhanVien_Load(sender, e);
        }
    }
}
