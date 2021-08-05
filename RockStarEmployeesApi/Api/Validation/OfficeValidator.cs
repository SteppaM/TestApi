using FluentValidation;
using RockStarEmployeesApi.Api.Requests;

namespace RockStarEmployeesApi.Api.Validation
{
    public class OfficeValidator : AbstractValidator<OfficeRequest>
    {
        public OfficeValidator()
        {
            RuleFor(o => o.Name).NotEmpty();
        }
    }
}