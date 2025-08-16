using System;

namespace SolidLib
{
    // This interface violates the Interface Segregation Principle by forcing
    // implementations to provide many unrelated methods.
    public interface IMultiFunctionDevice
    {
        void Print(string content);
        void Scan(string content);
        void Fax(string content);
    }

    // This class is forced to implement methods it doesn't need.
    public class SimplePrinter : IMultiFunctionDevice
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }

        public void Scan(string content)
        {
            throw new NotImplementedException();
        }

        public void Fax(string content)
        {
            throw new NotImplementedException();
        }
    }
}
