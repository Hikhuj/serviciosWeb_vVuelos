using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    public class airlinesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: airlines
        public ActionResult Index()
        {
            var airlines = db.airlines.Include(a => a.country);
            return View(airlines.ToList());
        }

        // GET: airlines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airline airline = db.airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            return View(airline);
        }

        // GET: airlines/Create
        public ActionResult Create()
        {
            ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1");
            return View();
        }

        // POST: airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consecutive_airline_id,name,consecutive_country_id_FK,image,status")] airline airline)
        {
            if (ModelState.IsValid)
            {
                db.sp_add_airline(airline.name,airline.consecutive_country_id_FK,airline.image,airline.status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1", airline.consecutive_country_id_FK);
            return View(airline);
        }

        // GET: airlines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            airline airline = db.airlines.Find(id);
            if (airline == null)
            {
                return HttpNotFound();
            }
            ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1", airline.consecutive_country_id_FK);
            return View(airline);
        }

        // POST: airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consecutive_airline_id,name,consecutive_country_id_FK,image,status")] airline airline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1", airline.consecutive_country_id_FK);
            return View(airline);
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
