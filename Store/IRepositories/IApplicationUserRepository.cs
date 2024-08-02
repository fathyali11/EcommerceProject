namespace WebStore.IRepositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(string id);
    }
}
