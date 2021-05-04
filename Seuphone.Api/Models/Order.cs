using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Seuphone.Api.Models.Enums;

namespace Seuphone.Api.Models
{

    [Table("tb_order")]
    public class Order
    {


        public int Id { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        public Order() { }

        public Order(int id, User user, DateTime creationDate, OrderStatus orderStatus)
        {
            Id = id;
            User = user;
            CreationDate = creationDate;
            OrderStatus = orderStatus;
        }
    }
}
