using System;
using System.Collections.Generic;
using System.Text;

namespace ArooshaPCPos
{
    public class ArooshaPosResult
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public int ResponceCode { get; set; }

        public string ResponceMessage { get; set; }

        public string Amount { get; set; }

        public string DiscountAmount { get; set; }

        public string ApprovalCode { get; set; }

        public string CardNo { get; set; }

        public string Merchant { get; set; }

        public string OptionalField { get; set; }

        public string Rrn { get; set; }

        public string Terminal { get; set; }

        public string SerialTransaction { get; set; }

        public string TransactionNo { get; set; }

        public string TransactionDate { get; set; }

        public string TransactionTime { get; set; }

        public string OrderID { get; set; }

        public string AccountNo { get; set; }

        public string PCID { get; set; }
    }
}
