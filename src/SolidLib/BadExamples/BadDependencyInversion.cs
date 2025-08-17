using System;

namespace SolidLib.BadExamples
{
    public class EmailClient
    {
        public void Send(string address, string message)
        {
            Console.WriteLine($"Sending to {address}: {message}");
        }
    }

    // This class violates the Dependency Inversion Principle by depending
    // on the concrete EmailClient instead of an abstraction.
    public class RegistrationService
    {
        private readonly EmailClient _client = new();

        public void Register(string email)
        {
            // register user
            _client.Send(email, "Welcome!");
        }
    }
}
