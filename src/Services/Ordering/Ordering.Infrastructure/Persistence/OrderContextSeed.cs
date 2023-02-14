using System;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
	public class OrderContextSeed
	{
        public static async Task SeedAsync(OrderContext orderContext,
            ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}",
                    typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                    UserName = "alimonova", FirstName = "Oleksandra",
                    LastName = "Alimonova", EmailAddress = "sburchinskaya.2000@gmail.com",
                    AddressLine = "Hertsena 2v", Country = "Ukraine",
                    State = "Chernivtsi", ZipCode = "58000",
                    TotalPrice = 500, CVV = "123", CardName = "Test Card",
                    CardNumber = "1234 5678 9101 1121", Expiration = "01/01"
                }
            };
        }
	}
}

