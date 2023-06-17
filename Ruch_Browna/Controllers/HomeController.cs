using Microsoft.AspNetCore.Mvc;
using Ruch_Browna.Models;
using System.Diagnostics;
using Ruch_Browna.Services;
using Newtonsoft.Json;

namespace Ruch_Browna.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new BrownianMotionIndex();
            return View(model);
        }

        // POST: BrownainMotionController/BrownainMotion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BrownianMotion(ParticlePositionGenerator modelGenerator)
        {
            try
            {
                var model = BrownianModelService.GenerateBrownianModel(modelGenerator.AmountOfSteps);
                return View(model);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult DownloadData(string coordinatesData)
        {
            // Pobierz dane z listy CoordinateView (przykładowo)
            List<CoordinateView> data = JsonConvert.DeserializeObject<List<CoordinateView>>(coordinatesData);

            // Utwórz nowy plik Excel
            var workbook = new ClosedXML.Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Dane");

            // Ustaw nagłówki kolumn
            worksheet.Cell(1, 1).Value = "Krok";
            worksheet.Cell(1, 2).Value = "Wsp. X";
            worksheet.Cell(1, 3).Value = "Wsp. Y";
            worksheet.Cell(1, 4).Value = "Wektor";

            // Wypełnij arkusz danymi
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.Step;
                worksheet.Cell(row, 2).Value = item.ValueX;
                worksheet.Cell(row, 3).Value = item.ValueY;
                worksheet.Cell(row, 4).Value = item.Vector;
                row++;
            }

            // Ustaw auto-szerokość kolumn
            worksheet.Columns().AdjustToContents();

            // Utwórz strumień dla pliku Excel
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            // Zwróć plik Excel jako pobieranie
            return File(stream, "application/vnd.ms-excel", "dane.xls");
        }
    }
}