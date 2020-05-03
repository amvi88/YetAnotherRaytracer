using System.IO;
using System.Threading.Tasks;

namespace YetAnotherRaytracerCore.Exporter
{

    public class PPMImageWriter : IImageWriter
    {
        public async Task WriteToFile(string fileName, int imageWidth, int imageHeight)
        {
            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine($"P3");
                sw.WriteLine($"{imageWidth} {imageHeight}");
                sw.WriteLine($"255");
                for (double j = imageHeight - 1; j >= 0; --j)
                {
                    for (double i = 0; i < imageWidth; ++i)
                    {
                        var currentVec = new Vector3(i / imageWidth, j / imageHeight, 0.2);
                        sw.WriteLine(ToColor(currentVec));
                    }
                }
            }
        }

        public string ToColor(Vector3 v) { 
            const double colorFactor = 255.999;
            return $"{(int)(colorFactor * v.X)} {(int)(colorFactor * v.Y)} {(int)(colorFactor * v.Z)}";
        }
    }
}
