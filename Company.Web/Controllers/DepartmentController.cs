using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.add(department);
                    return RedirectToAction(nameof(Index));
                }

                

                return View(department);
            }
            catch (Exception ex)
            {


                ModelState.AddModelError("Department error", ex.Message);
                return View(department);
            }


          
        }

        public IActionResult Details(int id ,string viewName="Details")
        {
            var department =_departmentService.GetById(id);

            if (department == null)
              return RedirectToAction("NotFoundPage",null,"Home");



            return View(viewName,department);


        }

        [HttpGet]
        public IActionResult Update(int id) {


            return Details(id, "Update"); 

        }
        [HttpPost]
        public IActionResult Update(int id, Department department) {

            if (department.Id != id)
            
                return RedirectToAction("NotFoundPage", null, "Home");



            _departmentService.update(department);

            return RedirectToAction(nameof(Index));
        }


    }
}
