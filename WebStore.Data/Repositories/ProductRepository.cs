using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Data.IRepositories;
using WebApplication_Models;
using WebApplication_Models;

namespace WebApplication_Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public Product? Update(Product model, int id)
        {
            var product = GetById(x=>x.Id==id);
            if (product is null)
                return null;
            product.Name = model.Name;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.Price50 = model.Price50;
            product.ListPrice = model.ListPrice;
            product.Price100 = model.Price100;  
            product.Author = model.Author;
            var numberOfUpdates= context.SaveChanges();
            if(numberOfUpdates > 0) 
                return product;
            return null;
        }
    }
}
