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
    public partial class FrmBezier : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private List<PointF> controlPoints = new List<PointF>();
        private int degree = 1;
        private bool isDragging = false;
        private int dragIndex = -1;
        private static FrmBezier instance;
        public static FrmBezier GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmBezier();
            }
            return instance;
        }

        public FrmBezier()
        {
            InitializeComponent();
            InitializeCanvas();

            cmbDegree.SelectedIndexChanged += (s, e) =>
            {
                degree = cmbDegree.SelectedIndex + 1;
                controlPoints.Clear();
                InitializeCanvas();
                RedrawAll();
            };
            cmbDegree.SelectedIndex = 1;

            btnGraphic.Click += BtnGraphic_Click;
            btnReset.Click += BtnReset_Click;

            picCanvas.MouseClick += PicCanvas_MouseClick;
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
        }

        private void InitializeCanvas()
        {
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;
        }

        private void PicCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (controlPoints.Count < degree + 1)
            {
                controlPoints.Add(e.Location);
                RedrawAll();
            }
        }

        private void BtnGraphic_Click(object sender, EventArgs e)
        {
            if (controlPoints.Count < degree + 1)
                return;

            // Dibujar curva
            const int steps = 100;
            PointF prev = Bezier.GetPoint(controlPoints, 0);
            for (int i = 1; i <= steps; i++)
            {
                float t = i / (float)steps;
                PointF curr = Bezier.GetPoint(controlPoints, t);
                graphics.DrawLine(Pens.Red, prev, curr);
                prev = curr;
            }
            picCanvas.Refresh();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            InitializeCanvas();
            RedrawAll();
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                var p = controlPoints[i];
                if (Distance(p, e.Location) < 6)
                {
                    isDragging = true;
                    dragIndex = i;
                    break;
                }
            }
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && dragIndex >= 0)
            {
                controlPoints[dragIndex] = e.Location;
                InitializeCanvas();
                RedrawAll();
                BtnGraphic_Click(sender, e);
            }
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            dragIndex = -1;
        }

        private void RedrawAll()
        {
            graphics.Clear(Color.White);
            for (int i = 0; i < controlPoints.Count; i++)
            {
                var p = controlPoints[i];
                graphics.FillEllipse(Brushes.Blue, p.X - 4, p.Y - 4, 8, 8);
                if (i > 0)
                    graphics.DrawLine(Pens.Gray, controlPoints[i - 1], p);
            }
            picCanvas.Refresh();
        }

        private float Distance(PointF p1, PointF p2)
            => (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
