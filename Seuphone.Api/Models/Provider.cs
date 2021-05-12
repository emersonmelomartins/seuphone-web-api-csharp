using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Seuphone.Api.Models
{
    [Table("tb_provider")]
    public class Provider
    {
        [Key, ForeignKey("Product")]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CNPJ { get; set; }
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

        public Provider() { }

        public Provider(int id, string companyName, string cNPJ, string zipCode, string address, int houseNumber, string district, string city, string state)
        {
            Id = id;
            CompanyName = companyName;
            CNPJ = cNPJ;
            ZipCode = zipCode;
            Address = address;
            HouseNumber = houseNumber;
            District = district;
            City = city;
            State = state;
        }

    }


}
