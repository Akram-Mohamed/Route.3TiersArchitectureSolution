using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;

namespace Route._3TiersArchitecture.PL.Controllers
{

    // Inhertiance DepartmentController is a Controller
    // Association : DepartmentController has a DepartmentRepositorys
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository departmentsRepo, IWebHostEnvironment env)// Ask CLR for Creating an Object from Class Implmenting IDepartmentReposi
        {
            _departmentsRepo = departmentsRepo;
            _env = env;

            /*new DepartmentRepository();*/
        }

        public IActionResult Index()
        {
            var deparments = _departmentsRepo.GetAll();
            return View(deparments);
        }

        ///Department/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _departmentsRepo.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult DepartmentDetails(int? id, string Name = "DepartmentDetails")
        {
            if (!id.HasValue /*id is null*/)
                return BadRequest();//400 Bad request
            var department = _departmentsRepo.GetSpecificEntity(id.Value);

            if (department is null)
                return NotFound();//404 Not Found

            return View(Name, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ///if (!id.HasValue /*id is null*/)
            ///    return BadRequest();//400 Bad request
            ///var department = _departmentsRepo.GetSpecificDepartment(id.Value);
            ///
            ///if (department is null)
            ///    return NotFound();//404 Not Found
            ///
            ///return View(department);

            return DepartmentDetails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department entity)
        {
            if (id != entity.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(entity);

            try
            {
                var count = _departmentsRepo.Update(entity);
                if (count > 0)
                {

                    return RedirectToAction(nameof(Index));
                }

                return View(entity);
            }

            catch (Exception ex)
            {
                // 1. Log Exception
                // 2. Friendly Message

                //ModelState.AddModelError(string.Empty, ex.Message);

                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Something Went WrongDuring Update Department:(");

                return View(entity);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? department_Id, int id)
        {
            //_departmentsRepo.Delete(department);
            if (id != department_Id)
                return BadRequest();

            var department = _departmentsRepo.GetSpecificEntity(id);

            if (department is null)
                return NotFound();//404 Not Found

            _departmentsRepo.Delete(department);

            return RedirectToAction(nameof(Index));
        }



    }
}
