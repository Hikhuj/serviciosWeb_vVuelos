using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    public class countriesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: countries
        public ActionResult Index()
        {
            return View(db.countries.ToList());
        }

        // GET: countries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string name1, HttpPostedFileBase image)
        {
            country country = new country();
            country.name1 = name1;
            country.image = "~/img/Flags/" + image.FileName;
            int affectedRows = db.sp_add_country(
                        country.name1,
                        country.image);
            if (affectedRows>0)
            {
                string path = Path.Combine(Server.MapPath("~/img/Flags/"), Path.GetFileName(image.FileName));
                image.SaveAs(path);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: countries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string consecutive_country_id, string name1, HttpPostedFileBase image, string currentImage)
        {
            country country = new country();
            country.consecutive_country_id = consecutive_country_id;
            country.name1 = name1;
            country.image = "~/img/Flags/" + image.FileName;
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                string path = Path.Combine(Server.MapPath("~/img/Flags/"), Path.GetFileName(image.FileName));
                image.SaveAs(path);
                return RedirectToAction("Index");
            }
            return View(country);
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
