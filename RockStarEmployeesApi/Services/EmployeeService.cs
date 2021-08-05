using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Api.Responses;
using RockStarEmployeesApi.Persistence;
using RockStarEmployeesApi.Persistence.Models;
using RockStarEmployeesApi.Services.Exceptions;

namespace RockStarEmployeesApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IReadOnlyCollection<EmployeeResponse> GetEmployees()
        {
            var employees = _myContext.Employees;
            return employees.Select(e => new EmployeeResponse
            {
                Id = e.Id,
                OfficeId = e.OfficeId,
                ChiefId = e.ChiefId,
                Salary = e.Salary,
                Name = e.Name
            }).ToList();
        }

        public IReadOnlyCollection<EmployeeResponse> GetRockStarEmployees()
        {
            //with raw SQL
            var employeesWithSQL = _myContext.Employees.FromSqlRaw(
                @"SELECT e1.""Id"", e1.""Name"", e1.""Salary"", e1.""OfficeId"", e1.""ChiefId""
                FROM employees AS e1 JOIN employees AS e2 
                ON e1.""ChiefId"" = e2.""Id""
                WHERE e1.""Salary""> e2.""Salary"";")
                .ToList();
            
            //with LINQ
            var employees = _myContext.Employees
                .Where(e => e.Salary > e.Chief.Salary);
            
            return employees.Select(e => new EmployeeResponse
            {
                Id = e.Id,
                OfficeId = e.OfficeId,
                ChiefId = e.ChiefId,
                Salary = e.Salary,
                Name = e.Name
            }).ToList();
        }

        public int AddEmployee(EmployeeRequest employeeRequest)
        {
            var employeeOffice = _myContext.Offices.Find(employeeRequest.OfficeId);
            if (employeeOffice == null)
            {
                throw new EntityNotFoundException($"No such office with Id = {employeeRequest.OfficeId}");
            }

            if (employeeRequest.ChiefId != null)
            {
                var employeeChief = _myContext.Employees.Find(employeeRequest.ChiefId);
                if (employeeChief == null)
                {
                    throw new EntityNotFoundException($"No such Chief with Id = {employeeRequest.ChiefId}");
                }
            }
            
            var employee = new Employee
            {
                OfficeId = employeeRequest.OfficeId,
                ChiefId = employeeRequest.ChiefId,
                Salary = employeeRequest.Salary,
                Name = employeeRequest.Name
            };

            var entry = _myContext.Employees.Add(employee);
            _myContext.SaveChanges();
            return entry.Entity.Id;
        }

        public EmployeeService(MyContext myContext)
        {
            _myContext = myContext;
        }
        
        private readonly MyContext _myContext;
    }
}