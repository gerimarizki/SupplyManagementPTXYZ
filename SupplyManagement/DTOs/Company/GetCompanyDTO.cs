using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Company
{
    public class GetCompanyDTO
    {

        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyPhoneNumber { get; set; }

        public string ApprovalStatus { get; set; }

        public string CompanyPhoto { get; set; }
    }
}
