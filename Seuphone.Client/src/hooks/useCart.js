import React, { createContext, useContext, useState } from 'react';
import { toast } from 'react-toastify';

import { GetProduct } from '../services/productService';

const CartContext = createContext({});

export function CartProvider({children}) {
  const [cart, setCart] = useState(() => {
    const storagedCart = localStorage.getItem("@Seuphone::cart");

    if(storagedCart) {
      return JSON.parse(storagedCart);
    }

    return [];
  });

    const addProduct = async (productId, productQtd) => {
      

    try {
      const checkProductInCart = cart.find(
        (product) => product.id === productId
      );

      // Verifica se produto já ta no carrinho
      if(!checkProductInCart) {
        const product = await GetProduct(productId).then((resp) => resp.data);

        // Verifica se produto possui estoque
        if(product.stockQuantity > 0 && product.stockQuantity >= productQtd) {

          setCart([...cart, { ...product, cartQuantity: productQtd }])
          localStorage.setItem("@Seuphone::cart", JSON.stringify([...cart, { ...product, cartQuantity: productQtd }]));

          toast.success("Produto adicionado ao carrinho com sucesso!");
          return;
        } else {
          toast.error("Quantidade solicitada fora de estoque");
        }
      }

      // Se o produto existir no carrinho
      if (checkProductInCart) {
        const product = await GetProduct(productId).then((resp) => resp.data);

        // Se o estoque for maior que a quantidade desejada
        if (product.stockQuantity > checkProductInCart.cartQuantity) {
          const updatedCart = cart.map((cartProduct) =>
            cartProduct.id === productId
              ? {
                  ...cartProduct,
                  cartQuantity: cartProduct.cartQuantity + productQtd,
                }
              : cartProduct
          );

          setCart(updatedCart);
          localStorage.setItem(
            "@Seuphone::cart",
            JSON.stringify(updatedCart)
          );
          return;

        } else {
          toast.error("Quantidade solicitada fora de estoque");
        }
      }

    } catch {
      toast.error("Ocorreu um erro ao adicionar produto ao carrinho.");
    }
  };

  const removeProduct = async (productId) => {
    try {
      const checkProductInCartIndex = cart.findIndex(
        (product) => product.id === productId
      );

      if (checkProductInCartIndex === -1) {
        toast.error("O produto a ser removido não foi encontrado.");
        return;
      }

      const updatedCart = cart.filter((product) => product.id !== productId);

      setCart(updatedCart);
      localStorage.setItem("@Seuphone::cart", JSON.stringify(updatedCart));

    } catch {
      toast.error("Ocorreu um erro ao remover um produto do carrinho.");
      return;
    }
  }


  return (
    <CartContext.Provider value={{ cart, addProduct, removeProduct }}>
      {children}
    </CartContext.Provider>
  )
}

export function useCart() {
  const context = useContext(CartContext);

  return context;
}