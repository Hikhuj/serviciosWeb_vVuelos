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
    public class countriesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: countries
        public ActionResult Index()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                return View(db.countries.ToList());
            }
            return RedirectToAction("Unauthorized", "Auth");
        }

        // GET: countries/Details/5
        public ActionResult Details(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
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
            return RedirectToAction("Unauthorized", "Auth");
        }

        // GET: countries/Create
        public ActionResult Create()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");   
        }

        // POST: countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string name1, HttpPostedFileBase image)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                country country = new country();
                country.name1 = name1;
                country.image = "~/img/Flags/" + image.FileName;
                int affectedRows = db.sp_add_country(
                            country.name1,
                            country.image);
                if (affectedRows > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/img/Flags/"), Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            return RedirectToAction("Unauthorized", "Auth");
        }

        // GET: countries/Edit/5
        public ActionResult Edit(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
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
            return RedirectToAction("Unauthorized", "Auth");
        }

        // POST: countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string consecutive_country_id, string name1, HttpPostedFileBase image, string currentImage)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
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
