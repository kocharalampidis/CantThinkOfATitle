namespace CantThinkOfATitle.Responses.Auth
{
    public class RegisterUserResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
