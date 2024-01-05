using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;

namespace TestCasePHEV2.Repository
{
    public class ApprovelRepository : GeneralRepository<Approvel>, IApprovelRepository
    {
        public ApprovelRepository(TestCasePHEV2DbContext context) :base(context)
        {

        }
    }
}
