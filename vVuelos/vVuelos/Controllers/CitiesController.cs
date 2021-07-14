using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vVuelos.Classes;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: Cities
        public ActionResult Index()
        {
            return View(db.cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                city city = db.cities.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1");
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,consecutive_country_id_FK")] city city)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.cities.Add(city);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(city);
            }
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                city city = db.cities.Find(id);
                if (city == null)
                {
                    return HttpNotFound();
                }
                return View(city);
            }
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,consecutive_country_id_FK")] city city)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(city).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(city);
            }
            return RedirectToAction("Unauthorized", "Auth");
            
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
