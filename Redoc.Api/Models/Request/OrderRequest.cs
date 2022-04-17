using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Redoc.Api.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace Redoc.Api.Models.Request
{
    public class OrderRequest
    {
        [Required]
        [MaxLength(100)]
        [SwaggerSchema(Description = "Example: Diego Barreto")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(200)]
        [SwaggerSchema(Description = "Example: Av Brigadeiro Faria Lima  N 2343 - São Paulo")]
        public string Address { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        [SwaggerSchema(Description = "Example: 1.200", Format = "decimal")]
        public decimal OrderValue { get; set; }

        [Required]
        public OrderState OrderState { get; set; }

        [Required]
        [SwaggerSchema(Description = "Items of Order")]
        public IEnumerable<OrderItemRequest> OrderItems { get; set; }
    }
}