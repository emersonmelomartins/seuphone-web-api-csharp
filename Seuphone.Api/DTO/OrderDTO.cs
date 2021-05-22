using Seuphone.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int ContractDuration { get; set; }

    }
}
