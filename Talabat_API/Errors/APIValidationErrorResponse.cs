namespace Talabat.API.Errors
{
    public class APIValidationErrorResponse:APIResponse
    {
        public IEnumerable<String> Errors { get; set; }

        public APIValidationErrorResponse()
            :base(400)
        {
            Errors = new List<String>(); 
        }
    }
}
