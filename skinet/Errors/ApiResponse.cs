namespace API.Errors
{
    // Represents a standardized API response for errors
    public class ApiResponse
    {
        // Initializes a new instance of the ApiResponse class with the specified status code and message
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        // The HTTP status code of the response
        public int StatusCode { get; set; }

        // The message associated with the response
        public string Message { get; set; }

        // Returns a default message for the given status code
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}
