using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
