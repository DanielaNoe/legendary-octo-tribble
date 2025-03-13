using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.ViewModels
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public ArticleViewModel Article { get; set; }
    }
}
