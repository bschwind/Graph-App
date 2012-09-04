using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.helpers
{
    public struct Circle
    {
        public Point Center;
        public int Radius;

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }
    }
}
