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
    public class VacationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VacationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: VacationTypeController
        public ActionResult Index()
        {
            List<VacationType> vacationtypes = _db.VacationTypes.ToList();
            return View(vacationtypes);
        }

        // GET: VacationTypeController/Details/5
        public ActionResult Details(int id)
        {
            VacationType vacationtype = _db.VacationTypes.Find(id);
            var model = ReverseMap(vacationtype);
            return View(model);
        }

        // GET: VacationTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacationTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationTypeVM model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                VacationType vacationType = new VacationType();
                vacationType = Map(model);
                _db.VacationTypes.Add(vacationType);
                _db.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: VacationTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var vacationtype = _db.VacationTypes.Find(id);
            VacationTypeVM model = ReverseMap(vacationtype);

            return View(model);

        }

        // POST: VacationTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(VacationTypeVM model)
        {
            try
            {
               
                VacationType vacationtype = Map(model);
                _db.VacationTypes.Update(vacationtype);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: VacationTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            VacationType vacationtype = _db.VacationTypes.Find(id);
            _db.VacationTypes.Remove(vacationtype);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // POST: VacationTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VacationTypeVM model)
        {
            return View(model);
        }
        public VacationType Map(VacationTypeVM model)
        {
            VacationType vacationtype = new VacationType();
            vacationtype.Id = model.Id;
            vacationtype.Name = model.Name;
            vacationtype.Balance = model.Balance;
            return vacationtype;
        }

        public VacationTypeVM ReverseMap(VacationType vacation)
        {
            VacationTypeVM model = new VacationTypeVM();
            model.Id = vacation.Id;
            model.Name = vacation.Name;
            model.Balance = vacation.Balance;
            return model;
        }

    }
}
