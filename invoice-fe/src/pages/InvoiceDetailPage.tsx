import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { InvoiceState, InvoiceViewModel } from "../models/InvoiceViewModel";
import { InvoiceService } from "../services/InvoiceService";
import IconCheck from "../icons/IconCheck";
import { getDefaultInvoice, invoiceStates, invoiceStateToText } from "../utils/InvoiceHelper";
import InvoiceInfo from "../components/invoice/InvoiceInfo";
import OrderInfo from "../components/order/OrderInfo";

function InvoicesDetailPage() {
  const { invoiceId } = useParams();
  
  const [invoice, setInvoice] = useState<InvoiceViewModel>(getDefaultInvoice());
  const [invoiceOriginal, setInvoiceOriginal] = useState<InvoiceViewModel>(getDefaultInvoice());
  const [dropdownIsOpen, setDropdownIsOpen] = useState(false);

  useEffect(() => {
    if (invoiceId) {
        InvoiceService.getInvoiceById(invoiceId!).then((data) => {
            if (data) {
                setInvoiceOriginal(data);
                setInvoice(data);
            }
       });
    }
  }, [invoiceId]);

  const updateInvoice = () => {
    InvoiceService.updateInvoice(invoice);
    window.location.reload()
  };

  const selectInvoiceState = (state: InvoiceState) => {
    setInvoice({ ...invoice, state: state } as InvoiceViewModel);
    setDropdownIsOpen(false);
  };

  return (
    <div className="w-100">
        <div className="w-90 d-flex">
            <div className="mt-1 flex-grow-1">
                <h2>Invoice Details</h2>
            </div>

            <div>
                <button className="btn btn-success mt-1" type="button" onClick={() => {updateInvoice()}} disabled={invoiceOriginal.state === invoice.state}>
                    <IconCheck />
                </button>
            </div>
        </div>

        <div className="d-flex mt-4 mb-5 w-90">
            <div className="w-60 pe-5 mt-2">
                <OrderInfo order={invoiceOriginal?.order} />
            </div>

            <div className="flex-grow-1 ps-5 mt-1">
                <h5>Invoice Data</h5>
                
                <InvoiceInfo invoiceNumber={invoiceOriginal.invoiceNumber} invoiceDate={invoiceOriginal.invoiceDate} totalPrice={invoiceOriginal.totalPrice} />

                <div className="row mt-4">
                    <div className="col-5 pt-2 fw-bold">Status: </div>
                    <div className="col-7">
                        {(invoiceOriginal.state !== InvoiceState.CANCELLED) ? (
                            <div className="dropdown w-100">
                            <button
                                className="btn btn-secondary bg-primary dropdown-toggle dropdown-toggle-split w-100"
                                type="button"
                                onClick={() => setDropdownIsOpen(!dropdownIsOpen)}
                                aria-expanded={dropdownIsOpen}
                            >
                                <span className="pe-4">{invoiceStateToText(invoice.state)}</span>
                            </button>

                            <ul className={`dropdown-menu w-100 ${dropdownIsOpen ? "show" : ""}`}>
                                {invoiceStates.map((state) => (
                                    <li key={state}>
                                        <button className="dropdown-item" onClick={() => {selectInvoiceState(state)}}>
                                            {invoiceStateToText(state)}
                                        </button>
                                    </li>
                                ))}
                            </ul>
                        </div>
                        ) : (
                            <div className="pt-1">{invoiceStateToText(invoiceOriginal.state)}</div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    </div>
  );
}

export default InvoicesDetailPage;