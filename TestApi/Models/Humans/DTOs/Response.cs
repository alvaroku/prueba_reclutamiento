namespace TestApi.Models.Humans.DTOs
{
    public class Response<ResponseType>
    {
        public ResponseType Data { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public Error GetErrorObject()
        {
            return new Error { Message = ErrorMessage };
        }
    }
}
