using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiBookingExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiBookingExchangeViewModel2> apiBookingExchangeViewModel2s = new List<ApiBookingExchangeViewModel2>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "2a1c3d9f65msh865cb62a5ba37d5p129316jsn7fd55e0b0de7" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiBookingExchangeViewModel2>(body);

                return View(values.data.exchange_rates);
                Console.WriteLine(body);
            }
        }
    }
}
