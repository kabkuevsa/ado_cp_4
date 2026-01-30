using Microsoft.AspNetCore.Mvc;

namespace EchoApp.Controllers
{
    public class EchoController : Controller
    {

        [HttpGet]
        public async Task Get()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("GET request received");
        }

        // Оригинальное POST-действие (тестировать через curl / Postman)
        [HttpPost]
        public async Task Post()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("POST request received");
        }

        // Вспомогательное GET-действие для просмотра в браузере
        [HttpGet("Echo/PostDemo")]
        public async Task PostDemo()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("[Demo] This would be a POST response. Use POST to /Echo/Post for real test.");
        }

        [HttpGet]
        public async Task Headers()
        {
            Response.ContentType = "application/json";
            var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
            await Response.WriteAsJsonAsync(headers);
        }

        [HttpGet]
        public async Task Query()
        {
            Response.ContentType = "application/json";
            var query = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
            await Response.WriteAsJsonAsync(query);
        }

        // Оригинальное POST-действие для тела
        [HttpPost]
        public async Task Body()
        {
            Response.ContentType = "text/plain";
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            if (string.IsNullOrEmpty(body))
                body = "[Empty body]";
            await Response.WriteAsync(body);
        }

        // Вспомогательное GET-действие для просмотра в браузере
        [HttpGet("Echo/BodyDemo")]
        public async Task BodyDemo()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("[Demo] Send a POST request with body to /Echo/Body to see it echoed back.");
        }
    }
}
