using System;
using System.Threading;
using NLog;
using NLog.Common;

namespace Railtown.Samples.NLog.NetFrameworkSample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            InternalLogger.LogToConsole = true;
            InternalLogger.LogLevel = LogLevel.Debug;

            for (var i = 0; i < 10; i++)
            {
                logger.Info("Testing log");

                if (i % 5 == 0)
                {
                    logger.Error("Testing error", new ArgumentException("I think not."));
                }
            }

            Thread.Sleep(1000);

        }
    }
}