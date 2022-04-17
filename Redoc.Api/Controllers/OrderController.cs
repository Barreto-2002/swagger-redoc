using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Redoc.Api.Models;
using Redoc.Api.Models.Request;
using Redoc.Api.Models.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace Redoc.Api.Controllers
{
    [Route("api/orders")]
    public class OrderController : MainController
    {

        [HttpGet]
        [SwaggerOperation(Summary = "Get an order by Order ID", Description = "Rquest an order by it's Order ID.",OperationId = "GetOrder")]
        [SwaggerResponse(200, "Resource found successfully", type: typeof(OrderResponse))]
        [SwaggerResponse(404, "Resource found not found")]
        public IActionResult GetOrder([FromQuery(Name ="Order-id"), SwaggerParameter("Order ID", Required = true)] int orderId)
        {
            var order = new OrderResponse
            {
                Id = 1,
                OrderId = 44,
                CustomerName = "Diego Barreto",
                Address = "Av Ibirapuera 4432",
                OrderValue = 1500,
                    OrderItems = new List<OrderItemResponse>
                    {
                        new OrderItemResponse
                        {
                            Name = "Macbook pro",
                            Description = "MacBook Pro 16 Apple Chip M1 Pro (16GB RAM 512GB SSD) Space Gray",
                            Price = 900,
                            Quantity = 1
                        },
                        new OrderItemResponse
                        {
                            Name = "Apple pencil",
                            Description = "White Apple Pencil Pen for iPad Pro 11' and Pro 12.9",
                            Price = 300,
                            Quantity = 2
                        }
                    }
            };

            if (order.OrderId !=  orderId)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Post an order", Description = "Request the creation of an order.", OperationId = "PostOrder")]
        [SwaggerResponse(201, "Resource created successfully", type: typeof(BaseResponse))]
        public IActionResult PostOrder([FromBody] OrderRequest order)
        {
            BaseResponse response = new ();
            response.DataCreation = DateTime.Now;
            response.Id = 2;

            return CreatedAtAction(nameof(GetOrder), new { response.Id }, response);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Put an order", Description = "Request an order update.", OperationId = "PutOrder")]
        [SwaggerResponse(204, "The resource has been updated successfully")]
        public IActionResult PutOrder([FromBody] OrderRequest orderId)
        {
            return NoContent();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Patch an order", Description = "Request a partial update of an order.", OperationId = "PatchOrder")]
        [SwaggerResponse(204, "The resource has been partially updated successfully")]
        public IActionResult PatchOrder([FromBody] OrderRequest orderId)
        {
            return NoContent();
        }

        [HttpDelete("{item-id}")]
        [SwaggerOperation(Summary = "Delete an order", Description = "Request the removal of an order.", OperationId = "DeleteOrder")]
        [SwaggerResponse(204, "The resource was deleted successfully")]
        public IActionResult DeleteOrder([FromRoute(Name = "item-id")] int itemId)
        {
            return NoContent();
        }
    }
}