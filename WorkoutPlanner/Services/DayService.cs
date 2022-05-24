using WorkoutPlanner.Data.Repositories;
using WorkoutPlanner.Models;

namespace WorkoutPlanner.Services
{
    public class DayService : ICrudService<Day, int>
    {
        private readonly ICrudRepository<Day, int> _dayRepository;
        public DayService(ICrudRepository<Day, int> dayRepository)
        {
            _dayRepository = dayRepository;
        }
        public void Add(Day element)
        {
            _dayRepository.Add(element);
            _dayRepository.Save();
        }
        public void Delete(int id)
        {
            _dayRepository.Delete(id);
            _dayRepository.Save();
        }
        public Day Get(int id)
        {
            return _dayRepository.Get(id);
        }
        public IEnumerable<Day> GetAll()
        {
            return _dayRepository.GetAll();
        }
        public void Update(Day old, Day newT)
        {
            old.ExerciseId = newT.ExerciseId;
            old.HasCompleted = newT.HasCompleted;
            _dayRepository.Update(old);
            _dayRepository.Save();
        }

        public IEnumerable<string> GetJoinedData()
        {
            return ((DayRepository)_dayRepository).GetJoinedData();
        }   
    }
}

