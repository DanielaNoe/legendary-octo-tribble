import React from 'react'
import Navbar from "../../src/components/navbar/Navbar"
import { MemoryRouter } from 'react-router-dom'

describe('navbar.cy.tsx', () => {
  const routes = [
    { path: '/', activeButton: 'Home' },
    { path: '/invoices', activeButton: 'Invoices' },
    { path: '/orders', activeButton: 'Orders' },
    { path: '/invoices/8d6ld7i3-8d63-d73n-d8js-2d5dsop9w7e8', activeButton: 'Invoices' },
    { path: '/invoices/create/5djd7sios-5dst-64e8-2d3h-5d984c16s5f4', activeButton: 'Invoices' }
  ];

  routes.forEach(({ path, activeButton }) => {
    it('path: ' + path + ', ' + activeButton + ' should be selected', () => {
      cy.mount(
        <MemoryRouter>
          <Navbar mockLocation={{ pathname: path }} />
        </MemoryRouter>
      );

      cy.get("#navbar").should("be.visible");
      const buttons = ['Home', 'Invoices', 'Orders'];
      buttons.forEach((button) => {
        cy.contains('button', button).should('have.class', button === activeButton ? 'btn-primary' : 'bg-none');
      });
    });
  });
});