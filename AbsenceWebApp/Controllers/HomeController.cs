using AbsenceAppData;
using AbsenceWebApp.FileImporter;
using AbsenceWebApp.FileReader;
using AbsenceWebApp.Helper;
using AbsenceWebApp.Models;
using AbsenceWebApp.Statistics;
using AbsenceWebApp.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

              List<Absence> bsenceReportResult =  _absenceReportHandler.GetAbsenceReport(FilePathA, FilePathB, StartData).ToList();
                           
            var SumStatisicBasedOnPrecentage=  _statisticManager.GetMonthStatisticBasedOnPrecentage(3, bsenceReportResult);

             var SumStatisicBasedOnType= _statisticManager.GetAbsenceNumbersWithTypeA(3, bsenceReportResult);

             var SumStatisicBasedOnContinuousAbsenceDays = _statisticManager.GetContinuousAbsenceForRangeOfDays(4, bsenceReportResult);

                using (XLWorkbook wb = new XLWorkbook())
                {

                    wb.Worksheets.Add(Common.ToDataTable(bsenceReportResult));
                    var data = new DataTable();
                    data.TableName="Statistic";
                    data.Columns.Add("Summary of statistics");

                    data.Rows.Add("Sum of absence numbers with type A for March");                   
                    data.Rows.Add(SumStatisicBasedOnType);

                    data.Rows.Add("Sum of continuous absence for range of days for April ");
                    data.Rows.Add(SumStatisicBasedOnContinuousAbsenceDays);

                    data.Rows.Add("List of absence Ids that have absence mimimum 85 in March ");
                    foreach (var item in SumStatisicBasedOnPrecentage)
                    {
                        data.Rows.Add(item);

                    }
                    wb.Author = "Marwan";
                    wb.Worksheets.Add(data);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AbscenceReport.xlsx");
                    }
                }


            }
            return View(model);
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
