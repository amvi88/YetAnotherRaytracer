namespace YetAnotherRaytracer
{
    using System;
    using YetAnotherRaytracerCore;
    using YetAnotherRaytracerCore.Exporter;

    class Program
    {
        static void Main(string[] args)
        {
            var imageOutput = new PPMImageWriter();
            imageOutput.WriteToFile("test.ppm", 200, 100);
        }
    }
}
