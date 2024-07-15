

using Microsoft.EntityFrameworkCore;

namespace WebStore.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Expression<Func<Product, bool>> filter);
        
        Product? Remove(CreateProductViewModel model);
        Product? Update(EditProductViewModel model,int id);
        CreateProductViewModel FullProductVM(CreateProductViewModel model);
        public Product? Add(CreateProductViewModel entity);
        EditProductViewModel GetEditProductViewModel(int id);
        CreateProductViewModel GetCreateProductViewModel(int id);

    }
}
