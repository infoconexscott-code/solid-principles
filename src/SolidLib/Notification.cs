using System;

namespace SolidLib
{
    // Base notification class
    public class Notification
    {
        public virtual void Send(string message)
        {
            Console.WriteLine($"Sending: {message}");
        }
    }

    public class EmailNotification : Notification
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }

    // This class violates the Liskov Substitution Principle by throwing
    // an exception for long messages, unlike the base class.
    public class SmsNotification : Notification
    {
        public override void Send(string message)
        {
            if (message.Length > 10)
            {
                throw new InvalidOperationException("Message too long");
            }

            Console.WriteLine($"SMS: {message}");
        }
    }
}
