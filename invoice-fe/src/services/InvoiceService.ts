import { InvoiceViewModel } from "../models/InvoiceViewModel";
import api from "./api";

export const InvoiceService = {
  async geAllInvoices(): Promise<InvoiceViewModel[]> {
    const response = await api.get<InvoiceViewModel[]>("/invoice/all");
    return response.data;
  },

  async getInvoiceById(invoiceId: string): Promise<InvoiceViewModel> {
    const response = await api.get<InvoiceViewModel>("/invoice/" + invoiceId);
    return response.data;
  },

  async updateInvoice(invoice: InvoiceViewModel): Promise<void> {
    await api.put<void>("/invoice", invoice);
  },

  async addInvoice(invoice: InvoiceViewModel): Promise<void> {
    await api.post<void>("/invoice", invoice);
  },

  async deleteInvoiceById(invoiceId: string): Promise<void> {
    await api.delete<void>("/invoice/" + invoiceId);
  }
};
