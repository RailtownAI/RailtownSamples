using System;
using System.Configuration;
using System.Threading;
using Serilog;
using Serilog.Sinks.Railtown;
using SerilogDebug = Serilog.Debugging;

namespace Railtown.Samples.Serilog.NetFrameworkSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var key = ConfigurationManager.AppSettings["RailtownKey"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Railtown(railtownKey: key)
                .CreateLogger();

            SerilogDebug.SelfLog.Enable(Console.Error);

            Log.Logger.Error(new Exception("Testing the exception log 123"), "Testing the exception log {prop}", 123);
            Log.Logger.Error("Testing the exception log {prop}", 123);
            Log.Logger.Error("Testing the exception log with no template");

            Thread.Sleep(2000);

            Log.CloseAndFlush();

        }
    }
}
