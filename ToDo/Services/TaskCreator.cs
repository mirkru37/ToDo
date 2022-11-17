using System;
using System.Collections.Generic;
using ToDo.Model;

namespace ToDo.Services
{

    internal class TaskCreator
    {
        private string Title { get; set; }
        private DateTime Deadline { get; set; }
        private string Description { get; set; }
        private Task_Category Task_Category { get; set; }

        public List<string> Errors { get; }

        public TaskCreator(string title, DateTime deadline, string description, Task_Category taskCategory)
        {
            Title = title;
            Deadline = deadline;
            Description = description;
            Task_Category = taskCategory;
        }

        public bool Validate()
        {
            return validateTitle() &&
                   validateDeadline() &&
                   validateDescription() &&
                   validateCategory();

        }

        private bool validateTitle()
        {
            // implement logic with EF
            // if title.valid?
            //  return true
            // else
            //  return false
            // ))
            return true;
        }

        private bool validateDeadline()
        {
            // implement logic with EF
            // if title.valid?
            //  return true
            // else
            //  return false
            // ))
            return true;
        }

        private bool validateDescription()
        {
            // implement logic with EF
            // if title.valid?
            //  return true
            // else
            //  return false
            // ))
            return true;
        }

        private bool validateCategory()
        {
            // implement logic with EF
            // if title.valid?
            //  return true
            // else
            //  return false
            // ))
            return true;
        }
    }
}