import { BrowserRouter } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { Routes } from "./routes";

import { Header } from "./components/Header";
import { Footer } from "./components/Footer";

import { GlobalStyle } from "./styles/global";
import { CartProvider } from "./hooks/useCart";
import { LoadingProvider } from "./hooks/useLoading";
import { AuthProvider } from "./hooks/useAuth";

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <LoadingProvider>
          <CartProvider>
            <Header />
            <GlobalStyle />
            <Routes />
            <ToastContainer autoClose={4000} />
            <Footer />
          </CartProvider>
        </LoadingProvider>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
