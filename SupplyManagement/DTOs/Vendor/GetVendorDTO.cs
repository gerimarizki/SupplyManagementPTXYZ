using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Vendor
{
    public class GetVendorDTO
    {

        public int VendorID { get; set; }

        public string VendorName { get; set; }


        public string BusinessType { get; set; }

   
        public string CompanyType { get; set; }


        public int UserID { get; set; }
    }
}
