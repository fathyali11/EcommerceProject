

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = categoryRepository.GetAll().ToList();
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
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Category is not created";
                return View(category);
            }
            Category? res = categoryRepository.Add(category);
            if (res is null)
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
            Category? category = categoryRepository.GetById(x => x.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category, int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Category is not updated";
                return View(category);
            }
            var res = categoryRepository.Update(category, id);
            if (res is null)
            {
                TempData["error"] = "Category is not updated";
                return BadRequest(res);
            }
            TempData["success"] = "Category Updated Successfly";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = categoryRepository.GetById(x => x.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            var res = categoryRepository.Remove(category);
            if (res is null)
            {
                TempData["error"] = "Category is not deleted";
                return BadRequest(res);
            }
            TempData["success"] = "Category Deleted Successfly";
            return RedirectToAction(nameof(Index));
        }
    }
}
