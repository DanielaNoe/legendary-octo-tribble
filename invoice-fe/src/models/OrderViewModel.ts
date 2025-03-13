import { AddressViewModel } from "./AddressViewModel";
import { CustomerViewModel } from "./CustomerViewModel";
import { PositionViewModel } from "./PositionViewModel";

export interface OrderViewModel {
    id: string;
    orderNumber: string;
    orderDate: Date;
    customer: CustomerViewModel;
    positions: PositionViewModel[];
    deliveryAddress: AddressViewModel;
    billingAddress: AddressViewModel;
    totalPrice: number;
    invoiceAddable: boolean;
  }