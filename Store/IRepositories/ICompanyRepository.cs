namespace WebStore.IRepositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company? GetById(Expression<Func<Company, bool>> filter);
        Company? Remove(Company entity);
        Company? Update(Company model, int id);
        Company? Add(Company company);
    }
}
