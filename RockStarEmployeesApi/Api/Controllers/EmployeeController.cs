using Microsoft.AspNetCore.Mvc;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Services;

namespace RockStarEmployeesApi.Api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("rockstars")]
        public IActionResult GetRockStars()
        {
            var employees = _employeeService.GetRockStarEmployees();
            return Ok(employees);
        }
        
        [HttpGet]
        [Route("employees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }     

        [HttpPost]
        [Route("employees")]
        public IActionResult AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            var employeeId = _employeeService.AddEmployee(employeeRequest);
            return Ok(employeeId);
        }

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private readonly IEmployeeService _employeeService;
    }
}