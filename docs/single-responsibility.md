# Single Responsibility Principle

A class should have only one reason to change.

Keeping a single focus makes classes easier to read, test, and modify. When responsibilities
are mixed together, even a small requirement change can force unrelated edits and lead to
fragile code.

Introduced by [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_C._Martin) (Uncle Bob).

## Violation

```csharp
public class MonolithicOrderService
{
    private readonly HttpClient _http = new();
    private readonly SmtpClient _smtp = new("localhost");

    public void Process(string orderFile)
    {
        var json = File.ReadAllText(orderFile);
        var order = JsonSerializer.Deserialize<Order>(json) ?? new Order();

        using var db = new SqliteConnection("Data Source=orders.db");
        db.Open();
        using var cmd = db.CreateCommand();
        cmd.CommandText = "INSERT INTO Orders(Id, Customer) VALUES ($id, $customer)";
        cmd.Parameters.AddWithValue("$id", order.Id);
        cmd.Parameters.AddWithValue("$customer", order.Customer);
        cmd.ExecuteNonQuery();

        double total = 0;
        foreach (var item in order.Items)
        {
            if (item.Quantity > 10)
                total += item.Price * item.Quantity * 0.9;
            else if (item.Quantity > 5)
                total += item.Price * item.Quantity * 0.95;
            else
                total += item.Price * item.Quantity;
        }

        if (total > 1000)
        {
            var response = _http.PostAsync("https://api.example.com/discounts",
                new StringContent(json)).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Discount API call failed");
            }
        }

        var mail = new MailMessage("sales@example.com", order.Email)
        {
            Subject = "Order processed",
            Body = $"Order total: {total}"
        };
        _smtp.Send(mail);
    }
}
```

`MonolithicOrderService` juggles file I/O, database access, business rules, HTTP calls and
email notifications. Any change in one area forces edits to the same class.

## Fix

Break up concerns into focused collaborators:

```csharp
public class FileOrderReader
{
    public Order Load(string path) =>
        JsonSerializer.Deserialize<Order>(File.ReadAllText(path)) ?? new Order();
}

public class OrderRepository
{
    private readonly string _connectionString = "Data Source=orders.db";
    public void Save(Order order)
    {
        using var db = new SqliteConnection(_connectionString);
        db.Open();
        using var cmd = db.CreateCommand();
        cmd.CommandText = "INSERT INTO Orders(Id, Customer) VALUES ($id, $customer)";
        cmd.Parameters.AddWithValue("$id", order.Id);
        cmd.Parameters.AddWithValue("$customer", order.Customer);
        cmd.ExecuteNonQuery();
    }
}

public class DiscountService
{
    private readonly HttpClient _http;
    public DiscountService(HttpClient http) => _http = http;
    public async Task ApplyDiscountAsync(Order order)
    {
        await _http.PostAsync("https://api.example.com/discounts",
            new StringContent(JsonSerializer.Serialize(order)));
    }
}

public class EmailNotifier
{
    private readonly SmtpClient _smtp;
    public EmailNotifier(SmtpClient smtp) => _smtp = smtp;
    public void SendConfirmation(Order order, double total)
    {
        var mail = new MailMessage("sales@example.com", order.Email)
        {
            Subject = "Order processed",
            Body = $"Order total: {total}"
        };
        _smtp.Send(mail);
    }
}

public class OrderProcessor
{
    private readonly FileOrderReader _reader;
    private readonly OrderRepository _repository;
    private readonly DiscountService _discounts;
    private readonly EmailNotifier _notifier;

    public OrderProcessor(FileOrderReader reader, OrderRepository repository,
        DiscountService discounts, EmailNotifier notifier)
    {
        _reader = reader;
        _repository = repository;
        _discounts = discounts;
        _notifier = notifier;
    }

    public async Task ProcessAsync(string orderFile)
    {
        var order = _reader.Load(orderFile);
        _repository.Save(order);
        await _discounts.ApplyDiscountAsync(order);
        _notifier.SendConfirmation(order, 0);
    }
}
```

Each class now focuses on one responsibility, making changes local and tests easier to write.

## Benefits

- **Simpler maintenance** – changing how orders are loaded, persisted, discounted or notified is isolated.
- **Easier testing** – each class can be exercised in isolation with focused unit tests.
- **Greater reuse** – order processing logic can be reused without carrying file system, database or email concerns.

[Back to overview](README.md)
