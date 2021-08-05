using Microsoft.AspNetCore.Mvc;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Services;

namespace RockStarEmployeesApi.Api.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOffices()
        {
            var offices = _officeService.GetOffices();
            return Ok(offices);
        }

        [HttpPost]
        public IActionResult AddOffice([FromBody] OfficeRequest officeRequest)
        {
            var officeId = _officeService.AddOffice(officeRequest);
            return Ok(officeId);
        }

        public OfficesController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        private readonly IOfficeService _officeService;
    }
}