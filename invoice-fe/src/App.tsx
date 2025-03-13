import LandingPage from './pages/LandingPage';
import InvoicesPage from './pages/InvoicePage';
import Navbar from './components/navbar/Navbar';
import { Route, Routes } from 'react-router';
import InvoiceDetailPage from './pages/InvoiceDetailPage';
import InvoiceCreationPage from './pages/InvoiceCreationPage';
import OrderPage from './pages/OrderPage';

const App: React.FC = () => {
  return (
    <>
      <div className="d-flex">
        <div className='me-5 pe-5 p-4 sticky-top vh-100 bg-black'>
          <Navbar />
        </div>

        <div className="flex-grow-1 p-4 ms-5 mt-4">
          <Routes>
            <Route path="/" element={<LandingPage />} />
            <Route path="/invoices" element={<InvoicesPage />} />
            <Route path="/invoices/:invoiceId" element={<InvoiceDetailPage />} />
            <Route path="/invoices/create/:orderId" element={<InvoiceCreationPage />} />
            <Route path="/invoices/create/" element={<OrderPage />} />
            <Route path="/orders" element={<OrderPage />} />
            <Route path="*" element={<LandingPage />} />
          </Routes>
        </div>
      </div>
    </>
  );
};

export default App;
