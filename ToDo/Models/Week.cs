using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class Week
    {
        public List<DateTime> days;

        public Week(DateTime date) {
            DateTime startOfWeek = date.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)date.DayOfWeek);
            days = Enumerable.Range(0, 7).Select(i => startOfWeek.AddDays(i)).ToList();
        }
    }
}
