using Leave_System.Data;
using Leave_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Controllers
{
    public class VacationAllocationController : Controller
    {
        ApplicationDbContext _db;
       

        public VacationAllocationController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: VacationAllocationController
        public ActionResult Index()
        {
            List<VacationRequest> requests = _db.VacationRequests.ToList();

            foreach(var request in requests)
            {
               

                if (request.Status == true )
                {
                    if(!_db.VacationAllocations.Any(q => q.EmployeeId == request.EmployeeId && q.VacationTypeId == request.VacationTypeId))
                    {
                        VacationAllocation allocation = new VacationAllocation();
                        allocation.Employee = request.Employee;
                        allocation.EmployeeId = request.EmployeeId;
                        allocation.VacationType = request.VacationType;
                        allocation.VacationTypeId = request.VacationTypeId;
                        allocation.Used++;

                        _db.VacationAllocations.Add(allocation);
                        _db.SaveChanges();
                    }
                    else
                    {
                        VacationAllocation allocation = _db.VacationAllocations.FirstOrDefault(q => q.EmployeeId == request.EmployeeId && q.VacationTypeId == request.VacationTypeId);
                        allocation.Used++;
                        _db.VacationAllocations.Update(allocation);
                        _db.SaveChanges();
                    }
                   
                }

              
            }

            List<VacationAllocationVM> alloc = Maplist(_db.VacationAllocations.ToList());
            return View(alloc);
        }

        // GET: VacationAllocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VacationAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacationAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VacationAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VacationAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VacationAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VacationAllocationController/Delete/5
        [HttpPost]
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

        public List<VacationAllocationVM> Maplist(List<VacationAllocation> list)
        {
            List<VacationAllocationVM> alloc_list = new List<VacationAllocationVM>();
            for (int i=0; i< list.Count(); i++) {
                VacationAllocationVM obj = new VacationAllocationVM();
                obj = Map(list[i]);
                alloc_list.Add(obj);
            }

            return alloc_list;
        }

        public VacationAllocationVM Map(VacationAllocation allocation)
        {
            VacationAllocationVM obj = new VacationAllocationVM();
            obj.Id = allocation.Id;
            obj.EmployeeId = allocation.EmployeeId;
            obj.VacationTypeId = allocation.VacationTypeId;
            obj.Used = allocation.Used;
            obj.EmployeeName = _db.Employees.Find(allocation.EmployeeId).fullname;
            obj.VacationTypeName = _db.VacationTypes.Find(allocation.VacationTypeId).Name;

            return obj;
        }

        public bool isExists(int id)
        {
            var exists = _db.VacationAllocations.Any(q => q.Id == id);
            return exists;
        }

    }
}
