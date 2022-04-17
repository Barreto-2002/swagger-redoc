namespace Redoc.Api.Models.Response
{
    public class OrderItemResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}