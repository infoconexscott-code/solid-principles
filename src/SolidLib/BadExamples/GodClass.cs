using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SolidLib.BadExamples
{
    // An exaggerated example of a "God Class" that tries to do everything.
    // Each method represents a different responsibility, making this class
    // extremely difficult to maintain and refactor.
    public class GodClass
    {
        public void CalculateSalary(double baseSalary, double bonus)
        {
            Console.WriteLine($"Total salary: {baseSalary + bonus}");
        }

        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"Sending email to {to}: {message}");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount}");
        }

        public string GenerateReport(IEnumerable<string> data)
        {
            return string.Join(",", data);
        }

        public string SerializeData(object obj)
        {
            return obj.ToString();
        }

        public object DeserializeData(string json)
        {
            return json;
        }

        public bool AuthenticateUser(string username, string password)
        {
            return username == password;
        }

        public bool AuthorizeUser(string username, string role)
        {
            return true;
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public void UploadFile(string path)
        {
            Console.WriteLine($"Uploading {path}");
        }

        public void DownloadFile(string url)
        {
            Console.WriteLine($"Downloading from {url}");
        }

        public void ConnectToDatabase(string connectionString)
        {
            Console.WriteLine($"Connecting to {connectionString}");
        }

        public void ExecuteSqlQuery(string query)
        {
            Console.WriteLine($"Executing SQL: {query}");
        }

        public void BackupDatabase()
        {
            Console.WriteLine("Backing up database");
        }

        public void RestoreDatabase()
        {
            Console.WriteLine("Restoring database");
        }

        public void SendSms(string number, string message)
        {
            Console.WriteLine($"Sending SMS to {number}: {message}");
        }

        public void PrintDocument(string document)
        {
            Console.WriteLine($"Printing {document}");
        }

        public void StartWorkflow(string name)
        {
            Console.WriteLine($"Starting workflow {name}");
        }

        public void StopWorkflow(string name)
        {
            Console.WriteLine($"Stopping workflow {name}");
        }

        public string GetConfiguration(string key)
        {
            return "value";
        }

        public void SetConfiguration(string key, string value)
        {
            Console.WriteLine($"Setting {key} to {value}");
        }

        public double CalculateTax(double amount)
        {
            return amount * 0.2;
        }

        public string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public double ParseNumber(string text)
        {
            return double.TryParse(text, out var number) ? number : 0;
        }

        public bool ValidateInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public string EncryptData(string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }

        public string DecryptData(string data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        public int GenerateRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
