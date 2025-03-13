using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();

        [Required]
        public bool Deleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
