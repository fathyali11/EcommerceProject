


using Microsoft.AspNetCore.Hosting;

namespace WebStore.Repositories
{
    public class ProductRepository :  IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoryRepository categoryRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductRepository(ApplicationDbContext context,ICategoryRepository categoryRepository,IWebHostEnvironment webHostEnvironment) 
        {
            this.context = context;
            this.categoryRepository = categoryRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public Product? Add(CreateProductViewModel entity)
        {
            if (entity == null)
            {
                return null;
            }
            if(entity.ImageFile == null) 
                return null;
            entity.product.ImageName=SaveGame(entity.ImageFile);

            context.Products.Add(entity.product);
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity.product;
            else
                return null;
        }
        public CreateProductViewModel FullProductVM(CreateProductViewModel model)
        {
            CreateProductViewModel viewModel = new CreateProductViewModel
            {
                product = model.product,
                categoriesSelectedList = categoryRepository
                .GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return viewModel;
        }

        public Product? Update(EditProductViewModel model, int id)
        {
            var product = GetById(x=>x.Id==id);
            if (product is null || model is null)
                return null;
            product.Name = model.product.Name;
            product.Description = model.product.Description;
            product.CategoryId = model.product.CategoryId;
            product.Price50 = model.product.Price50;
            product.ListPrice = model.product.ListPrice;
            product.Price100 = model.product.Price100;
            product.Author = model.product.Author;

            var ImageFile = model.ImageFile;
            var OldProductName = product.ImageName;
            var HasImage = ImageFile is not null;
            if (HasImage)
            {
                product.ImageName = SaveGame(ImageFile);
            }
            
            var numberOfUpdates= context.SaveChanges();
            if (numberOfUpdates > 0)
            {
                if (HasImage)
                {
                    var path = Path.Combine(FileSettings.ImagePath,OldProductName);
                    File.Delete(path);
                }
                return product;
            }
            else
            {
                var cover = Path.Combine(FileSettings.ImagePath, product.ImageName);
                File.Delete(cover);
                return null;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Include(x=>x.Category).ToList();
        }
        public Product? GetById(Expression<Func<Product, bool>> filter)
        {
            Product? item = context.Products.Include(x=>x.Category).FirstOrDefault(filter);
            return item;
        }
        public Product? Remove(Product entity)
        {
            if (entity == null)
            {
                return null;
            }
            context.Products.Remove(entity);
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity;
            else
                return null;
        }
        private string SaveGame(IFormFile formFile)
        {
            var name = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
            var FolderPath = Path.Combine(webHostEnvironment.ContentRootPath, FileSettings.ImagePath);
            var path=Path.Combine(FolderPath, name);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            using var stream=new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);


            return name;
        }

        public EditProductViewModel GetEditProductViewModel(int id)
        {
            EditProductViewModel model = new EditProductViewModel
            {
                product = GetById(x => x.Id == id),
                categoriesSelectedList = categoryRepository
                .GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return model;
        }
    }
}
