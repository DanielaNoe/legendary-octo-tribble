using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string CustomerName { get; set; }

        public virtual List<Address> Addresses { get; set; } = new List<Address>();

        public virtual List<Order> Orders { get; set; } = new List<Order>();

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
