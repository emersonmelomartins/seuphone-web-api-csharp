import { BrowserRouter } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { Routes } from './routes';


import { Header } from "./components/Header";
import { Footer } from './components/Footer';

import { GlobalStyle } from './styles/global';
import { CartProvider } from './hooks/useCart';

function App() {
  return (
    <BrowserRouter>
      <CartProvider>
        <Header />
        <GlobalStyle />
        <Routes />
        <ToastContainer autoClose={4000} />
        <Footer />
      </CartProvider>
    </BrowserRouter>
  );
}

export default App;
