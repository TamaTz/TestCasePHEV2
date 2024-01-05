﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;

namespace TestCasePHEV2.Repository
{
    public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
    {
       public VendorRepository(TestCasePHEV2DbContext context) : base(context) 
       {
       }
    }
}
