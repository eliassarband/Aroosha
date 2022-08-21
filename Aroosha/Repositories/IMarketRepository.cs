using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public interface IMarketRepository
    {
        IEnumerable<ShopGroup> ShopGroups { get; }

        IEnumerable<Shop> Shops { get; }

        IEnumerable<MarketStructure> MarketStructures { get; }

        IEnumerable<MarketStructure> MarketStructuresWithType { get; }

        bool SaveShopGroups(ShopGroup shopGroup);

        bool DeleteShopGroup(IEnumerable<ShopGroup> shopGroups);

        bool SaveMarketStructure(MarketStructure marketStructure);

        bool DeleteMarketStructure(IEnumerable<MarketStructure> marketStructures);

        bool SaveShop(Shop shop);

        bool DeleteShop(IEnumerable<Shop> shops);

        IEnumerable<Tariff> Tariffs { get; }

        bool SaveTariff(Tariff tariff);

        bool DeleteTariff(IEnumerable<Tariff> tariffs);

        IEnumerable<Customer> Customers { get; }

        IEnumerable<CustomerCard> CustomerCards { get; }

        bool SaveCustomer(Customer customer);

        bool DeleteCustomer(IEnumerable<Customer> customers);

        bool SaveCustomerCard(CustomerCard customerCard);

        bool DeleteCustomerCard(IEnumerable<CustomerCard> customerCards);

        IEnumerable<Credit> Credits{ get; }

        bool SaveCredit(Credit credit);

        bool DeleteCredit(IEnumerable<Credit> credits);

        IEnumerable<Rent> Rents { get; }

        bool SaveRent(Rent rent);

        bool DeleteRent(IEnumerable<Rent> rents);

        IEnumerable<MarketSchedule> MarketSchedules { get; }

        IEnumerable<MarketScheduleDetail> MarketScheduleDetails { get; }

        IEnumerable<Discount> Discounts { get; }

        bool SaveDiscount(Discount discount);

        bool DeleteDiscount(IEnumerable<Discount> discounts);

        IEnumerable<Reserve> Reserves { get; }

        bool SaveReserve(Reserve reserve);

        bool DeleteReserve(IEnumerable<Reserve> reserves);

        IEnumerable<Attendance> Attendances { get; }

    }
}
