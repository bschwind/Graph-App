using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphApp.src.helpers
{
    public struct Vector2
    {
        public static Vector2 Zero = new Vector2(0, 0);

        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public float Length()
        {
            float num = (this.X * this.X) + (this.Y * this.Y);
            return (float)Math.Sqrt((double)num);
        }

        public float LengthSquared()
        {
            return ((this.X * this.X) + (this.Y * this.Y));
        }

        public void Normalize()
        {
            float num2 = (this.X * this.X) + (this.Y * this.Y);
            float num = 1f / ((float)Math.Sqrt((double)num2));
            this.X *= num;
            this.Y *= num;
        }

        public Vector2 PerProduct()
        {
            return new Vector2(this.Y, -this.X);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }


        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public static Vector2 Normalize(Vector2 value)
        {
            Vector2 vector;
            float num2 = (value.X * value.X) + (value.Y * value.Y);
            float num = 1f / ((float)Math.Sqrt((double)num2));
            vector.X = value.X * num;
            vector.Y = value.Y * num;
            return vector;
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 vector2;
            float num = (vector.X * normal.X) + (vector.Y * normal.Y);
            vector2.X = vector.X - ((2f * num) * normal.X);
            vector2.Y = vector.Y - ((2f * num) * normal.Y);
            return vector2;
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = (value1.X < value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            return vector;
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Vector2 vector;
            vector.X = (value1.X > value2.X) ? value1.X : value2.X;
            vector.Y = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            return vector;
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            Vector2 vector;
            vector.X = value1.X + ((value2.X - value1.X) * amount);
            vector.Y = value1.Y + ((value2.Y - value1.Y) * amount);
            return vector;
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return ((value1.X * value2.X) + (value1.Y * value2.Y));
        }

        public static Vector2 operator +(Vector2 u, Vector2 v)
        {
            Vector2 vec;
            vec.X = u.X + v.X;
            vec.Y = u.Y + v.Y;
            return vec;
        }

        public static Vector2 operator -(Vector2 u, Vector2 v)
        {
            Vector2 vec;
            vec.X = u.X - v.X;
            vec.Y = u.Y - v.Y;
            return vec;
        }

        public static Vector2 operator *(float s, Vector2 v)
        {
            Vector2 vec;
            vec.X = s * v.X;
            vec.Y = s * v.Y;
            return vec;
        }

        public static Vector2 operator *(Vector2 u, float s)
        {
            Vector2 vec;
            vec.X = u.X * s;
            vec.Y = u.Y * s;
            return vec;
        }

        public static Vector2 operator /(Vector2 u, float s)
        {
            Vector2 vec;
            vec.X = u.X / s;
            vec.Y = u.Y / s;
            return vec;
        }
    }
}
