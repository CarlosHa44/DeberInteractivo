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
    public partial class FrmElipseBresenham : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private static FrmElipseBresenham instance;
        public static FrmElipseBresenham GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmElipseBresenham();
            }
            return instance;
        }
        public FrmElipseBresenham()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;
            picCanvas.MouseClick += picCanvas_MouseClick;
        }

        private async void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!int.TryParse(txtRadio.Text, out int rx) || rx <= 0 ||
                !int.TryParse(txtRadio2.Text, out int ry) || ry <= 0)
            {
                MessageBox.Show("Ingrese valores válidos y mayores a cero para ambos radios.");
                return;
            }

            int delay = (6 - trbarAnimationSpeed.Value + 1) * 5;
            int batchSize = 10;

            BresenhamEclipse ellipse = new BresenhamEclipse(e.X, e.Y, rx, ry);
            await ellipse.DrawAnimatedAsync(graphics, canvasBitmap, picCanvas, delay, batchSize);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            picCanvas.Refresh();
        }
    }
}
