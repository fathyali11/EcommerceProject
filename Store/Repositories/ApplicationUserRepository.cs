
namespace WebStore.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.ApplicationUsers;
        }

		public ApplicationUser GetById(string id)
		{
			return context.ApplicationUsers.FirstOrDefault(x=>x.Id==id);
		}
	}
}
