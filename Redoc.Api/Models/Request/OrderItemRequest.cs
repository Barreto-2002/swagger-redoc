using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Redoc.Api.Models.Request
{
    public class OrderItemRequest
    {
        [Required]
        [MaxLength(50)]
        [SwaggerSchema(Description = "Example: TV Samsung 75' 4K")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [SwaggerSchema(Description = "Example: Samsung Smart Tv 75' Crystal Uhd 4k 75au800, Painel Dynamic Crystal Color, Design Slim")]
        public string Description { get; set; }

        [Required]
        [Range(0, 9999999999999999.99)]
        [SwaggerSchema(Description = "Example: 5.200", Format = "decimal")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 10)]
        [SwaggerSchema(Description = "Example: 1")]
        public int Quantity { get; set; }
    }
}