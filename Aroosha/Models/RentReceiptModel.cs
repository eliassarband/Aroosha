using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Models
{
    public class RentReceiptModel
    {
        public int MarketId { get; set; }

        public int MarketCode { get; set; }

        public string MarketName { get; set; }

        public int ShopId { get; set; }

        public int ShopCode { get; set; }

        public string ShopStructureAddress { get; set; }

        public string ShopType { get; set; }

        public string ShopGroupName { get; set; }

        public string ShopIdentifier { get; set; }

        public int CustomerId { get; set; }

        public int CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string NationalCode { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string JobGroupName { get; set; }

        public string jobName { get; set; }

        public int DebtCeiling { get; set; }

        public string CardCode { get; set; }

        public int Balance { get; set; }

        public int RentId { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Amount { get; set; }

        public bool Paid { get; set; }

        public string TariffName { get; set; }

        public  int TariffAmount { get; set; }

        public string DiscountName { get; set; }

        public int DiscountAmount { get; set; }

       
    }
}
