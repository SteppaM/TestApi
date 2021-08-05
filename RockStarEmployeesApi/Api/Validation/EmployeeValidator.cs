using FluentValidation;
using RockStarEmployeesApi.Api.Requests;

namespace RockStarEmployeesApi.Api.Validation
{
    public class EmployeeValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.OfficeId).NotEmpty();
        }
    }
}