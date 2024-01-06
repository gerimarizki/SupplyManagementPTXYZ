using SupplyManagement.Helper.Enum;
using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.User
{
    public class UpdateUserDTO
    {

        public int UserID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public int CompanyID { get; set; }
        public int ManagerID { get; set; }
    }
}
