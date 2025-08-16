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

            // Additional classes demonstrating SOLID principle violations
            var userManager = new UserManager();
            userManager.CreateUser("Alice", "alice@example.com");

            var exporter = new ReportExporter();
            var exported = exporter.Export(1, report);

            Notification notification = new SmsNotification();
            try
            {
                notification.Send("This message is definitely too long");
            }
            catch
            {
                // ignore notification failures
            }

            IMultiFunctionDevice device = new SimplePrinter();
            device.Print(exported);

            var processor = new OrderProcessor();
            processor.Process("order data");
            Console.WriteLine("Report generated");
        }
    }
}
