using Domain.Contexts.ShoppingCarts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts.ShoppingCarts.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly WebshopDbContext _context;

        public ShoppingCartRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public ShoppingCart AddItemToCart(Guid shoppingCartId, Guid productid)
        {
            var shoppingCart = GetShoppingCartById(shoppingCartId);

            var cartItem = shoppingCart.Items.FirstOrDefault(sc => sc.ProductId == productid);
            if (cartItem is null)
                cartItem = new CartItem() { ProductId = productid, Quantity = 1 };
            else cartItem.Quantity++;

            _context.ShoppingCarts.Update(shoppingCart);

            return shoppingCart;
        }

        public ShoppingCart CreateShoppingCart()
        {
            var shoppingCartEntity = new ShoppingCart();
            shoppingCartEntity.Id = Guid.NewGuid();
 
            _context.ShoppingCarts.Add(shoppingCartEntity);

            return shoppingCartEntity;
        }

        public ShoppingCart GetShoppingCartBycustomerId(Guid customerId)
        {
            var customer = _context
               .Customers
               .Include(c => c.Cart)
               .ThenInclude(x => x.Items)
               .FirstOrDefault(customer => customer.Id == customerId);

            return customer?.Cart;
        }

        public ShoppingCart RemoveItemFromCart(Guid shoppingCartId, Guid productid)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart UpdateItemQuantity(Guid shoppingCartId, Guid cartItemId, int quantity)
        {
            var shoppingCart = GetShoppingCartById(shoppingCartId);

            var cartItem = shoppingCart.Items.Where(c => c.Id == cartItemId).FirstOrDefault();
            if (cartItem == null)
                return null;

            if (quantity <= 0)
                shoppingCart.Items.Remove(cartItem);

            cartItem.Quantity = quantity;

            _context.SaveChanges();

            return shoppingCart;
        }

        private ShoppingCart GetShoppingCartById(Guid shoppingCartId)
        {
            var shoppingCart = _context
             .ShoppingCarts
             .Include(x => x.Items)
             .FirstOrDefault(sc => sc.Id == shoppingCartId);

            return shoppingCart;
        }
    }
}
