using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src.helpers
{
    public class MathHelper
    {
        public static float ToRadians(float degrees)
        {
            return (degrees * (2f * (float)Math.PI)) / 360f;
        }
    }
}
