using log4net;
using log4net.Config;
using System;
using System.Threading;

namespace Railtown.Samples.log4net.NetFrameworkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger("log4net.NetFrameworkSample.Program");
            XmlConfigurator.Configure();

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
