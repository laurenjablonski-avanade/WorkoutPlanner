using WorkoutPlanner.Data.Repositories;
using WorkoutPlanner.Models;

namespace WorkoutPlanner.Services
{
    public class TodoExerciseService : ICrudService<TodoExercise, int>
    {
        private readonly ICrudRepository<TodoExercise, int> _todoExerciseRepository;
        public TodoExerciseService(ICrudRepository<TodoExercise, int> todoExerciseRepository)
        {
            _todoExerciseRepository = todoExerciseRepository;
        }
        public void Add(TodoExercise element)
        {
            _todoExerciseRepository.Add(element);
            _todoExerciseRepository.Save();
        }
        public void Delete(int id)
        {
            _todoExerciseRepository.Delete(id);
            _todoExerciseRepository.Save();
        }
        public TodoExercise Get(int id)
        {
            return _todoExerciseRepository.Get(id);
        }
        public IEnumerable<TodoExercise> GetAll()
        {
            return _todoExerciseRepository.GetAll();
        }
        public void Update(TodoExercise old, TodoExercise newT)
        {
            old.ExerciseName = newT.ExerciseName;
            old.Duration = newT.Duration;
            old.VideoURL = newT.VideoURL;
            _todoExerciseRepository.Update(old);
            _todoExerciseRepository.Save();
        }
    }
}
