using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Models
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        // FK Order
        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [Required]
        public InvoiceState State { get; set; } = InvoiceState.CREATED;

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

    public enum InvoiceState
    {
        CREATED,
        SENT,
        CANCELLED,
        COMPLETED
    }
}
