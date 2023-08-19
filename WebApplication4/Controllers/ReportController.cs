using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        public ReportController(IWebHostEnvironment webHostEnvironment, CompanyContext db)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Print() 
        {
            string mimetype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportParameter1", "Test Report");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension,parameters,mimetype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult MapData()
        {
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
    }
}
