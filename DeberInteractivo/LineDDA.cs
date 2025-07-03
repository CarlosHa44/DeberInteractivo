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
    class LineDDA
    {
        public async Task DrawAsync(Point start, Point end, Graphics g, Bitmap bmp, PictureBox canvas, int delayMs, int batchSize, CancellationToken token, Func<bool> isPaused)
        {
            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            int steps = Math.Max(Math.Abs((int)dx), Math.Abs((int)dy));

            float xIncrement = dx / steps;
            float yIncrement = dy / steps;

            float x = start.X;
            float y = start.Y;

            int painted = 0;

            for (int i = 0; i <= steps; i++)
            {
                g.FillRectangle(Brushes.Black, (int)Math.Round(x), (int)Math.Round(y), 1, 1);
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

                x += xIncrement;
                y += yIncrement;
            }

            canvas.Image = (Bitmap)bmp.Clone();
            canvas.Refresh();
        }
    }
}
