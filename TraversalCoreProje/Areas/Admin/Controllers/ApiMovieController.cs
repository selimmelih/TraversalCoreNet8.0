using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                    {
                        { "x-rapidapi-key", "2a1c3d9f65msh865cb62a5ba37d5p129316jsn7fd55e0b0de7" },
                        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body); // veri getirme deserialize ekleme güncelleme serialize

                return View(apiMovies);

            }
        }
    }
}
