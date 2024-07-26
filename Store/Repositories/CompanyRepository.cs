
using WebStore.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebStore.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext context;

        public CompanyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Company? Add(Company company)
        {
            if(company is null) 
                return null;
            context.Companies.Add(company);
            var NumberOfUpdates= context.SaveChanges();
            if(NumberOfUpdates > 0) 
                return company;
            return null;

        }

        public IEnumerable<Company> GetAll()
        {
            return context.Companies.ToList();
        }

        public Company? GetById(Expression<Func<Company, bool>> filter)
        {
            return context.Companies.SingleOrDefault(filter);
        }

        public Company? Remove(Company entity)
        {
            if (entity is null)
                return null;
            context.Companies.Remove(entity);
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity;
            return null;
        }

        public Company? Update(Company model, int id)
        {
            var company = context.Companies.SingleOrDefault(x=> x.Id == id);
            company.Name = model.Name;
            company.StreetAddress = model.StreetAddress;
            company.City = model.City;
            company.PhoneNumber = model.PhoneNumber;
            company.PostalCode = model.PostalCode;
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return company;
            return null;
        }
    }
}
