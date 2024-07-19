using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        User FindByUserName(string userName);
        User[] FindAll();
        void Add(User User);
        User FindById(int id);
        bool VerifyUserPassInfo(User user);
        void Update(User user);
        void Delete(User user);
    }
}
