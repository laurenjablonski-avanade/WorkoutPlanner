using Microsoft.AspNetCore.Mvc;
using WorkoutPlanner.Models;
using WorkoutPlanner.Services;


namespace WorkoutPlanner.Controllers
{

    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/todo
    public class TodoExerciseController : ControllerBase
    {
        private readonly ICrudService<TodoExercise, int> _todoExerciseService;
        //private ICrudService<TodoExercise, int> _todoExerciseService;

        public TodoExerciseController(ICrudService<TodoExercise, int> todoExerciseService)
        {
            _todoExerciseService = todoExerciseService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<TodoExercise>> GetAll() => _todoExerciseService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<TodoExercise> Get(int id)
        {
            var todo = _todoExerciseService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(TodoExercise todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _todoExerciseService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoExercise todo)
        {
            var existingTodoItem = _todoExerciseService.Get(id);
            if (existingTodoItem is null || existingTodoItem.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _todoExerciseService.Update(existingTodoItem, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoExerciseService.Get(id);
            if (todo is null) return NotFound();
            _todoExerciseService.Delete(id);
            return NoContent();
        }
    }
}
