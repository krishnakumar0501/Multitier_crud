using BusinessLogicLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Multitier_crud.Controllers
{
    public class EmployeeController : Controller
    {
        public BLEmployeeBussiness bussiness=new BLEmployeeBussiness();
        public IActionResult Index()
        {
            var emp=bussiness.GetEmployees();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee empolyee)
        {
            var emp=bussiness.InsertEmployee(empolyee);
            if(emp)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "error in create employee");
                return View(empolyee);
            }
            
        }

        public IActionResult Delete(int id)
        {
            var emp=bussiness.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var emp = bussiness.UpdateEmployee(employee);
            return RedirectToAction("Index");

        }
    }
}
