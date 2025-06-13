using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employees;
using Company.Service.Interfaces.Employees.Dto;
using Company.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        
      

        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            ViewBag.message = "hello from Employee Index";
            IEnumerable<EmployeeDto> employee =new List<EmployeeDto>();

            if (string.IsNullOrEmpty(searchInp))
            {

                var employees = _employeeService.GetAll();

                return View(employees);
            }
            else
            {


                var employees =_employeeService.GetEmployeeByName(searchInp);


                return View(employees);


            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments=_departmentService.GetAll();
            ViewBag.departments= departments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _employeeService.add(employee);
                    return RedirectToAction(nameof(Index));
                }



                return View(employee);
            }
            catch (Exception ex)
            {


                ModelState.AddModelError("Department error", ex.Message);
                return View(employee);
            }

        }
    }



}
