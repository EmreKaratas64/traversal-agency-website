using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.Models;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IExcelService _excelService;

        public ReportsController(UserManager<AppUser> userManager, IExcelService excelService)
        {
            _userManager = userManager;
            _excelService = excelService;
        }


        public IActionResult TakeReport()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            //ExcelPackage excel = new ExcelPackage();
            //var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            //worksheet.Cells[1, 1].Value = "Rota";
            //worksheet.Cells[1, 2].Value = "Rehber";
            //worksheet.Cells[1, 3].Value = "Kontenjan";

            //worksheet.Cells[2, 1].Value = "Tur 1";
            //worksheet.Cells[2, 2].Value = "Rehber1";
            //worksheet.Cells[2, 3].Value = "Kontenjan1";

            //worksheet.Cells[3, 1].Value = "Tur 2";
            //worksheet.Cells[3, 2].Value = "Rehber2";
            //worksheet.Cells[3, 3].Value = "Kontenjan2";

            //var bytes = excel.GetAsByteArray();

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DestinationExcelReport.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("TurListesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

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
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniList.xlsx");
                }
            }
        }

        public IActionResult StaticPdfReport()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Pdf report of Travel Online");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }


        public IActionResult DynamicCustomerPdfReport()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfTable = new PdfPTable(3);
            pdfTable.AddCell("Kullanıcı Ad");
            pdfTable.AddCell("Kullanıcı Soyad");
            pdfTable.AddCell("Kullanıcı Mail");

            var users = _userManager.Users.ToList();
            foreach (var item in users)
            {
                pdfTable.AddCell(item.Name);
                pdfTable.AddCell(item.Surname);
                pdfTable.AddCell(item.Email);
            }
            document.Add(pdfTable);
            document.Close();
            return File("/PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
