using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.helpers
{
    public static class GeometryHelper
    {
        public static bool Intersects(Rectangle rect, Circle circle)
        {
            float sqDist = SqDistPointRect(circle.Center, rect);
            return sqDist <= circle.Radius * circle.Radius;
        }

        public static bool Intersects(Point point, Circle circle)
        {
            Point vec = new Point(point.X - circle.Center.X, point.Y - circle.Center.Y);
            float sqDist = vec.X * vec.X + vec.Y * vec.Y;
            return sqDist <= circle.Radius * circle.Radius;
        }

        private static float SqDistPointRect(Point p, Rectangle r)
        {
            float sqDist = 0.0f;

            Point min = r.Location;
            Point max = new Point(r.Location.X + r.Width, r.Location.Y + r.Height);

            float v = p.X;
            if (v < min.X) sqDist += (min.X - v) * (min.X - v);
            if (v > max.X) sqDist += (v - max.X) * (v - max.X);

            v = p.Y;
            if (v < min.Y) sqDist += (min.Y - v) * (min.Y - v);
            if (v > max.Y) sqDist += (v - max.Y) * (v - max.Y);

            return sqDist;
        }
    }
}
