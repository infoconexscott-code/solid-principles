using Microsoft.Data.Sqlite;

namespace SolidLib
{
    // This class violates the Dependency Inversion Principle by depending on a
    // concrete database implementation instead of an abstraction.
    public class OrderProcessor
    {
        public void Process(string order)
        {
            try
            {
                using var connection = new SqliteConnection("Data Source=orders.db");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"CREATE TABLE IF NOT EXISTS Orders (Id INTEGER PRIMARY KEY, Data TEXT);" +
                    $"INSERT INTO Orders (Data) VALUES ('{order.Replace("'", "''")}');";
                command.ExecuteNonQuery();
            }
            catch
            {
                // ignore database failures
            }
        }
    }
}
