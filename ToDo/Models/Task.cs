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
        public string Description { get; set; }

        public virtual String Categories { get {
                String res = "";
                List<Category> mockCategories = new List<Category> { new Category(Name = "MOCKED"), new Category(Name = "Mocked11") };
                foreach(Category cat in mockCategories) {
                    if (res.Length != 0)
                        res += "\n";
                    res += cat.Name;
                }
                return res;
            } }

        public List<Task_Category> Task_Categories { get; set; } = new List<Task_Category>();
    }
}
