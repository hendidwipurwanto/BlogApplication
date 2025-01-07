using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public  string ImageUrl{ get; set; }
        public string Content { get; set; }

        public int Status { get; set; }

    }
}
