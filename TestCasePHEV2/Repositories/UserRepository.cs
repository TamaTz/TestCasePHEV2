using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

namespace TestCasePHEV2.Repositories
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        private readonly TestCasePHEV2DbContext context;
        public UserRepository(TestCasePHEV2DbContext context) : base(context) 
        {

        }

        public User GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public Role GetRoleByGuid(string roleGuid)
        {
            return context.Roles.FirstOrDefault(r => r.Guid == roleGuid);
        }

        public IEnumerable<Role> GetRolesByUserGuid(string userGuid)
        {
            var user = context.Users.FirstOrDefault(u => u.Guid == userGuid);

            if (user != null)
            {
                return context.Roles.Where(role => role.Guid == user.RoleGuid).ToList();
            }

            return Enumerable.Empty<Role>();
        }
    }
}