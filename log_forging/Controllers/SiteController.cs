using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MicroFocus.InsecureWebApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {

        private readonly ILogger _logger;

        public SiteController(ILogger<SiteController> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }


        // POST: api/v1/site/subscribe-newsletter-json
        [HttpPost("subscribe-newsletter-json")]
        public IActionResult SubscribeNewsletterJSON([FromForm] String name, [FromForm] String email)
        {
            Message = $"name: {name} and email: {email}";
            _logger.LogInformation(Message);
            _logger.LogInformation($"name: {name} and email: {email}");
            _logger.LogInformation("name: {0}, email {1}", name, email);
            return Ok(new { success = true });
        }
    }
}
