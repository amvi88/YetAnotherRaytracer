namespace YetAnotherRaytracerCore.Shape
{
    public class HitData {
        public bool IsHit {get; set;}
        public Vector3 P { get; set; }
        public Vector3 Normal { get; set; }
        public double T { get; set; }

        public bool IsFrontFacing { get; set; }

        public void SetFaceNormal(Ray ray, Vector3  outwardNormal) {
            IsFrontFacing = Vector3.DotProduct(ray.Direction, outwardNormal) < 0;
            Normal = IsFrontFacing ? outwardNormal :-outwardNormal;
        }
    }
}
