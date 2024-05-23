namespace API.Errors
{
    // Represents a standardized API response for validation errors
    public class ApiValidationErrorResponse : ApiResponse
    {
        // Initializes a new instance of the ApiValidationErrorResponse class with status code 400 (Bad Request)
        public ApiValidationErrorResponse() : base(400)
        {
        }

        // Gets or sets the collection of validation errors
        public IEnumerable<string> Errors { get; set; }
    }
}
