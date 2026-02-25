using ElectronicsStore.Models;

namespace ElectronicsStore.Services;

public class OrderService
{
    // 2.3
    public string? GetTopSpendingCustomer(List<Customer> customers)
    {
        //Sorts customers by total money spent (highest first) and returns the name of the biggest spender
        return customers
            .OrderByDescending(c => c.GetTotalSpent())
            .FirstOrDefault()?.Name;
    }

    // 2.4
    public Dictionary<string, int> GetPopularProducts(List<Order> orders)
    {
        //Collects all products from all orders, groups them by name, and calculates how many units of each product were sold
        return orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(i => i.Quantity)
            );
    }
}