using Microsoft.EntityFrameworkCore;
using WorkoutPlanner.Models;


namespace WorkoutPlanner.Data
{
    public class TodoExerciseContext : DbContext
    {
        public TodoExerciseContext(DbContextOptions<TodoExerciseContext> options) : base(options)
        {
        }
        public DbSet<TodoExercise> Exercises { get; set; }//so now we are setting the name of the database table to be Exercise
        public DbSet<Day> Day { get; set; }
    }
}
