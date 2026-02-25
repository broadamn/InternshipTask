namespace ElectronicsStore.Models;

public class OrderItem
{
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal GetTotalPrice()
    {
        return Quantity * UnitPrice;
    }
}