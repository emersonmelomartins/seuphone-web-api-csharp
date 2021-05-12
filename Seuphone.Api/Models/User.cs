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

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }

        [IgnoreDataMember]
        public string Token { get; set; }

        [Required]
        public string Name { get; set; }
        public char Genre { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }


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
