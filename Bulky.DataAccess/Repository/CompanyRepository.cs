using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Company company)
        {
           var companyFromDb = _db.Companies.FirstOrDefault(c => c.Id == company.Id);
           if (companyFromDb != null)
           {
                companyFromDb.Name = company.Name;
                companyFromDb.PhoneNumber = company.PhoneNumber;
                companyFromDb.StreetAddress = company.StreetAddress;
                companyFromDb.City = company.City;
                companyFromDb.State = company.State;
                companyFromDb.PostalCode = company.PostalCode;

           }
        }
    }
}
