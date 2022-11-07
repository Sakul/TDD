using DependencyInjection.Shared.Repositories;
using DependencyInjection.Shared.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new Serilog.LoggerConfiguration()
  .MinimumLevel.Error()
  .WriteTo.Console()
  .CreateLogger();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Setup IoC

builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<IOrderRepository, SqlOrderRepository>();
builder.Services.AddTransient<IProductRepository, SqlProductRepository>();
builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(pvd => new SerilogLoggerFactory(logger).CreateLogger("SerilogLogger"));
builder.Services.AddSingleton<ShoppingContext>(pvd =>
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
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

CreateNewProduct("iPhone 14 Pro Max", 44_900.00);
CreateNewProduct("iPhone 14 Pro", 41_900.00);
CreateNewProduct("iPhone 14 Plus", 37_900.00);
CreateNewProduct("Galaxy Flip 4", 38_900.00);
CreateNewProduct("Galaxy Z Fold4", 59_900.00);
CreateNewProduct("Galaxy S22 Ultra", 35_900.00);
CreateNewProduct("Galaxy S22", 25_900.00);

app.Run();

void CreateNewProduct(string name, double price)
    => app.Services.GetService<ProductService>().CreateNewProduct(name, price);