using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aroosha.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Aroosha.Filters;
using Aroosha.Services;
using Aroosha.Repositories;

namespace Aroosha.Controllers
{
    [SessionTimeout]
    public class HomeController : Controller
    {
        protected ISecurityService service;
        protected ISecurityRepository repository;

        public HomeController(ISecurityService _service, ISecurityRepository _repository)
        {
            service = _service;
            repository = _repository;
        }
        public ActionResult Index()
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            int LoginedDataId = Convert.ToInt32(HttpContext.Session.GetInt32("LoginedDataId"));

            LoginedDataModel model = service.GetUserLoginedData(repository, LoginedDataId, UserId);

            
            HttpContext.Session.SetInt32("TenantId", model.TenantId);

            ViewBag.SystemTitle = "سامانه روز بازارها - "+model.TenantName;
            ViewBag.CopyRight = "شرکت فناوری اطلاعات آروشا";

            ViewBag.PanelBarData = service.GetUserMenu(repository,UserId);

            return View(model);
        }
        


        public IActionResult Privacy()
        {

            ViewBag.SystemTitle = "سامانه بازار روز بعثت";

            return RedirectToAction("index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
