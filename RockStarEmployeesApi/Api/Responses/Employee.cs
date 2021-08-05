namespace RockStarEmployeesApi.Api.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int OfficeId { get; set; }
        public int? ChiefId { get; set; }
    }
}