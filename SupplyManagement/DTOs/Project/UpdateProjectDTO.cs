﻿using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Project
{
    public class UpdateProjectDTO
    {
        [Required]
        public Guid ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public Guid VendorID { get; set; }
    }
}
