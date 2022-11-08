using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;
using MVC.Models;

namespace MVC.Controllers
{
    public class CarController : Controller
    { 
        CarDAL cdal = null;
        public CarController()
        {
            cdal = new CarDAL();
        }
        // GET: Car
        public ActionResult Index()
        {
            List<CAR> cars = new List<CAR>();
            
            List<Car> cs = cdal.getcar();
            foreach(Car c in cs)
            {
                CAR cd = new CAR();
                cd.Carid = c.Carid;
                cd.Carname = c.Carname;
                cd.PerDayCharge = c.PerDayCharge;
                cd.ChargePerKm = c.ChargePerKm;
                cd.CarType = c.CarType;
                cars.Add(cd);
            }
            return View (cars);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string k = c["mail"].ToString();
            string p = c["password"].ToString();
            if (k == "email@gmail.com" && p == "password")
            {
                // return RedirectToRoute(new { action = "Index", controller = "Home", area = "" });
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message1 = "Invalid username/password";
                return View();
            }
        }
            // GET: Car/Details/5
            public ActionResult Details(int id)
        {
            CAR c = new CAR();
            Car cd = cdal.find(id);
            c.Carid = cd.Carid;
            c.Carname = cd.Carname;
            c.CarType = cd.CarType; 
            c.ChargePerKm = cd.ChargePerKm;
            c.PerDayCharge = cd.PerDayCharge;
            return View( c );
        }

        // GET: Car/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(CAR c)
        {
            try
            {
                Car cd = new Car();
                cd.Carid = c.Carid;
                cd.Carname = c.Carname;
                cd.PerDayCharge = c.PerDayCharge;
                cd.ChargePerKm = c.ChargePerKm;
                cd.CarType = c.CarType;
                cdal.addcar(cd);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CAR c)
        {
            try
            {
                Car cd = new Car();
                cd.Carid = c.Carid;
                cd.Carname = c.Carname;
                cd.PerDayCharge = c.PerDayCharge;
                cd.ChargePerKm = c.ChargePerKm;
                cd.CarType = c.CarType;
                cdal.update(id,cd);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CAR c)
        {
            try
            {
                cdal.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
