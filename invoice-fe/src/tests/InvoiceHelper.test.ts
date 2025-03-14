import { InvoiceState } from "../models/InvoiceViewModel";
import { getInvoiceTableRowColor } from "../utils/InvoiceHelper";

describe("getInvoiceTableRowColor", () => {
    test.each([
      [InvoiceState.CREATED, "table-danger"],
      [InvoiceState.SENT, "table-warning"],
      [InvoiceState.CANCELLED, "table-dark"],
      [InvoiceState.COMPLETED, "table-success"]
    ])("should return '%s' for state %s", (state, expected) => {
      expect(getInvoiceTableRowColor(state)).toBe(expected);
    });
});