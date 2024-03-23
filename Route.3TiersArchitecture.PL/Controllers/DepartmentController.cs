using Microsoft.AspNetCore.Mvc;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Models_Services_;

namespace Route._3TiersArchitecture.PL.Controllers
{

    // Inhertiance DepartmentController is a Controller
    // Association : DepartmentController has a DepartmentRepositorys
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo;

        public DepartmentController(IDepartmentRepository departmentsRepo)// Ask CLR for Creating an Object from Class Implmenting IDepartmentReposi
        {
            _departmentsRepo = departmentsRepo;

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
         
        public IActionResult DepartmentDetails(int? id)
        {
            if (!id.HasValue /*id is null*/)
                return BadRequest();//400 Bad request
            var department=_departmentsRepo.GetSpecificDepartment(id.Value);

            if (department is null  )
                return NotFound();//404 Not Found

            return View(department);
        }

    }
}
