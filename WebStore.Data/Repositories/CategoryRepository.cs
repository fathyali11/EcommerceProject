using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Data.IRepositories;
using WebApplication_Models;

namespace WebApplication_Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Category? Update(Category model, int id)
        {
            var category = GetById(x=>x.Id==id);
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
    }
}
