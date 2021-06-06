using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.Models
{
    public class PasswordReset
    {
        [Required(ErrorMessage = "Necessário informar um e-mail.")]
        public string Email { get; set; }
    }
}
