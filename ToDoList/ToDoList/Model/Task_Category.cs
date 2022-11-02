﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    internal class Task_Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + " " + Id + " " + TaskId + " " + CategoryId;
        }
    }
}
