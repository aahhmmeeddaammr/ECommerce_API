namespace Talabat.API.Errors
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public APIResponse(int statusCode) {
            StatusCode = statusCode;
            Message = GetDefaultMessageForStatusCode(statusCode);
        }
        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "UnAuthorized",
                404 => "Not Found",
                500 => "Server Error",
                _ =>null
            };
        }
    }
}
