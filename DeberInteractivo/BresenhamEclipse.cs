using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    class BresenhamEclipse
    {
        private int xc, yc, rx, ry;

        public BresenhamEclipse(int xc, int yc, int rx, int ry)
        {
            this.xc = xc;
            this.yc = yc;
            this.rx = rx;
            this.ry = ry;
        }

        public async Task DrawAnimatedAsync(Graphics g, Bitmap bmp, PictureBox canvas, int delayMs, int batchSize)
        {
            int x = 0;
            int y = ry;
            double rxSq = rx * rx;
            double rySq = ry * ry;
            double dx = 2 * rySq * x;
            double dy = 2 * rxSq * y;
            double d1 = rySq - (rxSq * ry) + (0.25 * rxSq);

            List<Point> pixels = new List<Point>();
            while (dx < dy)
            {
                AddSymmetricPoints(pixels, x, y);
                if (d1 < 0)
                {
                    x++;
                    dx += 2 * rySq;
                    d1 += dx + rySq;
                }
                else
                {
                    x++; y--;
                    dx += 2 * rySq;
                    dy -= 2 * rxSq;
                    d1 += dx - dy + rySq;
                }
            }

            double d2 = (rySq) * ((x + 0.5) * (x + 0.5)) + (rxSq) * ((y - 1) * (y - 1)) - (rxSq * rySq);
            while (y >= 0)
            {
                AddSymmetricPoints(pixels, x, y);
                if (d2 > 0)
                {
                    y--;
                    dy -= 2 * rxSq;
                    d2 += rxSq - dy;
                }
                else
                {
                    y--; x++;
                    dx += 2 * rySq;
                    dy -= 2 * rxSq;
                    d2 += dx - dy + rxSq;
                }
            }

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

        private void AddSymmetricPoints(List<Point> list, int x, int y)
        {
            list.Add(new Point(xc + x, yc + y));
            list.Add(new Point(xc - x, yc + y));
            list.Add(new Point(xc + x, yc - y));
            list.Add(new Point(xc - x, yc - y));
        }
    }
}
