using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seuphone.Api.Models
{
    [Table("tb_user")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }
        //[Required]
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }
        public string Token { get; set; }

        public string Name { get; set; }
        public char Genre { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }

        public string ZipCode { get; set; }
        public string Address { get; set; }
        public int HouseNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public User() { }

        public User(int id, string email, string password, string name, char genre, DateTime birthDate, string cPF, string zipCode, string address, int houseNumber, string district, string city, string state)
        {
            Id = id;
            Email = email;
            Password = password;
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
