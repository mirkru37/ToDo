using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Services;

namespace ToDo.UnitTest
{
    [TestClass]
    public class TaskTemplateSelectorTest
    {

        [TestMethod]
        public void TestTemplateSelectorDone()
        {
            TaskTemplateSelector TS = new TaskTemplateSelector();
            Model.Task t = new Model.Task();
            t.IsDone = true;
            var template = TS.SelectTemplate(t, null);
            Assert.AreEqual(TS.doneTemplate, template);
        }

        [TestMethod]
        public void TestTemplateSelectorUndone()
        {
            TaskTemplateSelector TS = new TaskTemplateSelector();
            Model.Task t = new Model.Task();
            t.IsDone = false;
            var template = TS.SelectTemplate(t, null);
            Assert.AreEqual(TS.notDoneTemplate, template);
        }
    }
}
