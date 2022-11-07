using BlackBoxTesting.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

const string TitleName = "Black Box Testing Challenge";
Console.WriteLine(TitleName);
Console.WriteLine(new string('─', TitleName.Length));

const string AppSettingFileName = "appsettings.json";
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile(AppSettingFileName)
    .Build();

// Serilog (original)
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
Log.Logger.Verbose("Serilog - Trace");
Log.Logger.Debug("Serilog - Debug");
Log.Logger.Information("Serilog - Information");
Log.Logger.Warning("Serilog - Warning");
Log.Logger.Error("Serilog - Error");
Log.Logger.Fatal("Serilog - Critical");


// Microsoft Logging Standard
//Microsoft.Extensions.Logging.ILogger logger = new SerilogLogger(configuration);
//logger.LogTrace("Microsoft - Trace");
//logger.LogDebug("Microsoft - Debug");
//logger.LogInformation("Microsoft - Information");
//logger.LogWarning("Microsoft - Warning");
//logger.LogError("Microsoft - Error");
//logger.LogCritical("Microsoft - Critical");