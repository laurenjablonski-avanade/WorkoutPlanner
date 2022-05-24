using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanner.Models
{
    public class TodoExercise
    {
        [Key]
        public int Id { get; set; } //id

        [Required(ErrorMessage = "Exercise name is required")]
        [MaxLength(64, ErrorMessage = "Length of exercise name cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of exercise name cannot be less than 2 characters")]
        public string? ExerciseName { get; set; }//Exercise name

        public string? Duration { get; set; }//duration of exercise / number of reps

        public string? VideoURL { get; set; }//url of video showing the exercise


    }
}