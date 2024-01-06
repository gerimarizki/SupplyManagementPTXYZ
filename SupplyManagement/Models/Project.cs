using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SupplyManagement.Models
{
    [Table("tb_m_project")]
    public class Project
    {
        [Key]
        [Column("ProjectID", TypeName = "int")]
        public int ProjectID { get; set; }

        [Column("projectName", TypeName = "nvarchar(100)")]
        public string ProjectName { get; set; }

        // Foreign Key
        public int VendorID { get; set; }

        public Vendor Vendor { get; set; }
    }
}
