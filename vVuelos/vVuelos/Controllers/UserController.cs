using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vVuelos.Models;
using vVuelos.Classes;

namespace vVuelos.Controllers
{
    public class UserController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        public object EncryptData { get; private set; }

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.country).Include(u => u.role);
            return View(users.ToList());
        }

        //GET: User/Profile
        [Authorize]
        public ActionResult Perfil() {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            user currentUser = db.users.Find(currentUserId);
            return View(currentUser);
        }

        // GET: User/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1");
            ViewBag.rol_id_FK = new SelectList(db.roles, "id", "name");
            return View();
        }

        // POST: User/Create
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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


        //GET
        [Authorize]
        public ActionResult ChangePassword() {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string old_password, string new_password) {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            user user = db.users.Find(currentUserId);
            string pw = Encryption.DecryptData(user.new_password);
            if (pw.Equals(old_password))
            {
                int status = db.sp_update_password(currentUserId, old_password, Encryption.EncryptData(new_password));
                if (status == 0)
                {
                    ViewBag.message = "Error al cambiar la contraseña, asegurese cumple con los requisitos de sistema.";
                }
                else
                {
                    ViewBag.message = "Contraseña actualizada correctamente";
                }
            }
            else { ViewBag.message = "Verificacion fallida"; }

            
            return View();
        }

        //GET
        public ActionResult Register() {
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1");
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "id,username,email,old_password,new_password,first_name,middle_name,last_name,second_last_name,rol_id_FK,cards,consecutive_country_id,security_question1,answer1")] user user)
        {
            if (ModelState.IsValid)
            {
                string passwordEnc = Encryption.EncryptData(user.new_password);
                int status = db.sp_add_user(user.username, user.email, passwordEnc, user.first_name, user.middle_name, user.last_name, user.second_last_name, user.security_question1, user.consecutive_country_id, user.answer1);
                if (status > 0)
                {
                    return RedirectToAction("Login", "Auth", null);
                }
            }
            ViewBag.consecutive_country_id = new SelectList(db.countries, "consecutive_country_id", "name1", user.consecutive_country_id);
            return View(user);
            
        }

        //GET
        [Authorize]
        public ActionResult UpdateInformation() {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            user currentUser = db.users.Find(currentUserId);
            return View(currentUser);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateInformation([Bind(Include = "username, email, first_name, middle_name, last_name,second_last_name")]user user) {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            int status = db.sp_update_user_information(currentUserId, user.username, user.email, user.first_name, user.middle_name, user.last_name, user.second_last_name);
            if (status == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.message = "La informacion ha sido actualizada";
            return RedirectToAction("Perfil");
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
