using ToDo.Models;
using ToDo.Model;
using ToDo.Services;

namespace ToDo.UnitTest
{
    [TestClass]
    public class TaskExecutorTest
    {
        [TestMethod]
        public void TestExecWeek()
        {
            Week week = new Week(DateTime.Now);
            List<Model.Task>[] expected_tasks = new List<Model.Task>[7];
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                for (int i = 0; i < 7; i++)
                {
                    Model.Task t = new Model.Task();
                    t.Name = $"task{i}";
                    t.Deadline = week.days[i];
                    t.IsDone = false;
                    t.Description = "Dess";
                    expected_tasks[i] = new List<Model.Task>();
                    expected_tasks[i].Add(t);
                    db.Add<Model.Task>(t);
                }

                Model.Task t1 = new Model.Task();
                t1.Name = $"task_less";
                t1.Deadline = week.days[0].AddDays(-1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                t1 = new Model.Task();
                t1.Name = $"task_more";
                t1.Deadline = week.days[0].AddDays(1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                db.SaveChanges();
            }
            List<Model.Task>[] tasks = new List<Model.Task>[7];
            TaskExecutor.ExecWeek(ref tasks, week);
            Assert.AreEqual(tasks.Count(), expected_tasks.Count());
        }

        [TestMethod]
        public void TestExecDay()
        {
            DateTime date = DateTime.Now;
            List<Model.Task> expected_tasks = new List<Model.Task>();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Model.Task t = new Model.Task();
                t.Name = $"task";
                t.Deadline = date;
                t.IsDone = false;
                t.Description = "Dess";
                expected_tasks.Add(t);
                db.Add<Model.Task>(t);

                Model.Task t1 = new Model.Task();
                t1.Name = $"task_less";
                t1.Deadline = date.AddDays(-1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                t1 = new Model.Task();
                t1.Name = $"task_more";
                t1.Deadline = date.AddDays(1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                db.SaveChanges();
            }
            List<Model.Task> tasks = new List<Model.Task>();
            TaskExecutor.ExecDay(ref tasks, date);
            Assert.AreEqual(tasks[0].Name, expected_tasks[0].Name);
            Assert.AreEqual(tasks.Count(), expected_tasks.Count());
        }

        [TestMethod]
        public void TestExecMonthDone()
        {
            DateTime date = DateTime.Now;
            List<Model.Task> expected_tasks = new List<Model.Task>();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Model.Task t = new Model.Task();
                t.Name = $"task";
                t.Deadline = date;
                t.IsDone = true;
                t.Description = "Dess";
                expected_tasks.Add(t);
                db.Add<Model.Task>(t);

                t = new Model.Task();
                t.Name = $"task";
                t.Deadline = date;
                t.IsDone = false;
                t.Description = "Dess";
                db.Add<Model.Task>(t);

                Model.Task t1 = new Model.Task();
                t1.Name = $"task_less";
                t1.Deadline = date.AddMonths(-1);
                t1.IsDone = true;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                t1 = new Model.Task();
                t1.Name = $"task_more";
                t1.Deadline = date.AddMonths(1);
                t1.IsDone = true;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                db.SaveChanges();
            }
            List<Model.Task> tasks = new List<Model.Task>();
            tasks = TaskExecutor.ExecMonth(date, true);
            Assert.AreEqual(tasks[0].Name, expected_tasks[0].Name);
            Assert.AreEqual(tasks.Count(), expected_tasks.Count());
        }

        [TestMethod]
        public void TestExecMonthUndone()
        {
            DateTime date = DateTime.Now;
            List<Model.Task> expected_tasks = new List<Model.Task>();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Model.Task t = new Model.Task();
                t.Name = $"task";
                t.Deadline = date;
                t.IsDone = false;
                t.Description = "Dess";
                expected_tasks.Add(t);
                db.Add<Model.Task>(t);

                t = new Model.Task();
                t.Name = $"task";
                t.Deadline = date;
                t.IsDone = true;
                t.Description = "Dess";
                db.Add<Model.Task>(t);

                Model.Task t1 = new Model.Task();
                t1.Name = $"task_less";
                t1.Deadline = date.AddMonths(-1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                t1 = new Model.Task();
                t1.Name = $"task_more";
                t1.Deadline = date.AddMonths(1);
                t1.IsDone = false;
                t1.Description = "Dess";
                db.Add<Model.Task>(t1);
                db.SaveChanges();
            }
            List<Model.Task> tasks = new List<Model.Task>();
            tasks = TaskExecutor.ExecMonth(date, false);
            Assert.AreEqual(tasks[0].Name, expected_tasks[0].Name);
            Assert.AreEqual(tasks.Count(), expected_tasks.Count());
        }
    }
}