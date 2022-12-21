using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        User GetUserByEmail(string email);
        void CreateUser(User user);
    }
}
