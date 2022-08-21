using Aroosha.Models;
using Aroosha.Repositories;
using Aroosha.Utilities;
using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    public class AccountService : IAccountService
    {
        public LoginedUser Authenticate(string username, string password, string DeviceName, string ClientIPAddr, IAccountRepository repository)
        {

            LoginedUser logined;

            var user = repository.Users.Join(
                                    repository.Persons,
                                    u => u.PersonId,
                                    p => p.Id,
                                    (u, p) => new
                                    {
                                        UserID = u.Id,
                                        Username = u.Username,
                                        Password = u.HashPassword,
                                        Active = u.Active,
                                        PersonCode = p.Code,
                                        PersonName = p.FullName,
                                        UserRole = "admin",
                                        LoginMessage = "",
                                        LoginStatus = true
                                    }
                                ).FirstOrDefault(x => x.Username == username);


            string LoginMessage = "";
            bool LoginStatus = true;
            int? LoginedUserId=null;

            if (user == null)
            {
                LoginMessage = "کاربری وارد شده در سامانه وجود ندارد";
                LoginStatus = false;

                logined = new LoginedUser()
                {
                    UserID = 0,
                    PersonCode = 0,
                    PersonName = "",
                    UserRole = "",
                    LoginMessage = LoginMessage,
                    LoginStatus = LoginStatus
                };
            }
            else
            {
                if (user.Active != true)
                {
                    LoginMessage = "کاربری وارد شده غیرفعال می باشد";
                    LoginStatus = false;
                }
                else if (CryptographyHelper.MD5Hash(password) != user.Password)
                {
                    LoginMessage = "کلمه عبور وارد شده نادرست می باشد";
                    LoginStatus = false;
                }

                LoginedUserId = user.UserID;

                logined = new LoginedUser()
                {
                    UserID = user.UserID,
                    PersonCode = user.PersonCode,
                    PersonName = user.PersonName,
                    UserRole = user.UserRole,
                    LoginMessage = LoginMessage,
                    LoginStatus = LoginStatus,
                    LoginedDataId = 0
                };
            }

            bool success = false;
            success = repository.SaveLoginAttempt(new GeneralDAL.Database.LoginAttempt()
            {
                UserId = LoginedUserId,
                Username = username,
                Logined = LoginStatus,
                LoginResult = LoginMessage,
                Date = PersianHelper.TodayDate(),
                Time = PersianHelper.NowLongTime(),
                DeviceName =DeviceName,
                ClientIPAddr=ClientIPAddr
            });

            if (LoginStatus)
            {
                success = repository.SaveLoginedData(new GeneralDAL.Database.LoginedData()
                {
                    UserId = LoginedUserId,
                    Date = PersianHelper.TodayDate(),
                    Time = PersianHelper.NowLongTime(),
                    DeviceName = DeviceName,
                    ClientIPAddr = ClientIPAddr
                });

                int LoginedDataId = repository.LoginedDatas.Where(l => l.UserId == LoginedUserId).OrderByDescending(l => l.Id).FirstOrDefault().Id;
                logined.LoginedDataId = LoginedDataId;
            }


            return logined;
        }

        public bool Logout(int LoginedDataId, IAccountRepository repository)
        {
            LoginedData logined;

            var u = repository.LoginedDatas.FirstOrDefault( l => l.Id == LoginedDataId);

            logined = new LoginedData()
            {
                Id=u.Id,
                UserId=u.UserId,
                Date=u.Date,
                Time=u.Time,
                DeviceName=u.DeviceName,
                ClientIPAddr=u.ClientIPAddr,
                LogoutDate=PersianHelper.TodayDate(),
                LogoutTime=PersianHelper.NowLongTime()
            };

            return repository.Logout(logined);
        }

    }
}
