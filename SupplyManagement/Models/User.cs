using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SupplyManagement.Helper.Enum;

namespace SupplyManagement.Models
{
    [Table("tb_m_user")]
    public class User
    {
        [Key]
        [Column("UserID", TypeName = "int")]
        public int UserID { get; set; }
        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column("Password", TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column("UserType")]
        public UserType UserType { get; set; }

        //Foreign Key
        public int CompanyID { get; set; }
        public int ManagerID { get; set; }


        //Cardinality
        public Company Company { get; set; }
        public ManagerLogistic ManagerLogistic { get; set; }
        public Vendor Vendor { get; set; }
    }
}
