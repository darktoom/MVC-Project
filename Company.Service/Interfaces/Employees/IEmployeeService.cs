using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Entities;
using Company.Service.Interfaces.Employees.Dto;

namespace Company.Service.Interfaces.Employees
{
   public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);

        IEnumerable<EmployeeDto> GetAll();

        void add(EmployeeDto employee);
        void remove(EmployeeDto employee);
       
        void update(EmployeeDto employee);
        public IEnumerable<EmployeeDto> GetEmployeeByName(string name);

    }
}
