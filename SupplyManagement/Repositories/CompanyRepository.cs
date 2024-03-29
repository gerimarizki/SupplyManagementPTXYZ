﻿using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Models;

namespace SupplyManagement.Repositories
{
    public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(BookingDbContext context) : base(context)
        {
        }
    }
}
