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
    public class HExtrasController : Controller
    {
        private Context db = new Context();

        // GET: HExtras
        public ActionResult Index()
        {
            var hExtras = db.HExtras.Include(h => h.Empleado);
            return View(hExtras.ToList());
        }

        // GET: HExtras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtras hExtras = db.HExtras.Find(id);
            if (hExtras == null)
            {
                return HttpNotFound();
            }
            return View(hExtras);
        }

        // GET: HExtras/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre");
            return View();
        }

        // POST: HExtras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExtras,Cantidad,IdEmpleado, TotalSalario")] HExtras hExtras)
        {
            if (ModelState.IsValid)
            {
                db.HExtras.Add(hExtras);
                db.SaveChanges();
                

                double horas = hExtras.Cantidad;

                if (horas == 3)
                {
                    hExtras.TotalSalario = horas * 3;
                }
                if (horas>6)
                {

                    hExtras.TotalSalario = horas * 6;
                }
                else
                {
                    ViewBag.error = "Error";
                }
                
                db.Entry(hExtras).State = EntityState.Modified;
                db.SaveChanges();

                //var Sal = (from p in db.Empleado where p.IdEmpleado == hExtras.IdEmpleado select p).FirstOrDefault();
                //double Pago = Sal.Salario;
                //double PagooHoras = hExtras.TotalSalario;

                //hExtras.TotalSalario = Pago + PagooHoras;
                //db.Entry(hExtras).State = EntityState.Modified;
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", hExtras.IdEmpleado);
            return View(hExtras);
        }

        // GET: HExtras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtras hExtras = db.HExtras.Find(id);
            if (hExtras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", hExtras.IdEmpleado);
            return View(hExtras);
        }

        // POST: HExtras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExtras,Cantidad,IdEmpleado, TotalSalario")] HExtras hExtras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hExtras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleado, "IdEmpleado", "Nombre", hExtras.IdEmpleado);
            return View(hExtras);
        }

        // GET: HExtras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HExtras hExtras = db.HExtras.Find(id);
            if (hExtras == null)
            {
                return HttpNotFound();
            }
            return View(hExtras);
        }

        // POST: HExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HExtras hExtras = db.HExtras.Find(id);
            db.HExtras.Remove(hExtras);
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
