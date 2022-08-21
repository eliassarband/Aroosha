using Kiccc.Ing.PcPos.Serial;
using Kiccc.Ing.PcPos.Tcp;
using Newtonsoft.Json;
using PAX.PCPOS;
using PcPosDll;
using PosInterface;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace ArooshaPCPos
{
    public class SyncPurchase
    {
        private string _PosType { get; set; }

        private string _ConnectionType { get; set; }

        private string _IPAddress { get; set; }

        private int _PortNumber { get; set; }

        private string _ComPortName { get; set; }

        private int _ComBaudRate { get; set; }

        private int _ConnectionTimeout { get; set; }

        private int _ResponceTimeout { get; set; }

        private int _Amount { get; set; }

        private string _OptionalData { get; set; }

        public string _TerminalSerialNo { get; set; }

        public string _AcceptorID { get; set; }

        public string _TerminalID { get; set; }

        public SyncPurchase(
          string PosType,
          string ConnectionType,
          string IPAddress,
          int PortNumber,
          int ComBaudRate,
          string ComPortName,
          string TerminalSerialNo,
          string AcceptorID,
          string TerminalID,
          int ConnectionTimeout,
          int ResponceTimeout,
          int Amount,
          string OptionalData)
        {
            this._PosType = PosType;
            this._ConnectionType = ConnectionType;
            this._IPAddress = IPAddress;
            this._PortNumber = PortNumber;
            this._ComPortName = ComPortName;
            this._ComBaudRate = ComBaudRate;
            this._TerminalSerialNo = TerminalSerialNo;
            this._AcceptorID = AcceptorID;
            this._TerminalID = TerminalID;
            this._ConnectionTimeout = ConnectionTimeout;
            this._ResponceTimeout = ResponceTimeout;
            this._Amount = Amount;
            this._OptionalData = OptionalData;
        }

        //public SyncPurchase(
        //  string PosType,
        //  string ConnectionType,
        //  int ComBaudRate,
        //  string ComPortName,
        //  string TerminalSerialNo,
        //  string AcceptorID,
        //  string TerminalID,
        //  int ConnectionTimeout,
        //  int ResponceTimeout,
        //  int Amount,
        //  string OptionalData)
        //{
        //    this._PosType = PosType;
        //    this._ConnectionType = ConnectionType;
        //    this._ComPortName = ComPortName;
        //    this._ComBaudRate = ComBaudRate;
        //    this._TerminalSerialNo = TerminalSerialNo;
        //    this._AcceptorID = AcceptorID;
        //    this._TerminalID = TerminalID;
        //    this._ConnectionTimeout = ConnectionTimeout;
        //    this._ResponceTimeout = ResponceTimeout;
        //    this._Amount = Amount;
        //    this._OptionalData = OptionalData;
        //}

        public DataTable GetPosType()
        {
            DataTable dt = new DataTable();

            dt.Rows.Add(new Object[] { "AAP", "آپ" });
            dt.Rows.Add(new Object[] { "Shahr_PAX_S80_S90", "بانک شهر" });
            dt.Rows.Add(new Object[] { "Saderat_AMP_KICE", "بانک صادرات" });
            dt.Rows.Add(new Object[] { "SamanKish_SSP1126", "بانک سامان" });
            dt.Rows.Add(new Object[] { "BehPardakht_WinService", "بانک ملت (سرویس)" });
            dt.Rows.Add(new Object[] { "BehPardakht_AMP7000", "بانک ملت (کتابخانه)" });
            dt.Rows.Add(new Object[] { "Sadad_BlueBird_S3500", "بانک ملی" });

            return dt;
        }
        public ArooshaPosResult StartPurchase()
        {
            ArooshaPosResult ArooshaPosResult;
            switch (this._PosType)
            {
                case "Sadad_BlueBird_S3500":
                    ArooshaPosResult = this.Sadad_BlueBird_S3500();
                    break;
                case "BehPardakht_AMP7000":
                    ArooshaPosResult = this.BehPardakht_AMP7000();
                    break;
                case "BehPardakht_WinService":
                    ArooshaPosResult = this.BehPardakht_WinService();
                    break;
                case "SamanKish_SSP1126":
                    ArooshaPosResult = this.SamanKish_SSP1126();
                    break;
                case "Saderat_AMP_KICE":
                    ArooshaPosResult = this.Saderat_AMP_KICE();
                    break;
                case "AAP":
                    ArooshaPosResult = this.AAP();
                    break;
                case "Shahr_PAX_S80_S90":
                    ArooshaPosResult = this.Shahr_PAX_S80_S90();
                    break;
                default:
                    ArooshaPosResult = this.OtherDevice();
                    break;
            }
            return ArooshaPosResult;
        }

        protected ArooshaPosResult OtherDevice() => new ArooshaPosResult()
        {
            StatusCode = -1,
            StatusMessage = "دستگاه تعریف نشده"
        };

        protected ArooshaPosResult Sadad_BlueBird_S3500()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            PcPosBusiness pcPosBusiness = new PcPosBusiness();
            if (this._ConnectionType.ToUpper() == "LAN")
            {
                pcPosBusiness.ConnectionType = (PcPosConnectionType)1;
                pcPosBusiness.Ip = this._IPAddress;
                pcPosBusiness.Port = this._PortNumber;
            }
            else if (this._ConnectionType.ToUpper() == "SERIAL")
            {
                pcPosBusiness.ConnectionType = (PcPosConnectionType)0;
                pcPosBusiness.ComPortName = this._ComPortName;
            }
            pcPosBusiness.SerialNo = this._TerminalSerialNo;
            int connectionTimeout = this._ConnectionTimeout;
            int responceTimeout = this._ResponceTimeout;
            pcPosBusiness.RetryTimeOut = new int[3]
            {
        connectionTimeout,
        connectionTimeout,
        connectionTimeout
            };
            pcPosBusiness.ResponseTimeout = new int[3]
            {
        responceTimeout,
        connectionTimeout,
        connectionTimeout
            };
            pcPosBusiness.Amount = this._Amount.ToString();
            PcPosDll.PosResult posResult1 = new PcPosDll.PosResult();
            PcPosDll.PosResult posResult2 = pcPosBusiness.SyncSaleTransaction();
            if (posResult2 != null)
            {
                ArooshaPosResult.StatusCode = posResult2.PcPosStatusCode;
                ArooshaPosResult.StatusMessage = posResult2.PcPosStatus;
                ArooshaPosResult.ResponceCode = Convert.ToInt32(posResult2.ResponseCode);
                ArooshaPosResult.ResponceMessage = posResult2.ResponseCodeMessage;
                ArooshaPosResult.Amount = posResult2.Amount;
                ArooshaPosResult.ApprovalCode = posResult2.ApprovalCode;
                ArooshaPosResult.CardNo = posResult2.CardNo;
                ArooshaPosResult.Merchant = posResult2.Merchant;
                ArooshaPosResult.OptionalField = posResult2.OptionalField;
                ArooshaPosResult.Rrn = posResult2.Rrn;
                ArooshaPosResult.Terminal = posResult2.TerminalId;
                ArooshaPosResult.TransactionNo = posResult2.TransactionNo;
                ArooshaPosResult.TransactionDate = posResult2.TransactionDate;
                ArooshaPosResult.TransactionTime = posResult2.TransactionTime;
                ArooshaPosResult.OrderID = posResult2.OrderId;
            }
            else
            {
                ArooshaPosResult.StatusCode = -1;
                ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                ArooshaPosResult.ResponceCode = -1;
                ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
            }
            return ArooshaPosResult;
        }

        protected ArooshaPosResult BehPardakht_AMP7000()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            BehPardakht behPardakht = new BehPardakht();
            if (this._ConnectionType.ToUpper() == "LAN")
            {
                behPardakht.IP = this._IPAddress;
                behPardakht.Port = this._PortNumber.ToString();
            }
            string pos = behPardakht.SendPriceToPos(this._Amount.ToString(), "", "", "", this._ResponceTimeout.ToString());
            if (pos == "-1" || pos == "-2" || pos == "-3")
            {
                switch (pos)
                {
                    case "-1":
                        ArooshaPosResult.StatusCode = -1;
                        ArooshaPosResult.StatusMessage = "مبلغ خرید نامعتبر";
                        break;
                    case "-2":
                        ArooshaPosResult.StatusCode = -2;
                        ArooshaPosResult.StatusMessage = "لطفا پورت سرویس خود را بررسی نمایید";
                        break;
                    case "-3":
                        ArooshaPosResult.StatusCode = -3;
                        ArooshaPosResult.StatusMessage = "ارتباط برقرار نشد ؛ از اتصال دستگاه و یا تنظیمات آن اطمینان حاصل نمایید";
                        break;
                }
            }
            else
            {
                Dictionary<string, string> dictionary = (Dictionary<string, string>)JsonConvert.DeserializeObject<Dictionary<string, string>>(pos);
                if (dictionary != null)
                {
                    if (dictionary["ReturnCode"].ToString() == "100")
                    {
                        ArooshaPosResult.StatusCode = 0;
                        ArooshaPosResult.StatusMessage = "ارتباط موفق";
                        ArooshaPosResult.ResponceCode = 0;
                        ArooshaPosResult.StatusMessage = "تراکنش موفق";
                    }
                    else
                    {
                        if (dictionary["ReturnCode"].ToString() != "")
                        {
                            ArooshaPosResult.StatusCode = Convert.ToInt32(dictionary["ReturnCode"].ToString());
                            ArooshaPosResult.StatusMessage = behPardakht.GetReturnCodeError(Convert.ToInt32(dictionary["ReturnCode"].ToString()));
                        }
                        if (dictionary["ReasonCode"].ToString() != "")
                        {
                            ArooshaPosResult.ResponceCode = Convert.ToInt32(dictionary["ReasonCode"].ToString());
                            ArooshaPosResult.StatusMessage = behPardakht.GetReasonCodeError(Convert.ToInt32(dictionary["ReasonCode"].ToString()));
                        }
                        ArooshaPosResult.OrderID = dictionary["ReqID"].ToString();
                        ArooshaPosResult.SerialTransaction = dictionary["SerialTransaction"].ToString();
                        ArooshaPosResult.TransactionNo = dictionary["TraceNumber"].ToString();
                        ArooshaPosResult.TransactionDate = dictionary["TransactionDate"].ToString();
                        ArooshaPosResult.TransactionTime = dictionary["TransactionTime"].ToString();
                        ArooshaPosResult.CardNo = dictionary["PAN"].ToString();
                        ArooshaPosResult.AccountNo = dictionary["AccountNo"].ToString();
                        ArooshaPosResult.PCID = dictionary["PcID"].ToString();
                        ArooshaPosResult.Amount = dictionary["TotalAmount"].ToString();
                        ArooshaPosResult.DiscountAmount = dictionary["DiscountAmount"].ToString();
                    }
                }
                else
                {
                    ArooshaPosResult.StatusCode = -1;
                    ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                    ArooshaPosResult.ResponceCode = -1;
                    ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
                }
            }
            return ArooshaPosResult;
        }

        protected ArooshaPosResult BehPardakht_WinService()
        {
            
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();

            if (this._Amount.ToString().Length < 4)
            {
                ArooshaPosResult.StatusCode = -1;
                ArooshaPosResult.StatusMessage = "مبلغ خرید نامعتبر";
            }
            else 
            {
                POS_PC_v3.Transaction.Connection _ConnectionInfo = new POS_PC_v3.Transaction.Connection();

                if (this._ConnectionType.ToUpper() == "LAN")
                {
                    _ConnectionInfo.CommunicationType = "TCP/IP";
                    _ConnectionInfo.POS_PORTtcp = Convert.ToInt16(this._PortNumber);
                    _ConnectionInfo.POS_IP = this._IPAddress;
                    _ConnectionInfo.PC_PORT_ReadTimeout = Convert.ToInt32(this._ConnectionTimeout);
                    _ConnectionInfo.POSPC_TCPCOMMU_SocketRecTimeout = Convert.ToInt32(this._ResponceTimeout);

                }

                POS_PC_v3.Transaction TXN = new POS_PC_v3.Transaction(_ConnectionInfo);
                POS_PC_v3.Result retCode = new POS_PC_v3.Result();

                retCode = TXN.Debits_Goods_And_Service("1", this._Amount.ToString(), "", "", "");


                if (retCode.ReturnCode.ToString() == "100")
                {
                    ArooshaPosResult.StatusCode = 0;
                    ArooshaPosResult.StatusMessage = "ارتباط موفق";
                    ArooshaPosResult.ResponceCode = 0;
                    ArooshaPosResult.StatusMessage = "تراکنش موفق";
                }
                else
                {
                    BehPardakht bp = new BehPardakht();

                    if (retCode.ReturnCode.ToString() != "")
                    {
                        ArooshaPosResult.StatusCode = Convert.ToInt32(retCode.ReturnCode.ToString());
                        ArooshaPosResult.StatusMessage = bp.GetReturnCodeError(Convert.ToInt32(retCode.ReturnCode.ToString()));
                    }
                    if (retCode.ReasonCode.ToString() != "")
                    {
                        ArooshaPosResult.ResponceCode = Convert.ToInt32(retCode.ReasonCode.ToString());
                        ArooshaPosResult.StatusMessage = bp.GetReasonCodeError(Convert.ToInt32(retCode.ReasonCode.ToString()));
                    }
                    ArooshaPosResult.OrderID = retCode.ReqID.ToString();
                    ArooshaPosResult.SerialTransaction = retCode.SerialTransaction.ToString();
                    ArooshaPosResult.TransactionNo = retCode.TraceNumber.ToString();
                    ArooshaPosResult.TransactionDate = retCode.TransactionDate.ToString();
                    ArooshaPosResult.TransactionTime = retCode.TransactionTime.ToString();
                    ArooshaPosResult.CardNo = retCode.PAN.ToString();
                    ArooshaPosResult.AccountNo = retCode.AccountNo.ToString();
                    ArooshaPosResult.PCID = retCode.PcID.ToString();
                    ArooshaPosResult.Amount = retCode.TotalAmount.ToString();
                    ArooshaPosResult.DiscountAmount = "0";
                }
            }
            
            return ArooshaPosResult;
        }

        protected ArooshaPosResult SamanKish_SSP1126()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            SamanKish samanKish1 = new SamanKish();
            SSP1126.PcPos.Infrastructure.PosResult posResult1 = new SSP1126.PcPos.Infrastructure.PosResult();
            SamanKish samanKish2 = samanKish1;
            string ipAddress = this._IPAddress;
            int num = this._PortNumber;
            string Port = num.ToString();
            num = this._Amount;
            string Amount = num.ToString();
            int responceTimeout = this._ResponceTimeout;
            SSP1126.PcPos.Infrastructure.PosResult posResult2 = samanKish2.SendAmountPcStater(ipAddress, Port, Amount, responceTimeout);
            if (posResult2 != null)
            {
                ArooshaPosResult.StatusCode = 0;
                ArooshaPosResult.StatusMessage = "ارتباط موفق";
                ArooshaPosResult.ResponceCode = Convert.ToInt32(posResult2.ResponseCode);
                ArooshaPosResult.StatusMessage = posResult2.ResponseDescription;
            }
            else
            {
                ArooshaPosResult.StatusCode = -1;
                ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                ArooshaPosResult.ResponceCode = -1;
                ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
            }
            return ArooshaPosResult;
        }

        protected ArooshaPosResult Saderat_AMP_KICE()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            SerialIngenico serialIngenico = new SerialIngenico();
            TcpIngenico tcpIngenico = new TcpIngenico();
            string str = "<sog>\r\n                      <field1>123</field1>\r\n                      <field2>a</field2>\r\n                      <field3>b</field3>\r\n                    </sog>";
            ArooshaPosResult.ResponceMessage = str;
            return ArooshaPosResult;
        }

        protected ArooshaPosResult AAP()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            PCPos pcPos = new PCPos();
            if (this._ConnectionType == "LAN")
                pcPos.InitLAN(this._IPAddress, this._PortNumber);
            else if (this._ConnectionType == "SERIAL")
                pcPos.InitSerial(this._ComPortName, this._ComBaudRate);
            pcPos.TimeOutPerTransaction = this._ResponceTimeout;
            PaymentResult paymentResult = pcPos.DoSyncPayment(this._Amount.ToString(), "", "", DateTime.Now);
            if (paymentResult != null)
            {
                ArooshaPosResult.StatusCode = 0;
                ArooshaPosResult.StatusMessage = "ارتباط موفق";
                ArooshaPosResult.ResponceCode = ((TransactionResult)paymentResult).ErrorCode;
                ArooshaPosResult.StatusMessage = ((TransactionResult)paymentResult).ErrorMsg;
                ArooshaPosResult.Merchant = ((TransactionResult)paymentResult).MerchantId;
                ArooshaPosResult.Terminal = ((TransactionResult)paymentResult).TerminalId;
                ArooshaPosResult.Rrn = ((TransactionResult)paymentResult).RRN;
                ArooshaPosResult.TransactionNo = ((TransactionResult)paymentResult).Stan;
                ArooshaPosResult.CardNo = ((TransactionResult)paymentResult).CardNumber;
                ArooshaPosResult.TransactionDate = ((TransactionResult)paymentResult).DateTime;
                ArooshaPosResult.Amount = ((TransactionResult)paymentResult).PaymentAmount;
            }
            else
            {
                ArooshaPosResult.StatusCode = -1;
                ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                ArooshaPosResult.ResponceCode = -1;
                ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
            }
            return ArooshaPosResult;
        }

        protected ArooshaPosResult Shahr_PAX_S80_S90()
        {
            ArooshaPosResult ArooshaPosResult = new ArooshaPosResult();
            bool flag = false;
            if (this._ConnectionType == "LAN")
                flag = PosCommander.Instance.Init(IPAddress.Parse(this._IPAddress), this._ResponceTimeout);
            else if (this._ConnectionType == "SERIAL")
                flag = PosCommander.Instance.Init(this._ComPortName, this._ComBaudRate.ToString(), this._ResponceTimeout);
            if (flag)
            {
                Response response = PosCommander.Instance.Purchase(this._OptionalData, this._Amount.ToString(), true, "", "", "");
                if (response != null)
                {
                    ArooshaPosResult.StatusCode = (int)response.ErrorCode;
                    ArooshaPosResult.StatusMessage = "";
                    if (!(bool)response.Success)
                    {
                        if ((int)response.ErrorCode == 3)
                        {
                            ArooshaPosResult.ResponceCode = -3;
                            // ISSUE: explicit non-virtual call
                            ArooshaPosResult.ResponceMessage = "انصراف از طرف کاربر . کد خطا : " + (response.ErrorCode.ToString());
                        }
                        else
                        {
                            ArooshaPosResult.ResponceCode = -2;
                            // ISSUE: explicit non-virtual call
                            ArooshaPosResult.ResponceMessage = "خطا در عملیات . کد خطا : " + (response.ErrorCode.ToString());
                        }
                    }
                    else
                    {
                        int ReasonCode = 0;
                        if ((string)((Transaction)response.TransactionInfo).ResponseCode != "")
                            ReasonCode = Convert.ToInt32((string)((Transaction)response.TransactionInfo).ResponseCode);
                        Shahr shahr = new Shahr();
                        ArooshaPosResult.ResponceCode = ReasonCode;
                        ArooshaPosResult.ResponceMessage = shahr.GetResponceCodeMessage(ReasonCode);
                        ArooshaPosResult.CardNo = (string)((Transaction)response.TransactionInfo).PAN;
                        ArooshaPosResult.TransactionNo = (string)((Transaction)response.TransactionInfo).Stan;
                        ArooshaPosResult.Amount = (string)((Transaction)response.TransactionInfo).Amount;
                        ArooshaPosResult.TransactionDate = (string)((Transaction)response.TransactionInfo).DateTime;
                        ArooshaPosResult.Terminal = (string)((PosInfo)response.PosInformation).TerminalId;
                        ArooshaPosResult.Merchant = (string)((PosInfo)response.PosInformation).MerchantId;
                    }
                }
                else
                {
                    ArooshaPosResult.StatusCode = -1;
                    ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                    ArooshaPosResult.ResponceCode = -1;
                    ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
                }
            }
            else
            {
                ArooshaPosResult.StatusCode = -1;
                ArooshaPosResult.StatusMessage = "خطا در ارتباط را دستگاه کارتخوان";
                ArooshaPosResult.ResponceCode = -1;
                ArooshaPosResult.ResponceMessage = "خطا در ارتباط را دستگاه کارتخوان";
            }
            return ArooshaPosResult;
        }
    }
}
