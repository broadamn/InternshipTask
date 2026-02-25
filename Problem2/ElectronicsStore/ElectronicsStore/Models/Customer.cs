namespace ElectronicsStore.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; } = [];
    
    public decimal GetTotalSpent()
    {
        return Orders.Sum(o => o.CalculateFinalPrice());
    }
}