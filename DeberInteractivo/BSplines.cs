using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeberInteractivo
{
    class BSplines
    {
        public static List<PointF> GetBSplinePoints(List<PointF> controlPoints, int steps = 100)
        {
            List<PointF> result = new List<PointF>();
            if (controlPoints.Count < 4) return result;

            for (int i = 0; i <= controlPoints.Count - 4; i++)
            {
                for (int j = 0; j <= steps; j++)
                {
                    float t = j / (float)steps;
                    result.Add(EvaluateBSpline(controlPoints, i, t));
                }
            }
            return result;
        }

        private static PointF EvaluateBSpline(List<PointF> pts, int i, float t)
        {
            float it = 1 - t;
            float b0 = (it * it * it) / 6f;
            float b1 = (3 * t * t * t - 6 * t * t + 4) / 6f;
            float b2 = (-3 * t * t * t + 3 * t * t + 3 * t + 1) / 6f;
            float b3 = (t * t * t) / 6f;

            float x = b0 * pts[i].X + b1 * pts[i + 1].X + b2 * pts[i + 2].X + b3 * pts[i + 3].X;
            float y = b0 * pts[i].Y + b1 * pts[i + 1].Y + b2 * pts[i + 2].Y + b3 * pts[i + 3].Y;

            return new PointF(x, y);
        }

    }
}
