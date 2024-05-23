using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Base API controller class for all API controllers in the application
    [ApiController] // Attribute indicating that this class is an API controller
    [Route("api/[controller]")] // Attribute defining the base route for API endpoints
    public class BaseApiController : ControllerBase
    {
        // This class doesn't contain any additional logic or properties, serving as a base for other API controllers.
        // It inherits from ControllerBase, the base class for ASP.NET Core API controllers.
        // [ApiController] attribute provides various features such as automatic HTTP 400 responses for invalid models, binding source parameter inference, etc.
        // [Route] attribute specifies the route template for the controller, which includes the base route and replaces [controller] with the name of the controller class.
    }
}
