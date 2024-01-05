using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SupplyManagement.Model
{
    [Table("tb_m_projects")]
    public class Project
    {
        [Key]
        [Column("ProjectID", TypeName = "uniqueidentifier")]
        public Guid ProjectID { get; set; }

        [Column("projectName", TypeName = "nvarchar(100)")]
        public string ProjectName { get; set; }

        // Foreign Key
        public Guid VendorID { get; set; }

        public Vendor Vendor { get; set; }
    }
}
