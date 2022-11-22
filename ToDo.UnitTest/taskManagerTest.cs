using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.UnitTest
{
    [TestClass]
    public class taskManagerTest
    {
        [TestMethod]
        public void TestExecWeek()
        {
            Model.Task t1 = new Model.Task();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                t1.Name = $"task_less";
                t1.Deadline = DateTime.Now;
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                db.SaveChanges();
            }

            TaskManager.UpdateDone(t1, !t1.IsDone);
            Model.Task actual;
            using (ApplicationContext db = new ApplicationContext())
            {
                actual = db.Tasks.SingleOrDefault(ts => t1.Id == ts.Id);
            }
            Assert.AreNotEqual(t1.IsDone, actual.IsDone);
        }
    }
}
