using Aroosha.Models;
using Aroosha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Aroosha.Services
{
    public interface IMarketService
    {
        IEnumerable<ShopGroupModel> GetShopGroups(IMarketRepository repository);

        ShopGroupDefineModel GetShopGroupDefine(IMarketRepository repository, int Id);

        NotificationModel DeleteShopGroup(IMarketRepository repository, int ShopGroupId);

        NotificationModel SaveShopGroup(IMarketRepository repository, ShopGroupDefineModel model);

        IEnumerable<MarketModel> GetMarketStructures(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        MarketStructureDefineModel GetMarketStructureDefine(IMarketRepository repository, IGeneralRepository genRepository, ISecurityRepository secRepository, int Id, int ParentId, int MarketId);

        NotificationModel DeleteMarketStructure(IMarketRepository repository, int MarketStructureId);

        NotificationModel SaveMarketStructure(IMarketRepository repository,ISecurityRepository secRepository, MarketStructureDefineModel model);

        IEnumerable<ShopModel> GetShops(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        ShopDefineModel GetShopDefine(IMarketRepository repository, ISecurityRepository secRepository,int Id, int TenantId);

        IEnumerable<BasicInformationForComboModel> GetShopTypeForCombo(IGeneralRepository genRepository);

        IEnumerable<ShopGroupForComboModel> GetShopGroupForCombo(IMarketRepository repository);

        IEnumerable<MarketStructureForComboModel> GetMarketStructureForCombo(IMarketRepository repository,ISecurityRepository secRepository,int TenantId);

        IEnumerable<ShopForComboModel> GetShopForCombo(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        NotificationModel DeleteShop(IMarketRepository repository, int ShopId);

        NotificationModel SaveShop(IMarketRepository repository, ISecurityRepository secRepository,IGeneralRepository genRepository, ShopDefineModel model);

        IEnumerable<TariffModel> GetTariffs(IMarketRepository repository);

        TariffDefineModel GetTariffDefine(IMarketRepository repository,int Id);

        NotificationModel DeleteTariff(IMarketRepository repository, int TariffId);

        NotificationModel SaveTariff(IMarketRepository repository, TariffDefineModel model);

        IEnumerable<CustomerModel> GetCustomers(IMarketRepository repository);

        CustomerDefineModel GetCustomerDefine(IMarketRepository repository,int Id);

        NotificationModel DeleteCustomer(IMarketRepository repository, int CustomerId);

        NotificationModel SaveCustomer(IMarketRepository repository,IGeneralRepository genRepository, CustomerDefineModel model);

        CustomerCardDefineModel GetCustomerCardDefine(IMarketRepository repository, int Id,int CustomerId);

        NotificationModel DeleteCustomerCard(IMarketRepository repository, int CustomerCardId);

        NotificationModel SaveCustomerCard(IMarketRepository repository, CustomerCardDefineModel model);

        IEnumerable<CreditModel> GetCredits(IMarketRepository repository,int CustomerId);

        CreditDefineModel GetCreditDefine(IMarketRepository repository, int Id, int CustomerId);

        IEnumerable<BasicInformationForComboModel> GetPaymentTypeForCombo(IGeneralRepository genRepository);

        IEnumerable<CustomerModel> GetCustomerForCombo(IMarketRepository repository);

        NotificationModel DeleteCredit(IMarketRepository repository, int CreditId);

        NotificationModel SaveCredit(IMarketRepository repository, CreditDefineModel model);

        IEnumerable<DiscountModel> GetDiscounts(IMarketRepository repository);

        DiscountDefineModel GetDiscountDefine(IMarketRepository repository, int Id);

        NotificationModel DeleteDiscount(IMarketRepository repository, int DiscountId);

        NotificationModel SaveDiscount(IMarketRepository repository, DiscountDefineModel model);

        IEnumerable<RentModel> GetRents(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        RentDefineModel GetRentDefine(IMarketRepository repository, int Id,int CustomerId);

        IEnumerable<DiscountForComboModel> GetDiscountTypeForCombo(IMarketRepository repository);

        IEnumerable<MarketScheduleModel> GetMarketScheduleForRent(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        IEnumerable<MarketScheduleModel> GetMarketScheduleForReserve(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        TariffDefineModel GetTariffDetail(IMarketRepository repository, int MarketScheduleDetailId, int ShopId);

        DiscountDefineModel GetDiscountDetail(IMarketRepository repository, int MarketScheduleDetailId, int DiscountId);

        CustomerDefineModel GetCustomerDetail(IMarketRepository repository, int CustomerId);

        ShopDefineModel GetShopDetail(IMarketRepository repository, int ShopId);

        NotificationModel DeleteRent(IMarketRepository repository, int RentId);

        NotificationModel SaveRent(IMarketRepository repository, RentDefineModel model);

        IEnumerable<ReserveModel> GetReserves(IMarketRepository repository, ISecurityRepository secRepository, int TenantId);

        ReserveDefineModel GetReserveDefine(IMarketRepository repository, int Id, int CustomerId);

        NotificationModel DeleteReserve(IMarketRepository repository, int ReserveId);

        NotificationModel SaveReserve(IMarketRepository repository, ReserveDefineModel model);

        IEnumerable<RentReceiptModel> GetRentReceipts(IMarketRepository repository, int CustomerId,string Date);
    }
}
