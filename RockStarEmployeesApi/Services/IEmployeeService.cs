using System.Collections.Generic;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Api.Responses;

namespace RockStarEmployeesApi.Services
{
    public interface IEmployeeService
    {
        IReadOnlyCollection<EmployeeResponse> GetEmployees();
        IReadOnlyCollection<EmployeeResponse> GetRockStarEmployees();
        int AddEmployee(EmployeeRequest employeeRequest);
    }
}