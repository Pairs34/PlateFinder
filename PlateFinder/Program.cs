using System;
using System.IO;
using openalprnet;
using System.Linq;

namespace PlateFinder
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var openalprConf = Path.Combine(Directory.GetCurrentDirectory(), "openalpr.conf");
            var runtimeData = Path.Combine(Directory.GetCurrentDirectory(), "runtime_data");
            var samplePath = Path.Combine(Directory.GetCurrentDirectory(),"samples\\tk2.png");
            var alpr = new AlprNet("eu",
                openalprConf,
                runtimeData);
            if (!alpr.IsLoaded())
            {
                Console.WriteLine("OpenAlpr failed to load!");
                return;
            }

            var results = alpr.Recognize(samplePath);
            Console.WriteLine(results.Plates.Select(x => x.BestPlate.Characters).FirstOrDefault());

            Console.ReadLine();
        }
    }
}