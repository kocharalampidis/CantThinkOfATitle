using System.ComponentModel.DataAnnotations;

namespace CantThinkOfATitle.Models
{
    public class Posts
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public User User { get; set; }
        
        public int UserId { get; set; }
    }
}