using System;
using System.IO;

namespace SolidLib
{
    // This class intentionally violates several SOLID principles.
    public class ReportGenerator
    {
        public string Generate(int reportType)
        {
            if (reportType == 1)
            {
                return "PDF Report";
            }
            else if (reportType == 2)
            {
                return "Excel Report";
            }
            else
            {
                return "Unknown Report";
            }
        }

        public void SaveReport(string data)
        {
            // Direct file system dependency
            File.WriteAllText("report.txt", data);
        }

        public void SendReport(string email, string data)
        {
            // Simulated email sending
            Console.WriteLine($"Sending report to {email}: {data}");
        }
    }
}
