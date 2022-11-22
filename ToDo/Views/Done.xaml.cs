using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using ToDo.Model;
using ToDo.Services;

namespace ToDo.Views;

public partial class Done : Window
{
    private DateTime date;
    private List<Task> DoneCollection = new List<Task>();
    private List<Task> UndoneCollection = new List<Task>();
    public Done(DateTime currentDate)
    {
        this.date = currentDate;
        InitializeComponent();
        InitialRender();
    }

    private void InitialRender()
    {
        DoneCollection = TaskExecutor.ExecMonth(date, true);
        UndoneCollection = TaskExecutor.ExecMonth(date, false);
        DoneList.ItemsSource= DoneCollection;
        UndoneList.ItemsSource= UndoneCollection;
    }

    private void OpenMain(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}