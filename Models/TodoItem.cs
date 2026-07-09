using System.ComponentModel.DataAnnotations;
using First.Enums;
using First.Models;

namespace First.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public TodoItemState State { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
