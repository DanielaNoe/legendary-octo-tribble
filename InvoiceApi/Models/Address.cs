using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string HouseNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        // FK Customer
        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public virtual List<Order> BillingOrders { get; set; } = new List<Order>();

        public virtual List<Order> DeliveryOrders { get; set; } = new List<Order>();

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}