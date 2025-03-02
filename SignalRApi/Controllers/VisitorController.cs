using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL;
using SignalRApi.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;
        private readonly Context _context;

        public VisitorController(VisitorService visitorService, Context context)
        {
            _visitorService = visitorService;
            _context = context;
        }
        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (Ecity item in Enum.GetValues(typeof(Ecity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.AddDays(x).Date,
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000); // her bir ekleme işlemini saniyede bir kez gerçekleştir.
                }
            });
            return Ok("Ziyaretçiler başarılı bir şekilde eklendi.");

        }
    }
}
