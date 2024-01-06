using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.ManagerLogistic;
using SupplyManagement.Services;
using System.Net;
using SupplyManagement.Handlers;

namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/Manager")]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerLogisticServices _services;

        public ManagerController(ManagerLogisticServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetAllManager();

            if (entities == null)
            {
                return NotFound(new HandlerForResponse<GetManagerLogisticDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<IEnumerable<GetManagerLogisticDTO>>
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
            var manager = _services.GetManagerId(id);
            if (manager is null)
            {
                return NotFound(new HandlerForResponse<GetManagerLogisticDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<GetManagerLogisticDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = manager
            });
        }

        [HttpPost]
        public IActionResult Create(NewManagerLogisticDTO newManager)
        {
            var createNewManager = _services.CreateNewManager(newManager);
            if (createNewManager is null)
            {
                return BadRequest(new HandlerForResponse<GetManagerLogisticDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<GetManagerLogisticDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewManager
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateManagerLogisticDTO updateManagerLogisticDTO)
        {
            var update = _services.UpdateManager(updateManagerLogisticDTO);
            if (update is -1)
            {
                return NotFound(new HandlerForResponse<UpdateManagerLogisticDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new HandlerForResponse<UpdateManagerLogisticDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new HandlerForResponse<UpdateManagerLogisticDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteManager(id);

            if (delete is -1)
            {
                return NotFound(new HandlerForResponse<GetManagerLogisticDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new HandlerForResponse<GetManagerLogisticDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new HandlerForResponse<GetManagerLogisticDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
