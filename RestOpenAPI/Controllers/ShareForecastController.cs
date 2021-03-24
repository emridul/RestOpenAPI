using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestOpenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShareForecastController : ControllerBase
    {
        private static readonly string[] Shares = new[]
        {
            "ICICI", "HDFC", "SBI", "Axis", "StanC", "Citi", "HSBC", "Barclays", "RBS", "Deushe"
        };

        private readonly ILogger<ShareForecastController> _logger;

        public ShareForecastController(ILogger<ShareForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ShareForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ShareForecast
            {
                Price = rng.Next(-20, 55),
                share = Shares[rng.Next(Shares.Length)]
            })
            .ToArray();
        }
    }
}
