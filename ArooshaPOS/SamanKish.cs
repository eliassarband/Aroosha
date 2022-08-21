using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System.Collections.Generic;
using System.Data;

namespace ArooshaPOS
{
    public class SamanKish
    {
        private ResponseLanguage _responseLanguage = (ResponseLanguage)0;
        private AsyncType _asyncType = (AsyncType)0;
        private TransactionType _tracsactionType = (TransactionType)2;
        private MediaType _mediaType = (MediaType)2;
        private AccountType _accountType = (AccountType)0;
        private PcPosFactory _PcPosFactory;
        private string _IP;
        private string _Port;
        private string _Amount;
        private int _Timeout;
        private DataTable dt = new DataTable();

        public SamanKish()
        {
            if (this._PcPosFactory == null)
                this._PcPosFactory = new PcPosFactory();
            this.dt.Columns.Add("ResponceCode", typeof(string));
            this.dt.Columns.Add("ResponceDescription", typeof(string));
        }

        public DataTable StartPurchase(string IP, string Port, string Amount, int Timeout)
        {
            this._IP = IP;
            this._Port = Port;
            this._Amount = Amount;
            this._Timeout = Timeout;
            if (this.PurchaseInitialization())
            {
                this.dt.Rows.Add((object)"999", (object)"خطا در پیکربندی سرویس");
                return this.dt;
            }
            PosResult posResult = this._PcPosFactory.PosStarterPurchaseInit();
            if (this._asyncType == null && posResult != null && posResult.ResponseCode != null)
            {
                this.dt.Rows.Add((object)posResult.ResponseCode, (object)posResult.ResponseDescription);
                return this.dt;
            }
            this.SendAmount();
            return this.dt;
        }

        private bool PurchaseInitialization()
        {
            this._tracsactionType = (TransactionType)2;
            if (this.TransactionMediaInitialization())
                return false;
            this._PcPosFactory.Initialization(this._responseLanguage, 0, this._asyncType);
            return false;
        }

        private bool TransactionMediaInitialization()
        {
            if (this._mediaType == MediaType.Network)
            {
                if (string.IsNullOrEmpty(this._IP))
                    return true;
                this._PcPosFactory.SetLan(this._IP);
            }
            this._PcPosFactory.Initialization(this._responseLanguage, 0, this._asyncType);
            return false;
        }

        private DataTable SendAmount()
        {
            List<string> stringList = new List<string>();
            PosResult posResult = new PosResult();
            int num = -1;
            string str1 = (string)null;
            string str2 = "";
            if (this._accountType == 0)
                posResult = this._PcPosFactory.PosStarterPurchase(this._Amount, string.Empty, "", "", num, str1, str2);
            if (this._asyncType == null && posResult != null)
                this.PurchaseResultReceived(posResult);
            return this.dt;
        }

        private void PurchaseResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            if (posResult.ResponseCode == "00")
                this.dt.Rows.Add((object)posResult.ResponseCode, (object)posResult.ResponseDescription);
            else
                this.dt.Rows.Add((object)posResult.ResponseCode, (object)posResult.ResponseDescription);
        }

        public PosResult SendAmountPcStater(
          string IP,
          string Port,
          string Amount,
          int Timeout)
        {
            this._IP = IP;
            this._Port = Port;
            this._Amount = Amount;
            this._Timeout = Timeout;
            if (this.PurchaseInitialization())
                return new PosResult()
                {
                    ResponseCode = "-1",
                    ResponseDescription = "خطا در پیکربندی سرویس"
                };
            List<string> stringList = new List<string>();
            PosResult posResult = new PosResult();
            string str1 = (string)null;
            string str2 = "";
            if (this._accountType == 0)
                posResult = this._PcPosFactory.PcStarterPurchase(this._Amount, string.Empty, string.Empty, string.Empty, str1, str2);
            if (this._asyncType == null && posResult != null)
                this.PurchaseResultReceived(posResult);
            return posResult;
        }
    }
}
