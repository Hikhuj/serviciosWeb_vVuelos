using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class airlinesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: airlines
        public ActionResult Index()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                var airlines = db.airlines.Include(a => a.country);
                return View(airlines.ToList());
            }
            return RedirectToAction("Unauthorized", "Auth");
         
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
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1");
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // POST: airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, string consecutive_country_id_FK,HttpPostedFileBase image, bool status)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                airline airline = new airline(name, consecutive_country_id_FK, "~/img/Airline/" + image.FileName, status);
                airline.image = "~/img/Airline/" + image.FileName;
                if (ModelState.IsValid)
                {
                    int affectedRows = db.sp_add_airline(airline.name, airline.consecutive_country_id_FK, airline.image, airline.status);
                    if (affectedRows > 0)
                    {
                        string path = Path.Combine(Server.MapPath("~/img/Airline/"), Path.GetFileName(image.FileName));
                        image.SaveAs(path);
                        return RedirectToAction("Index");
                    }

                }

                ViewBag.consecutive_country_id_FK = new SelectList(db.countries, "consecutive_country_id", "name1", airline.consecutive_country_id_FK);
                return View(airline);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // GET: airlines/Edit/5
        public ActionResult Edit(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
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
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // POST: airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consecutive_airline_id,name,consecutive_country_id_FK,image,status")] airline airline)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
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
