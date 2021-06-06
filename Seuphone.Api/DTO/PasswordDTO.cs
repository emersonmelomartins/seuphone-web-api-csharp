using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.DTO
{
    public class PasswordDTO
    {

        public string OldPassword { get; set; }

        [MinLength(5, ErrorMessage = "O campo senha deve conter entre 5 a 60 caracteres.")]
        [MaxLength(60, ErrorMessage = "O campo senha deve conter entre 5 a 60 caracteres.")]
        [Required(ErrorMessage = "É obrigatório informar a senha.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "É obrigatório confirmar sua senha.")]
        [Compare("NewPassword", ErrorMessage = "As senhas não coincidem.")]
        public virtual string ConfirmNewPassword { get; set; }
    }
}
