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
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public double Total { get; set; }
        [Required(ErrorMessage = "É obrigatório escolher a duração do contrato.")]
        [Range(0, 2, ErrorMessage = "É obrigatório informar entre 1 ou 2 anos de duração do contrato.")]
        public int ContractDuration { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        [Required(ErrorMessage = "É obrigatório escolher um método de pagamento.")]
        [Range(1, 2, ErrorMessage = "É obrigatório informar o método de pagamento entre 'Cartão de Crédito' ou 'Carnê'.")]
        public PaymentMethod PaymentMethod { get; set; }
        public OrderType OrderType { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

        public Order() { }

        public Order(int id, User user, DateTime creationDate,
            OrderStatus orderStatus, PaymentMethod paymentMethod,
            double total, int contractDuration, OrderType orderType)
        {
            Id = id;
            User = user;
            CreationDate = creationDate;
            OrderStatus = orderStatus;
            PaymentMethod = paymentMethod;
            Total = total;
            ContractDuration = contractDuration;
            OrderType = orderType;
        }
    }
}
