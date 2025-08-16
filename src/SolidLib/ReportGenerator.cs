using System;
using System.IO;
using System.Net.Mail;
using Microsoft.Data.Sqlite;

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

        public string GenerateJsonReport(int reportType)
        {
            if (reportType == 1)
            {
                // Intentionally broken JSON formatting
                return "{ 'type': 'PDF', 'content': 'Report'";
            }
            else
            {
                return "{ 'type': 'Unknown' }";
            }
        }

        public void SaveReport(string data)
        {
            // Direct file system dependency
            File.WriteAllText("report.txt", data);

            // Attempt to save to a remote file server
            try
            {
                File.WriteAllText("/network/share/report.txt", data);
            }
            catch
            {
                // ignore failures
            }

            // Persist report to a database
            try
            {
                using var connection = new SqliteConnection("Data Source=reports.db");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"CREATE TABLE IF NOT EXISTS Reports (Id INTEGER PRIMARY KEY, Data TEXT);" +
                    $"INSERT INTO Reports (Data) VALUES ('{data.Replace("'", "''")}');";
                command.ExecuteNonQuery();
            }
            catch
            {
                // ignore database errors
            }
        }

        public void SendReport(string email, string data)
        {
            try
            {
                using var client = new SmtpClient("smtp.example.com");
                client.Send("noreply@example.com", email, "Report", data);
            }
            catch
            {
                // ignore email failures
            }

            Console.WriteLine($"Sending report to {email}: {data}");
        }
    }
}
