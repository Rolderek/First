using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace First.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
