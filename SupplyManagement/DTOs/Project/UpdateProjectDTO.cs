using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Project
{
    public class UpdateProjectDTO
    {

        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public int VendorID { get; set; }
    }
}
