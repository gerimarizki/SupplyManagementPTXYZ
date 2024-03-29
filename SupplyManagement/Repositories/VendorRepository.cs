﻿using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Models;

namespace SupplyManagement.Repositories
{
    public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(BookingDbContext context) : base(context)
        {

        }
    }
}
