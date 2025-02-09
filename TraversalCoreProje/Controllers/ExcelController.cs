using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class ExcelController : Controller
    {
        private readonly Context _context;

        public ExcelController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = _context.Destinations
                .Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                })
                .ToList();

            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {

            ExcelPackage excel = new ExcelPackage();

            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";


            worksheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            worksheet.Cells[2, 2].Value = "Kadir Yıldız";
            worksheet.Cells[2, 3].Value = "50";

            worksheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            worksheet.Cells[3, 2].Value = "Zeynep Öztürk";
            worksheet.Cells[3, 3].Value = "35";

            var bytes = excel.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kontenjan";

                int rowCount = 2;

                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
            }
            }

           
        }
    }
}
