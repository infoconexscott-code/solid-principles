using System;

namespace SolidLib.BadExamples
{
    // This interface violates the Interface Segregation Principle by
    // requiring unrelated operations.
    public interface IOfficeMachine
    {
        void Print(string document);
        void Scan(string document);
        void Staple(string document);
    }

    // This class is forced to implement methods it does not need.
    public class DeskScanner : IOfficeMachine
    {
        public void Print(string document) => throw new NotImplementedException();
        public void Scan(string document) { /* scanning */ }
        public void Staple(string document) => throw new NotImplementedException();
    }
}
