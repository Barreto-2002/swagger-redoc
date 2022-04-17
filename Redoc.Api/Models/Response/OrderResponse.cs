using System.Collections.Generic;
using Redoc.Api.Utils;

namespace Redoc.Api.Models.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public decimal OrderValue { get; set; }

        public OrderState OrderState { get; set; }

        public IEnumerable<OrderItemResponse> OrderItems { get; set; }
    }
}

