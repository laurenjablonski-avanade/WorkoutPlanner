using WorkoutPlanner.Models;

namespace WorkoutPlanner.Data.Repositories
{
    public class TodoExerciseRepository : ICrudRepository<TodoExercise, int>
    {
        private readonly TodoExerciseContext _todoExerciseContext;
        public TodoExerciseRepository(TodoExerciseContext todoExerciseContext)
        {
            _todoExerciseContext = todoExerciseContext ?? throw new
            ArgumentNullException(nameof(todoExerciseContext));
        }
        public void Add(TodoExercise element)
        {
            _todoExerciseContext.Exercises.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _todoExerciseContext.Exercises.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _todoExerciseContext.Exercises.Any(u => u.Id == id);
        }
        public TodoExercise Get(int id)
        {
            return _todoExerciseContext.Exercises.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<TodoExercise> GetAll()
        {
            return _todoExerciseContext.Exercises.ToList();
        }
        public bool Save()
        {
            return _todoExerciseContext.SaveChanges() > 0;
        }
        public void Update(TodoExercise element)
        {
            _todoExerciseContext.Update(element);
        }
    }
}
