using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Models;

namespace SupplyManagement.Repositories
{
    public class ProjectRepository : GeneralRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BookingDbContext context) : base(context)
        {

        }
    }
}
