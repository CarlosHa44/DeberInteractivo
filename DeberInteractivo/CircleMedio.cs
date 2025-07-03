using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    class CircleMedio
    {
        private int xCenter, yCenter, radius;

        public CircleMedio(int xc, int yc, int r)
        {
            xCenter = xc;
            yCenter = yc;
            radius = r;
        }

        public async Task DrawAnimatedAsync(Graphics g, Bitmap bmp, PictureBox canvas, int delayMs, int batchSize)
        {
            int x = 0, y = radius;
            int d = 1 - radius;
            List<Point> pixels = new List<Point>();

            AddCirclePoints(pixels, x, y);

            while (x < y)
            {
                x++;
                if (d < 0)
                    d += 2 * x + 1;
                else
                {
                    y--;
                    d += 2 * (x - y) + 1;
                }
                AddCirclePoints(pixels, x, y);
            }

            // Animar el dibujo por lotes
            for (int i = 0; i < pixels.Count; i++)
            {
                Point p = pixels[i];
                if (p.X >= 0 && p.X < bmp.Width && p.Y >= 0 && p.Y < bmp.Height)
                {
                    bmp.SetPixel(p.X, p.Y, Color.Black);
                }

                if ((i + 1) % batchSize == 0)
                {
                    canvas.Image = (Bitmap)bmp.Clone();
                    canvas.Refresh();
                    if (delayMs > 0)
                        await Task.Delay(delayMs);
                }
            }

            canvas.Image = bmp;
            canvas.Refresh();
        }

        private void AddCirclePoints(List<Point> list, int x, int y)
        {
            list.Add(new Point(xCenter + x, yCenter + y));
            list.Add(new Point(xCenter - x, yCenter + y));
            list.Add(new Point(xCenter + x, yCenter - y));
            list.Add(new Point(xCenter - x, yCenter - y));
            list.Add(new Point(xCenter + y, yCenter + x));
            list.Add(new Point(xCenter - y, yCenter + x));
            list.Add(new Point(xCenter + y, yCenter - x));
            list.Add(new Point(xCenter - y, yCenter - x));
        }
    }
}