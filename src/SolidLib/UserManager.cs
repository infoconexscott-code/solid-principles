using System;
using System.IO;
using System.Net.Mail;

namespace SolidLib
{
    // This class intentionally violates the Single Responsibility Principle by
    // handling user creation, persistence, and notification in one place.
    public class UserManager
    {
        public void CreateUser(string name, string email)
        {
            Console.WriteLine($"Creating user {name}");
            // Persist user to a text file
            File.AppendAllText("users.txt", $"{name},{email}\n");

            // Notify the user via email
            try
            {
                using var client = new SmtpClient("smtp.example.com");
                client.Send("noreply@example.com", email, "Welcome", "Hello and welcome!");
            }
            catch
            {
                // ignore email failures
            }
        }
    }
}
