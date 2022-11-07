using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using ms = Microsoft.Extensions.Logging;

namespace BlackBoxTesting.Shared.Tests
{
    public class SerilogConsoleTests
    {
        private string _logOutput;
        private readonly string _token;

        public SerilogConsoleTests()
            => _token = Guid.NewGuid().ToString();

        [Theory]
        [ClassData(typeof(VerboseLog))]
        [ClassData(typeof(InformationLog))]
        public async Task Write_MultiLogEventLevels_ThenSpecificLogLevelAndHigherMustBeWrittenToTheLogOutput(ILogger sut,
            IEnumerable<LogEventLevel> writeLogEventLevels,
            IEnumerable<LogEventLevel> expectedWriteLogs,
            IEnumerable<LogEventLevel> expectedNotWriteLogs)
        {
            _logOutput = await writeLogs(sut, writeLogEventLevels);
            assertLogOutput(expectedWriteLogs, expectedNotWriteLogs);
        }
        class VerboseLog : TheoryData<ILogger, IEnumerable<LogEventLevel>, IEnumerable<LogEventLevel>, IEnumerable<LogEventLevel>>
        {
            public VerboseLog()
            {
                writeAllLogLevel_ThenTheLoggerMustWrittenAllLogLevels();
                writeVerboseOnly_ThenTheLoggerMustWrittenOnlyTheVerboseLevel();
                writeDebugOnly_ThenTheLoggerMustWrittenOnlyTheDebugLevel();
            }

            void writeAllLogLevel_ThenTheLoggerMustWrittenAllLogLevels()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                var expectedWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                var expectedNotWriteLogs = new LogEventLevel[0];
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            void writeVerboseOnly_ThenTheLoggerMustWrittenOnlyTheVerboseLevel()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Verbose,
                };
                var expectedWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                };
                var expectedNotWriteLogs = new[]
                {
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            void writeDebugOnly_ThenTheLoggerMustWrittenOnlyTheDebugLevel()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Debug,
                };
                var expectedWriteLogs = new[]
                {
                    LogEventLevel.Debug,
                };
                var expectedNotWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            // TODO: Add Information, Warning, Error, Fatal scenarios for verbose log level
        }
        // TODO: DebugLog
        class InformationLog : TheoryData<ILogger, IEnumerable<LogEventLevel>, IEnumerable<LogEventLevel>, IEnumerable<LogEventLevel>>
        {
            public InformationLog()
            {
                writeAllLogLevel_ThenTheLoggerMustWrittenInformationWarningErrorAndFatalLogLevels();
                writeVerboseOnly_ThenTheSystemDoesNotLogAnything();
                writeDebugOnly_ThenTheSystemDoesNotLogAnything();
            }

            void writeAllLogLevel_ThenTheLoggerMustWrittenInformationWarningErrorAndFatalLogLevels()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                var expectedWriteLogs = new[]
                {
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                var expectedNotWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                };
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            void writeVerboseOnly_ThenTheSystemDoesNotLogAnything()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Verbose,
                };
                var expectedWriteLogs = new LogEventLevel[0];
                var expectedNotWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            void writeDebugOnly_ThenTheSystemDoesNotLogAnything()
            {
                var sut = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
                var writeLogEventLevels = new[]
                {
                    LogEventLevel.Debug,
                };
                var expectedWriteLogs = new LogEventLevel[0];
                var expectedNotWriteLogs = new[]
                {
                    LogEventLevel.Verbose,
                    LogEventLevel.Debug,
                    LogEventLevel.Information,
                    LogEventLevel.Warning,
                    LogEventLevel.Error,
                    LogEventLevel.Fatal,
                };
                Add(sut, writeLogEventLevels, expectedWriteLogs, expectedNotWriteLogs);
            }
            // TODO: Add Information, Warning, Error, Fatal scenarios for information log level
        }
        // TODO: WarningLog
        // TODO: ErrorLog
        // TODO: FatalLog

        [Fact]
        public async Task Read_ConfigurationFile_ThenSerilogMustBeApplyFromTheSettingFile()
        {
            const string AppSettingFileName = "appsettings.json";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(AppSettingFileName)
                .Build();
            var sut = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .CreateLogger();

            var writeLogEventLevels = new[]
            {
                LogEventLevel.Verbose,
                LogEventLevel.Debug,
                LogEventLevel.Information,
                LogEventLevel.Warning,
                LogEventLevel.Error,
                LogEventLevel.Fatal,
            };
            _logOutput = await writeLogs(sut, writeLogEventLevels);

            var expectedWriteLogs = new[]
            {
                LogEventLevel.Information,
                LogEventLevel.Warning,
                LogEventLevel.Error,
                LogEventLevel.Fatal,
            };
            var expectedNotWriteLogs = new[]
            {
                LogEventLevel.Verbose,
                LogEventLevel.Debug,
            };
            assertLogOutput(expectedWriteLogs, expectedNotWriteLogs);
        }

        [Fact]
        public async Task Convert_FromSerilogToMicrosoftLogger_ThenBehaviourShouldBeTheSame()
        {
            const string AppSettingFileName = "appsettings.json";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(AppSettingFileName)
                .Build();

            var serilogLogger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .CreateLogger();

            var sut = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger("TestCategory");

            var writeLogEventLevels = new[]
            {
                ms.LogLevel.Trace,
                ms.LogLevel.Debug,
                ms.LogLevel.Information,
                ms.LogLevel.Warning,
                ms.LogLevel.Error,
                ms.LogLevel.Critical,
                ms.LogLevel.None,
            };
            _logOutput = await writeLogs(sut, writeLogEventLevels);

            var expectedWriteLogs = new[]
            {
                ms.LogLevel.Information,
                ms.LogLevel.Warning,
                ms.LogLevel.Error,
                ms.LogLevel.Critical,
            };
            var expectedNotWriteLogs = new[]
            {
                ms.LogLevel.Trace,
                ms.LogLevel.Debug,
            };
            assertLogOutput(expectedWriteLogs, expectedNotWriteLogs);
        }

        async Task<string> writeLogs(ILogger sut, IEnumerable<LogEventLevel> writeLogEventLevels)
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            Console.SetOut(writer);

            foreach (var level in writeLogEventLevels)
            {
                sut.Write(level, $"{level}-{_token}");
            }

            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }
        void assertLogOutput(IEnumerable<LogEventLevel> expectedWriteLogs, IEnumerable<LogEventLevel> expectedNotWriteLogs)
        {
            foreach (var level in expectedWriteLogs)
            {
                Assert.Contains($"{level}-{_token}", _logOutput);
            }

            foreach (var level in expectedNotWriteLogs)
            {
                Assert.DoesNotContain($"{level}-{_token}", _logOutput);
            }
        }

        async Task<string> writeLogs(ms.ILogger sut, IEnumerable<ms.LogLevel> writeLogLevels)
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            Console.SetOut(writer);

            foreach (var level in writeLogLevels)
            {
                ms.LoggerExtensions.Log(sut, level, $"{level}-{_token}");
            }

            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }
        void assertLogOutput(IEnumerable<ms.LogLevel> expectedWriteLogs, IEnumerable<ms.LogLevel> expectedNotWriteLogs)
        {
            foreach (var level in expectedWriteLogs)
            {
                Assert.Contains($"{level}-{_token}", _logOutput);
            }

            foreach (var level in expectedNotWriteLogs)
            {
                Assert.DoesNotContain($"{level}-{_token}", _logOutput);
            }
        }
    }
}