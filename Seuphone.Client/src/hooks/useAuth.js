import { decode } from "jsonwebtoken";
import { createContext, useContext, useState } from "react";
import { Redirect, useHistory } from "react-router";
import { toast } from "react-toastify";
import { Routes } from "../routes";
import api from "../services/api";
import { UserAuthenticate, GetUser } from "../services/userService";

const AuthContext = createContext({});

export function AuthProvider({ children }) {
  const history = useHistory();

  const [user, setUser] = useState(() => {
    const storagedUser = localStorage.getItem("@Seuphone::user");

    if (storagedUser) {
      api.defaults.headers.Authorization = `Bearer ${storagedUser.token}`;
      return JSON.parse(storagedUser);
    }

    return null;
  });

  function Authenticate(form) {
    form = {
      email: "bob.brown@gmail.com",
      password: "654321",
    };
    UserAuthenticate(form).then(
      (resp) => {
        const token = resp.data;

        const userInfo = {
          token,
          decodedToken: decode(token),
        };

        // GetUser(userInfo.decodedToken.nameid).then((resp) => {
        //   setUser(resp.data);
        // });
        setUser(userInfo);
        api.defaults.headers.Authorization = `Bearer ${token}`;

        toast.success(
          "Usuário autenticado, redirecionando para página inicial"
        );

        history.push("/");

        localStorage.setItem("@Seuphone::token", token);
        localStorage.setItem("@Seuphone::user", JSON.stringify(userInfo));
      },
      (error) => {
        const erro = error.response.data;
        toast.error(erro);
      }
    );
  }

  function Logout() {
    setUser(null);
    localStorage.removeItem("@Seuphone::user");
    localStorage.removeItem("@Seuphone::token");
  }

  return (
    <AuthContext.Provider
      value={{ signed: Boolean(user), user, Authenticate, Logout }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);

  return context;
}
