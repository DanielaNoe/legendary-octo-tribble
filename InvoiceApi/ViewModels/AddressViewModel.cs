namespace InvoiceApi.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }
}
