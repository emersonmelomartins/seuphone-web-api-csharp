using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Seuphone.Api.Models;
using System.Text.Json.Serialization;

namespace Seuphone.Api.Models
{
    [Table("tb_order_items")]
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }

        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public OrderItems() { }

        public OrderItems(int id, Product product, int quantity, double subtotal, Order order)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            SubTotal = subtotal;
            Order = order;
        }
    }
}
