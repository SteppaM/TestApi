namespace RockStarEmployeesApi.Api.Requests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int OfficeId { get; set; }
        public int? ChiefId { get; set; }
    }
}