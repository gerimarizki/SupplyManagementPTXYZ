﻿using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Models;

namespace SupplyManagement.Repositories
{
    public class ManagerLogisticsRepository : GeneralRepository<ManagerLogistic>, IManagerLogistic
    {
        public ManagerLogisticsRepository(BookingDbContext context) : base(context)
        {
        }
    }
}
