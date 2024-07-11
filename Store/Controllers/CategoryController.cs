using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories=categoryService.GetAll();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                TempData["error"] = "Category is not created";
                return View(category);
            }
            Category res=await categoryService.Add(category);
            if(res is null)
            {
                TempData["error"] = "Category is not created";
                return View(res);
            }
                
            TempData["success"] = "Category Created Successfly";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category=categoryService.GetById(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category,int id)
        {
            if(!ModelState.IsValid)
            {
                TempData["error"] = "Category is not updated";
                return View(category);
            }
            var res = categoryService.Update(category, id);
            if (res is null)
            {
                TempData["error"] = "Category is not updated";
                return BadRequest(res);
            }
            TempData["success"] = "Category Updated Successfly";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var res=categoryService.Remove(id);
            if(res is null)
            {
                TempData["error"] = "Category is not deleted";
                return BadRequest(res);
            }
            TempData["success"] = "Category Updated Successfly";
            return RedirectToAction(nameof(Index));
        }
    }
}
