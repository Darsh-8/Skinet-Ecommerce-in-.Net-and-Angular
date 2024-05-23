using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controller for handling error responses
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // Ignore this controller in API documentation
    public class ErrorController : BaseApiController
    {
        // Action method to handle error responses
        public IActionResult Error(int code)
        {
            // Return a new ObjectResult with a custom ApiResponse based on the error code
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
