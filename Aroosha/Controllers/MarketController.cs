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
using ArooshaPOS;
using System.Data;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Aroosha.Controllers
{
    [SessionTimeout]
    public class MarketController : Controller
    {

        protected IMarketService service;
        protected IMarketRepository repository;

        protected ISecurityService secService;
        protected ISecurityRepository secRepository;

        protected IGeneralService genService;
        protected IGeneralRepository genRepository;


        public MarketController(IHostingEnvironment hostEnvironment, IMarketService _service, IMarketRepository _repository, ISecurityService _secService, ISecurityRepository _secRepository,IGeneralService _genService,IGeneralRepository _genRepository)
        {
            service = _service;
            repository = _repository;

            secService = _secService;
            secRepository = _secRepository;

            genService = _genService;
            genRepository = _genRepository;

            var path = Path.Combine(hostEnvironment.ContentRootPath, "Content\\license.key");

            Stimulsoft.Base.StiLicense.LoadFromFile(path);
        }

        [HttpGet]
        public IActionResult ShopGroups()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "ShopGroups");

           var model = service.GetShopGroups(repository);
            return View(model);
        }

        [HttpGet]
        [Route("Market/ShopGroupDefine/{Id:int}")]
        public IActionResult ShopGroupDefine(int Id)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "ShopGroupDefine");

            var model = service.GetShopGroupDefine(repository,Id);
            return View(model);
        }

        [HttpPost]
        public string SaveShopGroup(ShopGroupDefineModel shopGroupModel)
        {
            
            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = shopGroupModel.ShopGroupDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveShopGroup(repository, shopGroupModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string DeleteShopGroup(int Id)
        {

            var model = service.DeleteShopGroup(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/Shops/{Id:int}")]
        public IActionResult Shops(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Shops");

            var model = service.GetShops(repository, secRepository, TenantId);
            return View();
        }

        [HttpGet]
        [Route("Market/Shops")]
        public IActionResult Shops()
        {
            
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Shops");

            var model = service.GetShops(repository,secRepository, TenantId);
            return View(model);
        }

        [HttpGet]
        [Route("Market/ShopDefine/{Id:int}")]
        public IActionResult ShopDefine(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "ShopDefine");

            ViewData["ShopTypeComboData"] = service.GetShopTypeForCombo(genRepository).ToList();
            ViewData["ShopGroupComboData"] = service.GetShopGroupForCombo(repository).ToList();
            ViewData["MarketStructureComboData"] = service.GetMarketStructureForCombo(repository,secRepository,TenantId).ToList();

            var model = service.GetShopDefine(repository,secRepository,Id,TenantId);
            return View(model);
        }

        [HttpPost]
        public string DeleteShop(int Id)
        {

            var model = service.DeleteShop(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveShop(ShopDefineModel shopModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = shopModel.ShopDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveShop(repository,secRepository,genRepository, shopModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult MarketStructures()
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "MarketStructures");

            var model = service.GetMarketStructures(repository,secRepository,TenantId);
            return View(model);
        }

        [HttpPost]
        public string DeleteMarkrtStructure(int Id)
        {
            
            var model = service.DeleteMarketStructure(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/MarketStructureDefine/{Id:int}/{ParentId:int}/{MarketId:int}")]
        public IActionResult MarketStructureDefine(int Id,int ParentId,int MarketId)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "MarketStructureDefine");

            var model = service.GetMarketStructureDefine(repository,genRepository,secRepository,Id,ParentId,MarketId);
            return View(model);
        }

        [HttpPost]
        public string SaveMarketStructure(MarketStructureDefineModel marketStructureModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = marketStructureModel.MarketStructureDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveMarketStructure(repository,secRepository, marketStructureModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Tariffs()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Tariffs");

            var model = service.GetTariffs(repository);
            return View(model);
        }

        [HttpGet]
        [Route("Market/TariffDefine/{Id:int}")]
        public IActionResult TariffDefine(int Id)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "TariffDefine");

            var model = service.GetTariffDefine(repository,Id);
            return View(model);
        }

        [HttpPost]
        public string DeleteTariff(int Id)
        {

            var model = service.DeleteTariff(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveTariff(TariffDefineModel tariffModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = tariffModel.TariffDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveTariff(repository, tariffModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Customers()
        {
            
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Customers");

            var model = service.GetCustomers(repository);
            return View(model);
        }

        [HttpPost]
        public string DeleteCustomer(int Id)
        {

            var model = service.DeleteCustomer(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

       
        [HttpGet]
        [Route("Market/CustomerDefine/{Id:int}")]
        public IActionResult CustomerDefine(int Id)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "CustomerDefine");

            ViewData["JobGroupsComboData"] = genService.GetJobGroups(genRepository).ToList();
            ViewData["JobsComboData"] = genService.GetJobGroupJobsForCombo(genRepository).ToList();
            ViewData["CitiesComboData"] = genService.GetCityForCombo(genRepository).ToList();

            var model = service.GetCustomerDefine(repository, Id);
            return View(model);
        }

        [HttpPost]
        public string SaveCustomer(CustomerDefineModel customerModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = customerModel.CustomerDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveCustomer(repository,genRepository, customerModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/CustomerCards/{Id:int}")]
        public IActionResult CustomerCards(int Id)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "CustomerCards");

            var model = service.GetCustomerDefine(repository, Id);
            return View(model);
        }

        [HttpPost]
        public string DeleteCustomerCard(int Id)
        {

            var model = service.DeleteCustomerCard(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/CustomerCardDefine/{Id:int}/{CustomerId:int}")]
        public IActionResult CustomerCardDefine(int Id,int CustomerId)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "CustomerCardDefine");

            var model = service.GetCustomerCardDefine(repository, Id,CustomerId);
            return View(model);
        }

        [HttpPost]
        public string SaveCustomerCard(CustomerCardDefineModel cardModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = cardModel.CustomerCardDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveCustomerCard(repository, cardModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Credits()
        {
            int CustomerId = 0;

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Credits");
            ViewData["CustomerId"] = CustomerId;

            var model = service.GetCredits(repository, CustomerId);
            return View(model);
        }

        [HttpGet]
        [Route("Market/Credits/{CustomerId:int}")]
        public IActionResult Credits(int CustomerId)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Credits");
            ViewData["CustomerId"] = CustomerId;

            var model = service.GetCredits(repository, CustomerId);
            return View(model);
        }

        [HttpPost]
        public string DeleteCredit(int Id)
        {

            var model = service.DeleteCredit(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/CreditDefine/{Id:int}/{CustomerId:int}")]
        public IActionResult CreditDefine(int Id, int CustomerId)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "CreditDefine");

            ViewData["PaymentTypeComboData"] = service.GetPaymentTypeForCombo(genRepository).ToList();
            ViewData["CustomerComboData"] = service.GetCustomerForCombo(repository).ToList();

            var model = service.GetCreditDefine(repository, Id, CustomerId);
            return View(model);
        }

        [HttpPost]
        public string SaveCredit(CreditDefineModel creditModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = creditModel.CreditDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {

                if (creditModel.CreditDefinePaymentTypeId > 0 && creditModel.CreditDefineType)
                {
                    string PaymentType = genService.GetBasicInformationById(genRepository, creditModel.CreditDefinePaymentTypeId).StrCode;

                    if (PaymentType == "PCPos")
                    {
                        string DeviceName = HttpContext.Session.GetString("DeviceName");
                        var PCPosSetting = genService.GetPCPosSetting(genRepository, DeviceName);

                        if (PCPosSetting != null)
                        {
                            if (PCPosSetting.PosType != "" && creditModel.CreditDefineAmount > 0)
                            {
                                ArooshaPosResult Result;
                                SyncPurchase PcPos;

                                if (PCPosSetting.ConnectionType != "" && ((PCPosSetting.IPAddress != "" && PCPosSetting.PortNumber > 0) || (PCPosSetting.ComPortName != "")) && PCPosSetting.ConnectionTimeout > 0)
                                {
                                    PcPos = new SyncPurchase(PCPosSetting.PosType, PCPosSetting.ConnectionType, PCPosSetting.IPAddress, PCPosSetting.PortNumber, (int)PCPosSetting.ComBaudRate, PCPosSetting.ComPortName, PCPosSetting.TerminalSerialID, PCPosSetting.AcceptorID, PCPosSetting.TerminalID, PCPosSetting.ConnectionTimeout, PCPosSetting.ResponceTimeout, creditModel.CreditDefineAmount, PCPosSetting.OptionalData);

                                    try
                                    {
                                        Result = PcPos.StartPurchase();


                                        if (Result.ResponceCode == 0)
                                        {
                                            creditModel.CreditDefineReceiptNumber = Result.TransactionNo;
                                            model = service.SaveCredit(repository, creditModel);
                                        }
                                        else
                                        {
                                            model.ResultType = "error";
                                            model.ResultMessage = Result.ResponceMessage;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        model.ResultType = "error";
                                        model.ResultMessage = ex.Message;
                                    }
                                }
                                else
                                {
                                    model.ResultType = "warning";
                                    model.ResultMessage = "اطلاعات کارتخوان ناقص می باشد";
                                }
                            }
                        }
                    }
                    else
                    {
                        model = service.SaveCredit(repository, creditModel);
                    }
                }

                
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Discounts()
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Discounts");

            var model = service.GetDiscounts(repository);
            return View(model);
        }


        [HttpGet]
        [Route("Market/DiscountDefine/{Id:int}")]
        public IActionResult DiscountDefine(int Id)
        {

            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "DiscountDefine");

            var model = service.GetDiscountDefine(repository, Id);
            return View(model);
        }

        [HttpPost]
        public string DeleteDiscount(int Id)
        {

            var model = service.DeleteDiscount(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveDiscount(DiscountDefineModel discountModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = discountModel.DiscountDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveDiscount(repository, discountModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        public IActionResult Rents()
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Rents");

            var model = service.GetRents(repository,secRepository, TenantId);
            return View(model);
        }

        [HttpGet]
        [Route("Market/RentDefine/{Id:int}")]
        public IActionResult RentDefine(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "RentDefine");
            ViewData["CustomerComboData"] = service.GetCustomerForCombo(repository).ToList();
            ViewData["ShopComboData"] = service.GetShopForCombo(repository, secRepository, TenantId).ToList();
            ViewData["DiscountTypeComboData"] = service.GetDiscountTypeForCombo(repository).ToList();
            ViewData["MarketScheduleComboData"] = service.GetMarketScheduleForRent(repository,secRepository,TenantId).ToList();

            

            var model = service.GetRentDefine(repository, Id,0);
            return View(model);
        }

        [HttpGet]
        [Route("Market/GetTariffDetail/{MarketScheduleDetailId:int}/{ShopId:int}")]
        public string GetTariffDetail(int MarketScheduleDetailId,int ShopId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));

            var model = service.GetTariffDetail(repository, MarketScheduleDetailId, ShopId);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/GetDiscountDetail/{MarketScheduleDetailId:int}/{DiscountId:int}")]
        public string GetDiscountDetail(int MarketScheduleDetailId, int DiscountId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));

            var model = service.GetDiscountDetail(repository, MarketScheduleDetailId, DiscountId);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/GetCustomerDetail/{CustomerId:int}")]
        public string GetCustomerDetail(int CustomerId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));

            var model = service.GetCustomerDetail(repository, CustomerId);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model); 
        }

        [HttpGet]
        [Route("Market/GetShopDetail/{ShopId:int}")]
        public string GetShopDetail(int ShopId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));

            var model = service.GetShopDetail(repository, ShopId);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpGet]
        [Route("Market/RentDefine/{Id:int}/{CustomerId:int}")]
        public IActionResult RentDefine(int Id,int CustomerId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "RentDefine");
            ViewData["CustomerComboData"] = service.GetCustomerForCombo(repository).ToList();
            ViewData["ShopComboData"] = service.GetShopForCombo(repository, secRepository, TenantId).ToList();
            ViewData["DiscountTypeComboData"] = service.GetDiscountTypeForCombo(repository).ToList();
            ViewData["MarketScheduleComboData"] = service.GetMarketScheduleForRent(repository, secRepository, TenantId).ToList();

            var model = service.GetRentDefine(repository, Id, CustomerId);
            return View(model);
        }

        [HttpPost]
        public string DeleteRent(int Id)
        {

            var model = service.DeleteRent(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveRent(RentDefineModel rentModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = rentModel.RentDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveRent(repository, rentModel);

                List<RentReceiptModel> receiptModel = service.GetRentReceipts(repository, (int)rentModel.RentDefineCustomerId, rentModel.RentDefineDate).ToList();
                DataTable dt = Utilities.Utility.ListToDataTable(receiptModel);

                string ClientIPAddr = GetClientIPAddr();
                string DeviceName = GetClientDeviceName(ClientIPAddr);
                

                StiReport report = new StiReport();


                var templateModel = genService.GetPrintTemplate(genRepository, "RentReceipt");

                if (templateModel != null)
                {
                    if (templateModel.Content != null && templateModel.Content != "")
                    {
                        report.LoadFromString(templateModel.Content);

                    }
                }
                

                report.RegData("receipts", dt);

                report.Dictionary.Synchronize();

                var printerSetting = genService.GetComputerPrinterSetting(genRepository, DeviceName);
                if (printerSetting != null)
                {
                    if (printerSetting.PrinterName != "")
                    {
                        System.Drawing.Printing.PrinterSettings pSet = new System.Drawing.Printing.PrinterSettings();

                        pSet.PrinterName = printerSetting.PrinterName;

                        report.Print(false, pSet);
                        
                    }
                }
                
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }


        [HttpGet]
        public IActionResult Reserves()
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "Reserves");

            var model = service.GetReserves(repository, secRepository, TenantId);
            return View(model);
        }

        [HttpGet]
        [Route("Market/ReserveDefine/{Id:int}")]
        public IActionResult ReserveDefine(int Id)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "ReserveDefine");
            ViewData["CustomerComboData"] = service.GetCustomerForCombo(repository).ToList();
            ViewData["ShopComboData"] = service.GetShopForCombo(repository, secRepository, TenantId).ToList();
            ViewData["DiscountTypeComboData"] = service.GetDiscountTypeForCombo(repository).ToList();
            ViewData["MarketScheduleComboData"] = service.GetMarketScheduleForReserve(repository, secRepository, TenantId).ToList();



            var model = service.GetReserveDefine(repository, Id, 0);
            return View(model);
        }

        [HttpGet]
        [Route("Market/ReserveDefine/{Id:int}/{CustomerId:int}")]
        public IActionResult ReserveDefine(int Id, int CustomerId)
        {
            int TenantId = Convert.ToInt32(HttpContext.Session.GetInt32("TenantId"));
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            ViewData["ToolbarData"] = secService.GetUserMenuAction(secRepository, UserId, "ReserveDefine");
            ViewData["CustomerComboData"] = service.GetCustomerForCombo(repository).ToList();
            ViewData["ShopComboData"] = service.GetShopForCombo(repository, secRepository, TenantId).ToList();
            ViewData["DiscountTypeComboData"] = service.GetDiscountTypeForCombo(repository).ToList();
            ViewData["MarketScheduleComboData"] = service.GetMarketScheduleForRent(repository, secRepository, TenantId).ToList();

            var model = service.GetReserveDefine(repository, Id, CustomerId);
            return View(model);
        }

        [HttpPost]
        public string DeleteReserve(int Id)
        {

            var model = service.DeleteReserve(repository, Id);

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }

        [HttpPost]
        public string SaveReserve(ReserveDefineModel reserveModel)
        {

            NotificationModel model = new NotificationModel();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        model.Id = reserveModel.ReserveDefineId;
                        model.ResultType = "error";
                        model.ResultMessage = error.ErrorMessage;

                    }
                }

            }
            else
            {
                model = service.SaveReserve(repository, reserveModel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
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
