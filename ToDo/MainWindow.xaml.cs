using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDo.Model;
using ToDo.Models;
using ToDo.Services;
using ToDo.Views;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string WEEK_DAY_FORMAT = "M";
        private const string MONTH_TEXT_FORMAT = "Y";
        private List<Task>[] tasks = new List<Task>[7];
        private Week week = new Week(DateTime.Today);
        private DateTime currentDate = DateTime.Today;
        private Window addTaskWindow = new Window();

        public MainWindow()
        {
            InitializeComponent();
            InitialRender();
        }

        public MainWindow(DateTime date)
        {
            this.currentDate = date;
            InitializeComponent();
            InitialRender();
        }

        private void InitialRender()
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

        private void nextWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(7);
            InitialRender();
        }

        private void prevWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-7);
            InitialRender();
        }

        private void MarkUndone(object sender, RoutedEventArgs e)
        {
            Task task = (Task)((FrameworkElement)e.Source).DataContext;
            TaskManager.UpdateDone(task, false);
            InitialRender();
        }

        private void MarkDone(object sender, RoutedEventArgs e)
        {
            Task task = (Task)((FrameworkElement)e.Source).DataContext;
            TaskManager.UpdateDone(task, true);
            InitialRender();
        }

        private void OpenDay(object sender, RoutedEventArgs e)
        {
            var t = Int32.Parse(((TextBlock)((Button)e.Source).Content).Name.Split("_").Last());
            Window day = new Day(week.days[t]);
            day.Show();
            this.Close();
        }

        private void OpenDone(object sender, RoutedEventArgs e)
        {
            Window done = new Done(currentDate);
            done.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window addTaskWindow = new Add_Task();
            addTaskWindow.Closing += (o, args) => {
                InitialRender();
            };
            addTaskWindow.Show();
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            Window addTaskWindow = new AddCategory();
            addTaskWindow.Show();
        }
    }
}