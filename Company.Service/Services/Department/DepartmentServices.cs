using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository) 
        {
            _departmentRepository = departmentRepository;
        }

        public void add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code =department.Code,
                Name = department.Name,
                CeateAt=department.CeateAt
            };

            _departmentRepository.add(mappedDepartment);

        }

        public void delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
           var departments = _departmentRepository.GetAll();
            return departments;
        }

        public Department GetById(int? id)
        {
            if (id == null) {

                throw new Exception("id is null");
            }
            var department = _departmentRepository.GetById(id.Value);

            if (department == null) {
                return null;
            
            }
            return department;
        }

        public void update(Department department)
        {
           
            _departmentRepository.update(department);

        }
    }
}
