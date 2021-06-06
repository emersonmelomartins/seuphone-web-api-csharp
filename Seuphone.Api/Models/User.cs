using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seuphone.Api.Models
{
    [Table("tb_user")]
    
    public class User
    {
        [Key]
        public int Id { get; set; }


        [MinLength(5, ErrorMessage = "O campo e-mail deve conter entre 5 a 40 caracteres.")]
        [MaxLength(40, ErrorMessage = "O campo e-mail deve conter entre 5 a 40 caracteres.")]
        [Required(ErrorMessage = "É obrigatório informar o e-mail.")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "O campo senha deve conter entre 5 a 60 caracteres.")]
        [MaxLength(60, ErrorMessage = "O campo senha deve conter entre 5 a 60 caracteres.")]
        [Required(ErrorMessage = "É obrigatório informar a senha.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "É obrigatório confirmar sua senha.")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public virtual string ConfirmPassword { get; set; }

        [IgnoreDataMember]
        public string Token { get; set; }

        [MinLength(5, ErrorMessage = "O campo nome deve conter entre 5 a 40 caracteres.")]
        [MaxLength(40, ErrorMessage = "O campo nome deve conter entre 5 a 40 caracteres.")]
        [Required(ErrorMessage = "É obrigatório informar o nome.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o gênero.")]
        public char Genre { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a data de nascimento.")]
        public DateTime BirthDate { get; set; }

        [MinLength(14, ErrorMessage = "O campo CPF deve conter 14 caracteres contando com pontuações.")]
        [MaxLength(14, ErrorMessage = "O campo CPF deve conter 14 caracteres contando com pontuações.")]
        [Required(ErrorMessage = "É obrigatório informar o CPF.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o cep.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o endereço.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o número da casa.")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o bairro.")]
        public string District { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a cidade.")]
        public string City { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o estado.")]
        public string State { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }


        public User() { }

        public User(int id, string email, string password, string confirmPassword, string name, char genre, DateTime birthDate, string cPF, string zipCode, string address, int houseNumber, string district, string city, string state)
        {
            Id = id;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Name = name;
            Genre = genre;
            BirthDate = birthDate;
            CPF = cPF;
            ZipCode = zipCode;
            Address = address;
            HouseNumber = houseNumber;
            District = district;
            City = city;
            State = state;
        }

    }



}
