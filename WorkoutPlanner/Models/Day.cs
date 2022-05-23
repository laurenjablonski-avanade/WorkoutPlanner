using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanner.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Day of exercise is required")]
        [MaxLength(64, ErrorMessage = "Length of Day cannot be greater than 9 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 6 characters")]
        public bool? HasCompleted { get; set; }

    }
}
