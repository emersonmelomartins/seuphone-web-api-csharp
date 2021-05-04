using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Seuphone.Api.Models;

namespace Seuphone.Api.Models
{
    [Table("tb_order_items")]
    public class OrderItems
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }

        [NotMapped]
        public Order Order { get; set; }

        public OrderItems() { }

        public OrderItems(int id, Product product, int quantity, double total, Order order)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            Total = total;
            Order = order;
        }
    }
}
