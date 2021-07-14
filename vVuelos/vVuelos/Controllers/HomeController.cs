using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vVuelos.Classes;
using vVuelos.Models;

namespace vVuelos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Console()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId,db))
            {
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");
        }
    }
}
