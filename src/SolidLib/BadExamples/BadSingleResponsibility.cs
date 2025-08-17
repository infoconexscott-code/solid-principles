using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace SolidLib.BadExamples
{
    // This class violates the Single Responsibility Principle by
    // handling file I/O, database persistence, business rules,
    // email notifications, and external API calls all in one place.
    public class MonolithicOrderService
    {
        private readonly HttpClient _http = new();
        private readonly SmtpClient _smtp = new("localhost");

        public void Process(string orderFile)
        {
            // load order from disk
            var json = File.ReadAllText(orderFile);
            var order = JsonSerializer.Deserialize<Order>(json) ?? new Order();

            // save to SQLite
            using var db = new SqliteConnection("Data Source=orders.db");
            db.Open();
            using var cmd = db.CreateCommand();
            cmd.CommandText = "INSERT INTO Orders(Id, Customer) VALUES ($id, $customer)";
            cmd.Parameters.AddWithValue("$id", order.Id);
            cmd.Parameters.AddWithValue("$customer", order.Customer);
            cmd.ExecuteNonQuery();

            // business rules with many branches
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

            // send confirmation email
            var mail = new MailMessage("sales@example.com", order.Email)
            {
                Subject = "Order processed",
                Body = $"Order total: {total}"
            };
            _smtp.Send(mail);
        }

        private class Order
        {
            public int Id { get; set; }
            public string Customer { get; set; } = "";
            public string Email { get; set; } = "";
            public List<OrderItem> Items { get; set; } = new();
        }

        private class OrderItem
        {
            public string Name { get; set; } = "";
            public int Quantity { get; set; }
            public double Price { get; set; }
        }
    }
}
