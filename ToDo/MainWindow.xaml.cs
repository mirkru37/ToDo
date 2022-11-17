using System;
using System.Collections.Generic;
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

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using(ApplicationContext db = new ApplicationContext())
            {
                Category category = new Category(); ;
                db.Categories.Add(category);
                List<Category> t = db.Categories.ToList();
                //Console.WriteLine(t.Count);
                lable1.Content = t.Count;
            }
            
        }
    }
}