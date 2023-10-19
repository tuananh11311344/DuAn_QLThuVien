using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bạnĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanDoc bd = new BanDoc();
            bd.MdiParent = this;
            bd.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MdiParent = this;
            nv.Show();
        }

        private void phiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon pm = new PhieuMuon();
            pm.MdiParent = this;
            pm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.MdiParent = this;
            ncc.Show();
        }

        private void phiếuMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon_Sach pms = new PhieuMuon_Sach();
            pms.MdiParent = this;
            pms.Show();
        }

        private void quảnLýTàiLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sach s = new Sach();
            s.MdiParent = this;
            s.Show();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MdiParent = this;
            pn.Show();
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhap_Sach pns = new PhieuNhap_Sach();
            pns.MdiParent = this;
            pns.Show();
        }

      

        private void nhậpSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThongkeNhapSach ns = new ThongkeNhapSach();
            ns.MdiParent = this;
            ns.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongkeMuonSach ms = new ThongkeMuonSach();
            ms.MdiParent = this;
            ms.Show();
        }
    }
}
