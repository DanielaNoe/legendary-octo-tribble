import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { formatDate, formatEUR } from "../utils/InvoiceHelper";
import { OrderService } from "../services/OrderService";
import { OrderViewModel } from "../models/OrderViewModel";
import IconPlus from "../icons/IconPlus";

function OrderPage() {
  const [orders, setOrders] = useState<OrderViewModel[]>([]);

  const navigate = useNavigate();

  useEffect(() => {
      OrderService.getAllOrders().then(setOrders);
  }, []);

  const openInvoiceCreationPage = (orderId: string) => {
    navigate(`/invoices/create/${orderId}`);
    window.location.reload();
  };

  return (
    <div>
        <div className="w-90 d-flex">
            <div className="mt-1 flex-grow-1">
                <h2>Orders</h2>
            </div>
        </div>

        <table className="table w-90 mt-4">
            <thead>
                <tr>
                <th scope="col">Order Number</th>
                <th scope="col">Order Date</th>
                <th scope="col">Customer Name</th>
                <th scope="col" className="text-end">Total Price (EUR)</th>
                <th scope="col" className="text-end">Add Invoice</th>
                </tr>
            </thead>
            <tbody>
                {orders.map((order) => (
                    <tr key={order.id}>
                        <td>{order.orderNumber}</td>
                        <td>{formatDate(order.orderDate)}</td>
                        <td>{order.customer?.customerName}</td>
                        <td className="text-end">{formatEUR(order.totalPrice)}</td>
                        <td className="text-end">
                          <button className="btn btn-success" type="button" onClick={() => {openInvoiceCreationPage(order.id)}} disabled={!order.invoiceAddable}>
                                <IconPlus />
                          </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
  );
}

export default OrderPage;