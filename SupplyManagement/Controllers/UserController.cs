using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.User;
using SupplyManagement.Services;
using System.Net;
using SupplyManagement.Handlers;


namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/User")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetAllUser();

            if (entities == null)
            {
                return NotFound(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<IEnumerable<GetUserDTO>>
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
            var company = _services.GetUserId(id);
            if (company is null)
            {
                return NotFound(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = company
            });
        }

        [HttpPost]
        public IActionResult Create(NewUserDTO newUser)
        {
            var createNewUser = _services.CreateNewUser(newUser);
            if (createNewUser is null)
            {
                return BadRequest(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewUser
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateUserDTO updateUserDTO)
        {
            var update = _services.UpdateUser(updateUserDTO);
            if (update is -1)
            {
                return NotFound(new HandlerForResponse<UpdateUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new HandlerForResponse<UpdateUserDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new HandlerForResponse<UpdateUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteUser(id);

            if (delete is -1)
            {
                return NotFound(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new HandlerForResponse<GetUserDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
