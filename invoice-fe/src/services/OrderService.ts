import { OrderViewModel } from "../models/OrderViewModel";
import api from "./api";

export const OrderService = {
  async getAllOrders(): Promise<OrderViewModel[]> {
    const response = await api.get<OrderViewModel[]>("/order/all");
    return response.data;
  },

  async getOrderById(orderId: string): Promise<OrderViewModel> {
    const response = await api.get<OrderViewModel>("/order/" + orderId);
    return response.data;
  }
};
