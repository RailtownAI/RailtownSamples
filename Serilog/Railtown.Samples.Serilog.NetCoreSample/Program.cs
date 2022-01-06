using System;
using System.Threading;
using SerilogDebug = Serilog.Debugging;
using Serilog.Sinks.Railtown;
using Serilog;

namespace Railtown.Samples.Serilog.NetCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Railtown() // this will read the key from Railtown.config
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
