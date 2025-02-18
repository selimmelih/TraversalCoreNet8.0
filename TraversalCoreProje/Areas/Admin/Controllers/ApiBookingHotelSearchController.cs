using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiBookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //List<ApiBookingHotelSearchController> apiBookingHotelSearchControllers = new List<ApiBookingHotelSearchController>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-1456928&search_type=CITY&arrival_date=2025-02-18&departure_date=2025-02-19&adults=2&children_age=0%2C17&room_qty=1&page_number=1&sort_by=popularity&units=metric&temperature_unit=c&languagecode=tr&currency_code=EUR"),
                Headers =
                    {
                        { "x-rapidapi-key", "be231e3f95msh05f59dbf82a49fdp13f7a4jsn7afef27c6bc5" },
                        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiBookingHotelSearchViewModel>(body);

                return View(values);
            }
        }
        [HttpGet]
        public IActionResult GetCityDestId()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestId(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={p}"),
                Headers =
                {
                    { "x-rapidapi-key", "be231e3f95msh05f59dbf82a49fdp13f7a4jsn7afef27c6bc5" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }
        }
    }
}
