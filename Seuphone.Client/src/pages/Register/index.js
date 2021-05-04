import React from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";

import { RegisterContainer } from "./styles";
import axios from "axios";

export function Register() {
  const { register, getValues, setValue } = useForm();

  async function pesquisacep(event) {
    const valor = event.target.value;
    var cep = valor.replace(/\D/g, "");

    if (cep !== "") {
      var validacep = /^[0-9]{8}$/;

      if (validacep.test(cep)) {
        setValue("city", "...");
        setValue("district", "...");
        setValue("address", "...");

        const response = await axios.get(
          "https://viacep.com.br/ws/" + cep + "/json/"
        );

        const viacep = response.data;

        setValue("city", viacep.localidade);
        setValue("district", viacep.bairro);
        setValue("address", viacep.logradouro);
      }
    }
  }

  return (
    <RegisterContainer>
      <div className="empty-container seuphone-background"></div>
      <div className="container py-5">
        <form className="bg-light p-5 mx-auto">
          <h1 className="py-2 text-uppercase">Novo Cadastro</h1>

          <br />
          <h4>Informações de Login</h4>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="input-email">E-mail</label>
              <input
                {...register("email")}
                type="email"
                className="form-control"
                id="input-email"
                placeholder="Ex: seuemail@email.com"
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="input-password">Senha</label>
              <input
                {...register("password")}
                type="password"
                className="form-control"
                id="input-password"
                placeholder="*******"
              />
            </div>
          </div>

          <br />
          <h4>Informações Pessoais</h4>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="input-name">Nome Completo</label>
              <input
                {...register("name")}
                type="text"
                className="form-control"
                id="input-name"
                placeholder="Ex: João da Silva"
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-genre">Sexo</label>
              <select id="input-genre" className="form-control">
                <option value="">Selecione o sexo...</option>
                <option value="M">Masculino</option>
                <option value="F">Feminino</option>
                <option value="X">Prefiro não informar</option>
              </select>
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-cpf">CPF</label>
              <input
                {...register("cpf")}
                type="text"
                className="form-control"
                id="input-cpf"
                placeholder="Ex: 123.456.789-10"
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-date">Data de Nascimento</label>
              <input
                {...register("birthdate")}
                type="date"
                className="form-control"
                id="input-date"
              />
            </div>
          </div>

          <br />
          <h4>Endereço</h4>
          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-zipcode">CEP</label>
              <input
                {...register("zipcode")}
                type="text"
                className="form-control"
                id="input-zipcode"
                size="10"
                maxLength="9"
                defaultValue=""
                placeholder="Ex: 09112-000"
                onBlur={pesquisacep}
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-8">
              <label htmlFor="input-address">Logradouro</label>
              <input
                {...register("address")}
                type="text"
                className="form-control"
                id="input-address"
                placeholder="Ex: Rua Machado de Assis"
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-district">Bairro</label>
              <input
                {...register("district")}
                type="text"
                className="form-control"
                id="input-district"
                placeholder="Ex: Bota Fogo"
              />
            </div>

            <div className="form-group col-md-4">
              <label htmlFor="input-city">Cidade</label>
              <input
                {...register("city")}
                type="text"
                className="form-control"
                id="input-city"
                placeholder="Ex: Mauá"
              />
            </div>
          </div>

          <div className="form-row">
            <div className="form-group col-md-4">
              <label htmlFor="input-state">Estado</label>
              <select id="input-state" className="form-control">
                <option value="">Selecione o estado...</option>
                <option value="AC">Acre</option>
                <option value="AL">Alagoas</option>
                <option value="AP">Amapá</option>
                <option value="AM">Amazonas</option>
                <option value="BA">Bahia</option>
                <option value="CE">Ceará</option>
                <option value="DF">Distrito Federal</option>
                <option value="ES">Espírito Santo</option>
                <option value="GO">Goiás</option>
                <option value="MA">Maranhão</option>
                <option value="MT">Mato Grosso</option>
                <option value="MS">Mato Grosso do Sul</option>
                <option value="MG">Minas Gerais</option>
                <option value="PA">Pará</option>
                <option value="PB">Paraíba</option>
                <option value="PR">Paraná</option>
                <option value="PE">Pernambuco</option>
                <option value="PI">Piauí</option>
                <option value="RJ">Rio de Janeiro</option>
                <option value="RN">Rio Grande do Norte</option>
                <option value="RS">Rio Grande do Sul</option>
                <option value="RO">Rondônia</option>
                <option value="RR">Roraima</option>
                <option value="SC">Santa Catarina</option>
                <option value="SP">São Paulo</option>
                <option value="SE">Sergipe</option>
                <option value="TO">Tocantins</option>
              </select>
            </div>
          </div>

          <button
            type="submit"
            className="btn btn-outline-success btn-rounded-seuphone"
            onClick={(event) => {
              event.preventDefault();
              console.log(getValues());
            }}
          >
            <i className="far fa-circle"></i> Cadastrar
          </button>
          <Link
            className="btn btn-outline-danger btn-rounded-seuphone"
            to="/login"
          >
            <i className="far fa-times-circle"></i> Cancelar
          </Link>
        </form>
      </div>
    </RegisterContainer>
  );
}
