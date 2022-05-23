using Domain.Entities;

namespace Domain.Contexts.ShoppingCarts
{
    public interface IShoppingCartRepository
    {
        ShoppingCart CreateShoppingCart();
        ShoppingCart GetShoppingCartBycustomerId(Guid customerId);
        ShoppingCart AddItemToCart(Guid shoppingCartId, Guid productid);
        ShoppingCart RemoveItemFromCart(Guid shoppingCartId, Guid productid);
        ShoppingCart UpdateItemQuantity(Guid shoppingCartId, Guid cartItemId, int quantity);
    }
}
