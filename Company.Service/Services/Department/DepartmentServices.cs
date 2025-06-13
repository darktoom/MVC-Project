using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void add(DepartmentDto department)
        {
            var mappedDepartment = new DepartmentDto
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = department.CreateAt
            };

            _unitOfWork.DepartmentRepository.add(mappedDepartment);

            _unitOfWork.Complete();
        }

        public void delete(DepartmentDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
           var departments =_unitOfWork.DepartmentRepository.GetAll();
            return departments;

           
        }

        public Department GetById(int? id)
        {
            if (id == null) {

                throw new Exception("id is null");
            }
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department == null) {
                return null;
            
            }
            return department;
        }

        public void update(Department department)
        {
           
           _unitOfWork.DepartmentRepository.update(department);

            _unitOfWork.Complete();
        }
    }
}
