using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;

namespace TestCasePHEV2.Repository
{
    public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(TestCasePHEV2DbContext context) :base(context)
        {
        }
    }
}