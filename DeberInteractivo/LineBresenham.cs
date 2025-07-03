using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    class LineBresenham
    {
        public async Task DrawAsync(Point start, Point end, Graphics g, Bitmap bmp, PictureBox canvas, int delayMs, int batchSize, CancellationToken token, Func<bool> isPaused)
        {
            int x0 = start.X, y0 = start.Y;
            int x1 = end.X, y1 = end.Y;
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = dx + dy;
            int painted = 0;

            while (true)
            {
                g.FillRectangle(Brushes.Black, x0, y0, 1, 1);
                painted++;

                if (painted % batchSize == 0)
                {
                    canvas.Image = (Bitmap)bmp.Clone();
                    canvas.Refresh();

                    while (isPaused()) await Task.Delay(100);
                    token.ThrowIfCancellationRequested();

                    if (delayMs > 0)
                        await Task.Delay(delayMs);
                }

                if (x0 == x1 && y0 == y1) break;

                int e2 = 2 * err;
                if (e2 >= dy) { err += dy; x0 += sx; }
                if (e2 <= dx) { err += dx; y0 += sy; }
            }

            canvas.Image = (Bitmap)bmp.Clone();
            canvas.Refresh();
        }
    }
}
