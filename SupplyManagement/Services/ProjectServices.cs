using SupplyManagement.Contracts;
using SupplyManagement.DTOs.Project;
using SupplyManagement.Models;

namespace SupplyManagement.Services
{
    public class ProjectServices
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public IEnumerable<GetProjectDTO>? GetProject()
        {
            var project = _projectRepository.GetAll();
            if (!project.Any())
            {
                return null; // No manager found
            }

            var toDto = project.Select(project =>
                                                new GetProjectDTO
                                                {
                                                    ProjectID = project.ProjectID,
                                                    ProjectName = project.ProjectName,
                                                    VendorID = project.VendorID,

                                                }).ToList();

            return toDto; // manager found
        }

        public GetProjectDTO? GetProjectID(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project is null)
            {
                return null; // Vendor not found
            }

            var toDto = new GetProjectDTO
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                VendorID = project.VendorID,
            };

            return toDto; // Vendor found
        }

        public GetProjectDTO? CreateProject(NewProjectDTO newProjectDTO)
        {
            var project = new Project
            {
                ProjectID = newProjectDTO.ProjectID,
                ProjectName = newProjectDTO.ProjectName,
                VendorID = newProjectDTO.VendorID,

            };

            var createdProject = _projectRepository.Create(project);
            if (createdProject is null)
            {
                return null; // Vendor not created
            }

            var toDto = new GetProjectDTO
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                VendorID = project.VendorID,
            };

            return toDto; // Vendor created
        }

        public int UpdateProject(UpdateProjectDTO updateProjectDTO)
        {
            var isExist = _projectRepository.IsExist(updateProjectDTO.VendorID);
            if (!isExist)
            {
                return -1; // Vendor Not Found
            }

            var getProject = _projectRepository.GetById(updateProjectDTO.VendorID);

            var project = new Project
            {
                ProjectID = updateProjectDTO.ProjectID,
                ProjectName = updateProjectDTO.ProjectName,
                VendorID = updateProjectDTO.VendorID,
            };

            var isUpdate = _projectRepository.Update(project);
            if (!isUpdate)
            {
                return 0; // company not updated
            }
            return 1;
        }

        public int DeleteProject(int id)
        {
            var isExist = _projectRepository.IsExist(id);
            if (!isExist)
            {
                return -1; // company not found
            }

            var project = _projectRepository.GetById(id);
            var isDelete = _projectRepository.Delete(project);
            if (!isDelete)
            {
                return 0; // company not deleted
            }

            return 1;
        }
    }

}
