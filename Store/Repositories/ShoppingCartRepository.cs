
namespace WebStore.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext context;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public ShoppingCart? Add(ShoppingCart shoppingCart)
        {
            if(shoppingCart == null)
                return null;
            context.ShoppingCarts.Add(shoppingCart);
            var NumberOfUpdates=context.SaveChanges();
            if(NumberOfUpdates > 0) 
                return shoppingCart;
            return null;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return context.ShoppingCarts
                .Include(x=>x.Product)
                .Include(x=>x.ApplicationUser)
                
                .ToList();
        }

        public ShoppingCart? GetById(Expression<Func<ShoppingCart, bool>> filter)
        {
            return context.ShoppingCarts
                .Include(x => x.Product)
                .Include(x => x.ApplicationUser)
                
                .FirstOrDefault(filter);
        }

        public double GetTotalPrice(IEnumerable<ShoppingCart> shoppingCarts)
        {
            double totalPrice = 0;
            foreach (var item in shoppingCarts)
                totalPrice += (item.Product.NewPrice*item.Count);
            return totalPrice;
        }

        public ShoppingCart? Remove(ShoppingCart shopping)
        {
            if(shopping == null)
                return null;
            context.ShoppingCarts.Remove(shopping);
            var NumberOfUpdates=context.SaveChanges();
            if(NumberOfUpdates > 0)
                return shopping;
            return null;
        }

        public ShoppingCart? Update(ShoppingCart model)
        {
            var NumberOfUpdates= context.SaveChanges();
            if(NumberOfUpdates>0)
                return model;
            return null;
        }
    }
}
