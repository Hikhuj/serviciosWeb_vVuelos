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
    public class ConsecutiveController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: Consecutive
        public ActionResult Index()
        {
            return View(db.consecutives.ToList());
        }

        // GET: Consecutive/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consecutive consecutive = db.consecutives.Find(id);
            if (consecutive == null)
            {
                return HttpNotFound();
            }
            return View(consecutive);
        }

        // GET: Consecutive/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consecutive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,value,prefix,range_int,range_out")] consecutive consecutive)
        {
            if (ModelState.IsValid)
            {
                db.sp_create_consecutive(consecutive.description, consecutive.value, consecutive.prefix, consecutive.range_int, consecutive.range_out);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consecutive);
        }

        // GET: Consecutive/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consecutive consecutive = db.consecutives.Find(id);
            if (consecutive == null)
            {
                return HttpNotFound();
            }
            return View(consecutive);
        }

        // POST: Consecutive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,value,prefix,range_int,range_out")] consecutive consecutive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consecutive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consecutive);
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
