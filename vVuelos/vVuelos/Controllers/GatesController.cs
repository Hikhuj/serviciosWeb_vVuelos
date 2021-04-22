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
    public class GatesController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: Gates
        public ActionResult Index()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                return View(db.airport_gates.ToList());
            }
            return RedirectToAction("Unauthorized", "Auth");

        }

        // GET: Gates/Details/5
        public ActionResult Details(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                airport_gates airport_gates = db.airport_gates.Find(id);
                if (airport_gates == null)
                {
                    return HttpNotFound();
                }
                return View(airport_gates);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // GET: Gates/Create
        public ActionResult Create()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // POST: Gates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consecutive_airport_gate_id,number,status")] airport_gates airport_gates)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.sp_add_gates(airport_gates.number, airport_gates.status);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(airport_gates);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // GET: Gates/Edit/5
        public ActionResult Edit(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                airport_gates airport_gates = db.airport_gates.Find(id);
                if (airport_gates == null)
                {
                    return HttpNotFound();
                }
                return View(airport_gates);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // POST: Gates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consecutive_airport_gate_id,number,status")] airport_gates airport_gates)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(airport_gates).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(airport_gates);
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
