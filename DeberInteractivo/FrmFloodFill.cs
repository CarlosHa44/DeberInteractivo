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
    public partial class FrmFloodFill : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private bool isFilling = false;
        private FloodFill floodFill;
        private FloodFillBFS floodFillBFS;
        private static FrmFloodFill instance;
        public static FrmFloodFill GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmFloodFill();
            }
            return instance;
        }
        public FrmFloodFill()
        {
            InitializeComponent();
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;

            floodFill = new FloodFill(canvasBitmap);
            floodFill.SetBitmap(canvasBitmap);
            floodFillBFS = new FloodFillBFS();
            floodFillBFS.SetBitmap(canvasBitmap);

            picCanvas.MouseClick += PicCanvas_MouseClick;
            btnReset.Click += btnReset_Click;
        }

        private async void PicCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (isFilling)
            {
                int delay = (6 - trbarAnimationSpeed.Value + 1) * 5;
                string metodo = cmbAlgoritmo.SelectedItem?.ToString();

                if (metodo == "Flood Fill DFS")
                {
                    await floodFill.AnimateFillFastAsync(e.X, e.Y, picCanvas, delay, 100);
                }
                else if (metodo == "Flood Fill BFS")
                {
                    await floodFillBFS.AnimateFillBFSAsync(e.X, e.Y, picCanvas, delay, 100);
                }

            }
            else
            {
                if (!int.TryParse(txtRadio.Text, out int radio) || radio <= 0)
                {
                    MessageBox.Show("Ingrese un valor de radio válido (positivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                graphics.DrawEllipse(Pens.Black, e.X - radio, e.Y - radio, radio * 2, radio * 2);
                picCanvas.Refresh();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isFilling = false;
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            floodFill.SetBitmap(canvasBitmap);
            picCanvas.Refresh();
            label7.Text = "Modo: Dibujar";
        }

        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            isFilling = !isFilling;
            label7.Text = isFilling ? "Modo: Rellenar" : "Modo: Dibujar";
        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            isFilling = true;
            label7.Text = isFilling ? "Modo: Rellenar" : "Modo: Dibujar";
        }
    }
}
