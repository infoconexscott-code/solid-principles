namespace SolidLib.BadExamples
{
    // This class violates the Open/Closed Principle because
    // adding new customer types requires modifying this method.
    public class DiscountCalculator
    {
        public decimal ApplyDiscount(string customerType, decimal price)
        {
            if (customerType == "Regular")
            {
                return price;
            }
            else if (customerType == "Premium")
            {
                return price * 0.9m;
            }
            else if (customerType == "Vip")
            {
                return price * 0.8m;
            }
            else
            {
                return price;
            }
        }
    }
}
