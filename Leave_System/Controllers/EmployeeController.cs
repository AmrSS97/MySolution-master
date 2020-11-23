using Leave_System.Data;
using Leave_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Controllers
{
    public class EmployeeController : Controller
    {
        //Depemdency Injection
        ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> employees = _db.Employees.Include(e => e.Gender).ToList();
            return View(MapList(employees));
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = _db.Employees.Include(e => e.Gender).FirstOrDefault(e => e.Id == id);
            return View(Map(employee));
        }

        //GET
        public ActionResult Create()
        {
            var genders = _db.Genders.ToList();
            var genderitems = genders.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            EmployeeVM employee = new EmployeeVM
            {
                GenderItems = genderitems
            };
            return View(employee);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM employeeVM)
        {
            try
            {
                Employee employee = ReverseMap(employeeVM);
                _db.Employees.Add(employee);
                 _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(employeeVM);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var genders = _db.Genders.ToList();
            var genderitems = genders.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            Employee employee = _db.Employees.Include(e => e.Gender).FirstOrDefault(e => e.Id == id);
            EmployeeVM emp = Map(employee);
            emp.GenderItems = genderitems;
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeVM employee)
        {
            try
            {
 
                Employee emp = ReverseMap(employee);
                _db.Employees.Update(emp);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Something went wrong...");
                return View(employee);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _db.Employees.FirstOrDefault(e => e.Id == id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<EmployeeVM> MapList(List<Employee> employees)
        {
            List<EmployeeVM> employeelist = new List<EmployeeVM>();

            for(int i=0; i < employees.Count(); i++)
            {
                EmployeeVM Emp = Map(employees[i]);
                employeelist.Add(Emp);
            }

            return employeelist;
        }

        public EmployeeVM Map(Employee employee)
        {
            EmployeeVM emp = new EmployeeVM();
            emp.Id = employee.Id;
            emp.FullName = employee.fullname;
            emp.Email = employee.Email;
            emp.BirthDate = employee.Birthdate;
            emp.GenderName = employee.Gender.Name;

            return emp;
        }

        public Employee ReverseMap(EmployeeVM employeeVM)
        {
            Employee employee = new Employee();
            employee.Id = employeeVM.Id;
            employee.fullname = employeeVM.FullName;
            employee.Email = employeeVM.Email;
            employee.Birthdate = employeeVM.BirthDate;
            employee.GenderId = employeeVM.GenderId;

            return employee;
        }

     
      
    }
}
