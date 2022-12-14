using Domain.Entities;

namespace Domain.Contexts.ShoppingCarts
{
    public interface IShoppingCartAdapter
    {
        ShoppingCart GetShoppingCartByUserId(Guid userId);
        ShoppingCart AddItemToCart(Guid shoppingCartId, Guid productid);
        ShoppingCart RemoveItemFromCart(Guid shoppingCartId, Guid productid);
        ShoppingCart UpdateItemQuantity(Guid shoppingCartId, Guid cartItemId, int quantity);
    }
}
