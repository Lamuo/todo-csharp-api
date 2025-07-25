using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public PriorityLevel priority { get; set; }
        public DateTime dueDate { get; set; }
        public bool isCompleted { get; set; }

        public TaskItem(int Id, string title, string description, PriorityLevel priority, DateTime dueDate, bool isCompleted)
        {
            this.Id = Id;
            this.title = title;
            this.description = description;
            this.priority = priority;
            this.dueDate = dueDate;
            this.isCompleted = isCompleted;
        }

        public enum PriorityLevel
        {
            Low,
            Medium,
            High
        }
    }
}