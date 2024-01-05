﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Model
{
    [Table("tb_m_companies")]
    public class Company 
    {
        [Key]
        [Column("companyID", TypeName = "uniqueidentifier")]
        public Guid CompanyID { get; set; }
        [Column("companyName", TypeName = "nvarchar(100)")]
        public string CompanyName { get; set; }
        [Column("companyEmail", TypeName = "nvarchar(100)")]
        public string CompanyEmail { get; set; }
        [Column("companyPhone", TypeName = "nvarchar(100)")]
        public string CompanyPhoneNumber { get; set; }
        [Column("approvalStatus", TypeName = "nvarchar(100)")]
        public string ApprovalStatus { get; set; }
        [Column("companyPhoto")]
        public byte[] CompanyPhoto { get; set; }

        public User User { get; set; }

    }
}
