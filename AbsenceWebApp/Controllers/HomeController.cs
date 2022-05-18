using AbsenceAppData;
using AbsenceWebApp.FileReader;
using AbsenceWebApp.Helper;
using AbsenceWebApp.Models;
using AbsenceWebApp.Statistics;
using AbsenceWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileWebHandler _fileWebHandler;
        private readonly IAbsenceReportHandler _absenceReportHandler;
        private readonly IStatisticManager _statisticManager;

        

        public HomeController(ILogger<HomeController> logger
            , IFileWebHandler fileWebHandler
            , IAbsenceReportHandler absenceReportHandler
            , IStatisticManager statisticManager

            )
        {
            _logger = logger;
            _fileWebHandler = fileWebHandler;
            _absenceReportHandler = absenceReportHandler;
            _statisticManager = statisticManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AbsenceInputsViewModel model)
        {
            if (ModelState.IsValid)
            {
              string FilePathA= _fileWebHandler.SaveFile(model.FileA);
              string FilePathB = _fileWebHandler.SaveFile(model.FileB);
              string StartData = _fileWebHandler.SaveFile(model.StartData);

              var results=  _absenceReportHandler.GetAbsenceReport(FilePathA, FilePathB, StartData).ToList();

              var st1=  _statisticManager.GetMonthStatisticBasedOnPrecentage(3, results);

              var st2 = _statisticManager.GetAbsenceNumbersWithTypeA(3, results);

              var st3 = _statisticManager.GetcContinuousAbsencForRangeOfDays(4, results);

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
