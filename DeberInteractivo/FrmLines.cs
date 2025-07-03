using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public partial class FrmLines : Form
    {
        private static FrmLines instance;
        private Point? puntoInicio = null;
        private Point? puntoFin = null;
        private Bitmap bmp;
        private Graphics g;
        private CancellationTokenSource cts;
        private bool pausado = false;
        public static FrmLines GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmLines();
            }
            return instance;
        }
        public FrmLines()
        {
            InitializeComponent();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (puntoInicio == null)
            {
                puntoInicio = e.Location;
                g.FillEllipse(Brushes.Green, e.X - 3, e.Y - 3, 6, 6);
                picCanvas.Image = bmp;
            }
            else if (puntoFin == null)
            {
                puntoFin = e.Location;
                g.FillEllipse(Brushes.Red, e.X - 3, e.Y - 3, 6, 6);
                picCanvas.Image = bmp;
            }
        }

        private void FrmLines_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(bmp);
            picCanvas.Image = bmp;
        }

        private async void btnGraphic_Click(object sender, EventArgs e)
        {
            if (puntoInicio == null || puntoFin == null || cmbAlgoritmo.SelectedItem == null)
            {
                MessageBox.Show("Selecciona los dos puntos y el algoritmo.");
                return;
            }

            cts = new CancellationTokenSource();
            pausado = false;

            int speed = trbarAnimationSpeed.Value; 
            int delayMs = 100 - speed * 5;         
            int batchSize = speed * 5;             

            string algoritmo = cmbAlgoritmo.SelectedItem.ToString();

            if (algoritmo == "DDA")
            {
                var dda = new LineDDA();
                await dda.DrawAsync((Point)puntoInicio, (Point)puntoFin, g, bmp, picCanvas, delayMs, batchSize, cts.Token, () => pausado);
            }
            else if (algoritmo == "Bresenham")
            {
                var bres = new LineBresenham();
                await bres.DrawAsync((Point)puntoInicio, (Point)puntoFin, g, bmp, picCanvas, delayMs, batchSize, cts.Token, () => pausado);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pausado=true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pausado = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            pausado = false;
            puntoInicio = null;
            puntoFin = null;
            bmp = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(bmp);
            picCanvas.Image = bmp;
        }
    }
}
