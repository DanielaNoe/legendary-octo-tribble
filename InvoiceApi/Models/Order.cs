using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceApi.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // FK Customer
        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [Required]
        public List<Position> Positions { get; set; } = new List<Position>();

        public virtual List<Invoice>? Invoices { get; set; } = new List<Invoice>();

        // FK DeliveryAddress
        [Required]
        public Guid DeliveryAddressId { get; set; }

        [ForeignKey(nameof(DeliveryAddressId))]
        public virtual Address DeliveryAddress { get; set; }

        // FK BillingAddress
        [Required]
        public Guid BillingAddressId { get; set; }

        [ForeignKey(nameof(BillingAddressId))]
        public virtual Address BillingAddress { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
