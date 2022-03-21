using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IUserBL userBL;
        public EmployeeController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = userBL.getEmployeeList().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                userBL.addEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = userBL.getEmployeeById(id);
            userBL.deleteEmployee(employee);  
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = userBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id,  EmployeeModel employee)
        {
            if (id != employee.Emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.editEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
