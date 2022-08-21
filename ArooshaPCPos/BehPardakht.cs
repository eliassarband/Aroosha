using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ArooshaPCPos
{
    public class BehPardakht
    {
        private string[,] ReturnError = new string[53, 2]
    {
      {
        "101",
        "invalid message size received from pos"
      },
      {
        "102",
        "invalid message received from pc (message size, process code)"
      },
      {
        "103",
        "invalid process code received from pos in response"
      },
      {
        "104",
        "invalid input amount or invalid received amount from pos in response"
      },
      {
        "105",
        "invalid input payer id"
      },
      {
        "106",
        "invalid input timeout for waiting to receive data from pos on serial port (the value of it must be : Min = 2000 ms Max = 600000 ms )"
      },
      {
        "107",
        "timeout occurred while waiting for receive data from pos on serial port"
      },
      {
        "108",
        "transaction failed: not receive response from server because of timeout or connection failed"
      },
      {
        "109",
        "transaction failed: credit is not sufficient, server is down or …"
      },
      {
        "110",
        "transaction failed because of printer error"
      },
      {
        "111",
        "transaction failed because of connection error"
      },
      {
        "112",
        "transaction failed because of error in send settlement, send reversal or generate transaction"
      },
      {
        "113",
        "invalid input serial port name"
      },
      {
        "114",
        "transaction failed because of aborting by user"
      },
      {
        "115",
        "invalid input bill id for bill payment transaction"
      },
      {
        "116",
        "invalid input payment id for bill payment transaction"
      },
      {
        "117",
        "error occurred while opening selected serial port"
      },
      {
        "118",
        "I/O error or a specific type of security error : the serial port can’t write data"
      },
      {
        "119",
        "I/O error occurs: the selected port isn’t serial port"
      },
      {
        "120",
        "argument out of range exception: one or more of the properties for this instance are invalid(on serial port)"
      },
      {
        "121",
        "arguments provided to a method is not valid: the serial port name is invalid"
      },
      {
        "122",
        "Argument Null Exception on serial port"
      },
      {
        "123",
        "timeout occurred while send data on serial port"
      },
      {
        "124",
        "the card has not been swiped on pos"
      },
      {
        "125",
        "invalid input account id for payment transaction"
      },
      {
        "126",
        "invalid received account id from pc"
      },
      {
        "127",
        "invalid received payer id from pc"
      },
      {
        "128",
        "invalid received amount from pc"
      },
      {
        "129",
        "invalid received reference number from pc"
      },
      {
        "130",
        "invalid received bill id from pc"
      },
      {
        "131",
        "invalid received payment id from pc"
      },
      {
        "132",
        "invalid received additional data from pc"
      },
      {
        "133",
        "invalid received multi payment total amount from pc"
      },
      {
        "134",
        "unconfirmed received data from pc by user"
      },
      {
        "161",
        "Invalid input multi payment request data set list( max 10 records)"
      },
      {
        "162",
        "invalid input multi payment amount"
      },
      {
        "163",
        "invalid input reference number"
      },
      {
        "164",
        "Invalid received data on pos or pc (crc error)"
      },
      {
        "165",
        "invalid input connection type of pos-pc(the value of it must be :Serial or tcp/ip )"
      },
      {
        "166",
        "invalid input tcp/ip connection port number(the value of it must be :MIN : 1024 MAX: 65535 )"
      },
      {
        "167",
        "invalid input timeout for waiting to receive data from pos on tcp/ip connection(the value of it must be : Min = 2000 ms Max = 600000 ms )"
      },
      {
        "168",
        "error occurred while creating socket on pc in tcp/ip communication"
      },
      {
        "169",
        "error occurred while send data to pos in tcp/ip communication"
      },
      {
        "170",
        "error occurred while receiving data from pos on tcp/ip communication because of timeout or …"
      },
      {
        "171",
        "invalid format of input merchant message"
      },
      {
        "172",
        "error occurred while prepare TLV message for send"
      },
      {
        "173",
        "Serial port exception for receiving data from pos"
      },
      {
        "174",
        "Serial port exception for receiving data from pos"
      },
      {
        "175",
        "error occurred while calculate crc of message"
      },
      {
        "176",
        "invalid input additional data of merchant"
      },
      {
        "177",
        "RET_OK_RequestID"
      },
      {
        "178",
        "POS is Busy can not accept new transaction"
      },
      {
        "200",
        "Other exception"
      }
    };
        private string[,] ReasonError = new string[99, 2]
        {
      {
        "1",
        "به صادر کننده کارت ارجاع گردد"
      },
      {
        "2",
        "تراکنش اصلاحیه قبلي با موفقیت انجام شد"
      },
      {
        "3",
        "پذيرنده کارت نامعتبر است"
      },
      {
        "4",
        "شماره مرجع تراکنش تكراری است"
      },
      {
        "5",
        "تراکنش نامعتبر است"
      },
      {
        "6",
        "خطای داخلي سويیچ صادر کننده کارت"
      },
      {
        "7",
        "شناسه قبض نادرست است"
      },
      {
        "8",
        "شناسه پرداخت نادرست است"
      },
      {
        "9",
        "درخواست قبلي در حال انجام است"
      },
      {
        "10",
        "تراکنش اصلي در سیستم موجود نمي باشد"
      },
      {
        "11",
        "کد پردازش تراکنش اصلي معتبر نمي باشد"
      },
      {
        "12",
        "رمز مورد نیاز است"
      },
      {
        "13",
        "مبلغ نامعتبر است"
      },
      {
        "14",
        "شماره کارت نامعتبر است"
      },
      {
        "15",
        "سرويس درخواستي موجود نمي باشد"
      },
      {
        "16",
        "شماره کارت با شماره کارت تراکنش اصلي يكسان نمي باشد"
      },
      {
        "17",
        "انجام تراکنش توسط کاربر لغو شد"
      },
      {
        "18",
        "در حال حاضر ارائه سرويس امكان پذير نمي باشد"
      },
      {
        "19",
        "تراکنش را دوباره انجام دهید"
      },
      {
        "20",
        "سیستم دچار اشكال شده است"
      },
      {
        "21",
        "عملي انجام نشد"
      },
      {
        "22",
        "خطای امنیتي رخ داده است"
      },
      {
        "23",
        "مبلغ کارمزد نامعتبر است"
      },
      {
        "24",
        "امكان اجرای تراکنش برگشت وجود ندارد تراکنش اصلي به صورت سیستمي برگشت خورده است"
      },
      {
        "25",
        "تراکنش مرجع موجود نیست"
      },
      {
        "26",
        "جمع مبلغ تراکنشهای برگشتي از تراکنش اصلي بیشتر ميباشد"
      },
      {
        "27",
        "مبلغ تراکنش اصلاحیه با تراکنش اصلي يكسان نمي باشد"
      },
      {
        "28",
        "تراکنش اصلي قبلا به صورت سیستمي برگشت خورده است"
      },
      {
        "29",
        "امكان انجام تراکنش اصلاحیه وجود ندارد"
      },
      {
        "30",
        "زمان درخواست خارج از بازه زماني اجرای عملیات مي باشد"
      },
      {
        "31",
        "صادر کننده کارت نامعتبر است"
      },
      {
        "32",
        "تراکنشي با اين شماره تسويه و شماره مشتری پیدا نشد"
      },
      {
        "33",
        "تاريخ انقضای کارت گذشته است"
      },
      {
        "34",
        "مشتری تراکنش برگشت با مشتری تراکنش اصلي يكسان نمي باشد"
      },
      {
        "35",
        "پذيرنده با بانک تماس بگیريد"
      },
      {
        "36",
        "کارت محدود شده است"
      },
      {
        "37",
        "نیازی به شناسه واريزنمي باشد"
      },
      {
        "38",
        "تعداد دفعات وارد کردن رمز بیش از حد مجاز است"
      },
      {
        "39",
        "حساب نامعتبر است"
      },
      {
        "40",
        "شناسه واريزتراکنش اصلي موجود نمي باشد"
      },
      {
        "41",
        "کارت نامعتبر است"
      },
      {
        "42",
        "برای اين hash code از طرف دارنده کارت تراکنش صورت نگرفت"
      },
      {
        "43",
        "زمان ارسال تراکنش از سمت پذيرنده همگون نیست"
      },
      {
        "44",
        "مشتری در سامانه متمرکز معتبر نمي باشد"
      },
      {
        "45",
        "شناسه واريزاجباری است و مقدار ندارد"
      },
      {
        "46",
        "حساب فروشنده مجوز برداشت غیر حضوری ندارد"
      },
      {
        "47",
        "نوع حساب مجوز واريز و يا برداشت ندارد"
      },
      {
        "48",
        "حساب مجوز واريز و يا برداشت ندارد"
      },
      {
        "49",
        "حساب فروشنده معتبر نمي باشد"
      },
      {
        "50",
        "تاريخ تراکنش اصلاحیه باتاريخ تراکنش اصلي متفاوت است"
      },
      {
        "51",
        "موجودی حساب کافي نیست"
      },
      {
        "52",
        "فرمت تاريخ تسويه اشتباه مي باشد"
      },
      {
        "53",
        "مشتری تراکنش اصلاحیه با مشتری تراکنش اصلي يكسان نمي باشد"
      },
      {
        "54",
        "مبلغ واريز از مینیمم مبلغ افتتاح حساب کمتر است"
      },
      {
        "55",
        "رمز نادرست است"
      },
      {
        "56",
        "امكان حذف اطلاعات مشتری وجود ندارد"
      },
      {
        "57",
        "دارنده کارت مجاز به انجام اين تراکنش نیست"
      },
      {
        "58",
        "پايانه مجاز به انجام اين تراکنش نیست"
      },
      {
        "59",
        "رمز شارژ با مبلغ مورد نظر موجود نیست"
      },
      {
        "60",
        "خطای داخلي در استخراج رمز شارژ"
      },
      {
        "61",
        "مبلغ برداشت وجه بیش از حد مجاز است"
      },
      {
        "62",
        "کد کالا نامعتبر است"
      },
      {
        "63",
        "خطای داخلي"
      },
      {
        "64",
        "اطلاعات تماس مشتری تعريف نشده است"
      },
      {
        "65",
        "دفعات برداشت وجه بیش از حد مجاز است"
      },
      {
        "66",
        "شعبه مشتری تعريف نشده است"
      },
      {
        "67",
        "حواله ای موجود نمي باشد"
      },
      {
        "68",
        "پاسخي از صادر کننده کارت دريافت نشد"
      },
      {
        "69",
        "شماره حساب/کارت مقصد نامعتبر است"
      },
      {
        "70",
        "کد کاربری يا رمز عبور نامعتبر است."
      },
      {
        "71",
        "فرمت پیام اشتباه مي باشد."
      },
      {
        "72",
        "مبلغ تراکنش از مبلغ کارمزد کوچكتراست"
      },
      {
        "73",
        "نوع مشتری حقیقي يا حقوقي نمي باشد"
      },
      {
        "74",
        "شرايط حساب فروشنده معتبر نمي باشد"
      },
      {
        "75",
        "کد رزرو تكراری است"
      },
      {
        "76",
        "شمار پیگیری تكراری است"
      },
      {
        "77",
        "تاريخ روزکاری نامعتبر است"
      },
      {
        "78",
        "شماره حساب/کارت مبداء با مقصد يكسان است"
      },
      {
        "79",
        "کارت غیر فعال است"
      },
      {
        "80",
        "حساب پذيرنده تعريف نشده است"
      },
      {
        "81",
        "اصلاحیه انتقال وجه قابل انجام نمي باشد"
      },
      {
        "82",
        "حساب اصلي کارت، حساب متصل به پايانه نمي باشد"
      },
      {
        "83",
        "صادر کننده کارت غیر فعال است"
      },
      {
        "84",
        "شناسه واريز صحیح نمي باشد"
      },
      {
        "85",
        "تراکنش صادر کننده نامعتبر است"
      },
      {
        "86",
        "سازمان صادر کننده قبض نامعتبر است"
      },
      {
        "87",
        "با بانک صادرکننده تماس بگیريد"
      },
      {
        "88",
        "پايانه نامعتبر است"
      },
      {
        "89",
        "بانک پذيرنده نامعتبر است"
      },
      {
        "90",
        "سیستم در حال انجام عملیات پايان روز کاری است , بعدا سعي نمايید."
      },
      {
        "91",
        "صادر کننده کارت در وضعیت عملیاتي نمي باشد"
      },
      {
        "92",
        "MAC نادرست است"
      },
      {
        "93",
        "خطا در تطابق MAC"
      },
      {
        "94",
        "تراکنش تكراری است"
      },
      {
        "95",
        "خطا در تطابق اطلاعات"
      },
      {
        "96",
        "کلیدهای ارتباطي موجود نمي باشد"
      },
      {
        "97",
        "خطا در تطابق کلیدهای رمزگذاری"
      },
      {
        "98",
        "خطای سیستمي ، دوباره سعي کنید"
      },
      {
        "99",
        "با پشتیباني تماس بگیريد"
      }
        };

        public string IP { get; set; }

        public string Port { get; set; }

        public string SendPriceToPos(
          string DebitAmount,
          string DebitPayerId,
          string DebitMsg,
          string DebitPcID,
          string ReadTimeOut)
        {
            string str1 = "";
            bool flag = int.TryParse(DebitAmount, out int _);
            if (DebitAmount.Length < 4 || !flag)
                return "-1";
            TcpClient tcpClient = (TcpClient)null;
            try
            {
                ServicePointManager.Expect100Continue = false;
                byte[] numArray = new byte[10025];
                tcpClient = new TcpClient(this.IP, (int)ushort.Parse(this.Port));
                if (!tcpClient.Connected)
                    return "-2";
                NetworkStream stream = tcpClient.GetStream();
                string str2 = "{\"ServiceCode\" :\"1";
                if (DebitAmount.Length > 0)
                    str2 = str2 + "\",\"Amount\":\"" + DebitAmount;
                if (DebitPayerId.Length > 0)
                    str2 = str2 + "\",\"PayerId\":\"" + DebitPayerId;
                if (DebitMsg.Length > 0)
                    str2 = str2 + "\",\"MerchantMsg\":\"" + DebitMsg;
                if (DebitPcID.Length > 0)
                    str2 = str2 + "\",\"PcID\":\"" + DebitPcID;
                byte[] bytes = Encoding.ASCII.GetBytes(str2 + "\"}");
                stream.Write(bytes, 0, bytes.Length);
                stream.ReadTimeout = int.Parse(ReadTimeOut);
                stream.Read(numArray, 0, numArray.Length);
                string str3 = Encoding.UTF8.GetString(numArray);
                Dictionary<string, string> dictionary = (Dictionary<string, string>)JsonConvert.DeserializeObject<Dictionary<string, string>>(str3);
                str1 = str3;
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                try
                {
                    tcpClient.Close();
                    return "-3";
                }
                catch
                {
                }
            }
            return str1;
        }

        public string GetReturnCodeError(int ReturnCode)
        {
            string str = "";
            if (ReturnCode > 0)
            {
                for (int index = 0; index < this.ReturnError.Length; ++index)
                {
                    if (ReturnCode.ToString() == this.ReturnError[index, 0].ToString())
                    {
                        str = this.ReturnError[index, 1].ToString();
                        break;
                    }
                }
            }
            return str;
        }

        public string GetReasonCodeError(int ReasonCode)
        {
            string str = "";
            if (ReasonCode > 0)
            {
                for (int index = 0; index < this.ReasonError.Length; ++index)
                {
                    if (ReasonCode.ToString() == this.ReasonError[index, 0].ToString())
                    {
                        str = this.ReasonError[index, 1].ToString();
                        break;
                    }
                }
            }
            return str;
        }
    }
}
