

namespace WebStore.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(Expression<Func<Category, bool>> filter);
        Category? Remove(Category entity);
        Category? Update(Category model,int id);
        Category? Add(Category category);
    }
}
