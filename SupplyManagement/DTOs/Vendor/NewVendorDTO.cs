using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Vendor
{
    public class NewVendorDTO
    {
        [Required]
        public Guid VendorID { get; set; }

        [Required]
        public string VendorName { get; set; }

        [Required]
        public string BusinessType { get; set; }

        [Required]
        public string CompanyType { get; set; }

        [Required]
        public Guid UserID { get; set; }
    }
}
