using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Model
{
    public class Task_Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
