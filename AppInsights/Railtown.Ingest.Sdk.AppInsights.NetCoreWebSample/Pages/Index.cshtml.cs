using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace Railtown.Samples.AppInsights.NetCoreWebSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TelemetryClient telemetry;
        private readonly ILogger<IndexModel> logger;

        public IndexModel(TelemetryClient telemetry, ILogger<IndexModel> logger)
        {
            this.logger = logger;
            this.telemetry = telemetry;
        }

        public void OnGet()
        {
            // any trace with SeverityLevel.Error will be sent to Railtown as an error.
            telemetry.TrackTrace("Page loaded from " + Request.HttpContext.Connection.RemoteIpAddress, SeverityLevel.Error);

            // railtown.ai will receive telemetry and ILogger events.
            logger.Log(LogLevel.Information, "Called OnGet");
        }
    }
}
