import React from "react";
import { Link } from "react-router-dom";
import { FiSearch, FiShoppingCart } from "react-icons/fi";

import { Cart, HeaderContainer } from "./styles";
import logoImg from "../../assets/img/logo.png";
import { useCart } from "../../hooks/useCart";

export function Header() {

  const { cart } = useCart();
  const cartSize = cart.length;

  return (
    <HeaderContainer>
      <nav className="navbar navbar-dark bg-dark text-light seuphone-background">
        <div className="container">
          <span className="navbar-brand" href="/">
            <span>
              <img src={logoImg} width="90px" alt="" />
            </span>

            <a
              className="navbar-toggler"
              type="button"
              data-toggle="collapse"
              data-target="#togglerMenu"
              href="/"
            >
              <span className="navbar-toggler-icon"></span>
            </a>
          </span>

          <form className="form-inline my-2 my-lg-0 mx-auto">
            <input
              className="form-control"
              type="search"
              placeholder="Buscar por produtos..."
              aria-label="Search"
            />
            <button
              className="btn btn-success btn-seuphone-outline-white btn-search"
              type="submit"
            >
              <FiSearch size="0.9rem" />
            </button>
          </form>

          <Link
            className="btn btn-rounded-seuphone btn-seuphone-outline-white"
            to="/login"
          >
            Entrar / Registrar
          </Link>

          <Cart to="/cart" className="mx-3">
            <FiShoppingCart size={30} color="#FFF" />
            <div className="mx-2">
              <span>
                {cartSize}
              </span>
            </div>
          </Cart>
        </div>

        <div className="container">
          <div className="collapse navbar-collapse" id="togglerMenu">
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link to="/" className="nav-link">
                  Home
                </Link>
              </li>
              <li className="nav-item">
                <Link to="/products" className="nav-link">
                  Produtos
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </HeaderContainer>
  );
}
