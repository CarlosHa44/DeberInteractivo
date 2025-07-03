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
    public partial class FrmInicio : Form
    {
        private static FrmInicio instance;
        public FrmInicio()
        {
            InitializeComponent();
        }
        private Image RedimensionarImagen(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap bmp = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return bmp;
        }

        public static FrmInicio GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmInicio();
            }
            return instance;
        }
        private void FrmInicio_Load_1(object sender, EventArgs e)
        {
            picCanvas.SizeMode = PictureBoxSizeMode.Normal;
            Image img = Properties.Resources.SpinosaurusThunder;
            Image img2 = RedimensionarImagen(img, 630, 400);
            picCanvas.Image = img2;
        }

    }
}
