﻿

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

            return View(ProductRepository.FullProductVM(new CreateProductViewModel()));
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product? Product = ProductRepository.GetById(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product Product)
        {
            var res = ProductRepository.Remove(Product);
            if (res is null)
            {
                TempData["error"] = "Product is not deleted";
                return BadRequest(res);
            }

            TempData["success"] = "Product Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
