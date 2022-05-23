using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }

        public virtual List<CartItem> Items { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
