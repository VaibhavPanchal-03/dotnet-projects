using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class TestModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        [MaxLength(10), MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
