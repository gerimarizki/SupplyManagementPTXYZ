using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.Model
{
    [Table("tb_m_manager_logistics")]
    public class ManagerLogistic
    {
        [Key]
        [Column("ManagerID", TypeName = "uniqueidentifier")]
        public Guid ManagerID { get; set; }
        [Column("managerName", TypeName = "nvarchar(100)")]
        public string ManagerName { get; set; }

        [Column("managerEmail", TypeName = "nvarchar(100)")]
        public string ManagerEmail { get; set; }

        [Column("managerPhone", TypeName = "nvarchar(100)")]
        public string ManagerPhone { get; set; }

        public User User { get; set; }
    }
}
