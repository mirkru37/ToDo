using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        public virtual String Categories { get {
                String res = "";
                List<Category> categories = new List<Category>();
                //List<Category> mockCategories = new List<Category> { new Category(Name = "MOCKED"), new Category(Name = "Mocked11") };
                using (ApplicationContext db = new ApplicationContext())
                {
                    List<Task_Category> tc = db.Task_Category.Where(tc_ => tc_.TaskId == Id).ToList();
                    List<int> c_id = tc.Select(tc_ => tc_.CategoryId).ToList();
                    categories = db.Categories.Where(c_ => c_id.Contains(c_.Id)).ToList();
                }
                foreach (Category cat in categories) {
                    if (res.Length != 0)
                        res += "\n";
                    res += cat.Name;
                }
                if (res.Length == 0)
                {
                    res = "Uncategorised";
                }
                return res;
            } }

        public List<Task_Category> Task_Categories { get; set; } = new List<Task_Category>();
    }
}
