using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROD.Models;

namespace PROD.Controllers
{
    public class CarController : Controller
    {
        CarDAL cdal = null;
        CarRentalEntities cd = null;
        CustomerDAL csdal = null;
        public CarController()
        {
            cdal = new CarDAL();
            cd = new CarRentalEntities();
            csdal=new CustomerDAL();
        }
        public ActionResult EmpIndex()
        {
            List<CustModel> s = new List<CustModel>();
            List<Customer> s1 = csdal.GetCustomers();
            foreach(var item in s1)
            {
                CustModel m = new CustModel();
                m.Customerid = item.Customerid;
                m.CustomerName = item.CustomerName;
                m.Password = item.CustomerName;
                m.LoyaltyPoints = Convert.ToInt32(item.LoyaltyPoints);
                m.Email = item.mail.ToString();
                s.Add(m);
               
            }
            return View(s);
        } 
        // GET: Car
        public ActionResult Index()
        {
            List<CAR> cars = new List<CAR>();

            List<Car> cs = cdal.getcar();
            foreach (Car c in cs)
            {
                CAR cd = new CAR();
                cd.Carid = c.Carid;
                cd.Carname = c.Carname;
                cd.PerDayCharge = c.PerDayCharge;
                cd.ChargePerKm = c.ChargePerKm;
                cd.CarType = c.CarType;
                cars.Add(cd);
            }
            return View(cars);
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(FormCollection c)
        {
            string k = c["Username"].ToString();
            string p = c["Password"].ToString();
            bool k1 = false;
            foreach (var item in cd.admins.ToList())
            {
                if (item.Username == k && item.Password == p)
                {
                    k1 = true;
                }
            }
            if (k1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid Credentials..Try Again";
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
            return View(c);
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
            Car c=cdal.find(id);
            CAR c1 = new CAR();
            c1.Carid = c.Carid;
            c1.Carname = c.Carname;
            c1.ChargePerKm = c.ChargePerKm;
            c1.PerDayCharge = c.PerDayCharge;
            c1.CarType = c.CarType;

            return View(c1);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CAR c)
        {
            try { 
                Car cd = new Car();
                cd.Carid = c.Carid;
                cd.Carname = c.Carname;
                cd.PerDayCharge = c.PerDayCharge;
                cd.ChargePerKm = c.ChargePerKm;
                cd.CarType = c.CarType;
            cdal.update(id, cd);
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
            CAR c = new CAR();
            Car cd = cdal.find(id);
            c.Carid = cd.Carid;
            c.Carname = cd.Carname;
            c.CarType = cd.CarType;
            c.ChargePerKm = cd.ChargePerKm;
            c.PerDayCharge = cd.PerDayCharge;
            return View(c);
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
