
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

using System;
using System.Threading;

namespace Railtown.Ingest.Sdk.AppInsights.NetFrameworkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var telemetryClient = new TelemetryClient(TelemetryConfiguration.Active); // see ApplicationInsights.config

            for (var i = 0; i < 10; i++)
            {
                telemetryClient?.TrackTrace("Testing log");

                if (i % 5 == 0)
                {
                    telemetryClient?.TrackException(new ArgumentException("I think not."));
                }
            }

            Thread.Sleep(2000);
            Console.ReadLine();
        }
    }
}
