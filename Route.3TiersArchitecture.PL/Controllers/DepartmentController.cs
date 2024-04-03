using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Route._3TiersArchitecture.BAL.Interface;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.PL.Controllers
{

    // Inhertiance DepartmentController is a Controller
    // Association : DepartmentController has a DepartmentRepositorys
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepository _unitOfWork.DepartmentRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork,
            //IDepartmentRepository departmentsRepo,
            IWebHostEnvironment env)
            // Ask CLR for Creating an Object from Class Implmenting IDepartmentReposi
        {
            _unitOfWork = unitOfWork;
            //_unitOfWork.DepartmentRepository = departmentsRepo;
            _env = env;

            /*new DepartmentRepository();*/
        }

        public async Task< IActionResult> Index()
        {


            // Binding Through View's Dictionary: Transfer Data from Action to View [One Way]
            // 1. ViewData
            ViewData["Message"] = "Hello ViewData";
            // 2. ViewBag
            ViewBag.Message = "Hello ViewData";

            var deparments =await _unitOfWork.Repository<Department>().GetAllAsync();
            return View(deparments);
        }

        ///Department/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                 _unitOfWork.Repository<Department>().Add(department);
                var count = await _unitOfWork.Complete();
                // 3. TempData
                if (count > 0)
                    TempData["Message"] = "Department is Created Successfully";
                else
                    TempData["Message"] = "An Error Has Occured, Department Not Created :(";


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
            var department = _unitOfWork.Repository<Department>().GetSpecificEntity(id.Value);

            if (department is null)
                return NotFound();//404 Not Found

            return View(Name, department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ///if (!id.HasValue /*id is null*/)
            ///    return BadRequest();//400 Bad request
            ///var department = _unitOfWork.DepartmentRepository.GetSpecificDepartment(id.Value);
            ///
            ///if (department is null)
            ///    return NotFound();//404 Not Found
            ///
            ///return View(department);

            return DepartmentDetails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit([FromRoute] int id, Department entity)
        {
            if (id != entity.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(entity);

            try
            {
                _unitOfWork.Repository<Department>().Update(entity);
                var count =await _unitOfWork.Complete();

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
        public async Task <IActionResult> Delete([FromRoute] int? Id, int id)
        {
            //_unitOfWork.DepartmentRepository.Delete(department);
            if (id != Id)
                return BadRequest();

            var department = await _unitOfWork.Repository<Department>().GetSpecificEntity(id);

            if (department is null)
                return NotFound();//404 Not Found

            _unitOfWork.Repository<Department>().Delete(department);

            return RedirectToAction(nameof(Index));
        }



    }
}
