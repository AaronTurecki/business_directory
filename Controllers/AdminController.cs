using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(string companyName, string lastName, string firstName, string phone, string address, string city, string province, string country,
                                            string postalCode, string latitude, string longitude)
        {
            BusinessRepository ab = new BusinessRepository();
            ab.AddCompany(companyName, lastName, firstName, phone, address, city, province, country, postalCode, latitude, longitude);
            return (RedirectToAction("Index", "Home"));
        }
       
        public ActionResult Remove(int id)
        {
            BusinessRepository rb = new BusinessRepository();
            rb.RemoveCompany(id);
            ViewData["Message"] = "Organization successfully removed.";
            return (RedirectToAction("Index", "Home"));
        }
    }
}
