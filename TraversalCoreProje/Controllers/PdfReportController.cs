using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);
            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya3.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);
            document.Open();


            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");


            pdfPTable.AddCell("Denizğğ");
            pdfPTable.AddCell("Turhan");
            pdfPTable.AddCell("110110010");

            pdfPTable.AddCell("Selğim");
            pdfPTable.AddCell("Turhan");
            pdfPTable.AddCell("287451578");
            
            pdfPTable.AddCell("Deni");
            pdfPTable.AddCell("Seli");
            pdfPTable.AddCell("4564987");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfreports/dosya3.pdf", "application/pdf", "dosya3.pdf");
        }
    }
}