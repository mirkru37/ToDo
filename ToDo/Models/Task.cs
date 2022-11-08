using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    internal class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public int UserId { get; set;}
        public User User { get; set; }

        public List<Task_Category> Task_Categories { get; set; }
    }
}
