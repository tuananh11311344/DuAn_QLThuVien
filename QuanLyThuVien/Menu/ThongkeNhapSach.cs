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

namespace Menu
{
    public partial class ThongkeNhapSach : Form
    {
        public ThongkeNhapSach()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void Thongke_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select PhieuNhap.*,pns.MaSach,pns.SoLuong  from PhieuNhap inner join PhieuNhap_Sach as pns on PhieuNhap.MaPhieuNhap = pns.MaPhieuNhap";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
