using SupplyManagement.Helper.Enum;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.User
{
    public class UpdateUserDTO
    {
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }

        public Guid CompanyID { get; set; }
        public Guid ManagerID { get; set; }
    }
}
