using log4net;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Model;

namespace ToDo.Services
{
    internal class TaskManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        public static void UpdateDone(Task task, bool value)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var a = db.Tasks.SingleOrDefault(ts => task.Id == ts.Id);
                a.IsDone = value;
                db.SaveChanges();
                log.Error("Just error example");
            }
        }
    }
}
