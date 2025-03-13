import { OrderViewModel } from "./OrderViewModel";

export interface InvoiceViewModel {
    id: string;
    invoiceNumber: string;
    invoiceDate: Date;
    order: OrderViewModel | undefined;
    state: InvoiceState;
    totalPrice: number;
}

export enum InvoiceState {
  CREATED,
  SENT,
  CANCELLED,
  COMPLETED
}