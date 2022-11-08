using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task_Category> Task_Categories { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + " " + Id + " " + Name;
        }
    }
}

