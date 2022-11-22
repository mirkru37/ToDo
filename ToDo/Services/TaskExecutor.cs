using log4net;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Model;
using ToDo.Models;
using log4net;
using MySqlX.XDevAPI.Common;

namespace ToDo.Services
{
    internal class TaskExecutor
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        public static void ExecWeek(ref List<Task>[] tasks, Week week)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                for (int i = 0; i < week.days.Count; i++)
                {
                    tasks[i] = db.Tasks.Where(t => t.Deadline == week.days[i]).ToList();
                }
            }
            log.Info($"Wekly tasks was executed. Week day: {week.days[0]}");
        }

        public static List<Task> ExecMonth(DateTime date, bool isDone = default)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            List<Task> result = new List<Task>();
            using (ApplicationContext db = new ApplicationContext())
            {
                result = db.Tasks.Where(t => t.Deadline > startDate && t.Deadline < endDate && t.IsDone == isDone).ToList();
            }
            log.Info($"{result.Count} monthly tasks was executed"); 
            return result;
        }

        public static List<Task> SearchCategory(Task_Category category)
        {
            List<Task> result = new List<Task>(); //Add logic from EF Ex: Task.where(category: category)
            return result;
        }

        internal static void ExecDay(ref List<Task> tasks, DateTime date)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                tasks = db.Tasks.Where(t => t.Deadline == date).ToList();
            }
            log.Info($"{tasks.Count} daily tasks was executed");
        }
    }
}

