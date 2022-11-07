using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace BlackBoxTesting.Shared
{
    public class SerilogLogger : ILogger
    {
        private readonly Logger serilogLogger;
        private readonly ILogger microsoftLogger;

        public SerilogLogger(IConfiguration configuration)
        {
            serilogLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            microsoftLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger(nameof(SerilogLogger));
        }

        public IDisposable BeginScope<TState>(TState state)
            => serilogLogger;

        public bool IsEnabled(LogLevel logLevel)
            => logLevel switch
            {
                LogLevel.Trace => serilogLogger.IsEnabled(LogEventLevel.Verbose),
                LogLevel.Debug => serilogLogger.IsEnabled(LogEventLevel.Debug),
                LogLevel.Information => serilogLogger.IsEnabled(LogEventLevel.Information),
                LogLevel.Warning => serilogLogger.IsEnabled(LogEventLevel.Warning),
                LogLevel.Error => serilogLogger.IsEnabled(LogEventLevel.Error),
                LogLevel.Critical => serilogLogger.IsEnabled(LogEventLevel.Fatal),
                _ => false,
            };

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            => microsoftLogger.Log(logLevel, eventId, state, exception, formatter);
    }
}