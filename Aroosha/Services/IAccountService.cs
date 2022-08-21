using Aroosha.Models;
using Aroosha.Repositories;
using GeneralDAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aroosha.Services
{
    public interface IAccountService
    {
        LoginedUser Authenticate(string username, string password,string DeviceName,string ClientIPAddr, IAccountRepository repository);

        bool Logout(int LoginedDataId, IAccountRepository repository);
    }
}
