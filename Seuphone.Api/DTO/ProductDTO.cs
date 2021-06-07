using Seuphone.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.DTO
{
    public class ProductDTO
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Storage { get; set; }
        [Required]
        public double Price { get; set; }
        public int StockQuantity { get; set; }
   
        [Column(TypeName = "varchar(MAX)")]
        public string Image { get; set; }
        [Required]
        public int ProviderId { get; set; }

    }
}
