using ElectronicsStore.Models;
using ElectronicsStore.Services;

var c1 = new Customer { Id = 1, Name = "Alice" };
var c2 = new Customer { Id = 2, Name = "Bob" };
var c3 = new Customer { Id = 3, Name = "Charlie" };
var c4 = new Customer { Id = 4, Name = "Diana" };

var order1 = new Order { OrderId = 101 };
order1.Items.Add(new OrderItem { ProductName = "Laptop", Quantity = 1, UnitPrice = 600 });
order1.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 2, UnitPrice = 40 });
c1.Orders.Add(order1);

var order2 = new Order { OrderId = 102 };
order2.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 1, UnitPrice = 120 });
c1.Orders.Add(order2);

var order3 = new Order { OrderId = 103 };
order3.Items.Add(new OrderItem { ProductName = "Monitor", Quantity = 2, UnitPrice = 250 });
c2.Orders.Add(order3);

var order4 = new Order { OrderId = 104 };
order4.Items.Add(new OrderItem { ProductName = "Mouse", Quantity = 1, UnitPrice = 40 });
order4.Items.Add(new OrderItem { ProductName = "Headphones", Quantity = 1, UnitPrice = 150 });
c2.Orders.Add(order4);

var order5 = new Order { OrderId = 105 };
order5.Items.Add(new OrderItem { ProductName = "Laptop", Quantity = 2, UnitPrice = 700 });
c3.Orders.Add(order5);

var order6 = new Order { OrderId = 106 };
order6.Items.Add(new OrderItem { ProductName = "Tablet", Quantity = 3, UnitPrice = 300 });
order6.Items.Add(new OrderItem { ProductName = "Keyboard", Quantity = 2, UnitPrice = 100 });
c4.Orders.Add(order6);

var customers = new List<Customer> { c1, c2, c3, c4 };

var orders = customers.SelectMany(c => c.Orders).ToList();

var service = new OrderService();

Console.WriteLine("Top spending customer: " + 
    service.GetTopSpendingCustomer(customers));

Console.WriteLine("\nPopular Products:");
var popularProducts = service.GetPopularProducts(orders);

foreach (var product in popularProducts
         .OrderByDescending(p => p.Value))
{
    Console.WriteLine($"{product.Key} - {product.Value} sold");
}