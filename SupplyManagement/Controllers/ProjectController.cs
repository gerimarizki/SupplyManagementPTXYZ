using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.Project;
using SupplyManagement.Handlers;
using SupplyManagement.Services;
using System.Net;

namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/Project")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectServices _services;

        public ProjectController(ProjectServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetProject();

            if (entities == null)
            {
                return NotFound(new HandlerForResponse<GetProjectDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<IEnumerable<GetProjectDTO>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = entities
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vendor = _services.GetProjectID(id);
            if (vendor is null)
            {
                return NotFound(new HandlerForResponse<GetProjectDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<GetProjectDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = vendor
            });
        }

        [HttpPost]
        public IActionResult Create(NewProjectDTO newProject)
        {
            var createNewProject = _services.CreateProject(newProject);
            if (createNewProject is null)
            {
                return BadRequest(new HandlerForResponse<GetProjectDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<GetProjectDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewProject
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateProjectDTO updateProjectDTO)
        {
            var update = _services.UpdateProject(updateProjectDTO);
            if (update is -1)
            {
                return NotFound(new HandlerForResponse<UpdateProjectDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new HandlerForResponse<UpdateProjectDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new HandlerForResponse<UpdateProjectDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteProject(id);

            if (delete is -1)
            {
                return NotFound(new HandlerForResponse<GetProjectDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new HandlerForResponse<GetProjectDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new HandlerForResponse<GetProjectDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
