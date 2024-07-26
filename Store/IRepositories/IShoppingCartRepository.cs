namespace WebStore.IRepositories
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCart> GetAll();
        ShoppingCart? GetById(Expression<Func<ShoppingCart, bool>> filter);
        ShoppingCart? Remove(ShoppingCart shopping);
        ShoppingCart? Update(ShoppingCart model);
        ShoppingCart? Add(ShoppingCart shoppingCart);
        double GetTotalPrice(IEnumerable<ShoppingCart> shoppingCarts);
    }
}
