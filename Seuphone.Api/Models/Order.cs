using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Seuphone.Api.Models.Enums;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Seuphone.Api.Models
{

    [Table("tb_order")]
    public partial class Order
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public double Total { get; set; }
        [Required]
        public int ContractDuration { get; set; }
        public DateTime CreationDate { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

        public Order() { }

        public Order(int id, User user, DateTime creationDate, OrderStatus orderStatus, double total, int contractDuration)
        {
            Id = id;
            User = user;
            CreationDate = creationDate;
            OrderStatus = orderStatus;
            Total = total;
            ContractDuration = contractDuration;
        }
    }
}
