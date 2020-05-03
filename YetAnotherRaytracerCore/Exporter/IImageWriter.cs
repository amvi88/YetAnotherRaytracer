using System.Threading.Tasks;

namespace YetAnotherRaytracerCore.Exporter
{
    public interface IImageWriter
    {
        Task WriteToFile(string fileName, int imageWidth, int imageHeight);
    }
}
