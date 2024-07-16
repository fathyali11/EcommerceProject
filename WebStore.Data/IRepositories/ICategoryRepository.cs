using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Models;

namespace WebApplication_Data.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category? Update(Category model,int id);
    }
}
