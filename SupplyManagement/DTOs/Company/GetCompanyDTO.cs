using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Company
{
    public class GetCompanyDTO
    {
        [Required]
        public Guid CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPhoneNumber { get; set; }
        [Required]
        public string ApprovalStatus { get; set; }

        public byte[] CompanyPhoto { get; set; }
    }
}
