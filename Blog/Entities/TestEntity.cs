using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class TestEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
