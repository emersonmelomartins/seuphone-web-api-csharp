using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Seuphone.Api.Models
{
    [Table("tb_user_role")]
    public class UserRole
    {
        [IgnoreDataMember]
        public int UserId { get; set; }

        [IgnoreDataMember]
        public User User { get; set; }

        [IgnoreDataMember]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public UserRole() { }

        public UserRole(User user, Role role)
        {
            User = user;
            Role = role;
        }
    }
}
