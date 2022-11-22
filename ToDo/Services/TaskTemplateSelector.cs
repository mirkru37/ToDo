using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ToDo.Model;

namespace ToDo.Services
{
    internal class TaskTemplateSelector:DataTemplateSelector
    {
        public DataTemplate doneTemplate { get; set; }
        public DataTemplate notDoneTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Task t = item as Task;
            if (t.IsDone)
            {
                return doneTemplate;
            }
            else
            {
                return notDoneTemplate;
            }
        }
    }
}
