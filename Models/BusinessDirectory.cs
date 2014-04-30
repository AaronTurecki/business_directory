using MvcApplication2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class BusinessDirectory
    {
        public const string ORG = "companyName";
        public const string ORG_DESC = "companyName_desc";
        public const string CONTACT = "lastName";
        public const string CONTACT_DESC = "lastName_desc";
        public const string ADDRESS = "address";
        public const string ADDRESS_DESC = "address_desc";
        public const string CITY = "city";
        public const string CITY_DESC = "city_desc";
        public const string PROV = "province";
        public const string PROV_DESC = "province_desc";
        public const string COUNTRY = "country";
        public const string COUNTRY_DESC = "country_desc";

        public List<Organization> DisplayDirectory()
        {
            directory_dbEntities context = new directory_dbEntities();
            List<Organization> organization = context.Organizations.ToList();

            return organization;
        }

        IEnumerable<Organization> SortDirectory(IEnumerable<Organization> organizations, string sortOrder)
        {
            switch (sortOrder)
            {
                case ORG:
                    organizations = organizations.OrderByDescending(s => s.companyName);
                    break;
                case CONTACT:
                    organizations = organizations.OrderBy(s => s.lastName);
                    break;
                case CONTACT_DESC:
                    organizations = organizations.OrderByDescending(s => s.lastName);
                    break;
                case ADDRESS:
                    organizations = organizations.OrderBy(s => s.address);
                    break;
                case ADDRESS_DESC:
                    organizations = organizations.OrderByDescending(s => s.address);
                    break;
                case CITY:
                    organizations = organizations.OrderBy(s => s.city);
                    break;
                case CITY_DESC:
                    organizations = organizations.OrderByDescending(s => s.city);
                    break;
                case PROV:
                    organizations = organizations.OrderBy(s => s.province);
                    break;
                case PROV_DESC:
                    organizations = organizations.OrderByDescending(s => s.province);
                    break;
                case COUNTRY:
                    organizations = organizations.OrderBy(s => s.country);
                    break;
                case COUNTRY_DESC:
                    organizations = organizations.OrderByDescending(s => s.country);
                    break;
                default:
                    organizations = organizations.OrderBy(s => s.companyName);
                    break;
            }
            return organizations;
        }

        IEnumerable<Organization> FilterOrganizations(IEnumerable<Organization> organizations, string searchString)
        {
            // Filter results based on search.
            if (!String.IsNullOrEmpty(searchString))
                organizations = organizations.Where(
                            s => s.lastName.ToUpper().Contains(searchString.ToUpper())
                              || s.firstName.ToUpper().Contains(searchString.ToUpper())
                              || s.companyName.ToUpper().Contains(searchString.ToUpper())
                              || s.city.ToUpper().Contains(searchString.ToUpper()));
            return organizations;
        }

        public IEnumerable<Organization> GetOrganizations(string searchString, string sortOrder)
        {
            directory_dbEntities context = new directory_dbEntities();
            IEnumerable<Organization> organizations = from s in context.Organizations
                                            select s;
            organizations = FilterOrganizations(organizations, searchString);
            organizations = SortDirectory(organizations, sortOrder);
            return organizations;
        }

        public Organization DisplayDetail(int id)
        {
            directory_dbEntities context = new directory_dbEntities();

            var organizations = context.Organizations.Where(b => b.id == id).FirstOrDefault();
            return organizations;
        }
    }
}

