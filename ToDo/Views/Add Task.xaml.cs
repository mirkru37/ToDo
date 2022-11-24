using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ToDo.Model;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Views;

public partial class Add_Task : Window
{
    List<DdlCategory> objCategoryList;
    List<int> catIds = new List<int>();
    public Add_Task()
    {
        InitializeComponent();
        InitialRender();
    }

    private void InitialRender()
    {
        objCategoryList = CategoryExecutor.ExecAll().Select(c => new DdlCategory(c.Id, c.Name, false)).ToList();
        Categories.ItemsSource= objCategoryList;
    }

    private void AllCheckbocx_CheckedAndUnchecked(object sender, RoutedEventArgs e)
    {
        BindListBOX();
    }

    private void BindListBOX()
    {
        catIds.Clear(); 
        List<string> names = new List<string>();
        foreach (var c in objCategoryList)
        {
            if (c.Check_Status == true)
            {
                names.Add(c.Name);
                catIds.Add(c.ID);
            }
        }
        Categories.Text = string.Join("; ", names);
    }


    private void CreateTask(object sender, RoutedEventArgs e)
    {
        List<Category> cats = new List<Category>();
        using (ApplicationContext db = new ApplicationContext())
        {
           cats = db.Categories.Where(c => catIds.Contains(c.Id)).ToList();
        }
        TaskCreator task_creator = new TaskCreator(TaskName.Text, Date.SelectedDate, Time.Text, Description.Text, cats);
        task_creator.Validate();
        if (task_creator.IsValid())
        {
            task_creator.Persist();
            this.Close();
        }
        else
        {
            string msg = String.Join("\n", task_creator.Errors.ToArray());
            MessageBox.Show(msg);
        }
        
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}