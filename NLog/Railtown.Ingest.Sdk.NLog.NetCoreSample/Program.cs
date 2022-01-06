using System;
using System.Threading;
using NLog;

namespace Railtown.Ingest.NetCoreSample.NLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

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