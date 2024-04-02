using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Route._3TiersArchitecture.BAL.Interface;
using Microsoft.Extensions.Hosting;
using Route._3TiersArchitecture.BAL.Repositries;
using Route._3TiersArchitecture.DAL.Models_Services_;
using System;
using System.Linq;
using Route._3TiersArchitecture.PL.Models;
using AutoMapper;
using System.Collections.Generic;
using Route._3TiersArchitecture.PL.Helpers;

namespace Route._3TiersArchitecture.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;
        //private readonly IEmployeeRepository _unitOfWork.EmployeeRepository;
        private readonly IWebHostEnvironment _env;
        // private readonly IDepartmentRepository _departmentRepository;



        public EmployeeController(IUnitOfWork unitOfWork,
            IMapper Mapper,
            /* IEmployeeRepository employeeRepository,*/
            IWebHostEnvironment Env
           /* IDepartmentRepository departmentRepository*/)
        {
            _Mapper = Mapper;
            _env = Env;
            _unitOfWork = unitOfWork;
            //_unitOfWork.EmployeeRepository = employeeRepository;
            // _departmentRepository = departmentRepository;
        }

        public IActionResult Index(string searchInp)
        {
            #region ViewBag &ViewData
            //// Binding Through View's Dictionary: Transfer Data from Action to View [One Way]
            //// 1. ViewData
            //ViewData["Message"] = "Hello ViewData";
            //// 2. ViewBag
            //ViewBag.Message = "Hello ViewData"; 
            #endregion

            var Employees = Enumerable.Empty<Employee>();
            var employeeRepo = _unitOfWork.Repository<Employee>() as EmployeeRepository;

            if (string.IsNullOrEmpty(searchInp))
                Employees = employeeRepo.GetAll();
            else
                Employees = employeeRepo.SearchByName(searchInp.ToLower());


            //Employees = _unitOfWork.Repository<Employee>().GetAll();
            var EmployeeMapped = _Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);
            return View(EmployeeMapped);

        }


        [HttpGet]
        public IActionResult Create()
        {

            //ViewData["Departments"] = _departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                employeeVM.ImageName = DocumentUploader.UploadFile(employeeVM.Image, "images");


                // Manual Mapping
                ///var mappedEmp = new Employee()
                ///{
                ///    Name = employeeVM.Name,
                ///    Age = employeeVM.Age,
                ///    Address = employeeVM.Address,
                ///    Salary = employeeVM.Salary,
                ///    Email = employeeVM.Email,
                ///    PhoneNumber = employeeVM.PhoneNumber,
                ///    ISActive = employeeVM.ISActive,
                ///    HiringDate = employeeVM.HiringDate,
                ///};

                var EmployeeMapped = _Mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                _unitOfWork.Repository<Employee>().Add(EmployeeMapped);
                var count = _unitOfWork.Complete();

                //EmployeeMapped.ImageName = FileName;

                /// 2. Update Department
                ///_unitOfWork.Repository<Employee>().Update(department);
                /// 3. Delete Project
                /// _unitOfWork.Repository<Employee>().Remove(project);
                ///_dbContext.SaveChanges(); unitOfWork.Complete();
                ///var count = _unitOfWork.Repository<Employee>().Add(employee);

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employeeVM);
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int? id, string Name = "EmployeeDetails")
        {
            if (!id.HasValue /*id is null*/)
                return BadRequest();//400 Bad request
            var employee = _unitOfWork.Repository<Employee>().GetSpecificEntity(id.Value);
            var EmployeeMapped = new Object();

            if (Name.Equals("Edit"))
            { EmployeeMapped = _Mapper.Map<Employee, EmployeeViewModel>(employee); }
            else
            {
                EmployeeMapped = _Mapper.Map<Employee, EmployeeResponseViewModel>(employee);
            }

            if (employee is null)
                return NotFound();//404 Not Found

            return View(Name, EmployeeMapped);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return EmployeeDetails(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel entity)
        {
            if (id != entity.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(entity);

            try
            {
                var EmployeeMapped = _Mapper.Map<EmployeeViewModel, Employee>(entity);
                _unitOfWork.Repository<Employee>().Update(EmployeeMapped);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Employee"] = "Employee Had Updated Successfully";
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
            var Employee = new Employee();
            try
            {

                Employee = _unitOfWork.Repository<Employee>().GetSpecificEntity(id);

                if (Employee is null)
                    return NotFound();//404 Not Found

                _unitOfWork.Repository<Employee>().Delete(Employee);
                var count = _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));

            }

            catch (Exception ex)
            {
                // 1. Log Exception
                // 2. Show Friendly Message
                ModelState.AddModelError(string.Empty, ex.Message);
                var EmployeeMapped = _Mapper.Map<Employee, EmployeeResponseViewModel>(Employee);
                return View(Employee);
            }


        }



    }
}
