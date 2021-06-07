using Seuphone.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.DTO
{
    public class UserEditDTO
    {

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public virtual string ConfirmPassword { get; set; }


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
    }
}
