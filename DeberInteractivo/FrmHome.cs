using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmLoad(Form frm)
        {
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(0, 0);
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            FrmInicio frm = FrmInicio.GetInstance();
            FrmLoad(frm);
        }

        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLines frm = FrmLines.GetInstance();
            FrmLoad(frm);
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuntoMedio frm = FrmPuntoMedio.GetInstance();
            FrmLoad(frm);
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmElipseBresenham frm = FrmElipseBresenham.GetInstance();
            FrmLoad(frm);
        }

        private void rellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFloodFill frm = FrmFloodFill.GetInstance();
            FrmLoad(frm);
        }

        private void recorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSutherland frm = FrmSutherland.GetInstance();
            FrmLoad(frm);
        }

        private void bezielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBezier frm = FrmBezier.GetInstance();
            FrmLoad(frm);
        }

        private void bSplinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBSpline frm = FrmBSpline.GetInstance();
            FrmLoad(frm);
        }
    }
}
