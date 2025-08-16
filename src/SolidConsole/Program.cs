using System;
using SolidLib;

namespace SolidConsole
{
    // This program violates several SOLID principles intentionally.
    public class Program
    {
        public static void Main(string[] args)
        {
            var generator = new ReportGenerator();
            var report = generator.Generate(1);
            var json = generator.GenerateJsonReport(1);
            generator.SaveReport(json);
            generator.SendReport("someone@example.com", json);
            Console.WriteLine("Report generated");
        }
    }
}
