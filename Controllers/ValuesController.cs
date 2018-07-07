using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetServerSentEventsExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("stream")]
        public async Task GetStream()
        {
            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            
            while(true)
            {
                await response.WriteAsync($"data: Hello {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\r");

                response.Body.Flush();
                await Task.Delay(1 * 5000);
            }
        }
    }
}
