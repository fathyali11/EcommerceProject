

using Microsoft.EntityFrameworkCore;

namespace WebStore.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Expression<Func<Product, bool>> filter);
        EditProductViewModel GetEditProductViewModel(int id);
        Product? Remove(Product entity);
        Product? Update(EditProductViewModel model,int id);
        CreateProductViewModel FullProductVM(CreateProductViewModel model);
        public Product? Add(CreateProductViewModel entity);
        
    }
}
