namespace WebAPI.Models
{
    public class LoginResponse
    {
        public LoginResponse() { }

        public LoginResponse(bool status, string message, string token = null)
        {
            Status = status;
            Token = token;
            Message = message;
        }

        public string Token { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
