using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using WebApiCoreWithEF.Context;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CompanyContext _db;
        private readonly ILogger _logger;
        public ReportController(IWebHostEnvironment webHostEnvironment, CompanyContext db, ILogger<ReportController> logger)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _db = db;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Print() 
        {
            string error = "";
            try
            {
                _logger.LogInformation("Log message in the Print() method");
                string mimetype = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("ReportParameter1", "Test Report");
                LocalReport localReport = new LocalReport(path);
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (System.Exception Ex)
            {

                _logger.LogError(Ex.StackTrace.ToString());
                ViewBag.MyString = Ex.StackTrace.ToString();
                error = Ex.StackTrace.ToString();
                //return View(Ex.StackTrace.ToString());
            }
            return Content(error);
        }

        public IActionResult MapData()
        {
            string error = "";
            try
            {
                int i = Convert.ToInt32("abc");
                _logger.LogInformation("Log message in the MapData() method");
                var dt = new DataTable();
                GetData getData = new GetData(_db);
                dt = getData.Data();
                string mimetype = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report2.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                //parameters.Add("ReportParameter1", "Hello from hisham");
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("DataSet1", dt);
                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
                return File(result.MainStream, "application/pdf");
            }
            catch (System.Exception Ex)
            {

                _logger.LogError(Ex.StackTrace.ToString());
                ViewBag.MyString = Ex.StackTrace.ToString();
                error = Ex.StackTrace.ToString();
                //return View(Ex.StackTrace.ToString());
            }
            return Content(error);
          
        }
    }
}
