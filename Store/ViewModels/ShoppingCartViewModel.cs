namespace WebStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
