using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models
{
    [Table("tb_m_company")]
    public class Company 
    {
        [Key]
        [Column("companyID", TypeName = "int")]
        public int CompanyID { get; set; }
        [Column("companyName", TypeName = "nvarchar(100)")]
        public string CompanyName { get; set; }
        [Column("companyEmail", TypeName = "nvarchar(100)")]
        public string CompanyEmail { get; set; }
        [Column("companyPhone", TypeName = "nvarchar(100)")]
        public string CompanyPhoneNumber { get; set; }
        [Column("approvalStatus", TypeName = "nvarchar(100)")]
        public string ApprovalStatus { get; set; }
        [Column("companyPhoto")]
        public string CompanyPhoto { get; set; }

        public User User { get; set; }

    }
}
