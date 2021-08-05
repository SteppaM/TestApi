using System.Collections.Generic;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Api.Responses;

namespace RockStarEmployeesApi.Services
{
    public interface IOfficeService
    {
        IReadOnlyCollection<OfficeResponse> GetOffices();
        int AddOffice(OfficeRequest officeRequest);
    }
}