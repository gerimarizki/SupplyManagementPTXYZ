﻿using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.ManagerLogistic
{
    public class NewManagerLogisticDTO
    {

        public int ManagerID { get; set; }

        public string ManagerName { get; set; }


        public string ManagerEmail { get; set; }


        public string ManagerPhone { get; set; }
    }
}
