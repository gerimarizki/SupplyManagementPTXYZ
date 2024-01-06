using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Models
{

    [Table("tb_m_manager")]
    public class ManagerLogistic
    {
        [Key]
        [Column("ManagerID", TypeName = "int")]
        public int ManagerID { get; set; }
        [Column("managerName", TypeName = "nvarchar(100)")]
        public string ManagerName { get; set; }

        [Column("managerEmail", TypeName = "nvarchar(100)")]
        public string ManagerEmail { get; set; }

        [Column("managerPhone", TypeName = "nvarchar(100)")]
        public string ManagerPhone { get; set; }

        public User User { get; set; }
    }
}
