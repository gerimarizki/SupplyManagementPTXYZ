using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.User;
using SupplyManagement.DTOs.Vendor;
using SupplyManagement.Handlers;
using SupplyManagement.Services;
using System.Net;

namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/Vendor")]
    public class VendorController : ControllerBase
    {
        private readonly VendorServices _services;

        public VendorController(VendorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetVendor();

            if (entities == null)
            {
                return NotFound(new HandlerForResponse<GetVendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<IEnumerable<GetVendorDTO>>
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
            var vendor = _services.GetVendorID(id);
            if (vendor is null)
            {
                return NotFound(new HandlerForResponse<GetVendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<GetVendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = vendor
            });
        }

        [HttpPost]
        public IActionResult Create(NewVendorDTO newVendor)
        {
            var createNewVendor = _services.CreateCompany(newVendor);
            if (createNewVendor is null)
            {
                return BadRequest(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<GetVendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewVendor
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateVendorDTO updateVendorDTO)
        {
            var update = _services.UpdateCompany(updateVendorDTO);
            if (update is -1)
            {
                return NotFound(new HandlerForResponse<UpdateVendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new HandlerForResponse<UpdateVendorDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new HandlerForResponse<UpdateVendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteVendor(id);

            if (delete is -1)
            {
                return NotFound(new HandlerForResponse<GetVendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new HandlerForResponse<GetVendorDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new HandlerForResponse<GetVendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
