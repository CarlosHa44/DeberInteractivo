using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public partial class FrmSutherland : Form
    {
        private Bitmap canvasBitmap;
        private Graphics graphics;

        // Managers
        private CohenSutherland clipManager;
        private SutherlandHodgman polyClipper;

        // Datos dinámicos
        private Point? firstPoint = null;
        private List<PointF> polygonPoints = new List<PointF>();
        private List<PointF> clippedPolygon = new List<PointF>();

        // Modos: 1 = línea, 2 = polígono
        private int captureMode = 1;

        private static FrmSutherland instance;

        public static FrmSutherland GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmSutherland();
            }
            return instance;
        }

        public FrmSutherland()
        {
            InitializeComponent();
            InitializeCanvas();

            var clipRect = new Rectangle(100, 100, 400, 300);
            clipManager = new CohenSutherland(clipRect);
            polyClipper = new SutherlandHodgman(clipRect);

            cmbAlgoritmo.SelectedIndexChanged += (s, e) =>
            {
                captureMode = cmbAlgoritmo.SelectedIndex == 0 ? 1 : 2;
                clipManager.Clear();
                polygonPoints.Clear();
                clippedPolygon.Clear();
                firstPoint = null;
                RedrawAll();
            };
            btnCut.Click += btnCut_Click;
            btnReset.Click += btnReset_Click;

            cmbAlgoritmo.SelectedIndex = 0;
        }

        private void InitializeCanvas()
        {
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            graphics = Graphics.FromImage(canvasBitmap);
            graphics.Clear(Color.White);
            picCanvas.Image = canvasBitmap;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (captureMode == 1)
            {
                // Cohen–Sutherland (líneas)
                if (firstPoint == null)
                    firstPoint = e.Location;
                else
                {
                    clipManager.AddLine(firstPoint.Value, e.Location);
                    firstPoint = null;
                }
            }
            else
            {
                // Sutherland–Hodgman (polígono)
                polygonPoints.Add(e.Location);
            }
            RedrawAll();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (captureMode == 1)
                clipManager.ClipLines();
            else
                clippedPolygon = polyClipper.ClipPolygon(polygonPoints);
            RedrawAll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clipManager.Clear();
            polygonPoints.Clear();
            clippedPolygon.Clear();
            firstPoint = null;
            InitializeCanvas();
            RedrawAll();
        }

        private void RedrawAll()
        {
            graphics.Clear(Color.White);
            graphics.DrawRectangle(Pens.Blue, clipManager.ClipRectangle);

            if (captureMode == 1)
            {
                // Dibujar líneas
                foreach (var (s, t) in clipManager.Lines)
                    graphics.DrawLine(new Pen(Color.Red, 2), s, t);
                // Dibujar puntos extremos
                foreach (var (s, t) in clipManager.Lines)
                {
                    graphics.FillEllipse(Brushes.Green, s.X - 3, s.Y - 3, 6, 6);
                    graphics.FillEllipse(Brushes.Green, t.X - 3, t.Y - 3, 6, 6);
                }
                // Línea temporal
                if (firstPoint != null)
                    graphics.FillEllipse(Brushes.Green, firstPoint.Value.X - 3, firstPoint.Value.Y - 3, 6, 6);
                // Dibujar líneas recortadas
                foreach (var (s, t) in clipManager.ClippedLines)
                    graphics.DrawLine(new Pen(Color.Green, 2), s, t);
            }
            else
            {
                // Polígono original
                if (polygonPoints.Count > 1)
                    graphics.DrawPolygon(Pens.DarkBlue, polygonPoints.ToArray());
                foreach (var p in polygonPoints)
                    graphics.FillEllipse(Brushes.DarkBlue, p.X - 3, p.Y - 3, 6, 6);

                // Polígono recortado
                if (clippedPolygon.Count > 1)
                    graphics.DrawPolygon(new Pen(Color.Green, 2), clippedPolygon.ToArray());
            }

            picCanvas.Refresh();
        }
    }
}