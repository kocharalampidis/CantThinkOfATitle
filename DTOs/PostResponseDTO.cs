using CantThinkOfATitle.Models;

namespace CantThinkOfATitle.DTOs
{
    public class PostResponseDTO
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public UserDTO User { get; set; }
    }
}
