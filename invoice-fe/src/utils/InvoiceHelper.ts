import { InvoiceState, InvoiceViewModel } from "../models/InvoiceViewModel";

export const invoiceStates = [InvoiceState.CREATED, InvoiceState.SENT, InvoiceState.CANCELLED, InvoiceState.COMPLETED];

export const getDefaultInvoice = (): InvoiceViewModel => ({
    id: "00000000-0000-0000-0000-000000000000",
    invoiceNumber: "",
    invoiceDate: new Date(),
    order: undefined,
    state: InvoiceState.CREATED,
    totalPrice: 0.0
});

export const invoiceStateToText = (state: InvoiceState) => {
    return state === InvoiceState.CREATED ? 'Created' : state === InvoiceState.SENT ? 'Sent' : state === InvoiceState.CANCELLED ? 'Canceled' : 'Completed';
};

export const getInvoiceTableRowColor = (state: InvoiceState) => {
    return state === InvoiceState.CREATED ? 'table-danger'
    : state === InvoiceState.SENT ? 'table-warning'
    : state === InvoiceState.COMPLETED ? 'table-success'
    : 'table-dark';
};

export const formatDate = (date?: Date) => {
    if (!date) return ('');

    return new Intl.DateTimeFormat("de-DE", {
      year: "numeric",
      month: "2-digit",
      day: "2-digit",
    }).format(new Date(date));
};

export const formatEUR = (value?: number) => {
    if (!value) return ('');

    return value.toFixed(2);
};