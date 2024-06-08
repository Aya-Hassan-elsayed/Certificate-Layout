namespace Certificit.PL.Error
{
    public class ApiServerError : ApiResponse
    {
        public string Detiles { get; set; }
        public ApiServerError(int statusCode , string Message = null , string detiles = null) :base(statusCode, Message)
        {
            Detiles = detiles;
        }
    }
}
