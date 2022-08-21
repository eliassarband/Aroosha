using Aroosha.Models;
using Aroosha.Repositories;
using Aroosha.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    public class MarketService:IMarketService
    {
        public IEnumerable<ShopGroupModel> GetShopGroups(IMarketRepository repository)
        {
            List<ShopGroupModel> model = new List<ShopGroupModel>();

            var groups = repository.ShopGroups;

            foreach (var item in groups)
            {
                
                model.Add(new ShopGroupModel()
                {
                    ShopGroupId = item.Id,
                    ShopGroupCode = item.Code,
                    ShopGroupName = item.Name,
                    ShopGroupDescription = item.Description,
                    ShopGroupShopCount = item.Shops.Count()
                });
            }

            return model;
        }

        public ShopGroupDefineModel GetShopGroupDefine(IMarketRepository repository, int Id)
        {
            ShopGroupDefineModel model = new ShopGroupDefineModel();

            var group = repository.ShopGroups.FirstOrDefault(g => g.Id == Id);

            if (group != null)
            {
               
                model.ShopGroupDefineId = group.Id;
                model.ShopGroupDefineCode = group.Code;
                model.ShopGroupDefineName = group.Name;
                model.ShopGroupDefineDescription = group.Description;
                model.ShopGroupDefineShopCount = group.Shops.Count();
                
            }

            return model;
        }

        public NotificationModel SaveShopGroup(IMarketRepository repository, ShopGroupDefineModel model)
        {
            bool success = true;
            int ShopGroupId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.ShopGroups.Where(g => g.Id != model.ShopGroupDefineId).Any(g => g.Code == model.ShopGroupDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد گروه وارد شده تکراری می باشد";

            }
            else if (repository.ShopGroups.Where(g => g.Id != model.ShopGroupDefineId).Any(g => g.Name == model.ShopGroupDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام گروه وارد شده تکراری می باشد";

            }


            if (success)
            {

                success = repository.SaveShopGroups(new GeneralDAL.Database.ShopGroup()
                {
                    Id = model.ShopGroupDefineId,
                    Code=model.ShopGroupDefineCode,
                    Name = model.ShopGroupDefineName,
                    Description=model.ShopGroupDefineDescription
                });

                ShopGroupId = repository.ShopGroups.FirstOrDefault(g => g.Name == model.ShopGroupDefineName && g.Code==model.ShopGroupDefineCode).Id;


                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = ShopGroupId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public NotificationModel DeleteShopGroup(IMarketRepository repository, int ShopGroupId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var shopGroup = repository.ShopGroups.FirstOrDefault(s => s.Id== ShopGroupId);

            if (shopGroup.Shops.Count()>0)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "به دلیل وجود عرفه در گروه انتخاب شده امکان حذف گروه وجود ندارد";
            }

            if (success)
            {
                var group = repository.ShopGroups.Where(s => s.Id == ShopGroupId);
                success = repository.DeleteShopGroup(group);
            }
            

            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public IEnumerable<MarketModel> GetMarketStructures(IMarketRepository repository,ISecurityRepository secRepository, int TenantId)
        {
            List<MarketModel> tenantModel = new List<MarketModel>();

            var tenants = secRepository.TenantsStructure.Where(t =>t.ParentId == null);

            foreach (var tenant in tenants)
            {
                List<MarketModel> tenantChildModel = new List<MarketModel>();

                foreach (var tenantChild in tenant.Tenants)
                {
                    List<MarketStructureModel> phaseModel = new List<MarketStructureModel>();

                    var phases = repository.MarketStructuresWithType.Where(m => m.TenantId == tenantChild.Id && m.Type.StrCode == "Phase");

                    foreach (var phase in phases)
                    {
                        List<MarketStructureModel> zoneModel = new List<MarketStructureModel>();

                        var zones = repository.MarketStructuresWithType.Where(m => m.TenantId == tenantChild.Id && m.Type.StrCode == "Zone" && m.ParentId==phase.Id);

                        foreach (var zone in zones)
                        {
                            List<MarketStructureModel> corridorModel = new List<MarketStructureModel>();

                            var corridors = repository.MarketStructuresWithType.Where(m => m.TenantId == tenantChild.Id && m.Type.StrCode == "Corridor" && m.ParentId == zone.Id);

                            foreach (var corridor in corridors)
                            {
                                List<MarketStructureModel> shopModel = new List<MarketStructureModel>();

                                var shops = repository.MarketStructuresWithType.Where(m => m.TenantId == tenantChild.Id && m.Type.StrCode == "Shop" && m.ParentId == corridor.Id);

                                foreach (var shop in shops)
                                {
                                    shopModel.Add(new MarketStructureModel()
                                    {
                                        MarketStructureId = shop.Id,
                                        MarketStructureCode = shop.Code,
                                        MarketStructureName = shop.Name,
                                        MarketStructureTypeId = shop.Type.Id,
                                        MarketStructureTypeStrCode = shop.Type.StrCode,
                                        MarketStructureTypeName = shop.Type.Name,
                                        MarketStructureParentId = corridor.Id,
                                        MarketStructureParentName = corridor.Name,
                                        MarketId = tenantChild.Id,
                                        MarketName = tenantChild.Name,
                                        MarketStructureAddress = shop.StructureAddress,
                                        MarketStructureDescription = shop.Description
                                    });
                                }

                                corridorModel.Add(new MarketStructureModel()
                                {
                                    MarketStructureId = corridor.Id,
                                    MarketStructureCode = corridor.Code,
                                    MarketStructureName = corridor.Name,
                                    MarketStructureTypeId = corridor.Type.Id,
                                    MarketStructureTypeStrCode = corridor.Type.StrCode,
                                    MarketStructureTypeName = corridor.Type.Name,
                                    MarketStructureParentId = zone.Id,
                                    MarketStructureParentName = zone.Name,
                                    MarketId = tenantChild.Id,
                                    MarketName = tenantChild.Name,
                                    MarketStructureAddress = corridor.StructureAddress,
                                    MarketStructureDescription = corridor.Description,
                                    MarketStructureModels=shopModel
                                });
                            }

                            zoneModel.Add(new MarketStructureModel()
                            {
                                MarketStructureId = zone.Id,
                                MarketStructureCode = zone.Code,
                                MarketStructureName = zone.Name,
                                MarketStructureTypeId = zone.Type.Id,
                                MarketStructureTypeStrCode = zone.Type.StrCode,
                                MarketStructureTypeName = zone.Type.Name,
                                MarketStructureParentId = phase.Id,
                                MarketStructureParentName = phase.Name,
                                MarketId = tenantChild.Id,
                                MarketName = tenantChild.Name,
                                MarketStructureAddress = zone.StructureAddress,
                                MarketStructureDescription = zone.Description,
                                MarketStructureModels= corridorModel
                            });
                        }

                        phaseModel.Add(new MarketStructureModel()
                        {
                            MarketStructureId = phase.Id,
                            MarketStructureCode = phase.Code,
                            MarketStructureName = phase.Name,
                            MarketStructureTypeId = phase.Type.Id,
                            MarketStructureTypeStrCode = phase.Type.StrCode,
                            MarketStructureTypeName = phase.Type.Name,
                            MarketStructureParentId = null,
                            MarketStructureParentName = null,
                            MarketId=tenantChild.Id,
                            MarketName= tenantChild.Name,
                            MarketStructureAddress = phase.StructureAddress,
                            MarketStructureDescription = phase.Description,
                            MarketStructureModels=zoneModel
                        });
                    }

                    tenantChildModel.Add(new MarketModel()
                    {
                        MarketId = tenantChild.Id,
                        MarketCode = tenantChild.Code,
                        MarketName = tenantChild.Name,
                        MarketType = "Market",
                        MarketParentId = tenantChild.ParentId,
                        MarketStructureModels= phaseModel
                    });
                }

                tenantModel.Add(new MarketModel()
                {
                    MarketId = tenant.Id,
                    MarketCode = tenant.Code,
                    MarketName = tenant.Name,
                    MarketType = "MainMarket",
                    MarketParentId = tenant.ParentId,
                    MarketModels=tenantChildModel
                });
            }

            return tenantModel;
        }

        public MarketStructureDefineModel GetMarketStructureDefine(IMarketRepository repository, IGeneralRepository genRepository, ISecurityRepository secRepository, int Id, int ParentId,int MarketId)
        {
            MarketStructureDefineModel model = new MarketStructureDefineModel();

            if (Id > 0)
            {
                var structure = repository.MarketStructures.FirstOrDefault(m => m.Id == Id);
                var Type = genRepository.BasicInformations.FirstOrDefault(b => b.Id == structure.TypeId);
                var Tenant = secRepository.Tenants.FirstOrDefault(t => t.Id == structure.TenantId);
                var Parent = repository.MarketStructures.FirstOrDefault(m => m.Id == structure.ParentId);

                model.MarketStructureDefineId = structure.Id;
                model.MarketStructureDefineCode = structure.Code;
                model.MarketStructureDefineName = structure.Name;
                model.MarketStructureDefineTypeId = structure.TypeId;
                model.MarketStructureDefineTypeStrCode = Type.StrCode;
                model.MarketStructureDefineTypeName = Type.Name;
                if (Parent != null)
                {
                    model.MarketStructureDefineParentId = structure.ParentId;
                    model.MarketStructureDefineParentName = Parent.Name;
                }
                else
                {
                    model.MarketStructureDefineParentId = 0;
                    model.MarketStructureDefineParentName = "";
                }
                model.MarketId = structure.TenantId;
                model.MarketName = Tenant.Name;
                model.MarketStructureDefineAddress = structure.StructureAddress;
                model.MarketStructureDefineDescription = structure.Description;

                

            }
            else if (ParentId > 0)
            {
                var structure = repository.MarketStructures.FirstOrDefault(m => m.Id == ParentId);
                var Type = genRepository.BasicInformations.FirstOrDefault(b => b.CategoryId==2 && b.Id == structure.TypeId+1);
                var Tenant = secRepository.Tenants.FirstOrDefault(t => t.Id == structure.TenantId);

                model.MarketStructureDefineId = 0;
                model.MarketStructureDefineCode = 0;
                model.MarketStructureDefineName = "";
                model.MarketStructureDefineTypeId = Type.Id;
                model.MarketStructureDefineTypeStrCode = Type.StrCode;
                model.MarketStructureDefineTypeName = Type.Name;
                model.MarketStructureDefineParentId = structure.Id;
                model.MarketStructureDefineParentName = structure.Name;
                model.MarketId = Tenant.Id;
                model.MarketName = Tenant.Name;
                model.MarketStructureDefineAddress = "";
                model.MarketStructureDefineDescription = "";
            }
            else if (MarketId > 0)
            {

                var Type = genRepository.BasicInformations.FirstOrDefault(b => b.CategoryId==2 && b.Code == 1);
                var Tenant = secRepository.Tenants.FirstOrDefault(t => t.Id == MarketId);

                model.MarketStructureDefineId = 0;
                model.MarketStructureDefineCode = 0;
                model.MarketStructureDefineName = "";
                model.MarketStructureDefineTypeId = Type.Id;
                model.MarketStructureDefineTypeStrCode = Type.StrCode;
                model.MarketStructureDefineTypeName = Type.Name;
                model.MarketStructureDefineParentId = 0;
                model.MarketStructureDefineParentName = "";
                model.MarketId = Tenant.Id;
                model.MarketName = Tenant.Name;
                model.MarketStructureDefineAddress = "";
                model.MarketStructureDefineDescription = "";
            }

            return model;
        }

        public NotificationModel DeleteMarketStructure(IMarketRepository repository, int MarketStructureId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var marketStructure = repository.MarketStructures.FirstOrDefault(s => s.Id == MarketStructureId);

            if (marketStructure.MarketStructures.Count() > 0)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            }

            if (success)
            {
                var structure = repository.MarketStructures.Where(s => s.Id == MarketStructureId);
                success = repository.DeleteMarketStructure(structure);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveMarketStructure(IMarketRepository repository, ISecurityRepository secRepository, MarketStructureDefineModel model)
        {
            bool success = true;
            int MarketStructureId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.MarketStructures.Where(m => m.Id != model.MarketStructureDefineId).Any(m => m.TenantId == model.MarketId && m.ParentId == model.MarketStructureDefineParentId && m.Code == model.MarketStructureDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد ساختار وارد شده تکراری می باشد";

            }
            else if (model.MarketStructureDefineTypeId != 204 && model.MarketStructureDefineCode > 99)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد ساختار برای انواع ساختار فاز، زون و تالار باید کمتر از 99 باشد";
            }
            else if (model.MarketStructureDefineTypeId == 204 && model.MarketStructureDefineCode > 999)
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد ساختار برای نوع ساختار غرفه باید کمتر از 999 باشد";
            }
            else if (repository.MarketStructures.Where(m => m.Id != model.MarketStructureDefineId).Any(m => m.TenantId == model.MarketId && m.ParentId == model.MarketStructureDefineParentId && m.Name == model.MarketStructureDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام ساختار وارد شده تکراری می باشد";

            }

            string ParentAddress = "";

            if (model.MarketStructureDefineParentId == 0 && model.MarketStructureDefineId > 0)
            {
                var structure = repository.MarketStructures.FirstOrDefault(m => m.Id == model.MarketStructureDefineId);

                model.MarketStructureDefineParentId = structure.ParentId;
                model.MarketId = structure.TenantId;
            }

            var parent = repository.MarketStructures.FirstOrDefault(m => m.Id == model.MarketStructureDefineParentId);
            if (model.MarketId == 0 && parent != null)
            {
                model.MarketId = parent.TenantId;
            }
            var tenant = secRepository.Tenants.FirstOrDefault(t => t.Id == model.MarketId);

            if (parent != null)
            {
                ParentAddress = parent.StructureAddress;
            }
            else if(tenant !=null)
            {
                ParentAddress = tenant.Name;
                model.MarketId = tenant.Id;
            }
            


            if (success)
            {

                success = repository.SaveMarketStructure(new GeneralDAL.Database.MarketStructure()
                {
                    Id = model.MarketStructureDefineId,
                    Code = model.MarketStructureDefineCode,
                    Name = model.MarketStructureDefineName,
                    TypeId=model.MarketStructureDefineTypeId,
                    TenantId=model.MarketId,
                    ParentId=model.MarketStructureDefineParentId,
                    StructureAddress=ParentAddress+">>"+model.MarketStructureDefineName,
                    Description = model.MarketStructureDefineDescription
                });

                if (success)
                {
                    MarketStructureId = repository.MarketStructures.FirstOrDefault(m => m.TenantId == model.MarketId && m.TypeId == model.MarketStructureDefineTypeId && m.Code == model.MarketStructureDefineCode).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = MarketStructureId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<ShopModel> GetShops(IMarketRepository repository, ISecurityRepository secRepository, int TenantId)
        {
            List<ShopModel> model = new List<ShopModel>();

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            int ShopGroupId = 0;
            string ShopGroupName = "";

            foreach (var tenant in tenants)
            {
                var shops = repository.Shops.Where(s => s.TenantId == tenant.Id);

                foreach (var shop in shops)
                {
                    if (shop.ShopGroup != null)
                    {
                        ShopGroupName = shop.ShopGroup.Name;
                        ShopGroupId = shop.ShopGroup.Id;
                    }
                    else
                    {
                        ShopGroupId = 0;
                        ShopGroupName = "";
                    }

                    model.Add(new ShopModel()
                    {
                        ShopId = shop.Id,
                        ShopCode = shop.Code,
                        ShopName = shop.Name,
                        ShopTypeId = shop.Type.Id,
                        ShopTypeName = shop.Type.Name,
                        ShopTypeStrCode = shop.Type.StrCode,
                        ShopGroupId = ShopGroupId,
                        ShopGroupName = ShopGroupName,
                        ShopMarketStructureId = shop.MarketStructure.Id,
                        ShopMarketStructureName = shop.MarketStructure.Name,
                        ShopMarketStructureAddress = shop.MarketStructure.StructureAddress,
                        TenantId = shop.Tenant.Id,
                        TenantName = shop.Tenant.Name,
                        ShopLength = shop.Length,
                        ShopWidth = shop.Width,
                        ShopArea = shop.Area,
                        ShopIdentifier = shop.ShopIdentifier
                    });

                    
                }
            }
                     

            return model;
        }

        public ShopDefineModel GetShopDefine(IMarketRepository repository, ISecurityRepository secRepository, int Id, int TenantId)
        {
            ShopDefineModel model = new ShopDefineModel();

            int ShopGroupId = 0;
            string ShopGroupName = "";
            if (Id > 0)
            {
                var shop = repository.Shops.FirstOrDefault(s => s.Id == Id);

                if (shop != null)
                {
                    if (shop.ShopGroup != null)
                    {
                        ShopGroupName = shop.ShopGroup.Name;
                        ShopGroupId = shop.ShopGroup.Id;
                    }
                    else
                    {
                        ShopGroupId = 0;
                        ShopGroupName = "";
                    }

                    model = new ShopDefineModel()
                    {
                        ShopDefineId = shop.Id,
                        ShopDefineCode = shop.Code,
                        ShopDefineName = shop.Name,
                        ShopDefineTypeId = shop.Type.Id,
                        ShopDefineTypeName = shop.Type.Name,
                        ShopDefineTypeStrCode = shop.Type.StrCode,
                        ShopGroupId = ShopGroupId,
                        ShopGroupName = ShopGroupName,
                        ShopDefineMarketStructureId = shop.MarketStructure.Id,
                        ShopDefineMarketStructureName = shop.MarketStructure.Name,
                        ShopDefineMarketStructureAddress = shop.MarketStructure.StructureAddress,
                        TenantId = shop.Tenant.Id,
                        TenantName = shop.Tenant.Name,
                        ShopDefineLength = shop.Length,
                        ShopDefineWidth = shop.Width,
                        ShopDefineArea = shop.Area,
                        ShopDefineIdentifier = shop.ShopIdentifier
                    };
                }
            }
           

            return model;
        }

        public IEnumerable<BasicInformationForComboModel> GetShopTypeForCombo(IGeneralRepository genRepository)
        {
            List<BasicInformationForComboModel> model = new List<BasicInformationForComboModel>();

            var types = genRepository.BasicInformations.Where(b => b.Category.Code == "ShopType").OrderBy(b => b.Priority);

            foreach (var type in types)
            {
                model.Add(new BasicInformationForComboModel()
                {
                    Id=type.Id,
                    Code=type.Code,
                    StrCode=type.StrCode,
                    Name=type.Name,
                    Priority=type.Priority
                });
            }

            return model;
        }

        public IEnumerable<ShopGroupForComboModel> GetShopGroupForCombo(IMarketRepository repository)
        {
            List<ShopGroupForComboModel> model = new List<ShopGroupForComboModel>();

            var groups = repository.ShopGroups.OrderBy(s => s.Code);

            foreach (var group in groups)
            {
                model.Add(new ShopGroupForComboModel()
                {
                    Id = group.Id,
                    Code = group.Code,
                    Name = group.Name
                });
            }

            return model;
        }

        public IEnumerable<MarketStructureForComboModel> GetMarketStructureForCombo(IMarketRepository repository, ISecurityRepository secRepository, int TenantId)
        {
            List<MarketStructureForComboModel> model = new List<MarketStructureForComboModel>();

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            foreach (var tenant in tenants)
            {
                var structures = repository.MarketStructures.Where(m => m.TenantId == tenant.Id && m.TypeId == 204 && m.Shops==null).OrderBy(m => m.Code);

                foreach (var structure in structures)
                {
                    //if (shops.Any(s => s.MarketStructureId == structure.Id))
                    //{
                        model.Add(new MarketStructureForComboModel()
                        {
                            Id = structure.Id,
                            Code = structure.Code,
                            Name = structure.Name,
                            StructureAddress = structure.StructureAddress
                        });
                    //}
                }
            }

            return model;
        }

        public IEnumerable<ShopForComboModel> GetShopForCombo(IMarketRepository repository, ISecurityRepository secRepository, int TenantId)
        {
            List<ShopForComboModel> model = new List<ShopForComboModel>();

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            foreach (var tenant in tenants)
            {
                var shops = repository.Shops.Where(m => m.TenantId == tenant.Id && m.MarketStructure.TypeId == 204).OrderBy(m => m.Code);

                foreach (var shop in shops)
                {
                    model.Add(new ShopForComboModel()
                        {
                            Id = shop.Id,
                            Code = shop.Code,
                            Name = shop.Name,
                            ShopIdentifier=shop.ShopIdentifier,
                            StructureAddress = shop.MarketStructure.StructureAddress
                        });
                    
                }
            }

            return model;
        }

        public NotificationModel DeleteShop(IMarketRepository repository, int ShopId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var shop = repository.Shops.Where(s => s.Id == ShopId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {
                
                success = repository.DeleteShop(shop);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveShop(IMarketRepository repository, ISecurityRepository secRepository, IGeneralRepository genRepository, ShopDefineModel model)
        {
            bool success = true;
            int ShopId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Shops.Where(m => m.Id != model.ShopDefineId).Any(m => m.TenantId == model.TenantId && m.Code == model.ShopDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد غرفه وارد شده تکراری می باشد";

            }
            else if (repository.Shops.Where(m => m.Id != model.ShopDefineId).Any(m => m.TenantId == model.TenantId && m.Name == model.ShopDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام غرفه وارد شده تکراری می باشد";

            }

            string ShopIdentifier= "";

            var marketStructure = repository.MarketStructures.FirstOrDefault(m => m.Id == model.ShopDefineMarketStructureId);

            int TenantId = marketStructure.TenantId;
            int len = 0;
            while (marketStructure != null)
            {
                switch (marketStructure.TypeId.ToString())
                {
                    case "204":
                        len = ("00" + marketStructure.Code.ToString()).Length;
                        ShopIdentifier = marketStructure.Type.StrCode.Substring(0, 1) + ("00" + marketStructure.Code.ToString()).Substring(len - 3, 3) + ShopIdentifier;
                        break;
                    case "203":
                        len = ("0" + marketStructure.Code.ToString()).Length;
                        ShopIdentifier = marketStructure.Type.StrCode.Substring(0, 1) + ("0" + marketStructure.Code.ToString()).Substring(len - 2, 2) + ShopIdentifier;
                        break;
                    case "202":
                        len = ("0" + marketStructure.Code.ToString()).Length;
                        ShopIdentifier = marketStructure.Type.StrCode.Substring(0, 1) + ("0" + marketStructure.Code.ToString()).Substring(len - 2, 2) + ShopIdentifier;
                        break;
                    case "201":
                        len = ("0" + marketStructure.Code.ToString()).Length;
                        ShopIdentifier = marketStructure.Type.StrCode.Substring(0, 1) + ("0" + marketStructure.Code.ToString()).Substring(len - 2, 2) + ShopIdentifier;
                        break;
                }

                marketStructure = repository.MarketStructures.FirstOrDefault(m => m.Id == marketStructure.ParentId);
            }

            var tenant = secRepository.Tenants.FirstOrDefault(t => t.Id == TenantId);

            ShopIdentifier = "M" + ("0" + tenant.Code.ToString()).PadRight(2)+ ShopIdentifier;

            var type = genRepository.BasicInformations.FirstOrDefault(b => b.Id == model.ShopDefineTypeId);

            ShopIdentifier = ShopIdentifier + type.StrCode;

            model.ShopDefineIdentifier = ShopIdentifier;

            if (success)
            {

                success = repository.SaveShop(new GeneralDAL.Database.Shop()
                {
                    Id = model.ShopDefineId,
                    Code = model.ShopDefineCode,
                    Name = model.ShopDefineName,
                    TypeId = model.ShopDefineTypeId,
                    ShopGroupId = model.ShopGroupId,
                    TenantId = TenantId,
                    MarketStructureId=model.ShopDefineMarketStructureId,
                    Length=model.ShopDefineLength,
                    Width=model.ShopDefineWidth,
                    ShopIdentifier = model.ShopDefineIdentifier
                });

                if (success)
                {
                    ShopId = repository.Shops.FirstOrDefault(m => m.Code == model.ShopDefineCode && m.ShopIdentifier== model.ShopDefineIdentifier).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = ShopId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<TariffModel> GetTariffs(IMarketRepository repository)
        {
            List<TariffModel> model = new List<TariffModel>();

            var tariffs = repository.Tariffs;

            foreach (var tariff in tariffs)
            {
                model.Add(new TariffModel()
                {
                    TariffId = tariff.Id,
                    TariffName = tariff.Name,
                    TariffPriority = tariff.Priority,
                    TariffFormula = tariff.Formula,
                    TariffStartDate = tariff.StartDate,
                    TariffEndDate = tariff.EndDate,
                    TariffRentAmount = tariff.RentAmount,
                    TariffReserveAmount = tariff.ReserveAmount,
                    TariffDescription = tariff.Description
                });
            }

            return model;
        }

        public TariffDefineModel GetTariffDefine(IMarketRepository repository, int Id)
        {
            TariffDefineModel model =new TariffDefineModel();

            
            var tariff = repository.Tariffs.FirstOrDefault(t =>t.Id==Id);

            if (tariff != null)
            {
                model = new TariffDefineModel()
                {
                    TariffDefineId = tariff.Id,
                    TariffDefineName = tariff.Name,
                    TariffDefinePriority = tariff.Priority,
                    TariffDefineFormula = tariff.Formula,
                    TariffDefineStartDate = tariff.StartDate,
                    TariffDefineEndDate = tariff.EndDate,
                    TariffDefineRentAmount = tariff.RentAmount,
                    TariffDefineReserveAmount = tariff.ReserveAmount,
                    TariffDefineDescription = tariff.Description
                };
            }

            return model;
        }

        public NotificationModel DeleteTariff(IMarketRepository repository, int TariffId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var tariff = repository.Tariffs.Where(s => s.Id == TariffId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteTariff(tariff);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveTariff(IMarketRepository repository, TariffDefineModel model)
        {
            bool success = true;
            int TariffId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Tariffs.Where(m => m.Id != model.TariffDefineId).Any(t => t.Name == model.TariffDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "نام تعرفه وارد شده تکراری می باشد";

            }
            else if (repository.Tariffs.Where(m => m.Id != model.TariffDefineId).Any(t => t.Priority == model.TariffDefinePriority))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "اولویت تعرفه وارد شده تکراری می باشد";

            }


            if (success)
            {

                success = repository.SaveTariff(new GeneralDAL.Database.Tariff()
                {
                    Id = model.TariffDefineId,
                    Name = model.TariffDefineName,
                    Priority= model.TariffDefinePriority,
                    Formula = model.TariffDefineFormula,
                    StartDate = model.TariffDefineStartDate,
                    EndDate = model.TariffDefineEndDate,
                    RentAmount = model.TariffDefineRentAmount,
                    ReserveAmount = model.TariffDefineReserveAmount,
                    Description = model.TariffDefineDescription
                });

                if (success)
                {
                    TariffId = repository.Tariffs.FirstOrDefault(m => m.Name == model.TariffDefineName && m.Priority == model.TariffDefinePriority && m.Formula==model.TariffDefineFormula && m.StartDate==model.TariffDefineStartDate).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = TariffId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<TenantModel> GetTenantChildren(ISecurityRepository repository, int TenantId, bool IncludeParent)
        {
            List<TenantModel> tenants = new List<TenantModel>();

            if (IncludeParent)
            {
                var parent = repository.Tenants.FirstOrDefault(testc => testc.Id == TenantId);

                tenants.Add(new TenantModel()
                {
                    Id = parent.Id,
                    Code = parent.Code,
                    Name = parent.Name,
                    ParentId = parent.ParentId
                });
            }

            var children = repository.Tenants.Where(t => t.ParentId == TenantId).ToList();

            foreach (var item in children)
            {
                tenants.Add(new TenantModel()
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    ParentId = item.ParentId
                });

            }

            return tenants;
        }

        public IEnumerable<CustomerModel> GetCustomers(IMarketRepository repository) {
            List<CustomerModel> model = new List<CustomerModel>();

            var customers = repository.Customers;

            int? JobGroupId = 0;
            string JobGroupName = "";

            foreach (var customer in customers)
            {
                List<CustomerCardModel> cardModel = new List<CustomerCardModel>();

                foreach (var card in customer.CustomerCards)
                {
                    cardModel.Add(new CustomerCardModel()
                    {
                        CustomerCardId = card.Id,
                        CustomerCardCustomerId = card.CustomerId,
                        CustomerCardCustomerName = card.Customer.FullName,
                        CustomerCardCardCode = card.CardCode,
                        CustomerCardStartDate = card.StartDate,
                        CustomerCardEndDate = card.EndDate,
                        CustomerCardActive = card.Active
                    });
                }

                if (customer.JobGroup != null)
                {
                    JobGroupId = customer.JobGroup.Id;
                    JobGroupName = customer.JobGroup.Name;
                }
                else
                {
                    JobGroupId = null;
                    JobGroupName = "";
                }

                model.Add(new CustomerModel()
                {
                    CustomerId = customer.Id,
                    CustomerJobGroupId = JobGroupId,
                    CustomerjobGroupName = JobGroupName,
                    CustomerFirstName = customer.FirstName,
                    CustomerLastName = customer.LastName,
                    CustomerFullName = customer.FullName,
                    CustomerNationalCode = customer.NationalCode,
                    CustomerMobileNumber = customer.MobileNumber,
                    CustomerCards=cardModel
                });
            }

            return model;
        }

        public CustomerDefineModel GetCustomerDefine(IMarketRepository repository, int Id)
        {
            CustomerDefineModel model = new CustomerDefineModel();

            var customer = repository.Customers.FirstOrDefault(c => c.Id==Id);

            string JobGroupName = "";
            string JobName = "";
            string? BirthCityName = "";
            string? IssuanceCityName = "";
            string GenderName = "";

            if (customer != null)
            {
                List<CustomerCardModel> cardModel = new List<CustomerCardModel>();

                foreach (var card in customer.CustomerCards)
                {
                    cardModel.Add(new CustomerCardModel()
                    {
                        CustomerCardId = card.Id,
                        CustomerCardCustomerId = card.CustomerId,
                        CustomerCardCustomerName = card.Customer.FullName,
                        CustomerCardCardCode = card.CardCode,
                        CustomerCardStartDate = card.StartDate,
                        CustomerCardEndDate = card.EndDate,
                        CustomerCardActive = card.Active
                    });
                }

                int Balance = 0;

                Balance = CalculateBalance(repository, customer.Id);

                if (customer.JobGroup != null)
                {
                    JobGroupName = customer.JobGroup.Name;
                }
                else
                {
                    JobGroupName = "";
                }

                if (customer.Job != null)
                {
                    JobName = customer.Job.Name;
                }
                else
                {
                    JobName = "";
                }

                if (customer.BirthCity != null)
                {
                    BirthCityName = customer.BirthCity.Name;
                }
                else
                {
                    BirthCityName = "";
                }

                if (customer.IssuanceCity != null)
                {
                    IssuanceCityName = customer.IssuanceCity.Name;
                }
                else
                {
                    IssuanceCityName = "";
                }

                if (customer.Gender)
                {
                    GenderName = "آقا";
                }
                else
                {
                    GenderName = "خانم";
                }

                model = new CustomerDefineModel()
                {
                    CustomerDefineId = customer.Id,
                    CustomerDefineCode = customer.Code,
                    CustomerDefineJobGroupId = customer.JobGroupId,
                    CustomerDefinejobGroupName = JobGroupName,
                    CustomerDefineJobId = customer.JobId,
                    CustomerDefineJobName = JobName,
                    CustomerDefineFirstName = customer.FirstName,
                    CustomerDefineLastName = customer.LastName,
                    CustomerDefineFullName = customer.FullName,
                    CustomerDefineNationalCode = customer.NationalCode,
                    CustomerDefineIdentityNumber = (long)customer.IdentityNumber,
                    CustomerDefineMobileNumber = customer.MobileNumber,
                    CustomerDefineFatherName = customer.FatherName,
                    CustomerDefineWorkAddress = customer.WorkAddress,
                    CustomerDefineWorkPhone = customer.WorkPhone,
                    CustomerDefineHomeAddress = customer.HomeAddress,
                    CustomerDefineHomePhone = customer.HomePhone,
                    CustomerDefineGender = customer.Gender,
                    CustomerDefineGenderName = GenderName,
                    CustomerDefineBirthYear = customer.BirthYear,
                    CustomerDefineBirthCityId = customer.BirthCityId,
                    CustomerDefineBirthCityName = BirthCityName,
                    CustomerDefineIssuanceCityId = customer.IssuanceCityId,
                    CustomerDefineIssuanceCityName = IssuanceCityName,
                    CustomerDefineAccountBalance = customer.AccountBalance,
                    CustomerDefineAppAccountBalance = customer.AppAccountBalance,
                    CustomerDefineTotalRentsAmount = customer.TotalRentsAmount,
                    CustomerDefineTotalPaymentsAmount = customer.TotalPaymentsAmount,
                    CustomerDefineDebtCeiling = customer.DebtCeiling,
                    CustomerDefineDescription = customer.Description,
                    CustomerDefineBalance = Balance,
                    CustomerCards = cardModel
                };

            }
            else
            {
                model = new CustomerDefineModel()
                {
                    CustomerDefineId = 0,
                    CustomerDefineCode = 0,
                    CustomerDefineJobGroupId = 0,
                    CustomerDefinejobGroupName = "",
                    CustomerDefineJobId = 0,
                    CustomerDefineJobName = "",
                    CustomerDefineFirstName = "",
                    CustomerDefineLastName = "",
                    CustomerDefineFullName = "",
                    CustomerDefineNationalCode = "",
                    CustomerDefineIdentityNumber = 0,
                    CustomerDefineMobileNumber = "",
                    CustomerDefineFatherName = "",
                    CustomerDefineWorkAddress = "",
                    CustomerDefineWorkPhone = "",
                    CustomerDefineHomeAddress = "",
                    CustomerDefineHomePhone = "",
                    CustomerDefineGender = true,
                    CustomerDefineGenderName = "",
                    CustomerDefineBirthYear = 0,
                    CustomerDefineBirthCityId = 0,
                    CustomerDefineBirthCityName = "",
                    CustomerDefineIssuanceCityId = 0,
                    CustomerDefineIssuanceCityName = "",
                    CustomerDefineAccountBalance = 0,
                    CustomerDefineAppAccountBalance = 0,
                    CustomerDefineTotalRentsAmount = 0,
                    CustomerDefineTotalPaymentsAmount = 0,
                    CustomerDefineDebtCeiling = 0,
                    CustomerDefineDescription = "",
                    CustomerDefineBalance = 0,
                    CustomerCards = null
                };
            }

            return model;
        }

        protected int CalculateBalance(IMarketRepository repository,int CustomerId)
        {
            var customer = repository.Customers.FirstOrDefault(c => c.Id == CustomerId);

            int Balance = 0;

            if (customer != null)
            {
                if (customer.AccountBalance != null)
                {
                    Balance = (int)customer.AccountBalance;
                }

                foreach (var credit in customer.Credits)
                {
                    if (credit.Type)
                        Balance += credit.Amount;
                    else
                        Balance -= credit.Amount;
                }

                foreach (var rent in customer.Rents)
                {
                    Balance -= rent.Payments.Sum(p => p.Amount);
                }
            }

            return Balance;
        }

        public NotificationModel DeleteCustomer(IMarketRepository repository, int CustomerId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var customer = repository.Customers.Where(s => s.Id == CustomerId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteCustomer(customer);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveCustomer(IMarketRepository repository, IGeneralRepository genRepository, CustomerDefineModel model)
        {
            bool success = true;
            int CustomerId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Customers.Where(m => m.Id != model.CustomerDefineId).Any(t => t.Code == model.CustomerDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد مشتری وارد شده تکراری می باشد";

            }
            else if (repository.Customers.Where(m => m.Id != model.CustomerDefineId).Any(t => t.NationalCode == model.CustomerDefineNationalCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد ملی وارد شده تکراری می باشد";

            }
            else if (repository.Customers.Where(m => m.Id != model.CustomerDefineId).Any(t => t.MobileNumber == model.CustomerDefineMobileNumber))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "شماره موبایل وارد شده تکراری می باشد";

            }


            if (success)
            {
                int JobGroupId = 0;
                if (model.CustomerDefineJobId != null)
                {
                    JobGroupId = genRepository.Jobs.FirstOrDefault(j => j.Id == model.CustomerDefineJobId).JobGroupId;
                }

                success = repository.SaveCustomer(new GeneralDAL.Database.Customer()
                {
                    Id = model.CustomerDefineId,
                    Code=model.CustomerDefineCode,
                    FirstName = model.CustomerDefineFirstName,
                    LastName = model.CustomerDefineLastName,
                    NationalCode = model.CustomerDefineNationalCode,
                    IdentityNumber=model.CustomerDefineIdentityNumber,
                    FatherName=model.CustomerDefineFatherName,
                    MobileNumber = model.CustomerDefineMobileNumber,
                    WorkAddress=model.CustomerDefineWorkAddress,
                    WorkPhone=model.CustomerDefineWorkPhone,
                    Gender=model.CustomerDefineGender,
                    HomeAddress=model.CustomerDefineHomeAddress,
                    HomePhone=model.CustomerDefineHomePhone,
                    BirthYear=model.CustomerDefineBirthYear,
                    BirthCityId=model.CustomerDefineBirthCityId,
                    IssuanceCityId=model.CustomerDefineIssuanceCityId,
                    JobGroupId = JobGroupId,
                    JobId=model.CustomerDefineJobId,
                    DebtCeiling=model.CustomerDefineDebtCeiling,
                    Description=model.CustomerDefineDescription
                });

                if (success)
                {
                    CustomerId = repository.Customers.FirstOrDefault(m => m.NationalCode == model.CustomerDefineNationalCode).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = CustomerId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public CustomerCardDefineModel GetCustomerCardDefine(IMarketRepository repository, int Id,int CustomerId)
        {
            CustomerCardDefineModel cardModel = new CustomerCardDefineModel();

            if (Id > 0)
            {
                var card = repository.CustomerCards.FirstOrDefault(c => c.Id == Id);

                if (card != null)
                {
                    cardModel = new CustomerCardDefineModel()
                    {
                        CustomerCardDefineId = card.Id,
                        CustomerCardDefineCustomerId = card.CustomerId,
                        CustomerCardDefineCustomerName = card.Customer.FullName,
                        CustomerCardDefineCardCode = card.CardCode,
                        CustomerCardDefineStartDate = card.StartDate,
                        CustomerCardDefineEndDate = card.EndDate,
                        CustomerCardDefineActive = card.Active
                    };
                }
            }
            else
            {
                var customer = repository.Customers.FirstOrDefault(c => c.Id == CustomerId);

                if (customer != null)
                {
                    cardModel = new CustomerCardDefineModel()
                    {
                        CustomerCardDefineId = 0,
                        CustomerCardDefineCustomerId = customer.Id,
                        CustomerCardDefineCustomerName = customer.FullName,
                        CustomerCardDefineCardCode = "",
                        CustomerCardDefineStartDate = "",
                        CustomerCardDefineEndDate = "",
                        CustomerCardDefineActive = false
                    };
                }
            }
        
            return cardModel;
        }

        public NotificationModel DeleteCustomerCard(IMarketRepository repository, int CustomerCardId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var customerCard = repository.CustomerCards.Where(s => s.Id == CustomerCardId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteCustomerCard(customerCard);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveCustomerCard(IMarketRepository repository, CustomerCardDefineModel model)
        {
            bool success = true;
            int CustomerCardId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.CustomerCards.Where(m => m.Id != model.CustomerCardDefineId).Any(t => t.CardCode == model.CustomerCardDefineCardCode))
            {
                success = false; 
                ResultType = "error";
                ResultMessage = "شماره کارت عضویت وارد شده تکراری می باشد";

            }
            else if (repository.CustomerCards.Where(m => m.Id != model.CustomerCardDefineId).Any(t => t.CustomerId==model.CustomerCardDefineCustomerId && t.Active == model.CustomerCardDefineActive))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "برای مشتری انتخاب شده تنهاامکان تعریف یک کارت فعال وجود دارد ";

            }


            if (success)
            {

                success = repository.SaveCustomerCard(new GeneralDAL.Database.CustomerCard()
                {
                    Id = model.CustomerCardDefineId,
                    CustomerId = model.CustomerCardDefineCustomerId,
                    CardCode = model.CustomerCardDefineCardCode,
                    StartDate = model.CustomerCardDefineStartDate,
                    EndDate = model.CustomerCardDefineEndDate,
                    Active = model.CustomerCardDefineActive
                });

                if (success)
                {
                    CustomerCardId = repository.CustomerCards.FirstOrDefault(m => m.CardCode == model.CustomerCardDefineCardCode).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = CustomerCardId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<CreditModel> GetCredits(IMarketRepository repository, int CustomerId)
        {
            List<CreditModel> model = new List<CreditModel>();

            var credits = repository.Credits.OrderBy(c => c.Customer.FullName).OrderByDescending(c => c.Date);

            if (CustomerId > 0)
            {
                credits = repository.Credits.Where(c => c.CustomerId == CustomerId).OrderByDescending(c => c.Date);
            }

            foreach (var credit in credits)
            {
                model.Add(new CreditModel()
                {
                    CreditId = credit.Id,
                    CreditCustomerId = credit.CustomerId,
                    CreditCustomerName = credit.Customer.FullName,
                    CreditDate = credit.Date,
                    CreditPaymentTypeId = credit.PaymentTypeId,
                    CreditPaymentTypeName = credit.PaymentType.Name,
                    CreditAmount = credit.Amount,
                    CreditType = credit.Type,
                    CreditReceiptNumber = credit.ReceiptNumber,
                    CreditDescription = credit.Description
                });
            }

            return model;
        }

        public IEnumerable<BasicInformationForComboModel> GetPaymentTypeForCombo(IGeneralRepository genRepository)
        {
            List<BasicInformationForComboModel> model = new List<BasicInformationForComboModel>();

            var types = genRepository.BasicInformations.Where(b => b.Category.Code == "PaymentType").OrderBy(b => b.Priority);

            foreach (var type in types)
            {
                model.Add(new BasicInformationForComboModel()
                {
                    Id = type.Id,
                    Code = type.Code,
                    StrCode = type.StrCode,
                    Name = type.Name,
                    Priority = type.Priority
                });
            }

            return model;
        }

        public IEnumerable<CustomerModel> GetCustomerForCombo(IMarketRepository repository)
        {
            List<CustomerModel> model = new List<CustomerModel>();

            var customers = repository.Customers.OrderBy(c => c.RevFullName);

            foreach (var customer in customers)
            {
                model.Add(new CustomerModel()
                {
                    CustomerId = customer.Id,
                    CustomerNationalCode = customer.NationalCode,
                    CustomerFirstName = customer.FirstName,
                    CustomerLastName = customer.LastName,
                    CustomerFullName = customer.FullName,
                    CustomerMobileNumber = customer.MobileNumber
                });
            }

            return model;
        }

        public CreditDefineModel GetCreditDefine(IMarketRepository repository, int Id, int CustomerId)
        {
            CreditDefineModel model = new CreditDefineModel();

            var credit = repository.Credits.FirstOrDefault(c => c.Id == Id);

            if (credit != null)
            {
                var customer = repository.Customers.FirstOrDefault(c => c.Id == credit.CustomerId);
                int Balance = 0;

                
                if (customer != null)
                {
                    Balance = CalculateBalance(repository, customer.Id);
                }

              

                model = new CreditDefineModel()
                {
                    CreditDefineId = credit.Id,
                    CreditDefineCustomerId = credit.CustomerId,
                    CreditDefineCustomerName = credit.Customer.FullName,
                    CreditDefineDate = credit.Date,
                    CreditDefinePaymentTypeId = credit.PaymentTypeId,
                    CreditDefinePaymentTypeName = credit.PaymentType.Name,
                    CreditDefineAmount = credit.Amount,
                    CreditDefineType = credit.Type,
                    CreditDefineReceiptNumber = credit.ReceiptNumber,
                    CreditDefineDescription = credit.Description,
                    CreditDefineBalance = Balance
                };
            }

           
            return model;
        }

        public NotificationModel DeleteCredit(IMarketRepository repository, int CreditId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var credit = repository.Credits.Where(s => s.Id == CreditId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteCredit(credit);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveCredit(IMarketRepository repository, CreditDefineModel model)
        {
            bool success = true;
            int CreditId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            //if (repository.CustomerCards.Where(m => m.Id != model.Id).Any(t => t.CardCode == model.CardCode))
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "شماره کارت عضویت وارد شده تکراری می باشد";

            //}
            //else if (repository.CustomerCards.Where(m => m.Id != model.Id).Any(t => t.CustomerId == model.CustomerId && t.Active == model.Active))
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "برای مشتری انتخاب شده تنهاامکان تعریف یک کارت فعال وجود دارد ";

            //}


            if (success)
            {

                success = repository.SaveCredit(new GeneralDAL.Database.Credit()
                {
                    Id = model.CreditDefineId,
                    CustomerId = model.CreditDefineCustomerId,
                    Date = model.CreditDefineDate,
                    PaymentTypeId = model.CreditDefinePaymentTypeId,
                    Amount = model.CreditDefineAmount,
                    Type = model.CreditDefineType,
                    ReceiptNumber=model.CreditDefineReceiptNumber,
                    Description=model.CreditDefineDescription
                });

                if (success)
                {
                    CreditId = repository.Credits.FirstOrDefault(m => m.CustomerId == model.CreditDefineCustomerId && m.Date == model.CreditDefineDate && m.Amount == model.CreditDefineAmount).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = CreditId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<DiscountModel> GetDiscounts(IMarketRepository repository)
        {
            List<DiscountModel> model = new List<DiscountModel>();

            var discounts = repository.Discounts;

            foreach (var discount in discounts)
            {
                model.Add(new DiscountModel()
                {
                    DiscountId = discount.Id,
                    DiscountCode = discount.Code,
                    DiscountName = discount.Name,
                    DiscountDefaultPercent = discount.DefaultPercent,
                    DiscountDefaultPrice = discount.DefaultPrice,
                    DiscountStartDate = discount.StartDate,
                    DiscountEndDate = discount.EndDate,
                    DiscountActive = discount.Active
                });
            }

            return model;
        }

        public DiscountDefineModel GetDiscountDefine(IMarketRepository repository, int Id)
        {
            DiscountDefineModel model = new DiscountDefineModel();

            var discount = repository.Discounts.FirstOrDefault(d => d.Id==Id);

            if (discount!=null)
            {
                model=new DiscountDefineModel()
                {
                    DiscountDefineId = discount.Id,
                    DiscountDefineCode = discount.Code,
                    DiscountDefineName = discount.Name,
                    DiscountDefineDefaultPercent = discount.DefaultPercent,
                    DiscountDefineDefaultPrice = discount.DefaultPrice,
                    DiscountDefineStartDate = discount.StartDate,
                    DiscountDefineEndDate = discount.EndDate,
                    DiscountDefineActive = discount.Active
                };
            }

            return model;
        }

        public NotificationModel DeleteDiscount(IMarketRepository repository, int DiscountId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var discounts = repository.Discounts.Where(d => d.Id == DiscountId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteDiscount(discounts);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveDiscount(IMarketRepository repository, DiscountDefineModel model)
        {
            bool success = true;
            int DiscountId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Discounts.Where(d => d.Id != model.DiscountDefineId).Any(d => d.Code== model.DiscountDefineCode))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "کد تخفیف وارد شده تکراری می باشد";

            }
            else if (repository.Discounts.Where(d => d.Id != model.DiscountDefineId).Any(d => d.Name == model.DiscountDefineName))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "عنوان تخفیف وارد شده تکراری می باشد";

            }


            if (success)
            {

                success = repository.SaveDiscount(new GeneralDAL.Database.Discount()
                {
                    Id = model.DiscountDefineId,
                    Code=model.DiscountDefineCode,
                    Name= model.DiscountDefineName,
                    DefaultPercent= model.DiscountDefineDefaultPercent,
                    DefaultPrice= model.DiscountDefineDefaultPrice,
                    StartDate= model.DiscountDefineStartDate,
                    EndDate= model.DiscountDefineEndDate,
                    Active= model.DiscountDefineActive
                });

                if (success)
                {
                    DiscountId = repository.Discounts.FirstOrDefault(d => d.Code == model.DiscountDefineCode).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }


            NotificationModel notificationModel = new NotificationModel()
            {
                Id = DiscountId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<RentModel> GetRents(IMarketRepository repository,ISecurityRepository secRepository,int TenantId)
        {
            List<RentModel> model = new List<RentModel>();

            

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            var rents = repository.Rents;

            foreach (var rent in rents)
            {
                if (tenants.Any(t=>t.Id==rent.Shop.TenantId))
                {
                    List<PaymentModel> paymentModel = new List<PaymentModel>();

                    foreach (var payment in rent.Payments)
                    {
                        paymentModel.Add(new PaymentModel()
                        {
                            Id=payment.Id,
                            Date=payment.Date,
                            RentId=payment.RentId,
                            ReserveId=payment.ReserveId,
                            Amount=payment.Amount,
                            Description=payment.Description
                        });
                    }

                    string DiscountName = "";
                    if (rent.Discount != null)
                    {
                        DiscountName = rent.Discount.Name;
                    }

                   
                    model.Add(new RentModel()
                    {
                        RentId = rent.Id,
                        RentDate = rent.Date,
                        RentMarketScheduleDetailId = rent.MarketScheduleDetail.Id,
                        RentMarketScheduleDescription = rent.MarketScheduleDetail.MarketSchedule.Description,
                        RentCustomerId = rent.CustomerId,
                        RentCustomerName = rent.Customer.FullName,
                        RentShopId = rent.ShopId,
                        RentShopIdentifier = rent.Shop.ShopIdentifier,
                        RentShopAddress = rent.Shop.MarketStructure.StructureAddress,
                        RentTariffId=rent.TariffId,
                        RentTariffName=rent.Tariff.Name,
                        RentTariffAmount=rent.TariffAmount,
                        RentDiscountId=rent.DiscountId,
                        RentDiscountName=DiscountName,
                        RentDiscountAmount=rent.DiscountAmount,
                        RentAmount = rent.Amount,
                        RentPaid = rent.Paid,
                        RentDescription = rent.Description,
                        PaymentModels=paymentModel
                    });
                }
            }

            return model;
        }

        public RentDefineModel GetRentDefine(IMarketRepository repository, int Id,int CustomerId)
        {
            RentDefineModel model = new RentDefineModel()
            {
                RentDefineShopIdentifier = " ",
                RentDefineTariffName = " "
            };

            int Balance = 0;
            if (CustomerId > 0 && Id == 0)
            {
                Balance = CalculateBalance(repository, CustomerId);
                List<PaymentModel> paymentModel = new List<PaymentModel>();

                var customer = repository.Customers.FirstOrDefault(c => c.Id == CustomerId);
                if (customer != null)
                {
                    model = new RentDefineModel()
                    {
                        RentDefineCustomerId = CustomerId,
                        RentDefineCustomerName = customer.FullName,
                        RentDefineCustomerBalance = Balance,
                        PaymentModels = paymentModel,
                        RentDefineShopIdentifier = " ",
                        RentDefineTariffName=" "
                    };
                }
            }
            else
            {

                var rent = repository.Rents.FirstOrDefault(r => r.Id == Id);

                if (rent != null)
                {
                    List<PaymentModel> paymentModel = new List<PaymentModel>();

                    foreach (var payment in rent.Payments)
                    {
                        paymentModel.Add(new PaymentModel()
                        {
                            Id = payment.Id,
                            Date = payment.Date,
                            RentId = payment.RentId,
                            ReserveId = payment.ReserveId,
                            Amount = payment.Amount,
                            Description = payment.Description
                        });
                    }

                    if (rent.CustomerId > 0)
                    {
                        Balance = CalculateBalance(repository, (int)rent.CustomerId);
                    }

                    var discount = rent.Discount;
                    string DiscountName = "";

                    if (discount != null)
                    {
                        DiscountName = discount.Name;
                    }

                    model = new RentDefineModel()
                    {
                        RentDefineId = rent.Id,
                        RentDefineDate = rent.Date,
                        RentDefineMarketScheduleDetailId = rent.MarketScheduleDetail.Id,
                        RentDefineMarketScheduleDescription = rent.MarketScheduleDetail.MarketSchedule.Description,
                        RentDefineCustomerId = rent.CustomerId,
                        RentDefineCustomerName = rent.Customer.FullName,
                        RentDefineCustomerBalance = Balance,
                        RentDefineShopId = rent.ShopId,
                        RentDefineShopIdentifier = rent.Shop.ShopIdentifier,
                        RentDefineShopAddress = rent.Shop.MarketStructure.StructureAddress,
                        RentDefineTariffId = rent.TariffId,
                        RentDefineTariffName = rent.Tariff.Name,
                        RentDefineTariffAmount = rent.TariffAmount,
                        RentDefineDiscountId = rent.DiscountId,
                        RentDefineDiscountName = DiscountName,
                        RentDefineDiscountAmount = rent.DiscountAmount,
                        RentDefineDiscounPercent=rent.DiscountPercent,
                        RentDefineAmount = rent.Amount,
                        RentDefinePaid = rent.Paid,
                        RentDefineDescription = rent.Description,
                        PaymentModels = paymentModel
                    };

                }
            }
            return model;
        }

        public IEnumerable<DiscountForComboModel> GetDiscountTypeForCombo(IMarketRepository repository)
        {
            List<DiscountForComboModel> model = new List<DiscountForComboModel>();

            var discounts = repository.Discounts.Where(d => d.Active == true).OrderBy(d=> d.Name);

            foreach (var discount in discounts)
            {
                model.Add(new DiscountForComboModel()
                {
                    DiscountId = discount.Id,
                    DiscountCode = discount.Code,
                    DiscountName = discount.Name,
                    DiscountActive=discount.Active
                });

            }

            return model;
        }

        public IEnumerable<MarketScheduleModel> GetMarketScheduleForRent(IMarketRepository repository,ISecurityRepository secRepository,int TenantId)
        {
            List<MarketScheduleModel> model = new List<MarketScheduleModel>();

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            string TodayDate = PersianHelper.TodayDate();

            foreach (var tenant in tenants)
            {
                var marketSchedules = repository.MarketSchedules.FirstOrDefault(m => m.MarketId == tenant.Id);
                if (marketSchedules != null)
                {
                    foreach (var detail in marketSchedules.MarketScheduleDetails.Where(m=>m.Date== TodayDate))
                    {
                        model.Add(new MarketScheduleModel()
                        {
                            MarketScheduleId = detail.MarketScheduleId,
                            MarketScheduleDetailId = detail.Id,
                            MarketId = detail.MarketSchedule.MarketId,
                            MarketName = detail.MarketSchedule.Market.Name,
                            MarketScheduleDescription = detail.MarketSchedule.Description,
                            MarketScheduleDate = detail.Date,
                            ComboDescription = detail.Date + " - تقویم : " + detail.MarketSchedule.Description + " - بازار : " + detail.MarketSchedule.Market.Name
                        });
                    }
                }
            }



            return model;
        }

        public IEnumerable<MarketScheduleModel> GetMarketScheduleForReserve(IMarketRepository repository, ISecurityRepository secRepository, int TenantId)
        {
            List<MarketScheduleModel> model = new List<MarketScheduleModel>();

            var tenants = GetTenantChildren(secRepository, TenantId, true);

            string TodayDate = PersianHelper.TodayDate();
            DateTime TDate = PersianHelper.PersianDateStringToDateTime(TodayDate);


            foreach (var tenant in tenants)
            {
                var marketSchedules = repository.MarketSchedules.FirstOrDefault(m => m.MarketId == tenant.Id);
                if (marketSchedules != null)
                {
                    foreach (var detail in marketSchedules.MarketScheduleDetails.Where(m =>TDate <= PersianHelper.PersianDateStringToDateTime(m.Date)))
                    {
                        model.Add(new MarketScheduleModel()
                        {
                            MarketScheduleId = detail.MarketScheduleId,
                            MarketScheduleDetailId = detail.Id,
                            MarketId = detail.MarketSchedule.MarketId,
                            MarketName = detail.MarketSchedule.Market.Name,
                            MarketScheduleDescription = detail.MarketSchedule.Description,
                            MarketScheduleDate = detail.Date,
                            ComboDescription = detail.Date + " - تقویم : " + detail.MarketSchedule.Description + " - بازار : " + detail.MarketSchedule.Market.Name
                        });
                    }
                }
            }



            return model;
        }

        public TariffDefineModel GetTariffDetail(IMarketRepository repository, int MarketScheduleDetailId, int ShopId)
        {
            TariffDefineModel model = new TariffDefineModel();

            if (MarketScheduleDetailId > 0 && ShopId > 0)
            {
                string Date = repository.MarketScheduleDetails.FirstOrDefault(m => m.Id == MarketScheduleDetailId).Date;
                DateTime GDate = PersianHelper.PersianDateStringToDateTime(Date);

                string ShopIdentifier = repository.Shops.FirstOrDefault(s => s.Id == ShopId).ShopIdentifier;

                var tariffs = repository.Tariffs.Where(t => GDate >= PersianHelper.PersianDateStringToDateTime(t.StartDate) && GDate <= PersianHelper.PersianDateStringToDateTime(t.EndDate) && Regex.IsMatch(ShopIdentifier, t.Formula)).OrderBy(t => t.Priority);


                foreach (var tariff in tariffs)
                {


                    if (tariff.RentAmount > 0)
                    {
                        model = new TariffDefineModel()
                        {
                            TariffDefineId = tariff.Id,
                            TariffDefineName = tariff.Name,
                            TariffDefinePriority = tariff.Priority,
                            TariffDefineDescription = tariff.Description,
                            TariffDefineRentAmount = tariff.RentAmount,
                            TariffDefineReserveAmount=tariff.ReserveAmount
                        };

                        break;
                    }
                }
            }

            return model;
        
        }

        public DiscountDefineModel GetDiscountDetail(IMarketRepository repository,int MarketScheduleDetailId, int DiscountId)
        {
            DiscountDefineModel model = new DiscountDefineModel();

            string Date = repository.MarketScheduleDetails.FirstOrDefault(m => m.Id == MarketScheduleDetailId).Date;
            DateTime GDate = PersianHelper.PersianDateStringToDateTime(Date);

            var discounts = repository.Discounts.Where(d => GDate >= PersianHelper.PersianDateStringToDateTime(d.StartDate) && GDate <= PersianHelper.PersianDateStringToDateTime(d.EndDate) && d.Id == DiscountId && d.Active==true);


            foreach (var discount in discounts)
            {


                if (discount.DefaultPercent > 0 || discount.DefaultPrice>0)
                {
                    model = new DiscountDefineModel()
                    {
                        DiscountDefineId = discount.Id,
                        DiscountDefineCode = discount.Code,
                        DiscountDefineName = discount.Name,
                        DiscountDefineDefaultPercent = discount.DefaultPercent,
                        DiscountDefineDefaultPrice = discount.DefaultPrice,
                        DiscountDefineActive = discount.Active
                    };

                    break;
                }
            }

            return model;
        }

        public CustomerDefineModel GetCustomerDetail(IMarketRepository repository, int CustomerId)
        {
            CustomerDefineModel model = new CustomerDefineModel();

            var customer = repository.Customers.FirstOrDefault(c => c.Id == CustomerId);


            if (customer != null)
            {
                model = new CustomerDefineModel()
                {
                    CustomerDefineId = customer.Id,
                    CustomerDefineCode = customer.Code,
                    CustomerDefineFullName = customer.FullName,
                    CustomerDefineBalance = CalculateBalance(repository,CustomerId)
                };

            }
            

            return model;
        }

        public ShopDefineModel GetShopDetail(IMarketRepository repository, int ShopId)
        {
            ShopDefineModel model = new ShopDefineModel();

            var shop = repository.Shops.FirstOrDefault(c => c.Id == ShopId);


            if (shop != null)
            {
                model = new ShopDefineModel()
                {
                    ShopDefineId = shop.Id,
                    ShopDefineCode = shop.Code,
                    ShopDefineName = shop.Name,
                    ShopDefineMarketStructureAddress=shop.MarketStructure.StructureAddress,
                    ShopDefineIdentifier=shop.ShopIdentifier
                };

            }


            return model;
        }


        public NotificationModel DeleteRent(IMarketRepository repository, int RentId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var rents = repository.Rents.Where(d => d.Id == RentId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteRent(rents);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveRent(IMarketRepository repository, RentDefineModel model)
        {
            bool success = true;
            int RentId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Rents.Any(d => d.Id != model.RentDefineId && d.ShopId == model.RentDefineShopId && d.MarketScheduleDetailId == model.RentDefineMarketScheduleDetailId && d.CustomerId != model.RentDefineCustomerId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ توسط مشتری دیگری اجاره گردیده است";

            }
            else if (repository.Rents.Any(d => d.Id != model.RentDefineId && d.ShopId == model.RentDefineShopId && d.MarketScheduleDetailId == model.RentDefineMarketScheduleDetailId && d.CustomerId == model.RentDefineCustomerId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ توسط همین مشتری اجاره گردیده است";

            }
            else if (repository.Reserves.Any(d => d.ShopId == model.RentDefineShopId && d.MarketScheduleDetailId == model.RentDefineMarketScheduleDetailId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ رزرو گردیده است";
            }

            if (success)
            {

                model.RentDefineDate = repository.MarketScheduleDetails.FirstOrDefault(m => m.Id == model.RentDefineMarketScheduleDetailId).Date;

                if (model.RentDefinePaid)
                    model.RentDefinePaid = true;
                else
                    model.RentDefinePaid = false;

                success = repository.SaveRent(new GeneralDAL.Database.Rent()
                {
                    Id = model.RentDefineId,
                    Date = model.RentDefineDate,
                    CustomerId = model.RentDefineCustomerId,
                    MarketScheduleDetailId = model.RentDefineMarketScheduleDetailId,
                    ShopId = model.RentDefineShopId,
                    Amount = model.RentDefineAmount,
                    Paid = model.RentDefinePaid,
                    Description = model.RentDefineDescription,
                    DiscountId=model.RentDefineDiscountId,
                    DiscountAmount= model.RentDefineDiscountAmount,
                    DiscountPercent= model.RentDefineDiscounPercent,
                    TariffId= model.RentDefineTariffId,
                    TariffAmount= model.RentDefineTariffAmount
                });

                if (success)
                {
                    RentId = repository.Rents.FirstOrDefault(r => r.ShopId == model.RentDefineShopId && r.MarketScheduleDetailId == model.RentDefineMarketScheduleDetailId && r.CustomerId == model.RentDefineCustomerId).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = RentId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<ReserveModel> GetReserves(IMarketRepository repository, ISecurityRepository secRepository, int TenantId)
        {
            List<ReserveModel> model = new List<ReserveModel>();



            var tenants = GetTenantChildren(secRepository, TenantId, true);

            var reserves = repository.Reserves;

            foreach (var reserve in reserves)
            {
                if (tenants.Any(t => t.Id == reserve.Shop.TenantId))
                {
                    List<PaymentModel> paymentModel = new List<PaymentModel>();

                    foreach (var payment in reserve.Payments)
                    {
                        paymentModel.Add(new PaymentModel()
                        {
                            Id = payment.Id,
                            Date = payment.Date,
                            RentId = payment.RentId,
                            ReserveId = payment.ReserveId,
                            Amount = payment.Amount,
                            Description = payment.Description
                        });
                    }

                    string DiscountName = "";
                    if (reserve.Discount != null)
                    {
                        DiscountName = reserve.Discount.Name;
                    }


                    model.Add(new ReserveModel()
                    {
                        ReserveId = reserve.Id,
                        ReserveDate = reserve.Date,
                        ReserveMarketScheduleDetailId = reserve.MarketScheduleDetail.Id,
                        ReserveMarketScheduleDescription = reserve.MarketScheduleDetail.MarketSchedule.Description,
                        ReserveCustomerId = reserve.CustomerId,
                        ReserveCustomerName = reserve.Customer.FullName,
                        ReserveShopId = reserve.ShopId,
                        ReserveShopIdentifier = reserve.Shop.ShopIdentifier,
                        ReserveShopAddress = reserve.Shop.MarketStructure.StructureAddress,
                        ReserveTariffId = reserve.TariffId,
                        ReserveTariffName = reserve.Tariff.Name,
                        ReserveTariffAmount = reserve.TariffAmount,
                        ReserveDiscountId = reserve.DiscountId,
                        ReserveDiscountName = DiscountName,
                        ReserveDiscountAmount = reserve.DiscountAmount,
                        ReserveAmount = reserve.Amount,
                        ReservePaid = reserve.Paid,
                        ReserveDescription = reserve.Description,
                        PaymentModels = paymentModel
                    });
                }
            }

            return model;
        }

        public ReserveDefineModel GetReserveDefine(IMarketRepository repository, int Id, int CustomerId)
        {
            ReserveDefineModel model = new ReserveDefineModel()
            {
                ReserveDefineShopIdentifier = " ",
                ReserveDefineTariffName = " "
            };

            int Balance = 0;
            if (CustomerId > 0 && Id == 0)
            {
                Balance = CalculateBalance(repository, CustomerId);
                List<PaymentModel> paymentModel = new List<PaymentModel>();

                var customer = repository.Customers.FirstOrDefault(c => c.Id == CustomerId);
                if (customer != null)
                {
                    model = new ReserveDefineModel()
                    {
                        ReserveDefineCustomerId = CustomerId,
                        ReserveDefineCustomerName = customer.FullName,
                        ReserveDefineCustomerBalance = Balance,
                        PaymentModels = paymentModel,
                        ReserveDefineShopIdentifier = " ",
                        ReserveDefineTariffName = " "
                    };
                }
            }
            else
            {

                var reserve = repository.Reserves.FirstOrDefault(r => r.Id == Id);

                if (reserve != null)
                {
                    List<PaymentModel> paymentModel = new List<PaymentModel>();

                    foreach (var payment in reserve.Payments)
                    {
                        paymentModel.Add(new PaymentModel()
                        {
                            Id = payment.Id,
                            Date = payment.Date,
                            RentId = payment.RentId,
                            ReserveId = payment.ReserveId,
                            Amount = payment.Amount,
                            Description = payment.Description
                        });
                    }

                    if (reserve.CustomerId > 0)
                    {
                        Balance = CalculateBalance(repository, (int)reserve.CustomerId);
                    }

                    var discount = reserve.Discount;
                    string DiscountName = "";

                    if (discount != null)
                    {
                        DiscountName = discount.Name;
                    }

                    model = new ReserveDefineModel()
                    {
                        ReserveDefineId = reserve.Id,
                        ReserveDefineDate = reserve.Date,
                        ReserveDefineMarketScheduleDetailId = reserve.MarketScheduleDetail.Id,
                        ReserveDefineMarketScheduleDescription = reserve.MarketScheduleDetail.MarketSchedule.Description,
                        ReserveDefineCustomerId = reserve.CustomerId,
                        ReserveDefineCustomerName = reserve.Customer.FullName,
                        ReserveDefineCustomerBalance = Balance,
                        ReserveDefineShopId = reserve.ShopId,
                        ReserveDefineShopIdentifier = reserve.Shop.ShopIdentifier,
                        ReserveDefineShopAddress = reserve.Shop.MarketStructure.StructureAddress,
                        ReserveDefineTariffId = reserve.TariffId,
                        ReserveDefineTariffName = reserve.Tariff.Name,
                        ReserveDefineTariffAmount = reserve.TariffAmount,
                        ReserveDefineDiscountId = reserve.DiscountId,
                        ReserveDefineDiscountName = DiscountName,
                        ReserveDefineDiscountAmount = reserve.DiscountAmount,
                        ReserveDefineDiscounPercent = reserve.DiscountPercent,
                        ReserveDefineAmount = reserve.Amount,
                        ReserveDefinePaid = reserve.Paid,
                        ReserveDefineDescription = reserve.Description,
                        PaymentModels = paymentModel
                    };

                }
            }
            return model;
        }

        public NotificationModel DeleteReserve(IMarketRepository repository, int ReserveId)
        {
            bool success = true;
            int Id = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            var reserves = repository.Reserves.Where(d => d.Id == ReserveId);

            //if (marketStructure.MarketStructures.Count() > 0)
            //{
            //    success = false;
            //    ResultType = "error";
            //    ResultMessage = "به دلیل وجود ساختار زیرمجموعه در ساختار انتخاب شده امکان حذف ساختار وجود ندارد";
            //}

            if (success)
            {

                success = repository.DeleteReserve(reserves);
            }


            if (!success)
            {
                ResultType = "error";
                ResultMessage = "خطا در انجام عملیات";
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = Id,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };


            return notificationModel;
        }

        public NotificationModel SaveReserve(IMarketRepository repository, ReserveDefineModel model)
        {
            bool success = true;
            int ReserveId = 0;
            string ResultType = "success";
            string ResultMessage = "عملیات با موفقیت انجام گردید";

            if (repository.Reserves.Any(d => d.Id != model.ReserveDefineId && d.ShopId == model.ReserveDefineShopId && d.MarketScheduleDetailId == model.ReserveDefineMarketScheduleDetailId && d.CustomerId != model.ReserveDefineCustomerId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ توسط مشتری دیگری رزرو گردیده است";

            }
            else if (repository.Reserves.Any(d => d.Id != model.ReserveDefineId && d.ShopId == model.ReserveDefineShopId && d.MarketScheduleDetailId == model.ReserveDefineMarketScheduleDetailId && d.CustomerId == model.ReserveDefineCustomerId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ توسط همین مشتری رزرو گردیده است";

            }
            else if (repository.Rents.Any(d => d.ShopId == model.ReserveDefineShopId && d.MarketScheduleDetailId == model.ReserveDefineMarketScheduleDetailId))
            {
                success = false;
                ResultType = "error";
                ResultMessage = "غرفه انتخاب شده در این تاریخ اجاره گردیده است";
            }

            if (success)
            {

                model.ReserveDefineDate = repository.MarketScheduleDetails.FirstOrDefault(m => m.Id == model.ReserveDefineMarketScheduleDetailId).Date;

                success = repository.SaveReserve(new GeneralDAL.Database.Reserve()
                {
                    Id = model.ReserveDefineId,
                    Date = model.ReserveDefineDate,
                    CustomerId = model.ReserveDefineCustomerId,
                    MarketScheduleDetailId = model.ReserveDefineMarketScheduleDetailId,
                    ShopId = model.ReserveDefineShopId,
                    Amount = model.ReserveDefineAmount,
                    Paid = false,
                    Description = model.ReserveDefineDescription,
                    DiscountId = model.ReserveDefineDiscountId,
                    DiscountAmount = model.ReserveDefineDiscountAmount,
                    DiscountPercent = model.ReserveDefineDiscounPercent,
                    TariffId = model.ReserveDefineTariffId,
                    TariffAmount = model.ReserveDefineTariffAmount
                });

                if (success)
                {
                    ReserveId = repository.Reserves.FirstOrDefault(r => r.ShopId == model.ReserveDefineShopId && r.MarketScheduleDetailId == model.ReserveDefineMarketScheduleDetailId && r.CustomerId == model.ReserveDefineCustomerId).Id;
                }

                if (!success)
                {
                    ResultType = "error";
                    ResultMessage = "خطا در انجام عملیات";
                }
            }

            NotificationModel notificationModel = new NotificationModel()
            {
                Id = ReserveId,
                ResultType = ResultType,
                ResultMessage = ResultMessage
            };

            return notificationModel;
        }

        public IEnumerable<RentReceiptModel> GetRentReceipts(IMarketRepository repository, int CustomerId,string Date)
        {
            List<RentReceiptModel> model = new List<RentReceiptModel>();

            var Rents = repository.Rents.Where(r => r.CustomerId == CustomerId && r.Date == Date);

            if (Rents != null && Rents.Count()>0)
            {
                foreach (var rent in Rents)
                {
                    var receipt = new RentReceiptModel()
                    {
                        RentId = rent.Id,
                        Date = rent.Date,
                        Amount = rent.Amount,
                        Paid = rent.Paid,
                        TariffName = rent.Tariff.Name,
                        TariffAmount = rent.Tariff.RentAmount
                    };


                    if (rent.Discount != null)
                    {
                        receipt.DiscountName = rent.Discount.Name;
                        receipt.DiscountAmount = rent.DiscountAmount;
                    }

                    if (rent.Shop != null)
                    {
                        receipt.ShopId = rent.Shop.Id;
                        receipt.ShopCode = rent.Shop.Code;
                        receipt.ShopIdentifier = rent.Shop.ShopIdentifier;
                        receipt.ShopStructureAddress = rent.Shop.MarketStructure.StructureAddress;
                        if (rent.Shop.ShopGroup != null)
                            receipt.ShopGroupName = rent.Shop.ShopGroup.Name;
                        if (rent.Shop.Type != null)
                            receipt.ShopType = rent.Shop.Type.Name;
                        if (rent.Shop.Tenant != null)
                        {
                            receipt.MarketId = rent.Shop.Tenant.Id;
                            receipt.MarketCode = rent.Shop.Tenant.Code;
                            receipt.MarketName = rent.Shop.Tenant.Name;
                        }

                    }

                    if (rent.Customer != null)
                    {
                        receipt.CustomerId = rent.Customer.Id;
                        receipt.CustomerCode = rent.Customer.Code;
                        receipt.CustomerName = rent.Customer.FullName;
                        receipt.NationalCode = rent.Customer.NationalCode;
                        receipt.MobileNumber = rent.Customer.MobileNumber;
                        receipt.DebtCeiling = (int)rent.Customer.DebtCeiling;
                        if (rent.Customer.Gender)
                            receipt.Gender = "آقا";
                        else
                            receipt.Gender = "خانم";
                        if (rent.Customer.Job != null)
                        {
                            receipt.jobName = rent.Customer.Job.Name;
                            if (rent.Customer.Job.JobGroup != null)
                            {
                                receipt.JobGroupName = rent.Customer.Job.JobGroup.Name;
                            }
                        }
                        if (rent.Customer.CustomerCards != null)
                        {
                            DateTime GDate = PersianHelper.PersianDateStringToDateTime(Date);

                            receipt.CardCode = rent.Customer.CustomerCards.FirstOrDefault(c => GDate >= PersianHelper.PersianDateStringToDateTime(c.StartDate) && GDate <= PersianHelper.PersianDateStringToDateTime(c.EndDate)).CardCode;
                        }

                        receipt.Balance = CalculateBalance(repository, rent.Customer.Id);

                        var attendance = repository.Attendances.FirstOrDefault(a => a.RentId == rent.Id);
                        if (attendance != null)
                            receipt.Time = attendance.Time;
                        else
                            receipt.Time = "ثبت نشده";
                        
                    }

                    model.Add(receipt);
                }
            }
            //else
            //{

            //    model.Add(new RentReceiptModel()
            //    {
            //        MarketId=0,
            //        MarketCode=0,
            //        MarketName="",
            //        ShopId=0,
            //        ShopCode=0,
            //        ShopStructureAddress="",
            //        ShopType="",
            //        ShopGroupName="",
            //        ShopIdentifier="",
            //        CustomerId=0,
            //        CustomerCode=0,
            //        CustomerName="",
            //        NationalCode="",
            //        Gender="",
            //        MobileNumber="",
            //        JobGroupName="",
            //        jobName="",
            //        DebtCeiling=0,
            //        CardCode="",
            //        Balance=0,
            //        RentId=0,
            //        Date="",
            //        Amount=0,
            //        Paid=false,
            //        TariffName="",
            //        TariffAmount=0,
            //        DiscountName="",
            //        DiscountAmount=0
            //    });
                
            //}

            return model;
        }
    }
}
