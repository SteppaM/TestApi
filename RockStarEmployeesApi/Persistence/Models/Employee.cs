namespace RockStarEmployeesApi.Persistence.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int? ChiefId { get; set; }
        public Employee Chief { get; set; }
    }
}