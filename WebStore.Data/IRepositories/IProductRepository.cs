using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Models;
using WebApplication_Models;

namespace WebApplication_Data.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Product? Update(Product model,int id);
    }
}
