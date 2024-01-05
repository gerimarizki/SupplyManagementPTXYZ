using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Model
{
    [Table("tb_m_vendors")]
    public class Vendor
    {
        [Key]
        [Column("VendorID", TypeName = "uniqueidentifier")]
        public Guid VendorID { get; set; }

        [Column("vendorName", TypeName = "nvarchar(100)")]
        public string VendorName { get; set; }

        [Column("businessType", TypeName = "nvarchar(100)")]
        public string BusinessType { get; set; }

        [Column("companyType", TypeName = "nvarchar(100)")]
        public string CompanyType { get; set; }

        // Foreign Key
        public Guid UserID { get; set; }

        public User User { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
