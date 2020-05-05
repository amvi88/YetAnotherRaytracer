namespace YetAnotherRaytracerCore.Shape
{
    using System;

    public class Sphere : IShape
    {
        public Vector3 Center { get; set; }

        public double Radius { get; set; }
        
        public Sphere(Vector3 center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }


        public HitData IsHit(Ray ray, double tMin, double tMax)
        {
            HitData result = new HitData { IsHit = false };

            Vector3 oc = ray.Origin - this.Center;
            var a = ray.Direction.LengthSquared;
            var half_b = Vector3.DotProduct(oc, ray.Direction);
            var c = oc.LengthSquared - this.Radius * Radius;
            var discriminant = half_b * half_b - a * c;

            if (discriminant > 0)
            {
                var root = Math.Sqrt(discriminant);
                var temp = (-half_b - root) / a;
                if (temp < tMax && temp > tMin)
                {
                    result.T = temp;
                    result.P = ray.At(result.T);
                    result.Normal = (result.P - this.Center) / this.Radius;
                    result.IsHit = true;

                    Vector3 outwardNormal = (result.P - this.Center) / this.Radius;
                    result.SetFaceNormal(ray, outwardNormal);
                    return result;
                }
                temp = (-half_b + root) / a;
                if (temp < tMax && temp > tMin)
                {
                    result.T = temp;
                    result.P = ray.At(result.T);
                    result.Normal = (result.P - this.Center) / this.Radius;
                    result.IsHit = true;

                    Vector3 outwardNormal = (result.P - this.Center) / this.Radius;
                    result.SetFaceNormal(ray, outwardNormal);
                    return result;
                }
            }
            return result;
        }
    }
}
