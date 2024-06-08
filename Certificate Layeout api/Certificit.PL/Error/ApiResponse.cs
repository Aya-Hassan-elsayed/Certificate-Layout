namespace Certificit.PL.Error
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int status ,string message = null)
        {
            StatusCode = status;
            Message = message ?? GetDefaultErrorMessageForStatusCode(status);
        }

        public string GetDefaultErrorMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "The request could not be understood or was missing required parameters.";
                case 401:
                    return "Authentication failed or user does not have permissions for the requested operation.";
                case 403:
                    return "Access to the requested resource is forbidden.";
                case 404:
                    return "The requested resource could not be found on the server.";
                case 500:
                    return "An internal server error occurred. Please try again later.";
                default:
                    return "An unknown error occurred. Please contact support for assistance.";
            }
        }

    }
}
