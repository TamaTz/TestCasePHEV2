using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;

namespace TestCasePHEV2.Repository
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        private readonly TestCasePHEV2DbContext _context;
        public RoleRepository(TestCasePHEV2DbContext context) : base(context) 
        {
            _context = context;
        }

        public Role GetRoleByGuid(string roleGuid)
        {

            return _context.Roles.FirstOrDefault(r => r.Name == roleGuid);
        }
    }
}
