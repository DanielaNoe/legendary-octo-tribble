using InvoiceApi.Models;

namespace InvoiceApi.ViewModels
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public OrderViewModel Order { get; set; }

        public InvoiceState State { get; set; }

        public double TotalPrice { get; set; }
    }
}
