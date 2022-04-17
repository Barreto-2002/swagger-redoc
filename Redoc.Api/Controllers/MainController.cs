using Microsoft.AspNetCore.Mvc;
using Redoc.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Redoc.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [SwaggerResponse(400, "Bad request", type: typeof(ErrorResponse))]
    [SwaggerResponse(401, "Authorization information is missing or invalid.", type: typeof(ErrorResponse))]

    public abstract class MainController : ControllerBase
    {
    }
}