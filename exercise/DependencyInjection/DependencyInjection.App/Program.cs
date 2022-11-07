using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Repositories;
using DependencyInjection.Shared.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using System.Text.Json;
using System.Text.Json.Serialization;
using sl = Serilog;

const string TitleName = "Dependency Injection (DEMO)";
Console.WriteLine(TitleName);
Console.WriteLine(new string('─', TitleName.Length));

#region Register IoC

var container = new Container();
container.Register<OrderService>();
container.Register<ProductService>();
container.Register<IOrderRepository, SqlOrderRepository>();
container.Register<IProductRepository, SqlProductRepository>();
container.Register<ILogger>(() =>
{
    var config = new sl.LoggerConfiguration().MinimumLevel.Error();
    var serilogLogger = sl.ConsoleLoggerConfigurationExtensions.Console(config.WriteTo).CreateLogger();
    var microsoftLogger = new sl.Extensions.Logging.SerilogLoggerFactory(serilogLogger).CreateLogger("SerilogLogger");
    return microsoftLogger;
}, Lifestyle.Singleton);
container.Register<ShoppingContext>(() =>
{
    var connBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
    var connection = new SqliteConnection(connBuilder.ConnectionString);
    var options = new DbContextOptionsBuilder<ShoppingContext>()
        .UseSqlite(connection)
        .Options;
    var context = new ShoppingContext(options);
    context.Database.OpenConnection();
    context.Database.EnsureCreated();
    return context;
}, Lifestyle.Singleton);
container.Verify();

#endregion

SetupProducts();

var command = string.Empty;
do
{
    Console.WriteLine(new string('─', TitleName.Length));
    Console.WriteLine("MENU");
    Console.WriteLine("(1) List all products");
    Console.WriteLine("(2) List all orders");
    Console.WriteLine("(3) Add new product");
    Console.WriteLine("(4) Add new order");
    Console.WriteLine("(5) Cancel an order");
    Console.WriteLine("(0) Exit");
    Console.Write("Please choose a command number: ");
    command = Console.ReadLine();
    Console.WriteLine(new string('─', TitleName.Length));
    switch (command)
    {
        case "1": ListAllProducts(); break;
        case "2": ListAllOrders(); break;
        case "3":
            {
                Console.Write("Add new product name: ");
                var name = Console.ReadLine();
                while (true)
                {
                    Console.Write("Add new product price: ");
                    if (double.TryParse(Console.ReadLine(), out double price))
                    {
                        CreateNewProduct(name, price);
                        break;
                    }
                    Console.WriteLine("PLEASE INSERT NUMBER ONLY!");
                }
                break;
            }
        case "4":
            {
                Console.Write("Order a product Id: ");
                if (null == CreateNewOrder(Console.ReadLine()))
                {
                    Console.WriteLine("INVALID PRODUCT ID!");
                }
                break;
            }
        case "5":
            {
                Console.Write("Cancel an order Id: ");
                if (null == CancelOrder(Console.ReadLine()))
                {
                    Console.WriteLine("INVALID ORDER ID OR IT CANCELLED ALREADY!");
                }
                break;
            }
        default: break;
    }

} while (command.ToLower() != "0");


#region Utilities

void SetupProducts()
{
    Console.WriteLine("Setup products");
    CreateNewProduct("iPhone 14 Pro Max", 44_900.00);
    CreateNewProduct("iPhone 14 Pro", 41_900.00);
    CreateNewProduct("iPhone 14 Plus", 37_900.00);
    CreateNewProduct("Galaxy Flip 4", 38_900.00);
    CreateNewProduct("Galaxy Z Fold4", 59_900.00);
    CreateNewProduct("Galaxy S22 Ultra", 35_900.00);
    CreateNewProduct("Galaxy S22", 25_900.00);
}

IEnumerable<ProductInfo> ListAllProducts()
{
    var result = container.GetInstance<ProductService>()
        .GetAllProducts();
    WriteToConsole(result);
    return result;
}
IEnumerable<OrderInfo> ListAllOrders()
{
    var result = container.GetInstance<OrderService>()
        .GetAllOrders();
    WriteToConsole(result);
    return result;
}
ProductInfo CreateNewProduct(string name, double price)
    => container.GetInstance<ProductService>().CreateNewProduct(name, price);
OrderInfo CreateNewOrder(string productId)
    => container.GetInstance<OrderService>().CreateNewOrder(productId);
OrderInfo CancelOrder(string orderId)
    => container.GetInstance<OrderService>().CancelOrder(orderId);

void WriteToConsole<T>(IEnumerable<T> data)
{
    var options = new JsonSerializerOptions();
    options.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd"));
    var qry = data.Select(it => JsonSerializer.Serialize(it, options));
    foreach (var item in qry)
    {
        Console.WriteLine(item);
    }
}

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string Format;
    public CustomDateTimeConverter(string format)
        => Format = format;
    public override void Write(Utf8JsonWriter writer, DateTime date, JsonSerializerOptions options)
        => writer.WriteStringValue(date.ToString(Format));
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString(), Format, null);
}

#endregion