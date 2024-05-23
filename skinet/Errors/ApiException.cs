namespace API.Errors
{
    // Represents an exception that includes additional details
    public class ApiException : ApiResponse
    {
        // Initializes a new instance of the ApiException class with the specified status code, message, and details
        public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        // Additional details about the exception
        public string Details { get; set; }
    }
}
