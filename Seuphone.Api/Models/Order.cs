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
    public partial class Order
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

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
