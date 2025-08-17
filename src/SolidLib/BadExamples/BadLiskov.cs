using System;

namespace SolidLib.BadExamples
{
    public class PaymentProcessor
    {
        public virtual void Refund(decimal amount)
        {
            // base refund logic
        }
    }

    // This subclass violates Liskov Substitution Principle by throwing
    // when clients expect a refund to succeed.
    public class GiftCardProcessor : PaymentProcessor
    {
        public override void Refund(decimal amount)
        {
            throw new InvalidOperationException("Gift cards cannot be refunded");
        }
    }
}
