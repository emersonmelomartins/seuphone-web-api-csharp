using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Seuphone.Api.Models
{
    [Table("tb_role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o nome da função.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 20 caracteres.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 a 20 caracteres.")]
        public string RoleName { get; set; }
        public string Description { get; set; }

        [IgnoreDataMember]
        public virtual List<UserRole> UserRoles { get; set; }

        public Role() { }

        public Role(int id, string roleName, string description)
        {
            Id = id;
            RoleName = roleName;
            Description = description;
        }
    }
}
