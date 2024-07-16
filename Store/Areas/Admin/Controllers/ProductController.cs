

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public IActionResult Index()
        {
            var products = ProductRepository.GetAll().ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = ProductRepository.FullProductVM(new CreateProductViewModel());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Product is not created";
                return View(ProductRepository.FullProductVM(model));
            }

            Product? res =  ProductRepository.Add(model);
            if (res is null)
            {
                TempData["error"] = "Product is not created";
                return View(model);
            }

            TempData["success"] = "Product Created Successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model=ProductRepository.GetEditProductViewModel(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Product is not updated";
                return View(model);
            }

            var res =  ProductRepository.Update(model, id);
            if (res is null)
            {
                TempData["error"] = "Product is not updated";
                return BadRequest(res);
            }

            TempData["success"] = "Product Updated Successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = ProductRepository.Remove(id);

            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            return Json(new { success = true, message = "Product deleted successfully." });
        }

        public IActionResult Details(int id)
        {
            Product product=ProductRepository.GetById(x=>x.Id==id);
            if(product == null)
                return NotFound();
            return View(product);
        }
    }
}
