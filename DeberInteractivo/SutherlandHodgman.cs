using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeberInteractivo
{
    class SutherlandHodgman
    {
        private Rectangle clipRect;

        public SutherlandHodgman(Rectangle clipRectangle)
        {
            clipRect = clipRectangle;
        }

        public List<PointF> ClipPolygon(List<PointF> polygon)
        {
            if (polygon == null || polygon.Count < 3)
                return new List<PointF>();

            List<PointF> outputList = new List<PointF>(polygon);

            var edges = new[]
            {
                new ClipEdge(p => p.X >= clipRect.Left,
                             (P1, P2) => Intersect(P1, P2, clipRect.Left, true)),
                new ClipEdge(p => p.X <= clipRect.Right,
                             (P1, P2) => Intersect(P1, P2, clipRect.Right, true)),
                new ClipEdge(p => p.Y <= clipRect.Bottom,
                             (P1, P2) => Intersect(P1, P2, clipRect.Bottom, false)),
                new ClipEdge(p => p.Y >= clipRect.Top,
                             (P1, P2) => Intersect(P1, P2, clipRect.Top, false)),
            };

            foreach (var edge in edges)
            {
                var inputList = new List<PointF>(outputList);
                outputList.Clear();
                if (inputList.Count == 0) break;

                var S = inputList[inputList.Count - 1];
                foreach (var E in inputList)
                {
                    bool Ein = edge.IsInside(E);
                    bool Sin = edge.IsInside(S);
                    if (Ein)
                    {
                        if (!Sin)
                            outputList.Add(edge.Intersection(S, E));
                        outputList.Add(E);
                    }
                    else if (Sin)
                    {
                        outputList.Add(edge.Intersection(S, E));
                    }
                    S = E;
                }
            }

            return outputList;
        }

        private PointF Intersect(PointF p1, PointF p2, float value, bool vertical)
        {
            if (vertical)
            {
                float m = (p2.Y - p1.Y) / (p2.X - p1.X);
                float y = p1.Y + (value - p1.X) * m;
                return new PointF(value, y);
            }
            else
            {
                if (p2.Y == p1.Y)
                    return new PointF(p1.X, value);
                float m = (p2.X - p1.X) / (p2.Y - p1.Y);
                float x = p1.X + (value - p1.Y) * m;
                return new PointF(x, value);
            }
        }

        private class ClipEdge
        {
            public Func<PointF, bool> IsInside { get; }
            public Func<PointF, PointF, PointF> Intersection { get; }
            public ClipEdge(Func<PointF, bool> inside, Func<PointF, PointF, PointF> intersect)
            {
                IsInside = inside;
                Intersection = intersect;
            }
        }
    }
}
