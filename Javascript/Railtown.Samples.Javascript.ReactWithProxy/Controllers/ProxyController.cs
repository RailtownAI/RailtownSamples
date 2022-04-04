using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Railtown.Ingest.Logs.Client.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railtown.Samples.Javascript.ReactWithProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProxyController : ControllerBase
    {

        private readonly ILogger<ProxyController> _logger;

        private string key;

        public ProxyController(IConfiguration configuration, ILogger<ProxyController> logger)
        {
            key = configuration["RailtownKey"];
            _logger = logger;
        }

        [HttpPost]
        public async Task<int> Post(RestEventData[] logs)
        {
            var railtownClient = new RestWriter(key);
            await railtownClient.WriteAsync(logs);
            return 200;
        }
    }
}
