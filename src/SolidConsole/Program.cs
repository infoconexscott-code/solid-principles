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
            generator.SaveReport(report);
            generator.SendReport("someone@example.com", report);
            Console.WriteLine("Report generated");
        }
    }
}
