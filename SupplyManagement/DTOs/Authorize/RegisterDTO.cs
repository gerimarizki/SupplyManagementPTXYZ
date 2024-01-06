﻿using SupplyManagement.Helper.Enum;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Authorize
{
    public class RegisterDTO
    {
        //Company
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPhoneNumber { get; set; }
        public string CompanyPhoto { get; set; }

        public int VendorID { get; set; }

        public string VendorName { get; set; }

        public string BusinessType { get; set; }
        
        public string CompanyType { get; set; }

        public int UserID { get; set; }
        

        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }


    }
}
