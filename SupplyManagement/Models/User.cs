using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SupplyManagement.Helper.Enum;

namespace SupplyManagement.Model
{
    [Table("tb_m_users")]
    public class User
    {
        [Key]
        [Column("UserID", TypeName = "uniqueidentifier")]
        public Guid UserID { get; set; }
        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column("Password", TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column("UserType")]
        public UserType UserType { get; set; }

        //Foreign Key
        public Guid CompanyID { get; set; }
        public Guid ManagerID { get; set; }


        //Cardinality
        public Company Company { get; set; }
        public ManagerLogistic ManagerLogistic { get; set; }
        public Vendor Vendor { get; set; }
    }
}
