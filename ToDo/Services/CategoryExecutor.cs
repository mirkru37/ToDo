using System.Collections.Generic;
using System.Linq;
using ToDo.Model;
using ToDo.Models;

namespace ToDo.Services
{
    public class CategoryExecutor
    {
        public static List<Category> ExecAll()
        {
            List<Category> result = new List<Category>();
            using (ApplicationContext db = new ApplicationContext())
            {
                result = db.Categories.ToList();
            }
            return result;
        }
    }
}

