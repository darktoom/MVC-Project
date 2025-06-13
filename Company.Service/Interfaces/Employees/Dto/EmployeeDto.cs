using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Http;

namespace Company.Service.Interfaces.Employees.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Hiringdate { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string ImageName { get; set; }

        public DepartmentDto Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
