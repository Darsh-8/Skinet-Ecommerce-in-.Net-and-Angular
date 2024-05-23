using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controller for testing different types of errors
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;

        // Constructor to inject StoreContext
        public BuggyController(StoreContext context)
        {
            this.context = context;
        }

        // Action method to simulate a NotFound (404) error
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404)); // Return a NotFound response with custom ApiResponse
            }
            return Ok(); // Return OK if no error occurs
        }

        // Action method to simulate a ServerError (500) error
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = context.Products.Find(42);
            var thingToReturn = thing.ToString(); // This will throw a NullReferenceException to simulate a server error
            return Ok(); // Return OK if no error occurs (won't reach here if an exception is thrown)
        }

        // Action method to simulate a BadRequest (400) error
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400)); // Return a BadRequest response with custom ApiResponse
        }

        // Action method to demonstrate parameterized routes and simulate a NotFound (404) error
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok(); // Return OK for demonstration purposes
        }

    }
}
