using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherRaytracerCore
{
    public class Ray
    {
        public readonly Vector3 Origin;
        public readonly Vector3 Direction;

        public Ray(Vector3 origin, Vector3 destination)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Direction = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        public Vector3 At(double t)
        {
            return Origin + (Direction * t);
        }
    }
}
