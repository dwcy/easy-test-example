using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30), Required]
        public string FirstName { get; set; }

        [MaxLength(30), Required]
        public string LastName { get; set; }

        public ShoppingCart Cart { get; set; }
    }
}
