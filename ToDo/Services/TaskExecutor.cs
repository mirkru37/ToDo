using System;
using System.Collections.Generic;

namespace ToDo.Services;

public class TaskExecutor
{
    //when is done default return done tasks as well as not done
    public static List<ToDo.Models.Task> ExecDay(DateTime date, bool isDone = default)
    {
        List<ToDo.Models.Task> result = new List<ToDo.Models.Task>(); //Add logic from EF Ex: Task.where(date: date)
        return result;
    }
    
    public static List<ToDo.Models.Task> ExecWeek(DateTime start, DateTime end, bool isDone = default)
    {
        List<ToDo.Models.Task> result = new List<ToDo.Models.Task>(); //Add logic from EF Ex: Task.where(date: start..end)
        return result;
    }
    
    public static List<ToDo.Models.Task> ExecMonth(DateTime start, DateTime end, bool isDone = default)
    {
        List<ToDo.Models.Task> result = new List<ToDo.Models.Task>(); //Add logic from EF Ex: Task.where(date: start..end)
        return result;
    }

    public static List<ToDo.Models.Task> SearchCategory(ToDo.Models.Task_Category category)
    {
        List<ToDo.Models.Task> result = new List<ToDo.Models.Task>(); //Add logic from EF Ex: Task.where(category: category)
        return result;
    }
}