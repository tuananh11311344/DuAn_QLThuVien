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
    public partial class ThongkeMuonSach : Form
    {
        public ThongkeMuonSach()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void ThongkeMuonSach_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sql = "select PhieuMuon.*,pms.MaSach,pms.SoLuong  from PhieuMuon inner join PhieuMuon_Sach as pms on PhieuMuon.MaPhieuMuon = pms.MaPhieuMuon";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
