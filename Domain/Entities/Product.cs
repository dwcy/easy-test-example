using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200), Required]
        public string Name { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; }
    }
}
