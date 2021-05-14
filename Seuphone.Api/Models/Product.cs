using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Seuphone.Api.Models;

namespace Seuphone.Api.Models
{
    [Table("tb_product")]
    public class Product
    {
        [Key, ForeignKey("OrderItems")]
        public int Id { get; set; }
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
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Image { get; set; }
        public int ProviderId { get; set; }
        [Required]
        public Provider Provider { get; set; }

        public Product () { }

        public Product(int id, string productName, string description, string model, string color, string storage, double price, int stockQuantity, string image, Provider provider)
        {
            Id = id;
            ProductName = productName;
            Description = description;
            Model = model;
            Color = color;
            Storage = storage;
            Price = price;
            StockQuantity = stockQuantity;
            Image = image;
            Provider = provider;
        }
    }
}
