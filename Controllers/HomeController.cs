using MvcApplication2.Models;
using MvcApplication2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            directory_dbEntities context = new directory_dbEntities();
            BusinessDirectory bd = new BusinessDirectory();

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            bd.DisplayDirectory();

            IEnumerable<Organization> organizations = bd.GetOrganizations(searchString, sortOrder);

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;

            if (String.IsNullOrEmpty(sortOrder))
                ViewBag.NameSortParm = BusinessDirectory.ORG;
            else
                ViewBag.NameSortParm = "";

            if (sortOrder == BusinessDirectory.CONTACT)
                ViewBag.DateSortParm = BusinessDirectory.CONTACT_DESC;
            else
                ViewBag.DateSortParm = BusinessDirectory.CONTACT;

            if (sortOrder == BusinessDirectory.ADDRESS)
                ViewBag.DateSortParm = BusinessDirectory.ADDRESS_DESC;
            else
                ViewBag.DateSortParm = BusinessDirectory.ADDRESS;

            if (sortOrder == BusinessDirectory.CITY)
                ViewBag.DateSortParm = BusinessDirectory.CITY_DESC;
            else
                ViewBag.DateSortParm = BusinessDirectory.CITY;

            if (sortOrder == BusinessDirectory.PROV)
                ViewBag.DateSortParm = BusinessDirectory.PROV_DESC;
            else
                ViewBag.DateSortParm = BusinessDirectory.PROV;

            if (sortOrder == BusinessDirectory.COUNTRY)
                ViewBag.DateSortParm = BusinessDirectory.COUNTRY_DESC;
            else
                ViewBag.DateSortParm = BusinessDirectory.COUNTRY;

            const int PAGE_SIZE = 10;
            int pageNumber = (page ?? 1);

            // Truncate results to fit in the view provided.
            organizations = organizations.ToPagedList(pageNumber, PAGE_SIZE);

            return View(organizations);
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            directory_dbEntities db = new directory_dbEntities();
            DBUser user = new DBUser();
            user = db.DBUsers.Where(b => b.userName == "portfolio" && b.password == "P@ssw0rd").FirstOrDefault();
            if (user.userName == userName && user.password == password)
            {
                Session["sessionID"] = "true";
                return RedirectToAction("Add", "Admin");
            }
            else
            {
                ViewBag.Message = "Login Unsuccessful! Please try again.";
                return View();
            }
        }
        
        public ActionResult Detail(int id)
        {
            BusinessDirectory bd = new BusinessDirectory();       
            return View(bd.DisplayDetail(id));
        }

        public ActionResult Logout()
        {
            Session.Remove("ASP.NET_SessionID");
            return View();
        }
    }
}
