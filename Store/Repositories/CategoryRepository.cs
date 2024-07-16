

namespace WebStore.Repositories
{
    public class CategoryRepository :  ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category? GetById(Expression<Func<Category, bool>> filter)
        {
            Category? item = context.Categories.FirstOrDefault(filter);
            return item;
        }
        public Category? Remove(Category entity)
        {
            if (entity == null)
            {
                return null;
            }
            context.Categories.Remove(entity);
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity;
            else
                return null;
        }

        public Category? Add(Category category)
        {
            if (category is null)
                return null;
            context.Categories.Add(category);
            var numberOfUpdates= context.SaveChanges();
            if (numberOfUpdates > 0)
                return category;
            return null;
        }

        public Category? Update(Category model, int id)
        {
            var category = GetById(x=>x.Id==id);
            if (category is null)
                return null;
            category.Name = model.Name;
            category.CategoryOrder = model.CategoryOrder;
            context.SaveChanges();
            return category;
            
        }
    }
}
