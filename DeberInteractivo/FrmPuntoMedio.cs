using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public partial class FrmPuntoMedio : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private static FrmPuntoMedio instance;

        public static FrmPuntoMedio GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmPuntoMedio();
            }
            return instance;
        }
        public FrmPuntoMedio()
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
            if (!int.TryParse(txtRadio.Text, out int radio) || radio <= 0)
            {
                MessageBox.Show("Ingrese un radio válido y mayor a cero.");
                return;
            }

            int delay = (6 - trbarAnimationSpeed.Value + 1) * 5;
            int batchSize = 10;

            CircleMedio circle = new CircleMedio(e.X, e.Y, radio);
            await circle.DrawAnimatedAsync(graphics, canvasBitmap, picCanvas, delay, batchSize);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            picCanvas.Refresh();
        }
    }
}
