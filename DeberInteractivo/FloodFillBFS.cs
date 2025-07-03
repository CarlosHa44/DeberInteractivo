using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    class FloodFillBFS
    {
        private Bitmap canvasBitmap;

        public FloodFillBFS()
        {
            canvasBitmap = null;
        }

        public void SetBitmap(Bitmap bmp)
        {
            canvasBitmap = bmp;
        }

        public async Task AnimateFillBFSAsync(int startX, int startY, PictureBox pictureBox, int delayMs = 1, int batchSize = 100)
        {
            if (canvasBitmap == null) return;
            if (startX < 0 || startY < 0 || startX >= canvasBitmap.Width || startY >= canvasBitmap.Height) return;

            Color target = canvasBitmap.GetPixel(startX, startY);
            Color replacement = Color.Blue;
            if (target.ToArgb() == replacement.ToArgb()) return;

            var queue = new Queue<Point>();
            queue.Enqueue(new Point(startX, startY));

            int painted = 0;
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (p.X < 0 || p.Y < 0 || p.X >= canvasBitmap.Width || p.Y >= canvasBitmap.Height)
                    continue;
                if (canvasBitmap.GetPixel(p.X, p.Y).ToArgb() != target.ToArgb())
                    continue;

                canvasBitmap.SetPixel(p.X, p.Y, replacement);
                painted++;

                queue.Enqueue(new Point(p.X + 1, p.Y));
                queue.Enqueue(new Point(p.X - 1, p.Y));
                queue.Enqueue(new Point(p.X, p.Y + 1));
                queue.Enqueue(new Point(p.X, p.Y - 1));

                if (painted % batchSize == 0)
                {
                    pictureBox.Image = canvasBitmap;
                    pictureBox.Refresh();
                    if (delayMs > 0)
                        await Task.Delay(delayMs);
                }
            }

            pictureBox.Image = canvasBitmap;
            pictureBox.Refresh();
        }
    }
}