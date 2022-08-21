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

namespace Aroosha.Controllers
{
    [SessionTimeout]
    public class SecurityController : Controller
    {
        protected ISecurityService service;
        protected ISecurityRepository repository;

        protected IGeneralService genService;
        protected IGeneralRepository genRepository;

        public SecurityController(ISecurityService _service, ISecurityRepository _repository, IGeneralService _genService, IGeneralRepository _genRepository)
        {
            service = _service;
            repository = _repository;

            genService = _genService;
            genRepository = _genRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult Users()
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "Users");

            var model = service.GetUsers(repository, TenantId);
            return View(model);
        }

        [HttpGet]
        [Route("Security/UserDefine/{Id:int}")]
        public IActionResult UserDefine(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "UserDefine");

            ViewData["TenantComboData"] = service.GetTenantChildren(repository, TenantId, true);

            var model = service.GetUserDefine(repository,Id);
            return View(model);
        }

        [HttpPost]
        public string DeleteUser(int Id)
        {
            
            var model = service.DeleteUser(repository,Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveUser(UserDefineModel userModel)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = userModel.UserDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;
                        
                    }
                }

            }
            else
            {
                model = service.SaveUser(repository, userModel,TenantId);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Groups()
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "Groups");

            var model = service.GetGroups(repository);
            return View(model);
        }

        [HttpPost]
        public string DeleteGroup(int Id)
        {

            var model = service.DeleteGroup(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Security/GroupDefine/{Id:int}")]
        public IActionResult GroupDefine(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "GroupDefine");

            var model = service.GetGroupDefine(repository, Id,TenantId);
            return View(model);
        }

        [HttpGet]
        [Route("Security/GroupUsers/{Id:int}")]
        public IActionResult GroupUsers(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "GroupUsers");

            ViewData["UsersForComboData"] = service.GetUsers(repository,TenantId);

            var model = service.GetGroupDefine(repository, Id,TenantId);
            return View(model);
        }

        [HttpPost]
        public string SaveGroup(GroupDefineModel groupModel)
        {
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = groupModel.GroupDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveGroup(repository, groupModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Security/UserAccess/{Id:int}")]
        public IActionResult UserAccess(int Id)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "UserAccess");
            ViewData["UserId"] = Id;
            ViewData["GroupId"] = 0;

            var model = service.GetGroupUserAccess(repository,0, Id);

            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            //string test = json.ToString();
            return View(model);
        }

        [HttpPost]
        public string SaveUserAccess(SaveMenuAccessModel accessModel)
        {
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = 0;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveMenuAccess(repository, accessModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Security/GroupAccess/{Id:int}")]
        public IActionResult GroupAccess(int Id)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "GroupAccess");
            ViewData["UserId"] = 0;
            ViewData["GroupId"] = Id;

            var model = service.GetGroupUserAccess(repository, Id,0);
            return View(model);
        }

        [HttpPost]
        public string SaveGroupAccess(SaveMenuAccessModel accessModel)
        {
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = 0;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveMenuAccess(repository, accessModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "ChangePassword");

            var model = service.GetUserInfo(repository,UserId);
            return View(model);
        }

       

        [HttpPost]
        public string ChangePassword(ChangePasswordModel changePasswordModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = 0;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.ChangePassword(repository, changePasswordModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult UserSetting()
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = service.GetUserMenuAction(repository, UserId, "UserSetting");

            ViewData["HomeTypeComboData"] = genService.GetHomeTypeForCombo(genRepository).ToList();

            var model = service.GetUserSetting(repository,UserId);
            return View(model);
        }

        [HttpPost]
        public string SaveUserSetting(UserSettingModel userSettingModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = 0;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveUserSetting(repository, userSettingModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

    }
}