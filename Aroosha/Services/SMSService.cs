using Aroosha.Models;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    
    public class SMSService:ISMSService
    {
        //private readonly string ServiceName = "SMSService";
        //private readonly IHttpClientFactory ClientFactory;

        //public SMSService(IHttpClientFactory clientFactory)
        //{
        //    ClientFactory = clientFactory;
        //}
        //public async Task<FeedBack<bool>> SendSMS(string Text, long Number)
        //{
        //    var Result = new FeedBack<bool>(ServiceName, OperationType.Fetch);
        //    try
        //    {
        //        string myUsername = "___USER";
        //        string myPassword = "___PASS";
        //        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(myUsername + ":" + myPassword));
        //        var client = ClientFactory.CreateClient();

        //        client.BaseAddress = new Uri("http://smspishgam.com:8080/");
        //        client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
        //        client.DefaultRequestHeaders.Add("accept", "application/json");

        //        var messageModel = new SMSModel();
        //        messageModel.SmsText = Text;
        //        messageModel.Receivers = "98" + Number;
        //        messageModel.SenderId = "300003553";
        //        messageModel.IsUnicode = true;
        //        messageModel.IsFlash = false;

        //        var postTask = client.PostAsync("Messages/Send", new StringContent(JsonConvert.SerializeObject(messageModel), Encoding.UTF8, "application/json"));
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var Res = await result.Content.ReadAsStringAsync();
        //            if (Res.StartsWith("<?xml"))
        //            {
        //                Result.Set(FeedBackStatus.Custom);
        //                Result.Message = "ارسال پیام با مشکل مواجه شد.";
        //                return Result;
        //            }
        //            else
        //            {
        //                object obj = JsonConvert.DeserializeObject(Res);
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Set(FeedBackStatus.Exception, ex);
        //        Result.Message = "ارسال پیام با مشکل مواجه شد.";
        //        return Result;

        //    }
        //    return Result;
        //}
        //public async Task<FeedBack<bool>> SendBulkSMS(string Text, List<long> Numbers)
        //{
        //    var Result = new FeedBack<bool>(ServiceName, OperationType.Fetch);
        //    try
        //    {
        //        string myUsername = "___USER";
        //        string myPassword = "___PASS";
        //        String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(myUsername + ":" + myPassword));
        //        var client = ClientFactory.CreateClient();

        //        client.BaseAddress = new Uri("http://smspishgam.com:8080/");
        //        client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
        //        client.DefaultRequestHeaders.Add("accept", "application/json");

        //        var messageModel = new SMSModel();
        //        messageModel.SmsText = Text;
        //        messageModel.Receivers = string.Join(",", Numbers.Select(x => "98" + x));
        //        messageModel.SenderId = "300003553";
        //        messageModel.IsUnicode = true;
        //        messageModel.IsFlash = false;

        //        var postTask = client.PostAsync("Messages/Send", new StringContent(JsonConvert.SerializeObject(messageModel), Encoding.UTF8, "application/json"));
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var Res = await result.Content.ReadAsStringAsync();
        //            if (Res.StartsWith("<?xml"))
        //            {
        //                Result.Set(FeedBackStatus.Custom);
        //                Result.Message = "ارسال پیام با مشکل مواجه شد.";
        //                return Result;
        //            }
        //            else
        //            {
        //                object obj = JsonConvert.DeserializeObject(Res);
        //                Result.Set(FeedBackStatus.Succeeded);
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Result.Set(FeedBackStatus.Exception, ex);
        //        Result.Message = "ارسال پیام با مشکل مواجه شد.";
        //        return Result;

        //    }
        //    return Result;
        //}

    }
}
