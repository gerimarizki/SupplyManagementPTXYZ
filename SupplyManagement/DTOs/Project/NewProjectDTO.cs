using System.ComponentModel.DataAnnotations;

namespace SupplyManagement.DTOs.Project
{
    public class NewProjectDTO
    {

        public int ProjectID { get; set; }


        public string ProjectName { get; set; }

        public int VendorID { get; set; }
    }
}
