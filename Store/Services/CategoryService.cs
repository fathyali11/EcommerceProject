

using Store.Data;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Category?> Add(Category category)
        {
            if(category is null)
                return null;

            context.Categories.Add(category);
            var NumberOfUpdates = await context.SaveChangesAsync();
            if(NumberOfUpdates > 0)
                return category;
            else
                return null;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category Update(Category model,int id)
        {
            var category = GetById(id);
            if (category is null)
                return null;
            category.Name = model.Name;
            category.CategoryOrder = model.CategoryOrder;
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return category;
            else
                return null;
        }
        public Category Remove(int id)
        {
            Category category = GetById(id);
            if (category is null)
                return null;
            context.Remove(category);
            var NumberOfUpdates =context.SaveChanges();
            if (NumberOfUpdates > 0)
                return category;
            else
                return null;
        }
    }
}
