using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.ViewModel
{
    public class Company
    {
        public string CompanyName { get; set; }
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public Company(string companyName, int id, string lastName, string firstName, string phone, string address, string city, string province, string country, string postalCode,
            double? latitude, double? longitude)
        {
            CompanyName = companyName;
            ID = ID;
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
            Address = address;
            City = city;
            Province = province;
            Country = country;
            PostalCode = postalCode;
            Latitude = latitude;
            Longitude = longitude; 
        }
        public Company()
        {

        }
    }
}