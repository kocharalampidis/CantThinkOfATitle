namespace CantThinkOfATitle.Responses.Auth
{
    public class LoginResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string Token { get; set; }
    }
}
