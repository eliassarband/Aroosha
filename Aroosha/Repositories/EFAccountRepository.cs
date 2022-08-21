using GeneralDAL.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public class EFAccountRepository:IAccountRepository
    {
        //private ArooshaContext context;//= new ArooshaContext();

        private readonly ArooshaContext context;

        public EFAccountRepository(ArooshaContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public IEnumerable<Person> Persons
        {
            get { return context.Persons; }
        }

        public bool SaveLoginAttempt(LoginAttempt loginAttempt)
        {
            try
            {
                context.LoginAttempts.Add(loginAttempt);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveLoginedData(LoginedData loginedData)
        {
            try
            {
                context.loginedDatas.Add(loginedData);

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<LoginAttempt> LoginAttempts
        {
            get { return context.LoginAttempts.Include(u => u.User); }
        }

        public IEnumerable<LoginedData> LoginedDatas
        {
            get { return context.loginedDatas.Include(u => u.User); }
        }

        public bool Logout(LoginedData loginedData)
        {
            try
            {
                if (loginedData.Id > 0)
                {
                    var u = context.loginedDatas.FirstOrDefault(x => x.Id == loginedData.Id);
                    u.LogoutDate = loginedData.LogoutDate;
                    u.LogoutTime = loginedData.LogoutTime;

                }
                

                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
