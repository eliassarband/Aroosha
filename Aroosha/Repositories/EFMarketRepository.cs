using GeneralDAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public class EFMarketRepository:IMarketRepository
    {
        private readonly ArooshaContext context;

        public EFMarketRepository(ArooshaContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<ShopGroup> ShopGroups
        {
            get { return context.ShopGroups.Include(g =>g.Shops); }
        }

        public IEnumerable<Shop> Shops
        {
            get { return context.Shops.Include(s => s.MarketStructure).Include(s => s.ShopGroup).Include(s => s.Type).Include(s => s.Tenant).Include(s => s.Rents); }
        }

        public IEnumerable<MarketStructure> MarketStructures
        {
            get { return context.MarketStructures.Include(m => m.MarketStructures).Include(m => m.Tenant).Include(m => m.Type).Include(m => m.Shops); }
        }

        public IEnumerable<MarketStructure> MarketStructuresWithType
        {
            get { return context.MarketStructures.Include(m => m.Type); }
        }

        public bool SaveShopGroups(ShopGroup shopGroup)
        {
            try
            {

                
                if (shopGroup.Id > 0)
                {
                    var g = context.ShopGroups.FirstOrDefault(x => x.Id == shopGroup.Id);

                    g.Code = shopGroup.Code;
                    g.Name = shopGroup.Name;
                    g.Description = shopGroup.Description;

                }
                else
                    context.ShopGroups.Add(shopGroup);
                


                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteShopGroup(IEnumerable<ShopGroup> shopGroups)
        {
            try
            {
                foreach (var group in shopGroups)
                {
                    var gu = context.ShopGroups.FirstOrDefault(g => g.Id == group.Id);

                    if (gu != null)
                        context.ShopGroups.Remove(gu);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveMarketStructure(MarketStructure marketStructure)
        {
            try
            {
                if (marketStructure.ParentId == 0)
                    marketStructure.ParentId = null;

                if (marketStructure.Id > 0)
                {
                    var ms = context.MarketStructures.FirstOrDefault(x => x.Id == marketStructure.Id);

                    ms.Code = marketStructure.Code;
                    ms.Name = marketStructure.Name;
                    ms.TypeId = marketStructure.TypeId;
                    ms.ParentId = marketStructure.ParentId;
                    ms.TenantId = marketStructure.TenantId;
                    ms.Description = marketStructure.Description;
                    ms.StructureAddress = marketStructure.StructureAddress;
                }
                else
                    context.MarketStructures.Add(marketStructure);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMarketStructure(IEnumerable<MarketStructure> marketStructures)
        {
            try
            {
                foreach (var structure in marketStructures)
                {
                    var ms = context.MarketStructures.FirstOrDefault(g => g.Id == structure.Id);

                    if (ms != null)
                        context.MarketStructures.Remove(ms);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveShop(Shop shop)
        {
            try
            {

                if (shop.Id > 0)
                {
                    var s = context.Shops.FirstOrDefault(x => x.Id == shop.Id);

                    s.Code = shop.Code;
                    s.Name = shop.Name;
                    s.TypeId = shop.TypeId;
                    s.ShopGroupId = shop.ShopGroupId;
                    s.TenantId = shop.TenantId;
                    s.MarketStructureId = shop.MarketStructureId;
                    s.Length = shop.Length;
                    s.Width = shop.Width;
                    s.ShopIdentifier = shop.ShopIdentifier;
                }
                else
                    context.Shops.Add(shop);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteShop(IEnumerable<Shop> shops)
        {
            try
            {
                foreach (var shop in shops)
                {
                    var s = context.Shops.FirstOrDefault(g => g.Id == shop.Id);

                    if (s != null)
                        context.Shops.Remove(s);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Tariff> Tariffs {
            get { return context.Tariffs; }
        }

        public bool SaveTariff(Tariff tariff)
        {
            try
            {

                if (tariff.Id > 0)
                {
                    var s = context.Tariffs.FirstOrDefault(x => x.Id == tariff.Id);

                    s.Name = tariff.Name;
                    s.Priority = tariff.Priority;
                    s.Formula = tariff.Formula;
                    s.StartDate = tariff.StartDate;
                    s.EndDate = tariff.EndDate;
                    s.RentAmount = tariff.RentAmount;
                    s.ReserveAmount = tariff.ReserveAmount;
                    s.Description = tariff.Description;
                }
                else
                    context.Tariffs.Add(tariff);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteTariff(IEnumerable<Tariff> tariffs)
        {
            try
            {
                foreach (var tariff in tariffs)
                {
                    var s = context.Tariffs.FirstOrDefault(g => g.Id == tariff.Id);

                    if (s != null)
                        context.Tariffs.Remove(s);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers.Include(c => c.CustomerCards).Include(c => c.JobGroup).Include(c => c.Job).Include(c => c.Credits).Include(c => c.BirthCity).Include(c => c.IssuanceCity).Include(c => c.Rents).ThenInclude(r => r.Payments); }
        }

        public IEnumerable<CustomerCard> CustomerCards
        {
            get { return context.CustomerCards.Include(c => c.Customer); }
        }

        public bool SaveCustomer(Customer customer)
        {
            try
            {

                if (customer.Id > 0)
                {
                    var s = context.Customers.FirstOrDefault(x => x.Id == customer.Id);

                    s.Code = customer.Code;
                    s.FirstName = customer.FirstName;
                    s.LastName = customer.LastName;
                    s.NationalCode = customer.NationalCode;
                    s.IdentityNumber = customer.IdentityNumber;
                    s.FatherName = customer.FatherName;
                    s.MobileNumber = customer.MobileNumber;
                    s.WorkAddress = customer.WorkAddress;
                    s.WorkPhone = customer.WorkPhone;
                    s.Gender = customer.Gender;
                    s.HomeAddress = customer.HomeAddress;
                    s.HomePhone = customer.HomePhone;
                    s.BirthYear = customer.BirthYear;
                    s.BirthCityId = customer.BirthCityId;
                    s.IssuanceCityId = customer.IssuanceCityId;
                    s.JobGroupId = customer.JobGroupId;
                    s.JobId = customer.JobId;
                    s.DebtCeiling = customer.DebtCeiling;
                    s.Description = customer.Description;
                }
                else
                {
                    customer.AccountBalance = 0;
                    customer.AppAccountBalance = 0;
                    customer.TotalRentsAmount = 0;
                    customer.TotalPaymentsAmount = 0;

                    context.Customers.Add(customer);

                }



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCustomer(IEnumerable<Customer> customers)
        {
            try
            {
                foreach (var customer in customers)
                {
                    var s = context.Customers.FirstOrDefault(g => g.Id == customer.Id);

                    foreach (var card in s.CustomerCards)
                    {
                        context.CustomerCards.Remove(card);
                    }

                    if (s != null)
                        context.Customers.Remove(s);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveCustomerCard(CustomerCard customerCard)
        {
            try
            {

                if (customerCard.Id > 0)
                {
                    var s = context.CustomerCards.FirstOrDefault(x => x.Id == customerCard.Id);

                    s.CardCode = customerCard.CardCode;
                    s.CustomerId = customerCard.CustomerId;
                    s.StartDate = customerCard.StartDate;
                    s.EndDate = customerCard.EndDate;
                    s.Active = customerCard.Active;
                }
                else
                    context.CustomerCards.Add(customerCard);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCustomerCard(IEnumerable<CustomerCard> customerCards)
        {
            try
            {
                foreach (var card in customerCards)
                {
                    var s = context.CustomerCards.FirstOrDefault(g => g.Id == card.Id);

                    if (s != null)
                        context.CustomerCards.Remove(s);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Credit> Credits
        {
            get { return context.Credits.Include(c => c.Customer).Include(c => c.PaymentType); }
        }

        public bool SaveCredit(Credit credit)
        {
            try
            {

                if (credit.Id > 0)
                {
                    var s = context.Credits.FirstOrDefault(x => x.Id == credit.Id);

                    s.CustomerId = credit.CustomerId;
                    s.Date = credit.Date;
                    s.PaymentTypeId = credit.PaymentTypeId;
                    s.Amount = credit.Amount;
                    s.Type = credit.Type;
                    s.ReceiptNumber = credit.ReceiptNumber;
                    s.Description = credit.Description;
                }
                else
                    context.Credits.Add(credit);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCredit(IEnumerable<Credit> credits)
        {
            try
            {
                foreach (var credit in credits)
                {
                    var s = context.Credits.FirstOrDefault(g => g.Id == credit.Id);

                    if (s != null)
                        context.Credits.Remove(s);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Rent> Rents
        {
            get {
                return context.Rents
                  .Include(r => r.Customer)
                      .ThenInclude(c => c.CustomerCards)
                  .Include(r => r.Customer)
                      .ThenInclude(c=> c.Job)
                        .ThenInclude(j => j.JobGroup)
                  .Include(r => r.Shop)
                      .ThenInclude(s => s.MarketStructure)
                  .Include(r => r.Shop)
                      .ThenInclude(s => s.Type)
                  .Include(r => r.Shop)
                      .ThenInclude(s => s.Tenant)
                  .Include(r => r.Shop)
                      .ThenInclude(s => s.ShopGroup)
                  .Include(r => r.Payments)
                  .Include(r => r.MarketScheduleDetail)
                      .ThenInclude(ms => ms.MarketSchedule)
                  .Include(r => r.Tariff)
                  .Include(r => r.Discount);
                
                   }
        }


        public bool SaveRent(Rent rent)
        {
            try
            {

                if (rent.Id > 0)
                {
                    var r = context.Rents.FirstOrDefault(r=> r.Id == rent.Id);

                    r.Date = rent.Date;
                    r.CustomerId = rent.CustomerId;
                    r.MarketScheduleDetailId = rent.MarketScheduleDetailId;
                    r.ShopId = rent.ShopId;
                    r.Amount = rent.Amount;
                    r.Description = rent.Description;
                    r.DiscountAmount = rent.DiscountAmount;
                    r.DiscountPercent = rent.DiscountPercent;
                    r.DiscountId = rent.DiscountId;
                    r.TariffId = rent.TariffId;
                    r.TariffAmount = rent.TariffAmount;
                }
                else
                    context.Rents.Add(rent);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteRent(IEnumerable<Rent> rents)
        {
            try
            {
                foreach (var rent in rents)
                {
                    var r = context.Rents.FirstOrDefault(r => r.Id == rent.Id);

                    if (r != null)
                        context.Rents.Remove(r);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<MarketSchedule> MarketSchedules
        {
            get { return context.MarketSchedules.Include(m => m.MarketScheduleDetails).Include(m => m.Market); }
        }

        public IEnumerable<MarketScheduleDetail> MarketScheduleDetails {
            get { return context.MarketScheduleDetails.Include(m => m.Rents).Include(m => m.MarketSchedule).ThenInclude(m => m.Market); }
        }

        public IEnumerable<Discount> Discounts 
        {
            get { return context.Discounts.Include(d => d.Rents); }
        }

        public bool SaveDiscount(Discount discount)
        {
            try
            {

                if (discount.Id > 0)
                {
                    var d = context.Discounts.FirstOrDefault(x => x.Id == discount.Id);

                    d.Code = discount.Code;
                    d.Name = discount.Name;
                    d.DefaultPercent = discount.DefaultPercent;
                    d.DefaultPrice = discount.DefaultPrice;
                    d.StartDate = discount.StartDate;
                    d.EndDate = discount.EndDate;
                    d.Active = discount.Active;
                }
                else
                    context.Discounts.Add(discount);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteDiscount(IEnumerable<Discount> discounts)
        {
            try
            {
                foreach (var discount in discounts)
                {
                    var d = context.Discounts.FirstOrDefault(g => g.Id == discount.Id);

                    if (d != null)
                        context.Discounts.Remove(d);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public IEnumerable<Reserve> Reserves
        {
            get { return context.Reserves.Include(r => r.Customer).Include(r => r.Shop).ThenInclude(s => s.MarketStructure).Include(r => r.Payments).Include(r => r.MarketScheduleDetail).ThenInclude(ms => ms.MarketSchedule).Include(r => r.Tariff); }
        }


        public bool SaveReserve(Reserve reserve)
        {
            try
            {

                if (reserve.Id > 0)
                {
                    var r = context.Reserves.FirstOrDefault(r => r.Id == reserve.Id);

                    r.Date = reserve.Date;
                    r.CustomerId = reserve.CustomerId;
                    r.MarketScheduleDetailId = reserve.MarketScheduleDetailId;
                    r.ShopId = reserve.ShopId;
                    r.Amount = reserve.Amount;
                    r.Description = reserve.Description;
                    r.DiscountAmount = reserve.DiscountAmount;
                    r.DiscountPercent = reserve.DiscountPercent;
                    r.DiscountId = reserve.DiscountId;
                    r.TariffId = reserve.TariffId;
                    r.TariffAmount = reserve.TariffAmount;
                }
                else
                    context.Reserves.Add(reserve);



                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteReserve(IEnumerable<Reserve> reserves)
        {
            try
            {
                foreach (var reserve in reserves)
                {
                    var r = context.Reserves.FirstOrDefault(r => r.Id == reserve.Id);

                    if (r != null)
                        context.Reserves.Remove(r);
                }

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Attendance> Attendances {
            get { return context.Attendances; }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
