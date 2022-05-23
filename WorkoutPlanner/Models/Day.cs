using System.ComponentModel.DataAnnotations;

namespace WorkoutPlanner.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }
        public bool? HasCompleted { get; set; }

    }
}
