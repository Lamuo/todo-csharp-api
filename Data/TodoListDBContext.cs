using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Data
{
    public class TodoListDBContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public TodoListDBContext(DbContextOptions<TodoListDBContext> options)
            :base (options)
        {

        }
    }
}
