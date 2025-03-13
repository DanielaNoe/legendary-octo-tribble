import { useEffect, useState } from "react";
import { OrderService } from "../services/OrderService";
import { OrderViewModel } from "../models/OrderViewModel";
import { InvoiceViewModel } from "../models/InvoiceViewModel";
import { getDefaultInvoice } from "../utils/InvoiceHelper";
import OrderInfo from "../components/order/OrderInfo";
import InvoiceInfo from "../components/invoice/InvoiceInfo";
import { InvoiceService } from "../services/InvoiceService";
import IconCheck from "../icons/IconCheck";
import { useNavigate, useParams } from "react-router-dom";

function InvoiceCreationPage() {   
    const { orderId } = useParams();

    const navigate = useNavigate();

    const [order, setOrder] = useState<OrderViewModel>();
    const [newInvoice, setNewInvoice] = useState<InvoiceViewModel>(getDefaultInvoice());

    useEffect(() => {
        OrderService.getOrderById(orderId!).then(setOrder);
    }, []);

    useEffect(() => {
        if (order) {
            setNewInvoice({ ...newInvoice, order: order } as InvoiceViewModel);
          }
    }, [order]);

    const openInvoices = () => {
        navigate(`/invoices`);
      };

    const addInvoice = () => {
        if (order) {
            InvoiceService.addInvoice(newInvoice).then(openInvoices);
        }
    };

    return (
        <div className="w-100">
            <div className="w-90 d-flex">
                <h2>Create New Invoices</h2>
            </div>

            <div className="d-flex mt-4 mb-5 w-90">
                <div className="w-60 pe-5 mt-2">
                    <OrderInfo order={order} />
                </div>

                <div className="flex-grow-1 ps-5 mt-1">
                    {order && (
                        <>
                            <h5>Invoice Data</h5>
                            <InvoiceInfo invoiceNumber={'GENERATED'} invoiceDate={newInvoice.invoiceDate} totalPrice={order?.totalPrice} />

                            <div className="row mt-4">
                                <div className="col-5 fw-bold">Status: </div>
                                <div className="col-7">Created</div>
                            </div>

                            <button className="btn btn-success mt-3 w-100" type="button" onClick={() => {addInvoice()}}>
                                <IconCheck />
                            </button>
                        </>
                    )}
                </div>
            </div>
        </div>
    );
}
  
export default InvoiceCreationPage;