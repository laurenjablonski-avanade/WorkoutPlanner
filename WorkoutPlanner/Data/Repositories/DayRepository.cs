using WorkoutPlanner.Models;

namespace WorkoutPlanner.Data.Repositories
{
    public class DayRepository : ICrudRepository<Day, int>
    {
        private readonly TodoExerciseContext _todoExerciseContext;
        public DayRepository(TodoExerciseContext todoExerciseContext)
        {
            _todoExerciseContext = todoExerciseContext ?? throw new
            ArgumentNullException(nameof(todoExerciseContext));
        }
        public void Add(Day element)
        {
            _todoExerciseContext.Day.Add(element); 
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _todoExerciseContext.Day.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _todoExerciseContext.Day.Any(u => u.Id == id);
        }
        public Day Get(int id)
        {
            return _todoExerciseContext.Day.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Day> GetAll()
        {
            return _todoExerciseContext.Day.ToList();
        }
        public bool Save()
        {
            return _todoExerciseContext.SaveChanges() > 0;
        }
        public void Update(Day element)
        {
            _todoExerciseContext.Update(element);
        }
    }
}

