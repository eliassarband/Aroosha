using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Person> Persons { get; }
        bool SaveLoginAttempt(LoginAttempt loginAttempt);
        bool SaveLoginedData(LoginedData loginedData);

        IEnumerable<LoginAttempt> LoginAttempts { get; }

        IEnumerable<LoginedData> LoginedDatas { get; }

        bool Logout(LoginedData loginedData);
       
        void SaveChanges();

       
    }
}
