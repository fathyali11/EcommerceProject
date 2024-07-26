namespace WebStore.IRepositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
    }
}
