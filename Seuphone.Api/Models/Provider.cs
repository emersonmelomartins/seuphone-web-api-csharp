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
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }

        public string ZipCode { get; set; }
        public string Address { get; set; }
        public int HouseNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
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
