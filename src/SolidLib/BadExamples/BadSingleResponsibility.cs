using System;
using System.IO;

namespace SolidLib.BadExamples
{
    // This class violates the Single Responsibility Principle by
    // performing calculation, persistence, and notification.
    public class InvoiceService
    {
        public void Process(string customer, double amount)
        {
            var total = amount * 1.2; // apply tax
            File.AppendAllText("invoices.txt", $"{customer}:{total}\n");
            Console.WriteLine($"Invoice for {customer} processed: {total}");
        }
    }
}
