using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using PROD.Models;
using WebGrease.ImageAssemble;

namespace PROD.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL cd = null;
        CarDAL cdal = null;
        public CustomerController()
        {
            cd = new CustomerDAL();
            cdal= new CarDAL();
        }
        public ActionResult Register()
        {
            CustModel customer = new CustModel();
            customer.LoyaltyPoints = 0;
            return View(customer);
        }
        [HttpPost]
        public ActionResult Register(FormCollection c)
        {
            Customer c1 = new Customer();
            c1.LoyaltyPoints =Convert.ToInt32(c["LoyaltyPoints"]);
            c1.Customerid = Convert.ToInt32(c["Customerid"]);
            c1.CustomerName = c["CustomerName"].ToString();
            c1.mail = c["Email"].ToString();
            c1.Password = c["Password"].ToString();
            bool k=cd.AddCustomer(c1);
            if (k)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }


        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string s = c["Email"].ToString();
            string k = c["Password"].ToString();
            bool k1 = false;
            foreach(var item in cd.GetCustomers())
            {
               if(item.mail==s && item.Password == k)
                {
                    TempData["User"] = item;
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

      
        // GET: Customer
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

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
