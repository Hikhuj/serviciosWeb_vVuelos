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
    public class flightsController : Controller
    {
        private vVuelosEntities db = new vVuelosEntities();

        // GET: flights
        public ActionResult Index()
        {
            var flights = db.flights.Include(f => f.airline).Include(f => f.airport_gates).Include(f => f.city);
            return View(flights.ToList());
        }
        //GET: Arrivals
        public ActionResult Arrivals()
        {
            var flights = db.flights.Where(f => f.onflight == true).ToList(); ;
            return View(flights);
        }

        //GET: Departures
        public ActionResult Departures()
        {
            var flights = db.flights.Where(f=>f.onflight == false).ToList();
            return View(flights);
        }

        // GET: flights/Details/5
        public ActionResult Details(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                flight flight = db.flights.Find(id);
                if (flight == null)
                {
                    return HttpNotFound();
                }
                return View(flight);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // GET: flights/Create
        public ActionResult Create()
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                ViewBag.consecutive_airline_id = new SelectList(db.airlines, "consecutive_airline_id", "name");
                ViewBag.consecutive_airport_gate_id_FK = new SelectList(db.airport_gates, "consecutive_airport_gate_id", "consecutive_airport_gate_id");
                ViewBag.city_id = new SelectList(db.cities, "id", "name");
                return View();
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // POST: flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "consecutive_flight_id,code,consecutive_airline_id,city_id,arrival_date,arrival_time,consecutive_airport_gate_id_FK,status,onflight")] flight flight)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.sp_add_fligths(flight.code, flight.consecutive_airline_id, flight.city_id, flight.arrival_date,
                        flight.arrival_time, flight.consecutive_airport_gate_id_FK, flight.status, flight.onflight);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.consecutive_airline_id = new SelectList(db.airlines, "consecutive_airline_id", "name", flight.consecutive_airline_id);
                ViewBag.consecutive_airport_gate_id_FK = new SelectList(db.airport_gates, "consecutive_airport_gate_id", "consecutive_airport_gate_id", flight.consecutive_airport_gate_id_FK);
                ViewBag.city_id = new SelectList(db.cities, "id", "name", flight.city_id);
                return View(flight);
            }
            return RedirectToAction("Unauthorized", "Auth");
            
        }

        // GET: flights/Edit/5
        public ActionResult Edit(string id)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                flight flight = db.flights.Find(id);
                if (flight == null)
                {
                    return HttpNotFound();
                }
                ViewBag.consecutive_airline_id = new SelectList(db.airlines, "consecutive_airline_id", "name", flight.consecutive_airline_id);
                ViewBag.consecutive_airport_gate_id_FK = new SelectList(db.airport_gates, "consecutive_airport_gate_id", "consecutive_airport_gate_id", flight.consecutive_airport_gate_id_FK);
                ViewBag.city_id = new SelectList(db.cities, "id", "name", flight.city_id);
                return View(flight);
            }
            return RedirectToAction("Unauthorized", "Auth");

            
        }

        // POST: flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "consecutive_flight_id,code,consecutive_airline_id,city_id,arrival_date,arrival_time,consecutive_airport_gate_id_FK,status,onflight")] flight flight)
        {
            int currentUserId = Int32.Parse(FormsAuthentication.Decrypt(HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            if (UserVerficication.IsAdmin(currentUserId, db))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(flight).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.consecutive_airline_id = new SelectList(db.airlines, "consecutive_airline_id", "name", flight.consecutive_airline_id);
                ViewBag.consecutive_airport_gate_id_FK = new SelectList(db.airport_gates, "consecutive_airport_gate_id", "consecutive_airport_gate_id", flight.consecutive_airport_gate_id_FK);
                ViewBag.city_id = new SelectList(db.cities, "id", "name", flight.city_id);
                return View(flight);
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
