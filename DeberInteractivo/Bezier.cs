using System;
using System.Collections.Generic;
using System.Drawing;

namespace DeberInteractivo
{
    public static class Bezier
    {
        public static PointF GetPoint(List<PointF> pts, float t)
        {
            int grado = pts.Count - 1;
            if (grado == 1)
                return Grado1(pts, t);
            else if (grado == 2)
                return Grado2(pts, t);
            else if (grado == 3)
                return Grado3(pts, t);
            else
                throw new ArgumentException("Grado no soportado.");
        }

        private static PointF Grado1(List<PointF> pts, float t)
            => new PointF(
                (1 - t) * pts[0].X + t * pts[1].X,
                (1 - t) * pts[0].Y + t * pts[1].Y);

        private static PointF Grado2(List<PointF> pts, float t)
            => new PointF(
                (float)(Math.Pow(1 - t, 2) * pts[0].X + 2 * (1 - t) * t * pts[1].X + Math.Pow(t, 2) * pts[2].X),
                (float)(Math.Pow(1 - t, 2) * pts[0].Y + 2 * (1 - t) * t * pts[1].Y + Math.Pow(t, 2) * pts[2].Y));

        private static PointF Grado3(List<PointF> pts, float t)
            => new PointF(
                (float)(Math.Pow(1 - t, 3) * pts[0].X + 3 * Math.Pow(1 - t, 2) * t * pts[1].X + 3 * (1 - t) * Math.Pow(t, 2) * pts[2].X + Math.Pow(t, 3) * pts[3].X),
                (float)(Math.Pow(1 - t, 3) * pts[0].Y + 3 * Math.Pow(1 - t, 2) * t * pts[1].Y + 3 * (1 - t) * Math.Pow(t, 2) * pts[2].Y + Math.Pow(t, 3) * pts[3].Y));
    }
}