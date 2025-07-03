using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeberInteractivo
{
    public class FloodFill
    {
        private Bitmap canvasBitmap;

        public FloodFill(Bitmap bmp)
        {
            canvasBitmap = bmp;
        }

        public void SetBitmap(Bitmap bmp)
        {
            canvasBitmap = bmp;
        }

        public async Task AnimateFillFastAsync(int x, int y, PictureBox pictureBox, int delayMs = 1, int batchSize = 100)
        {
            if (x < 0 || y < 0 || x >= canvasBitmap.Width || y >= canvasBitmap.Height) return;

            Color target = canvasBitmap.GetPixel(x, y);
            Color replacement = Color.Red;

            if (target.ToArgb() == replacement.ToArgb()) return;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));
            int painted = 0;

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                if (p.X < 0 || p.Y < 0 || p.X >= canvasBitmap.Width || p.Y >= canvasBitmap.Height)
                    continue;
                if (canvasBitmap.GetPixel(p.X, p.Y).ToArgb() != target.ToArgb())
                    continue;

                canvasBitmap.SetPixel(p.X, p.Y, replacement);
                painted++;

                stack.Push(new Point(p.X + 1, p.Y));
                stack.Push(new Point(p.X - 1, p.Y));
                stack.Push(new Point(p.X, p.Y + 1));
                stack.Push(new Point(p.X, p.Y - 1));

                if (painted % batchSize == 0)
                {
                    pictureBox.Image = canvasBitmap;
                    pictureBox.Refresh();
                    await Task.Delay(delayMs);
                }
            }

            pictureBox.Image = canvasBitmap;
            pictureBox.Refresh();
        }
    }
}