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


        public IActionResult Create()
        {
            return View();
        }



    }
}
