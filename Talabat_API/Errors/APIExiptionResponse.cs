namespace Talabat.API.Errors
{
    public class APIExiptionResponse:APIResponse
    {
        public string? Details { get; set; }

        public APIExiptionResponse(string? Details)
            : base(500)
        {
            this.Details = Details;
        }
    }
}
