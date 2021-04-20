﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    public class AuthController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string new_password)
        {

            if (username != null && new_password != null)
            {
                user currentUser = db.users.Where(m => m.username == username).FirstOrDefault();
                if (currentUser != null && currentUser.username == username && currentUser.new_password.Equals(new_password))
                {
                    //creating authentication ticket (will go insde the cookie)
                    var authTicket = new FormsAuthenticationTicket(
                          1,
                          currentUser.id.ToString(),  //user id
                          DateTime.Now,
                          DateTime.Now.AddMinutes(15),  // expiry after 15 minutes of not using the system
                          false,  //true to remember -> REMEMBER ME OPTION
                          "", //roles 
                          "/"
                        ) ;
                    //encrypt the ticket and add it to a cookie
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "usuario or contraseña incorrecta";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "Por favor llene los campos";
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}