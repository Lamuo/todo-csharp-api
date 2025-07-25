using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly TodoListDBContext _context;

        public TodoListController(TodoListDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> CreateEdit(TaskItem task)
        {
            if (task.Id == 0)
            {
                await _context.Tasks.AddAsync(task);
            }
            else
            {
                var taskInDb = await _context.Tasks.FindAsync(task.Id);

                if (taskInDb == null)
                    return new JsonResult(NotFound());

                taskInDb = task;
            }
            await _context.SaveChangesAsync();

            return new JsonResult(Ok(task));
        }

        [HttpGet]
        public async Task<JsonResult> Get(int Id)
        {
            var result = await _context.Tasks.FindAsync(Id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]

        public async Task<JsonResult> Delete(int Id)
        {
            var result = await _context.Tasks.FindAsync(Id);

            if (result == null) return new JsonResult(NotFound());

            _context.Tasks.Remove(result);
            await _context.SaveChangesAsync();


            return new JsonResult(NoContent());
        }


        [HttpGet()]
        public async Task<JsonResult> GetAll()
        {
            var result = await _context.Tasks.ToListAsync();

            return new JsonResult(Ok(result));
        }
    }
}
