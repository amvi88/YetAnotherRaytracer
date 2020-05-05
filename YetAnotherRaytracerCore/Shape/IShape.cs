namespace YetAnotherRaytracerCore.Shape
{
    using System.Collections.Generic;
    using System.Text;

    public interface IShape
    {
        HitData IsHit(Ray r, double tMin, double tMax);
    }
}
