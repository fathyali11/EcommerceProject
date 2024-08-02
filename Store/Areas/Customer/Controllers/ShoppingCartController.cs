using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using WebStore.Models;

namespace WebStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
		private readonly IApplicationUserRepository _applicationUserRepository;
		private readonly IOrderHeaderRepository _orderHeaderRepository;
		private readonly IOrderDetailRepository _orderDetailRepository;

		[BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

		public ShoppingCartController(
             IShoppingCartRepository shoppingCartRepository
            ,IApplicationUserRepository applicationUserRepository
            ,IOrderHeaderRepository orderHeaderRepository
            ,IOrderDetailRepository orderDetailRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
			this._applicationUserRepository = applicationUserRepository;
			this._orderHeaderRepository = orderHeaderRepository;
			this._orderDetailRepository = orderDetailRepository;
		}
        [HttpGet]
        public IActionResult Index()
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var carts = new ShoppingCartViewModel();
            carts.OrderHeader = new();
            carts.ShoppingCarts = shoppingCartRepository.GetAll().Where(x => x.ApplicationUserId == userId).ToList();
            carts.OrderHeader.OrderTotal = shoppingCartRepository.GetTotalPrice(carts.ShoppingCarts);
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
        [HttpGet]
        public IActionResult Summary()
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            var applicationUser=_applicationUserRepository.GetById(userId);

            var cartVM=new ShoppingCartViewModel();
            cartVM.ShoppingCarts = shoppingCartRepository.GetAll().Where(x=>x.ApplicationUserId==userId).ToList();
            cartVM.OrderHeader=new OrderHeader();
            if(applicationUser!=null)
            {
                cartVM.OrderHeader.Name=$"{applicationUser.FirstName} {applicationUser.LastName}";
                cartVM.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
                cartVM.OrderHeader.City = applicationUser.City;
				cartVM.OrderHeader.OrderTotal = shoppingCartRepository.GetTotalPrice(cartVM.ShoppingCarts);
			}
            return View(cartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


			var applicationUser = _applicationUserRepository.GetById(userId);

			ShoppingCartVM.ShoppingCarts= shoppingCartRepository.GetAll().Where(x => x.ApplicationUserId == userId).ToList();
			ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
			ShoppingCartVM.OrderHeader.OrderTotal=shoppingCartRepository.GetTotalPrice(ShoppingCartVM.ShoppingCarts);
            if(applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                // it is customer
                ShoppingCartVM.OrderHeader.OrderStatus=Status.StatusPending;
                ShoppingCartVM.OrderHeader.PaymentStatus=Status.PaymentStatusPending;
            }
            else
            {
                ShoppingCartVM.OrderHeader.OrderStatus = Status.StatusApproved;
                ShoppingCartVM.OrderHeader.PaymentStatus = Status.PaymentStatusDelayedPayment;
			}
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;
            _orderHeaderRepository.Add(ShoppingCartVM.OrderHeader);
            //Create order detail
            foreach(var cart in ShoppingCartVM.ShoppingCarts)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Count = cart.Count,
                    Price = cart.Product.NewPrice
                };
                _orderDetailRepository.Add(orderDetail);
            }
            if(applicationUser.CompanyId.GetValueOrDefault()==0)
            {
                //stripe for customer

                var domain = "https://localhost:44379/";
				var options = new Stripe.Checkout.SessionCreateOptions
				{
					SuccessUrl = $"{domain}Customer/ShoppingCart/OrderConfirmation/{ShoppingCartVM.OrderHeader.Id}",
					CancelUrl = $"{domain}Customer/ShoppingCart/Index",
					LineItems = new List<Stripe.Checkout.SessionLineItemOptions>(),
					Mode = "payment",
				};
                foreach(var item in ShoppingCartVM.ShoppingCarts)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount=(long)item.Product.NewPrice*100,
                            Currency="usd",
                            ProductData =new SessionLineItemPriceDataProductDataOptions
                            {
                                Name=item.Product.Name,
                            }
                        }
                    };
                    options.LineItems.Add(sessionLineItem);
				}
                var service = new SessionService();
                Session session =service.Create(options);
                _orderHeaderRepository.UpdateStripePaymentId(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
				Response.Headers.Add("Location", session.Url);
				return new StatusCodeResult(303);
			}
			return RedirectToAction(nameof(OrderConfirmation), new {id=ShoppingCartVM.OrderHeader.Id});
        }
        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }
    }
}
