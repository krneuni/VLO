using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VLO.Models;

namespace VLO.Controllers
{
    public class AsignacionTurnosController : Controller
    {
        private Context db = new Context();

        // GET: AsignacionTurnos
        public ActionResult Index()
        {
            var asignacionTurno = db.AsignacionTurno.Include(a => a.Empleado).Include(a => a.Turnos);
            return View(asignacionTurno.ToList());
        }

        // GET: AsignacionTurnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionTurno asignacionTurno = db.AsignacionTurno.Find(id);
            if (asignacionTurno == null)
            {
                return HttpNotFound();
            }
            return View(asignacionTurno);
        }

        // GET: AsignacionTurnos/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre");
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "Nombre");
            return View();
        }

        // POST: AsignacionTurnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsignacion,IdTurno,IdEmpleado")] AsignacionTurno asignacionTurno)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionTurno.Add(asignacionTurno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", asignacionTurno.IdEmpleado);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "Nombre", asignacionTurno.IdTurno);
            return View(asignacionTurno);
        }

        // GET: AsignacionTurnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionTurno asignacionTurno = db.AsignacionTurno.Find(id);
            if (asignacionTurno == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", asignacionTurno.IdEmpleado);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "Nombre", asignacionTurno.IdTurno);
            return View(asignacionTurno);
        }

        // POST: AsignacionTurnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsignacion,IdTurno,IdEmpleado")] AsignacionTurno asignacionTurno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionTurno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", asignacionTurno.IdEmpleado);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "Nombre", asignacionTurno.IdTurno);
            return View(asignacionTurno);
        }

        // GET: AsignacionTurnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionTurno asignacionTurno = db.AsignacionTurno.Find(id);
            if (asignacionTurno == null)
            {
                return HttpNotFound();
            }
            return View(asignacionTurno);
        }

        // POST: AsignacionTurnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionTurno asignacionTurno = db.AsignacionTurno.Find(id);
            db.AsignacionTurno.Remove(asignacionTurno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
