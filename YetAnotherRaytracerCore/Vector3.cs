using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherRaytracerCore
{
    public class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3() : this(0, 0, 0)
        {
        }

        public double Length => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

        public static Vector3 operator -(Vector3 v) => new Vector3(-v.X, -v.Y, -v.Z);

        public static Vector3 operator -(Vector3 v, Vector3 u) => new Vector3(v.X - u.X, v.Y - u.Y, v.Y - u.Y);

        public static Vector3 operator +(Vector3 u, Vector3 v) => new Vector3(u.X + v.X, u.Y + v.Y, u.Z + v.Z);

        public static Vector3 operator *(Vector3 v, double t) => new Vector3(t * v.X, t * v.Y, t * v.Z);

        public static Vector3 operator *(Vector3 v, Vector3 u) => new Vector3(v.X * u.X, v.Y * u.Y, v.Z * u.Z);

        public static Vector3 operator /(Vector3 v, double t) => v * (1 / t);

        public double DotProduct(Vector3 v) => this.X * v.X + this.Y * v.Y + this.Z * v.Z;

        public static double DotProduct(Vector3 v, Vector3 u) => u.X * v.X + u.Y * v.Y + u.Z * v.Z;

        public Vector3 CrossProduct(Vector3 v) => new Vector3(this.Y * v.Z - this.Z * v.Y, this.Z * v.X - this.X * v.Z, this.X * v.Y - this.Y * v.X);

        public static Vector3 CrossProduct(Vector3 v, Vector3 u) => new Vector3(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);

        public static Vector3 UnitVector(Vector3 v) => v / v.Length;

        public override string ToString() => $"X:{this.X}, Y:{this.Y}, Z:{this.Z}";
    }
}
