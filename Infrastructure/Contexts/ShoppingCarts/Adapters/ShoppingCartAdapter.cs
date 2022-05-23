using Domain.Contexts.ShoppingCarts;

namespace Infrastructure.Contexts.ShoppingCarts.Adapters
{
    public class ShoppingCartAdapter : IShoppingCartAdapter
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartAdapter(IShoppingCartRepository shoppingCartRepository)
        { 
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCart AddItemToCart(Guid shoppingCartId, Guid productid)
        {
            return _shoppingCartRepository.AddItemToCart(shoppingCartId, productid);
        }

        public ShoppingCart GetShoppingCartByUserId(Guid userId)
        {
            return _shoppingCartRepository.GetShoppingCartBycustomerId(userId);
        }

        public ShoppingCart RemoveItemFromCart(Guid shoppingCartId, Guid productid)
        {
            return _shoppingCartRepository.RemoveItemFromCart(shoppingCartId, productid);
        }

        public ShoppingCart UpdateItemQuantity(Guid shoppingCartId, Guid cartItemId, int quantity)
        {
            return _shoppingCartRepository.UpdateItemQuantity(shoppingCartId, cartItemId, quantity);
        }
    }
}
