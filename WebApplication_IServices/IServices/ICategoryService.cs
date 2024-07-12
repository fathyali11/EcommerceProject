
using WebApplication_Models;

namespace WebApplication_IServices
{
    public interface ICategoryService
    {
        Task<Category?> Add(Category category);
        List<Category> GetAll();
        
        Category GetById(int id);
        Category Update(Category model, int id);
        Category Remove(int id);
    }
}
