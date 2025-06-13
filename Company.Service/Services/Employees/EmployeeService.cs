using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces.Employees;
using Company.Service.Interfaces.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.Employees
{
public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void add(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,Email = employeeDto.Email,Hiringdate = employeeDto.Hiringdate,
            //    ImageUrl = employeeDto.ImageUrl,Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,





            //};
            //var mappedemployee = new EmployeeDto
            //{

            //    Name = employee.Name,
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    PhoneNumber = employee.PhoneNumber,
            //    Hiringdate = employee.Hiringdate,
            //    Salary = employee.Salary,
            //    Email = employee.Email,

            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.add(employee);

            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //  var mappedemployees = employees.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    Hiringdate = x.Hiringdate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id



            //});
          IEnumerable  <EmployeeDto> mappedemployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);


            return mappedemployees;

        }

        public EmployeeDto GetById(int? id)
        {
            if (id == null)
            {

                throw new Exception("id is null");
            }
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee == null)
            {
                return null;

            }
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    Hiringdate = employee.Hiringdate,
            //    ImageUrl = employee.ImageUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    Id= employee.Id,
               





            //};


            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        { 


       var employees= _unitOfWork.EmployeeRepository.GetEmployeeByName(name);

            //var mappedemployees = employees.Select(x => new EmployeeDto
            //{
            //    Address = x.Address,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    Hiringdate = x.Hiringdate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id



            //});

            IEnumerable<EmployeeDto> mappedemployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedemployees;


        }

        public void remove(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public void update(EmployeeDto employee)
        {
           // _unitOfWork.EmployeeRepository.update(employee);

            _unitOfWork.Complete();
        }
    }
}
