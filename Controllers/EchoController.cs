using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_cp_4.Controllers
{
    public class EchoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("GET request received");
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("POST request received");
            return new EmptyResult();
        }

        [HttpGet]
        public async Task<IActionResult> Headers()
        {
            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()));
            return new EmptyResult();
        }

        [HttpGet]
        public async Task<IActionResult> Query()
        {
            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString()));
            return new EmptyResult();
        }

        [HttpPost]
        public async Task<IActionResult> Body()
        {
            Response.ContentType = "text/plain";

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var bodyText = await reader.ReadToEndAsync();
                await Response.WriteAsync(bodyText);
            }
            return new EmptyResult();
        }
    }
}