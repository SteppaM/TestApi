using System.Collections.Generic;
using System.Linq;
using RockStarEmployeesApi.Api.Requests;
using RockStarEmployeesApi.Api.Responses;
using RockStarEmployeesApi.Persistence;
using RockStarEmployeesApi.Persistence.Models;

namespace RockStarEmployeesApi.Services
{
    public class OfficeService : IOfficeService
    {
        public IReadOnlyCollection<OfficeResponse> GetOffices()
        {
            var offices = _myContext.Offices;
            return offices.Select(e => new OfficeResponse { Id = e.Id, Name = e.Name}).ToList();
        }

        public int AddOffice(OfficeRequest officeRequest)
        {
            var office = new Office
            {
                Name = officeRequest.Name
            };

            var entry = _myContext.Offices.Add(office);
            _myContext.SaveChanges();
            return entry.Entity.Id;
        }

        public OfficeService(MyContext myContext)
        {
            _myContext = myContext;
        }

        private readonly MyContext _myContext;
    }
}