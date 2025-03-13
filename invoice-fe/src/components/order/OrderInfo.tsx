import { OrderViewModel } from "../../models/OrderViewModel";
import { formatDate } from "../../utils/InvoiceHelper";
import Address from "./Address";
import PositionsTable from "./PositionsTable";

interface OrderInfoProps {
    order?: OrderViewModel
}

function OrderInfo({ order }: OrderInfoProps) {
    if (!order) return (<></>);

    return (
        <>
            <h5>Order: {order?.orderNumber}</h5>

            <div className="row w-100 mt-4">
                <div className="col-4 fw-bold">Order Date: </div>
                <div className="col-8">
                    {formatDate(order?.orderDate)}
                </div>
            </div>

            <div className="row w-100 mt-3">
                <div className="col-4 fw-bold">Customer: </div>
                <div className="col-8">
                    {order?.customer?.customerName}
                </div>
            </div>

            <div className="row w-100 mt-3">
                <div className="col-4 fw-bold">Total Price (EUR): </div>
                <div className="col-8">
                {order?.totalPrice?.toFixed(2)}
                </div>
            </div>

            <div className="mt-5">
                <h6>Billing Address</h6>
                <Address address={order?.billingAddress} />
            </div>

            <div className="mt-5">
                <h6>Delivery Address</h6>
                <Address address={order?.deliveryAddress} />
            </div>

            <div className="mt-5 w-90">
                <h6>Positions</h6>
                <PositionsTable positions={order?.positions} />
            </div>
        </>
    );
};

export default OrderInfo;
