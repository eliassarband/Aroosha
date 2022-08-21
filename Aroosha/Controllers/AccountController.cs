using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Aroosha.Services;
using Aroosha.Repositories;
using Aroosha.Models;
using Aroosha.Utilities;
using System.Net;

namespace Aroosha.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        protected IAccountService service;
        protected IAccountRepository repository;

        public AccountController(IAccountService _service, IAccountRepository _repository)
        {
            service = _service;
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            int? LoginedDataId = HttpContext.Session.GetInt32("LoginedDataId");
            if (LoginedDataId != null)
            {
                int Id = Convert.ToInt32(LoginedDataId);

                service.Logout(Id, repository);
                HttpContext.Session.Clear();
            }


            ViewBag.SystemTitle = "سامانه روز بازارها";
            ViewBag.CopyRight = "شرکت فناوری اطلاعات آروشا";
            ViewBag.TodayDescription = PersianHelper.TodayDateDescription();

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginInformation model)
        {

            if (!ModelState.IsValid)
                return View(model);

            string ClientIPAddr = GetClientIPAddr();
            string DeviceName = GetClientDeviceName(ClientIPAddr);


            LoginedUser logined = service.Authenticate(model.Username, model.Password,DeviceName,ClientIPAddr, repository);
            if (logined.LoginStatus)
            {

                HttpContext.Session.SetString("DeviceName", DeviceName);
                HttpContext.Session.SetInt32("UserID", logined.UserID);
                HttpContext.Session.SetInt32("LoginedDataId", logined.LoginedDataId);
                


                return RedirectToAction("index", "Home");
            }
            else
            {
                
                ViewBag.ErrorMessage = logined.LoginMessage;
                return View(model);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
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