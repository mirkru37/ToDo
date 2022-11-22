using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TaskExecutorTest
    {
        [TestMethod]
        public void TestExecWeek()
        {
            week = new Week(currentDate);
            TaskExecutor.ExecWeek(ref tasks, week);
            month_text.Text = currentDate.ToString(MONTH_TEXT_FORMAT);
            for (int i = 0; i < week.days.Count; i++)
            {
                TextBlock tb = (TextBlock)this.FindName($"day_text_{i}");
                tb.Text = week.days[i].ToString(WEEK_DAY_FORMAT);
                ListView d = (ListView)this.FindName($"day_{i + 1}");
                d.ItemsSource = tasks[i];
            }
        }
    }
}