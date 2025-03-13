import { formatDate, formatEUR } from "../../utils/InvoiceHelper";

interface InvoiceInfoProps {
    invoiceNumber?: string,
    invoiceDate?: Date,
    totalPrice?: number,
}

function InvoiceInfo({ invoiceNumber, invoiceDate, totalPrice }: InvoiceInfoProps) {
    return (
        <>
            <div className="row mt-4">
                <div className="col-5 fw-bold">Invoice Number: </div>
                <div className="col-7">
                    {invoiceNumber}
                </div>
            </div>
            <div className="row mt-2">
                <div className="col-5 fw-bold">Invoice Date: </div>
                <div className="col-7">
                    {formatDate(invoiceDate)}
                </div>
            </div>
            
            <div className="row mt-4">
                <div className="col-5 fw-bold">Total Price (EUR): </div>
                <div className="col-7">
                    {formatEUR(totalPrice)}
                </div>
            </div>
        </>
    );
};

export default InvoiceInfo;
