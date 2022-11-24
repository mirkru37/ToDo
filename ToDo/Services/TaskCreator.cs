using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToDo.Model;

namespace ToDo.Services
{

    internal class TaskCreator
    {
        private const int TITLE_MAX = 10;
        private const int DESC_MAX = 100;
        private const int TITLE_MIN = 3;
        private const int DESC_MIN = -1;
        private string Title { get; set; }
        private DateTime? Deadline { get; set; }
        private string Time { get; set; }
        private string Description { get; set; }
        private List<Category> Categories { get; set; }

        public List<string> Errors { get; }

        public TaskCreator(string title, DateTime? deadline, string time, string description, List<Category> categories)
        {
            Title = title;
            Deadline = deadline;
            Description = description;
            Time = time;
            Categories = categories;
            Errors = new List<string>();
        }

        public void Validate()
        {
            Errors.Clear();
            validateTitle();
            validateDescription();
            validateTime();
            validateDate();
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }

        public void Persist()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Task t = new Task();
                t.Name = Title;
                t.Description = Description;
                t.IsDone = false;
                TimeSpan time = TimeSpan.Parse(Time);
                t.Deadline = Deadline.GetValueOrDefault().Add(time);
                db.Add(t);
                db.SaveChanges();
                foreach(Category cat in Categories)
                {
                    Task_Category tc = new Task_Category();
                    tc.CategoryId = cat.Id;
                    tc.TaskId = t.Id;
                    db.Add(tc);
                }

                db.SaveChanges();
            }
        }

        private void validateTitle()
        {
            if(Title.Length >= TITLE_MAX)
            {
                Errors.Add($"Title must be less than {TITLE_MAX} symbols");
                return;
            }
            if (Title.Length <= TITLE_MIN)
            {
                Errors.Add($"Title must be more than {TITLE_MIN} symbols");
                return;
            }
        }

        private void validateTime()
        {
            try
            {
                TimeSpan time = TimeSpan.Parse(Time);
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }
        }

        private void validateDate()
        {
            if (Deadline == null)
            {
                Errors.Add("Dedline must be valid");
            }
        }

        private void validateDescription()
        {
            if (Description.Length >= DESC_MAX)
            {
                Errors.Add($"Description must be less than {DESC_MAX} symbols");
                return;
            }
            if (Description.Length <= DESC_MIN)
            {
                Errors.Add($"Description must be more than {DESC_MIN} symbols");
                return;
            }
        }
    }
}