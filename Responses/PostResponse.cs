namespace CantThinkOfATitle.Responses
{
    public class PostResponse<T>
    {

        public T? Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

    }
}
