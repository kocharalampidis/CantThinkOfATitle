using System.ComponentModel.DataAnnotations;

namespace CantThinkOfATitle.Models
{
    public class Posts
    {
        //private int Id { get; set; }
        [Key]
        public int Id { get; set; }
    
        public string Title { get; set; }

        public string Body { get; set; }
    }
}

//"userId": 1,
//    "id": 1,
//    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
//    "body"