using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenerateData();
            PrintData();
            Console.ReadKey();
        }
        protected static String RandomString(Random random)
        {
            var res = new StringBuilder(random.Next(8, 15));
            char offset = 'a';
            const int lettersOffset = 26; // A...Z or a..z: length=26 
            for (int j = 0; j < 15; j++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                res.Append(@char);
            }
            return res.ToString().ToLower();
        }
        protected static DateTime RandomDay(Random random)
        {
            DateTime start = new DateTime(2022, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        protected static void GenerateData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> toAddUsers = new List<User>();
                List<Model.Task> toAddTask = new List<Model.Task>();
                List<Category> toAddCategory = new List<Category>();
                List<Task_Category> toAddTaskCategory = new List<Task_Category>();
                List<Model.Task> toDelete = db.Tasks.ToList();
                Random random = new Random();
                if (db.Users.ToList().Count() < 30)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        String username = RandomString(random);
                        String password = RandomString(random);

                        toAddUsers.Add(new User
                        {
                            Username = username.ToString().ToLower(),
                            Password = password.ToString().ToLower()
                        });

                    }
                }
                if (db.Categories.ToList().Count() < 30)
                {

                    for (int i = 0; i < 30; i++)
                    {
                        String categoryName = RandomString(random);
                        toAddCategory.Add(new Category { Name = categoryName.ToString().ToLower() });
                    }

                }
                if (db.Tasks.ToList().Count() < 30)
                {

                    for (int i = 0; i < 30; i++)
                    {
                        String name = RandomString(random);
                        bool isDone = random.Next(-100, 100) > 0;
                        int userIndex = random.Next(0, db.Users.ToList().Capacity - 2);
                        User user = db.Users.ToList()[userIndex];
                        toAddTask.Add(new Model.Task
                        {
                            Name = name,
                            IsDone = isDone,
                            Deadline = RandomDay(random),
                            Priority = random.Next(0, 10),
                            User = user,
                            UserId = user.Id

                        });
                    }

                }
                if (db.Task_Category.ToList().Count() < 30)
                {

                    for (int i = 0; i < 30; i++)
                    {
                        int taskIndex = random.Next(0, db.Tasks.ToList().Capacity - 2);
                        Model.Task task = db.Tasks.ToList()[taskIndex];
                        int categoryIndex = random.Next(0, db.Categories.ToList().Capacity - 2);
                        Category category = db.Categories.ToList()[categoryIndex];
                        toAddTaskCategory.Add(new Task_Category
                        {
                            Task = task,
                            TaskId = task.Id,
                            Category = category,
                            CategoryId = category.Id
                        });
                    }


                }

                /*else
                {
                    foreach(var u in toDelete)
                    {
                        db.Tasks.Remove(u);
                    }
                }*/
                db.Users.AddRange(toAddUsers);
                db.Categories.AddRange(toAddCategory);
                db.Tasks.AddRange(toAddTask);
                db.Task_Category.AddRange(toAddTaskCategory);
                db.SaveChanges();

            }
        }
        protected static void PrintData()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                foreach(var user in db.Users)
                {
                    Console.WriteLine(user);
                }
                foreach (var task in db.Tasks)
                {
                    Console.WriteLine(task);
                }
                foreach (var category in db.Categories)
                {
                    Console.WriteLine(category);
                }
                foreach (var task_Category in db.Task_Category)
                {
                    Console.WriteLine(task_Category);
                }
            }
        }
    }
}
