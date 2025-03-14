describe('navigate around the application', () => {
  it('navigate from home to invoices page via navbar', () => {
    cy.visit('/');
    cy.get("#home").should("be.visible");

    cy.get("#navbar").should("be.visible");
    cy.contains('button', 'Invoices').click();

    cy.get("#invoices").should("be.visible");
  });

  it('navigate from home to orders page via navbar', () => {
    cy.visit('/');
    cy.get("#home").should("be.visible");
    cy.get("#navbar").should("be.visible");
    cy.contains('button', 'Orders').click();

    cy.get("#orders").should("be.visible");
  });

  it('navigate from invoices page to orders page via add button', () => {
    cy.visit('/invoices');
    cy.get("#invoices").should("be.visible");
    cy.get('#btn-add').click();

    cy.get("#orders").should("be.visible");
  });

  it('navigate from orders page to home page via navbar', () => {
    cy.visit('/orders');
    cy.get("#orders").should("be.visible");
    cy.get("#navbar").should("be.visible");
    cy.contains('button', 'Home').click();

    cy.get("#home").should("be.visible");
  });
});