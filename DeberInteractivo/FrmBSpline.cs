using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public partial class FrmBSpline : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;
        private List<PointF> controlPoints = new List<PointF>();
        private bool isDragging = false;
        private int dragIndex = -1;
        private static FrmBSpline instance;
        public static FrmBSpline GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmBSpline();
            }
            return instance;
        }

        public FrmBSpline()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;
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
            var curve = BSplines.GetBSplinePoints(controlPoints);
            for (int i = 1; i < curve.Count; i++)
            {
                graphics.DrawLine(Pens.Red, curve[i - 1], curve[i]);
            }
            picCanvas.Refresh();
        }

        private void BtnGraphic_Click(object sender, EventArgs e)
        {
            RedrawAll();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            controlPoints.Clear();
            InitializeCanvas();
        }

        private void PicCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            controlPoints.Add(e.Location);
            RedrawAll();
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                if (Distance(controlPoints[i], e.Location) < 6)
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
                RedrawAll();
            }
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            dragIndex = -1;
        }

        private float Distance(PointF a, PointF b)
            => (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
}