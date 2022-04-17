using System.Collections.Generic;

namespace Redoc.Api.Models
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public List<ErrorParameterResponse> InvalidParams { get; set; }
    }

    public class ErrorParameterResponse
    {
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}
