using System;
using Microsoft.AspNetCore.Mvc;
using Redoc.Api.Models;
using Redoc.Api.Models.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace Redoc.Api.Controllers
{
    [Route("api/order-items")]
    public class OrderItemController : MainController
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Post an order item", Description = "Request the creation of an order item.", OperationId = "PostOrderItem")]
        [SwaggerResponse(201, "Resource created successfully", type: typeof(BaseResponse))]
        public IActionResult PostOrder([FromBody] OrderItemRequest orderItem)
        {
            BaseResponse response = new();
            response.DataCreation = DateTime.Now;
            response.Id = 2;

            return CreatedAtAction(null, response);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Put an order item", Description = "Request an order item update.", OperationId = "PutOrderItem")]
        [SwaggerResponse(204, "The resource has been updated successfully")]
        public IActionResult PutOrder([FromBody] OrderItemRequest orderItem)
        {
            return NoContent();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Patch an order item", Description = "Request a partial update of an order item.", OperationId = "PatchOrderItem")]
        [SwaggerResponse(204, "The resource has been partially updated successfully")]
        public IActionResult PatchOrder([FromBody] OrderItemRequest orderItem)
        {
            return NoContent();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete an order item", Description = "Request the removal of an order iten.", OperationId = "DeleteOrderItem")]
        [SwaggerResponse(204, "The resource was deleted successfully")]
        public IActionResult DeleteOrder([FromBody] OrderItemRequest orderItem)
        {
            return NoContent();
        }
    }
}