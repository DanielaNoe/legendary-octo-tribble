import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { InvoiceViewModel } from "../models/InvoiceViewModel";
import { InvoiceService } from "../services/InvoiceService";
import IconPlus from "../icons/IconPlus";
import { formatDate, getInvoiceTableRowColor, invoiceStateToText } from "../utils/InvoiceHelper";
import IconTrash from "../icons/IconTrash";

function InvoicePage() {
  const [invoices, setInvoices] = useState<InvoiceViewModel[]>([]);

  const navigate = useNavigate();

  useEffect(() => {
    InvoiceService.geAllInvoices().then(setInvoices);
  }, []);

  const openDetailPage = (invoiceId: string) => {
    navigate(`/invoices/${invoiceId}`);
  };

  const openOrderPage = () => {
    navigate(`/orders`);
    reload();
  };

  const deleteInvoice = (invoiceId: string) => {
    InvoiceService.deleteInvoiceById(invoiceId).then(reload);
  };

  const reload = () => {
    window.location.reload();
  };

  return (
    <div id="invoices">
        <div className="w-90 d-flex">
            <div className="mt-1 flex-grow-1">
                <h2>Invoices</h2>
            </div>

            <div>
                <button id="btn-add" className="btn btn-success mt-1" type="button" onClick={() => openOrderPage()}>
                    <IconPlus />
                </button>
            </div>
        </div>

        <table className="table table-hover w-90 mt-4">
            <thead>
                <tr>
                  <th scope="col">Invoice Number</th>
                  <th scope="col">Invoice Date</th>
                  <th scope="col">Customer Name</th>
                  <th scope="col">State</th>
                  <th scope="col" className="text-end">Delete Invoice</th>
                </tr>
            </thead>
            <tbody>
                {invoices.map((invoice) => (
                    <tr key={invoice.id}
                      className={`${getInvoiceTableRowColor(invoice.state)}`} >
                        <td onClick={() => openDetailPage(invoice.id)} className="cursor-pointer">{invoice.invoiceNumber}</td>
                        <td onClick={() => openDetailPage(invoice.id)} className="cursor-pointer">{formatDate(invoice.invoiceDate)}</td>
                        <td onClick={() => openDetailPage(invoice.id)} className="cursor-pointer">{invoice.order?.customer?.customerName}</td>
                        <td onClick={() => openDetailPage(invoice.id)} className="cursor-pointer">{invoiceStateToText(invoice.state)}</td>
                        <td className="text-end">
                          <button className="btn btn-danger" type="button" onClick={() => deleteInvoice(invoice.id)}>
                              <IconTrash />
                          </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
  );
}

export default InvoicePage;