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


        public IEnumerable<string> GetJoinedData()
        {
            List<Day> day = _todoExerciseContext.Day.ToList();
            List<TodoExercise> exercises = _todoExerciseContext.Exercises.ToList();

            var result = from days in day //second day is a collection. eachrow from dayz collection in turn and call it day
                         join exercise in exercises //join with the other exercises collection
                         on days.ExerciseId equals exercise.Id //there;s a column in the day table called exercise id which needs to match the id field in the exercise table
                         select $"{days.HasCompleted} {exercise.ExerciseName}";//what will we return from this - instead of selecitng a new obect, just return a string from the data collected from the 2 tables. 


            return result;
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

