using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Models
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        // FK Article
        [Required]
        public Guid ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public virtual Article Article { get; set; }

        // FK Order
        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
