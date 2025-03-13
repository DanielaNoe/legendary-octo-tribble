namespace InvoiceApi.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public CustomerViewModel Customer { get; set; }

        public List<PositionViewModel> Positions { get; set; }

        public AddressViewModel DeliveryAddress { get; set; }

        public AddressViewModel BillingAddress { get; set; }

        public double TotalPrice { get; set; }

        public bool InvoiceAddable { get; set; }
    }
}
