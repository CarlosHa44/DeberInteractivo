using System;
using System.Collections.Generic;
using System.Drawing;

namespace DeberInteractivo
{
    public class CohenSutherland
    {
        private Rectangle clipRect;
        private List<(Point start, Point end)> lines = new List<(Point start, Point end)>();
        private List<(Point start, Point end)> clippedLines = new List<(Point start, Point end)>();

        public CohenSutherland(Rectangle clipRectangle)
        {
            clipRect = clipRectangle;
        }

        public IReadOnlyList<(Point start, Point end)> Lines => lines;
        public IReadOnlyList<(Point start, Point end)> ClippedLines => clippedLines;
        public Rectangle ClipRectangle => clipRect;

        public void AddLine(Point p1, Point p2)
        {
            lines.Add((p1, p2));
        }

        public void Clear()
        {
            lines.Clear();
            clippedLines.Clear();
        }

        public void ClipLines()
        {
            clippedLines.Clear();

            foreach (var (start, end) in lines)
            {
                if (ClipLine(start, end, out Point clippedStart, out Point clippedEnd))
                {
                    clippedLines.Add((clippedStart, clippedEnd));
                }
            }
        }

        private bool ClipLine(Point p1, Point p2, out Point clippedStart, out Point clippedEnd)
        {
            const int INSIDE = 0;
            const int LEFT = 1;
            const int RIGHT = 2;
            const int BOTTOM = 4;
            const int TOP = 8;

            clippedStart = p1;
            clippedEnd = p2;

            int ComputeOutCode(Point p)
            {
                int code = INSIDE;
                if (p.X < clipRect.Left) code |= LEFT;
                else if (p.X > clipRect.Right) code |= RIGHT;
                if (p.Y < clipRect.Top) code |= TOP;
                else if (p.Y > clipRect.Bottom) code |= BOTTOM;
                return code;
            }

            double x0 = p1.X, y0 = p1.Y;
            double x1 = p2.X, y1 = p2.Y;
            int outcode0 = ComputeOutCode(p1);
            int outcode1 = ComputeOutCode(p2);
            bool accept = false;

            while (true)
            {
                if ((outcode0 | outcode1) == 0)
                {
                    accept = true;
                    break;
                }
                else if ((outcode0 & outcode1) != 0)
                {
                    break;
                }
                else
                {
                    double x = 0, y = 0;
                    int outcodeOut = (outcode0 != 0) ? outcode0 : outcode1;

                    if ((outcodeOut & TOP) != 0)
                    {
                        x = x0 + (x1 - x0) * (clipRect.Top - y0) / (y1 - y0);
                        y = clipRect.Top;
                    }
                    else if ((outcodeOut & BOTTOM) != 0)
                    {
                        x = x0 + (x1 - x0) * (clipRect.Bottom - y0) / (y1 - y0);
                        y = clipRect.Bottom;
                    }
                    else if ((outcodeOut & RIGHT) != 0)
                    {
                        y = y0 + (y1 - y0) * (clipRect.Right - x0) / (x1 - x0);
                        x = clipRect.Right;
                    }
                    else if ((outcodeOut & LEFT) != 0)
                    {
                        y = y0 + (y1 - y0) * (clipRect.Left - x0) / (x1 - x0);
                        x = clipRect.Left;
                    }

                    if (outcodeOut == outcode0)
                    {
                        x0 = x; y0 = y;
                        outcode0 = ComputeOutCode(new Point((int)x0, (int)y0));
                    }
                    else
                    {
                        x1 = x; y1 = y;
                        outcode1 = ComputeOutCode(new Point((int)x1, (int)y1));
                    }
                }
            }

            if (accept)
            {
                clippedStart = new Point((int)x0, (int)y0);
                clippedEnd = new Point((int)x1, (int)y1);
            }
            return accept;
        }
    }
}