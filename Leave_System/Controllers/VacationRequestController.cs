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
    public class VacationRequestController : Controller
    {
        ApplicationDbContext _db;

        public VacationRequestController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: VacationRequestController
        public ActionResult Index()
        {
            List<VacationRequest> requests = _db.VacationRequests.Include(q => q.Employee).Include(q => q.VacationType).ToList();
            List<VacationRequestVM> requestsVM = Maplist(requests);
            return View(requestsVM);
        }

        // GET: VacationRequestController/Details/5
        public ActionResult Review(int id)
        {

            VacationRequestVM request = new VacationRequestVM();
            VacationRequest vacationrequest = _db.VacationRequests.Include(q => q.Employee).Include(q => q.VacationType).FirstOrDefault(q => q.Id == id);
            request = ReverseMap(vacationrequest);

            return View(request);
        }

        //POST:Status
        public ActionResult ApproveRequest(int id)
        {
            VacationRequest request = _db.VacationRequests.Find(id);
            request.Status = true;
            _db.VacationRequests.Update(request);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //POST:Status
        public ActionResult RejectRequest(int id)
        {
            VacationRequest request = _db.VacationRequests.Find(id);
            request.Status = false;
            _db.VacationRequests.Update(request);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: VacationRequestController/Create
        public ActionResult Create(int id)
        {
            VacationRequestVM requestVM = new VacationRequestVM();
            var vacationtypes = _db.VacationTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            requestVM.vacationtypes = vacationtypes;
            return View(requestVM);
        }

        // POST: VacationRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationRequestVM requestVM, int id)
        {
            try
            {
                requestVM.Id = 0;
                requestVM.EmployeeId = id;
                requestVM.EmployeeName = _db.Employees.Find(requestVM.EmployeeId).fullname;
                requestVM.VacationTypeName = _db.VacationTypes.Find(requestVM.VacationTypeId).Name;
                requestVM.DateRequested = DateTime.Now;
                requestVM.Status = false;
                requestVM.Cancelled = false;
               

                var vacationtypes = _db.VacationTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });

                requestVM.vacationtypes = vacationtypes;
                VacationRequest request = Map(requestVM);
             

                _db.VacationRequests.Add(request);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(requestVM);
            }
        }

        // GET: VacationRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            VacationRequest request = _db.VacationRequests.Include(q => q.Employee).Include(q => q.VacationType).FirstOrDefault(q => q.Id == id);
            VacationRequestVM requestVM = ReverseMap(request);
            var vacationtypes = _db.VacationTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            requestVM.vacationtypes = vacationtypes;

            return View(requestVM);
        }

        // POST: VacationRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VacationRequestVM requestVM)
        {
            try
            {
                var vacationtypes = _db.VacationTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                requestVM.vacationtypes = vacationtypes;

                VacationRequest request = Map(requestVM);
                _db.VacationRequests.Update(request);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(requestVM);
            }
        }

        // GET: VacationRequestController/Delete/5
        public ActionResult Delete(int id)
        {

            VacationRequest request = _db.VacationRequests.Find(id);
            _db.VacationRequests.Remove(request);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: VacationRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Delete(VacationRequestVM model)
        {
          
                VacationRequest request = _db.VacationRequests.Find(id);
                _db.VacationRequests.Remove(request);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
        }*/
        public List<VacationRequestVM> Maplist(List<VacationRequest> list)
        {
            List<VacationRequestVM> listVM = new List<VacationRequestVM>();
            for (int i = 0; i < list.Count(); i++)
            {
              
                VacationRequestVM obj = ReverseMap(list[i]);
                listVM.Add(obj);
            }
            return listVM;
        }

        public VacationRequest Map(VacationRequestVM requestVM)
        {
            VacationRequest obj = new VacationRequest();

            obj.Id = requestVM.Id;
            obj.VacationAllocationId = requestVM.Id;
            obj.EmployeeId = requestVM.EmployeeId;
            obj.Employee = _db.Employees.Find(requestVM.EmployeeId);
            obj.StartDate = requestVM.StartDate;
            obj.EndDate = requestVM.EndDate;
            obj.VacationTypeId = requestVM.VacationTypeId;
            obj.VacationType = _db.VacationTypes.Find(requestVM.VacationTypeId);
            obj.Cancelled = requestVM.Cancelled;
            obj.Status = requestVM.Status;


            return obj;

        }

        public VacationRequestVM ReverseMap(VacationRequest request)
        {
            VacationRequestVM obj = new VacationRequestVM();
            obj.Id = request.Id;
            obj.EmployeeId = request.EmployeeId;
            obj.EmployeeName = _db.Employees.Find(request.EmployeeId).fullname;
            obj.VacationTypeId = request.VacationTypeId;
            obj.VacationTypeName = _db.VacationTypes.Find(request.VacationTypeId).Name;
            obj.StartDate = request.StartDate;
            obj.EndDate = request.EndDate;
            obj.DateRequested = request.DateRequested;
            obj.Status = request.Status;

            return obj;
        }

    }
}