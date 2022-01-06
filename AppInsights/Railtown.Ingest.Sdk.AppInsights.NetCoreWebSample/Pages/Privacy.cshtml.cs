using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace Railtown.Samples.AppInsights.NetCoreWebSample.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
            var logs = 5;
            var testRun = $"expect_{logs}_test_{DateTime.Now.Ticks}";
            for (var i = 0; i < logs; i++)
            {
                try
                {
                    throw new ArgumentException("No!");
                }
                catch (Exception exception)
                {
                    logger.LogError(testRun); // this will create a new bucket each time the page loads because the message is unique per call
                    logger.LogError("Exception caught", exception); // this will be added to a bucket containing all occurrences of this exception
                    // you can also use the telemetry client to send logs:
                    //    Microsoft.ApplicationInsights.TelemetryClient.TrackException();
                }
            }
        }
    }
}
