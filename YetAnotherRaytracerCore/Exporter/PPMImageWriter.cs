using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YetAnotherRaytracerCore.Shape;

namespace YetAnotherRaytracerCore.Exporter
{

    public class PPMImageWriter : IImageWriter
    {
        public async Task WriteToFile(string fileName, int imageWidth, int imageHeight)
        {

            var lowerLeftCorner = new Vector3 (-2.0, -1.0, -1.0);
            var horizontal = new Vector3(4.0, 0.0, 0.0);
            var vertical = new Vector3(0.0, 2.0, 0.0);
            var origin = new Vector3(0.0, 0.0, 0.0);

            var shapes = new List<IShape>() { 
                new Sphere(new Vector3(0, 0, -1), 0.5),
                new Sphere(new Vector3(0, -100.5, -1), 100)
            };
            

            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine($"P3");
                sw.WriteLine($"{imageWidth} {imageHeight}");
                sw.WriteLine($"255");
                for (double j = imageHeight - 1; j >= 0; --j)
                {
                    for (double i = 0; i < imageWidth; ++i)
                    {
                        var u = i / imageWidth;
                        var v = j / imageHeight;
                        var ray = new Ray(origin, lowerLeftCorner + horizontal * u  +  vertical * v );
                        sw.WriteLine(ToColor(GetRayColor(ray, shapes)));
                    }
                }
            }
        }

        public string ToColor(Vector3 v) { 
            const double colorFactor = 255.999;
            return $"{(int)(colorFactor * v.X)} {(int)(colorFactor * v.Y)} {(int)(colorFactor * v.Z)}";
        }

        public Vector3 GetRayColor(Ray ray, List<IShape> shapes) {

            var hits = shapes.Select(x => x.IsHit(ray, 0, double.MaxValue))
                .Where(y => y.IsHit)
                .OrderBy(z => z.T);
                       
            if (hits.Any())
            {
                var closest = hits.First();
                return (closest.Normal + new Vector3(1, 1, 1)) *0.5;
            }

            var unitDirection = ray.Direction.UnitVector();
            var t = 0.5 * (unitDirection.Y + 1.0);
            return new Vector3(1.0, 1.0, 1.0) * (1.0 - t) +  new Vector3(0.5, 0.7, 1.0) * t;
         }
    }
}
