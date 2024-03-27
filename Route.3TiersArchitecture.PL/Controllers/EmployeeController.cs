using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Route._3TiersArchitecture.BAL.Interface;
using Microsoft.Extensions.Hosting;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Linq;

namespace Route._3TiersArchitecture.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment Env, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _env = Env;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index(string searchInp)
        {

            var Employees = Enumerable.Empty<Employee>();

            if (string.IsNullOrEmpty(searchInp))
            {
                 Employees = _employeeRepository.GetAll();
                return View(Employees);
            }
            else
            {
                 Employees = _employeeRepository.GetAll();

                return View(Employees);
            }

        }


        [HttpGet]
        public IActionResult Create()
        {

            ViewData["Departments"] = _departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int? id, string Name = "EmployeeDetails")
        {
            if (!id.HasValue /*id is null*/)
                return BadRequest();//400 Bad request
            var department = _employeeRepository.GetSpecificEntity(id.Value);

            if (department is null)
                return NotFound();//404 Not Found

            return View(Name, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return EmployeeDetails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee entity)
        {
            if (id != entity.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(entity);

            try
            {
                var count = _employeeRepository.Update(entity);
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));
                }

                return View(entity);
            }

            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Something Went WrongDuring Update Department:(");

                return View(entity);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? Id, int id)
        {
            //_departmentsRepo.Delete(department);
            if (id != Id)
                return BadRequest();

            var department = _employeeRepository.GetSpecificEntity(id);

            if (department is null)
                return NotFound();//404 Not Found

            _employeeRepository.Delete(department);

            return RedirectToAction(nameof(Index));
        }



    }
}
