using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class BusinessRepository
    {
        public void AddCompany(string company, string last, string first, string phoneNum, string addr, string cityName, string prov, string ctry,
                                            string pc, string lat, string longit)
        {
            directory_dbEntities db = new directory_dbEntities();
            Organization organization = new Organization();

            //make sure organization is not already there. query database and compare two properties....

            organization.companyName = company;
            organization.lastName = last;
            organization.firstName = first;
            organization.phone = phoneNum;
            organization.address = addr;
            organization.city = cityName;
            organization.province = prov;
            organization.country = ctry;
            organization.postalCode = pc;
            organization.latitude = lat;
            organization.longitude = longit;

            db.Organizations.Add(organization);
            db.SaveChanges();

        }
        public void RemoveCompany(int id)
        {
            directory_dbEntities db = new directory_dbEntities();
            Organization organization = new Organization();

            organization = db.Organizations.Where(b => b.id == id).FirstOrDefault();

            organization.id = id;

            db.Organizations.Remove(organization);
            db.SaveChanges();

        }
    }
}