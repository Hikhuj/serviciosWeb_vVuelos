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
    public class UserController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: User
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.country).Include(u => u.role);
            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1");
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,email,old_password,new_password,first_name,middle_name,last_name,second_last_name,rol_id_FK,cards,consecutive_country_id,security_question1,answer1")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1", user.consecutive_country_id);
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name", user.rol_id_FK);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1", user.consecutive_country_id);
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name", user.rol_id_FK);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,email,old_password,new_password,first_name,middle_name,last_name,second_last_name,rol_id_FK,cards,consecutive_country_id,security_question1,answer1")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1", user.consecutive_country_id);
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name", user.rol_id_FK);
            return View(user);
        }

        public ActionResult ChangePassword(int? id) {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1", user.consecutive_country_id);
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name", user.rol_id_FK);
            return View(user);
        }

        public ActionResult Register() {
            return View();
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
