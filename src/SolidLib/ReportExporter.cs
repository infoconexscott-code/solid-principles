namespace SolidLib
{
    // This class intentionally violates the Open/Closed Principle. Every new
    // export format requires modifying this class.
    public class ReportExporter
    {
        public string Export(int format, string data)
        {
            if (format == 1)
            {
                return $"PDF:{data}";
            }
            else if (format == 2)
            {
                return $"Excel:{data}";
            }
            else
            {
                return $"Unknown:{data}";
            }
        }
    }
}
