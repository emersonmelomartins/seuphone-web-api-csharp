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
        public string Description { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Storage { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string Image { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public Product () { }

        public Product(int id, string description, string model, string color, string storage, double price, int stockQuantity, string image, Provider provider)
        {
            Id = id;
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
