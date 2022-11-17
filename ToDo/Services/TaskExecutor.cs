using System;
using System.Collections.Generic;
using ToDo.Model;

namespace ToDo.Services
{
    internal class TaskExecutor
    {
        //when is done default return done tasks as well as not done
        public static List<Task> ExecDay(DateTime date, bool isDone = default)
        {
            List<Task> result = new List<Task>(); //Add logic from EF Ex: Task.where(date: date)
            return result;
        }

        public static List<Task> ExecWeek(DateTime start, DateTime end, bool isDone = default)
        {
            List<Task> result = new List<Task>(); //Add logic from EF Ex: Task.where(date: start..end)
            return result;
        }

        public static List<Task> ExecMonth(DateTime start, DateTime end, bool isDone = default)
        {
            List<Task> result = new List<Task>(); //Add logic from EF Ex: Task.where(date: start..end)
            return result;
        }

        public static List<Task> SearchCategory(Task_Category category)
        {
            List<Task> result = new List<Task>(); //Add logic from EF Ex: Task.where(category: category)
            return result;
        }
    }
}

