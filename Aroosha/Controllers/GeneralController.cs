using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aroosha.Repositories;
using Aroosha.Services;
using Microsoft.AspNetCore.Mvc;
using Aroosha.Filters;
using Microsoft.AspNetCore.Http;
using Aroosha.Models;
using System.Net;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Data;


namespace Aroosha.Controllers
{
    [SessionTimeout]
    public class GeneralController : Controller
    {
        protected IGeneralService service;
        protected IGeneralRepository repository;

        protected ISecurityService secService;
        protected ISecurityRepository secRepository;

        protected IMarketService mrkService;
        protected IMarketRepository mrkRepository;

        public GeneralController(IHostingEnvironment hostEnvironment, IGeneralService _service,IGeneralRepository _repository ,ISecurityService _secService, ISecurityRepository _secRepository, IMarketService _mrkService, IMarketRepository _mrkRepository)
        {
            service = _service;
            repository = _repository;

            secService = _secService;
            secRepository = _secRepository;

            mrkService = _mrkService;
            mrkRepository = _mrkRepository;


            var path = Path.Combine(hostEnvironment.ContentRootPath, "Content\\license.key");

            Stimulsoft.Base.StiLicense.LoadFromFile(path);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult JobGroups()
        {
            
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "JobGroups");

            var model = service.GetJobGroups(repository);
            return View(model);
        }

        [HttpGet]
        [Route("General/JobGroupDefine/{Id:int}")]
        public IActionResult JobGroupDefine(int Id)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "JobGroupDefine");

            var model = service.GetJobGroupDefine(repository,Id);
            return View(model);
        }

        [HttpPost]
        public string DeleteJobGroup(int Id)
        {

            var model = service.DeleteJobGroup(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveJobGroup(JobGroupDefineModel jobGroupModel)
        {
            
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = jobGroupModel.JobGroupDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveJobGroup(repository, jobGroupModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("General/Jobs/{Id:int}")]
        public IActionResult Jobs(int Id)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Jobs");

            var model = service.GetJobs(repository,Id);
            return View(model);
        }

        [HttpGet]
        [Route("General/Jobs")]
        public IActionResult Jobs()
        {
            int Id = 0;
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Jobs");

            

            var model = service.GetJobs(repository, Id);
            return View(model);
        }

       

        [HttpGet]
        [Route("General/JobDefine/{Id:int}/{JobGroupId:int}")]
        public IActionResult JobDefine(int Id,int JobGroupId)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "JobDefine");

            ViewData["JobGroupsComboData"] = service.GetJobGroups(repository).ToList();

            var model = service.GetJobDefine(repository, Id,JobGroupId);
            return View(model);
        }

        [HttpPost]
        public string DeleteJob(int Id)
        {

            var model = service.DeleteJob(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveJob(JobDefineModel jobModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = jobModel.JobDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveJob(repository, jobModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("General/PrinterSetting")]
        public IActionResult PrinterSetting()
        {
            
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "PrinterSetting");

            string ClientIPAddr = GetClientIPAddr();
            string DeviceName = GetClientDeviceName(ClientIPAddr);

            var model = service.GetComputerPrinterSetting(repository, DeviceName);
            return View(model);
        }

        [HttpPost]
        public string SavePrinterSetting(PrinterSettingModel printerModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = printerModel.Id;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SavePrinterSetting(repository, printerModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("General/PrintTemplate")]
        public IActionResult PrintTemplate()
        {
            
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "PrintTemplate");

            var model = service.GetPrintTemplate(repository, "RentReceipt");
            return View(model);
        }

        

        public IActionResult GetRentReceiptReport()
        {
            string ClientIPAddr = GetClientIPAddr();
            string DeviceName = GetClientDeviceName(ClientIPAddr);

           List<RentReceiptModel> receipts= mrkService.GetRentReceipts(mrkRepository, 0,"").ToList();

            DataTable dt = Utilities.Utility.ListToDataTable(receipts);

            StiReport report = new StiReport();
            

            var model = service.GetPrintTemplate(repository, "RentReceipt");

            if (model != null)
            {
                if (model.Content!=null && model.Content != ""  )
                {
                    report.LoadFromString(model.Content);
                    
                }
            }

        
            report.RegData("receipts", dt);

            report.Dictionary.Synchronize();

            return StiNetCoreDesigner.GetReportResult(this, report);

        }

        public IActionResult DesignerRentReceiptEvent()

        {

            return StiNetCoreDesigner.DesignerEventResult(this);

        }

        public IActionResult SaveRentReceiptReport()
        {
            StiReport report = StiNetCoreDesigner.GetReportObject(this);

            PrintTemplateModel printModel = new PrintTemplateModel() { 
                Id=0,
                Code="RentReceipt",
                Name="فرمت رسید اجاره",
                Content=report.SaveToString()
            };

            var model = service.SavePrintTemplate(repository, printModel);

            return StiNetCoreDesigner.SaveReportResult(this);
        }


        public string GetClientIPAddr()
        {
            string ClientIPAddr;
            try
            {
                ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
            }
            catch (Exception ex)
            {
                ClientIPAddr = "";
            }

            return ClientIPAddr;

        }

        public string GetClientDeviceName(string ClientIPAddr)
        {
            string DeviceName;
            try
            {
                var hostEntry = Dns.GetHostEntry(ClientIPAddr);
                DeviceName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                DeviceName = "Unknown";
            }

            return DeviceName;
        }
        

    }
}
