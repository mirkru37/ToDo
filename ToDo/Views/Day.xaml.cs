using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDo.Model;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Views;

public partial class Day : Window
{
    private DateTime date;
    private const string HEADER_FORMAT = "D";
    private List<Task> tasks = new List<Task>();
    public Day(DateTime date)
    {
        this.date = date;
        InitializeComponent();
        InitialRender();
    }

    private void InitialRender()
    {
        headerText.Text = date.ToString(HEADER_FORMAT);
        TaskExecutor.ExecDay(ref tasks, date);
        TaskList.ItemsSource = tasks;
    }

    private void OpenMain(object sender, RoutedEventArgs e)
    {
        Window main = new MainWindow(date);
        main.Show();
        this.Close();
    }

    private void NextDay(object sender, RoutedEventArgs e)
    {
        date = date.AddDays(1);
        InitialRender();
    }

    private void PrevDay(object sender, RoutedEventArgs e)
    {
        date = date.AddDays(-1);
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
}