using InvoiceApi.ViewModels;
using InvoiceApi.Models;

namespace InvoiceApi.Helper
{
    public class OrderMapper
    {
        public OrderViewModel MapOrderToOrderViewModel(Order o)
        {
            return new OrderViewModel()
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                Customer = new CustomerViewModel()
                {
                    Id = o.Customer.Id,
                    CustomerName = o.Customer.CustomerName
                },
                Positions = o.Positions.Select(p => new PositionViewModel()
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Article = new ArticleViewModel()
                    {
                        Id = p.Article.Id,
                        Name = p.Article.Name,
                        Description = p.Article.Description,
                        Price = p.Article.Price
                    },
                    Price = p.Price,
                    TotalPrice = p.TotalPrice
                }).ToList(),
                DeliveryAddress = new AddressViewModel()
                {
                    Id = o.DeliveryAddressId,
                    Name = o.DeliveryAddress.Name,
                    HouseNumber = o.DeliveryAddress.HouseNumber,
                    Street = o.DeliveryAddress.Street,
                    PostalCode = o.DeliveryAddress.PostalCode,
                    Country = o.DeliveryAddress.Country
                },
                BillingAddress = new AddressViewModel()
                {
                    Id = o.BillingAddressId,
                    Name = o.BillingAddress.Name,
                    HouseNumber = o.BillingAddress.HouseNumber,
                    Street = o.BillingAddress.Street,
                    PostalCode = o.BillingAddress.PostalCode,
                    Country = o.BillingAddress.Country
                },
                TotalPrice = o.TotalPrice,
                InvoiceAddable = o.Invoices == null ? true : IsInvoiceAddable(o.Invoices)
            };
        }

        private bool IsInvoiceAddable(List<Invoice> invoices)
        {
            bool addable = true;

            for (int i = 0; i < invoices.Count(); i++)
            {
                if (invoices[i].State == InvoiceState.CREATED || invoices[i].State == InvoiceState.SENT || invoices[i].State == InvoiceState.COMPLETED)
                {
                    addable = false;
                    break;
                }
            }

            return addable;
        }
    }
}
