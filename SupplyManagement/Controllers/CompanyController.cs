using Microsoft.AspNetCore.Mvc;
using SupplyManagement.DTOs.Company;
using SupplyManagement.DTOs.User;
using SupplyManagement.Services;
using System.Net;
using SupplyManagement.Handlers;

namespace SupplyManagement.Controllers
{
    [ApiController]
    [Route("Api/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyServices _services;

        public CompanyController(CompanyServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _services.GetCompany();

            if (entities == null)
            {
                return NotFound(new HandlerForResponse<GetCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<IEnumerable<GetCompanyDTO>>
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
            var company = _services.GetCompanyID(id);
            if (company is null)
            {
                return NotFound(new HandlerForResponse<GetCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new HandlerForResponse<GetCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = company
            });
        }

        [HttpPost]
        public IActionResult Create(NewCompanyDTO newCompany)
        {
            var createNewCompany = _services.CreateCompany(newCompany);
            if (createNewCompany is null)
            {
                return BadRequest(new HandlerForResponse<GetUserDTO>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new HandlerForResponse<GetCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createNewCompany
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDTO updateCompanyDTO)
        {
            var update = _services.UpdateCompany(updateCompanyDTO);
            if (update is -1)
            {
                return NotFound(new HandlerForResponse<UpdateCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new HandlerForResponse<UpdateCompanyDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new HandlerForResponse<UpdateCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _services.DeleteCompany(id);

            if (delete is -1)
            {
                return NotFound(new HandlerForResponse<GetCompanyDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new HandlerForResponse<GetCompanyDTO>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new HandlerForResponse<GetCompanyDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    }
}
