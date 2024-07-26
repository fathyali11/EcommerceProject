using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var carts = new ShoppingCartViewModel();
            carts.ShoppingCarts = shoppingCartRepository.GetAll().Where(x => x.ApplicationUserId == userId).ToList();
            carts.TotalPrice = shoppingCartRepository.GetTotalPrice(carts.ShoppingCarts);
            return View(carts);
        }
        public IActionResult Plus(int cartId)
        {
            var cart = shoppingCartRepository.GetById(x => x.ShoppingCartId == cartId);
            cart.Count += 1;
            shoppingCartRepository.Update(cart);
            return RedirectToAction(nameof(ShoppingCartController.Index));
        }
        public IActionResult Minus(int cartId)
        {
            var cart = shoppingCartRepository.GetById(x => x.ShoppingCartId == cartId);
            cart.Count-= 1;
            shoppingCartRepository.Update(cart);
            if(cart.Count == 0)
            {
                shoppingCartRepository.Remove(cart);
            }
            return RedirectToAction(nameof(ShoppingCartController.Index));
        }
        public IActionResult Delete(int cartId)
        {
            if (cartId == 0)
                return NotFound();
            var cart = shoppingCartRepository.GetById(x => x.ShoppingCartId == cartId);

            shoppingCartRepository.Remove(cart);
            return RedirectToAction(nameof(ShoppingCartController.Index));
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
