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
    public partial class BanDoc : Form
    {
        public BanDoc()
        {
            InitializeComponent();
        }
        SqlConnection con;
        public void hiendl()
        {
            SqlCommand cmd = new SqlCommand("select *from BanDoc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BanDoc_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            hiendl();
        }

        private void BanDoc_FormClosed(object sender, FormClosedEventArgs e)
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
                SqlCommand cmd = new SqlCommand("insert into BanDoc(MaBanDoc,TenBanDoc,DiaChi) values(@MaBanDoc,@TenBanDoc,@DiaChi)", con);
                cmd.Parameters.AddWithValue("@MaBanDoc", txtMaBanDoc.Text);
                cmd.Parameters.AddWithValue("@TenBanDoc", txtTenBanDoc.Text);
                cmd.Parameters.AddWithValue("@DiaChi", cbDiaChi.SelectedItem);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm bạn đọc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm bạn đọc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã tồn tại mã bạn đọc trong hệ thống.Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dataGridView1.CurrentRow.Index;
            txtMaBanDoc.Text = dataGridView1.Rows[dongchon].Cells["MaBanDoc"].Value.ToString();
            txtTenBanDoc.Text = dataGridView1.Rows[dongchon].Cells["TenBanDoc"].Value.ToString();
            cbDiaChi.SelectedItem = dataGridView1.Rows[dongchon].Cells["DiaChi"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update BanDoc set MaBanDoc=@MaBanDoc,TenBanDoc=@TenBanDoc,DiaChi=@DiaChi where MaBanDoc=@MaBanDocCu", con);
                cmd.Parameters.AddWithValue("@MaBanDoc", txtMaBanDoc.Text);
                cmd.Parameters.AddWithValue("@TenBanDoc", txtTenBanDoc.Text);
                cmd.Parameters.AddWithValue("@DiaChi", cbDiaChi.SelectedItem);
                cmd.Parameters.AddWithValue("@MaBanDocCu", dataGridView1.Rows[dongchon].Cells["MaBanDoc"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thông tin bạn đọc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin bạn đọc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn đọc này đang thực hiện mượn sách nên không thể sửa đổi thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            hiendl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int dongchon = dataGridView1.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("delete from BanDoc where MaBanDoc=@MaBanDoc", con);
                cmd.Parameters.AddWithValue("@MaBanDoc", dataGridView1.Rows[dongchon].Cells["MaBanDoc"].Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thông tin bạn đọc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thông tin bạn đọc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bạn đọc này đang thực hiện mượn sách nên không thể xóa thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            hiendl();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from BanDoc where MaBanDoc like '%" + txtThongTin.Text + "%' or TenBanDoc like N'%" + txtThongTin.Text + "%' or DiaChi like N'%" + txtThongTin.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            txtThongTin.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            BanDoc_Load(sender, e);
        }
    }
}
