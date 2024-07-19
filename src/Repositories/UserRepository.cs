using Dot.Net.WebApi.Data;
using System.Linq;
using Dot.Net.WebApi.Domain;
using System;
using System.Collections.ObjectModel;
using WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public LocalDbContext DbContext { get; }

        public UserRepository(LocalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User FindByUserName(string userName)
        {
            return DbContext.Users.Where(user => user.UserName == userName)
                                  .FirstOrDefault();
        }

        public User[] FindAll()
        {
            return DbContext.Users.ToArray();
        }

        public void Add(User user)
        {
            DbContext.Add(user);
            DbContext.SaveChanges();
        }

        public User FindById(int id)
        {
            return DbContext.Users.Where(user => user.Id == id)
                                  .FirstOrDefault();
        }

        public bool VerifyUserPassInfo(User user)
        {
            //Hash given password
            string password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            //Compare with stored password
            return (password == FindById(user.Id).Password);
        }

        public void Update(User user)
        {
            DbContext.Update(user);
            DbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            DbContext.Remove(user);
            DbContext.SaveChanges();
        }

    }
}