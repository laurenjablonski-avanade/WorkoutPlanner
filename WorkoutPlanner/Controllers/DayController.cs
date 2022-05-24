using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Models;
using WorkoutPlanner.Services;


namespace WorkoutPlanner.Controllers
{

    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/todo
    public class DayController : ControllerBase
    {
        private readonly ICrudService<Day, int> _dayService;
       
        public DayController(ICrudService<Day, int> dayService)
        {
            _dayService = dayService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Day>> GetAll() => _dayService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Day> Get(int id)
        {
            var todo = _dayService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Day todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _dayService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Day todo)
        {
            var existingTodoItem = _dayService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _dayService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _dayService.Get(id);
            if (todo is null) return NotFound();
            _dayService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("info")]

        public ActionResult<List<string>> GetInfo()
        {
            return ((DayService)_dayService).GetJoinedData().ToList();
        }
        

    }
}
