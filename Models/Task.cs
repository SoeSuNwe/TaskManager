using System.ComponentModel.DataAnnotations;

namespace TaskCRUDContoller.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title must be at most 100 characters.")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Title can only contain letters, numbers, and spaces.")]
        public string? Title { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; } 
        
    }
    
}
