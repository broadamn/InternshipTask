namespace ElectronicsStore.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; set; } = [];

    // 2.2
    public decimal CalculateFinalPrice()
    {
        var total = Items.Sum(i => i.GetTotalPrice());

        if (total > 500)
            total *= 0.9m;

        return total;
    }
}