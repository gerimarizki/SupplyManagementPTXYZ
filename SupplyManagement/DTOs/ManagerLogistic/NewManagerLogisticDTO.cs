using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.ManagerLogistic
{
    public class NewManagerLogisticDTO
    {
        [Required]
        public Guid ManagerID { get; set; }
        [Required]
        public string ManagerName { get; set; }

        [Required]
        public string ManagerEmail { get; set; }

        [Required]
        public string ManagerPhone { get; set; }
    }
}
