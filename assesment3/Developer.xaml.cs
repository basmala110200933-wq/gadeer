using assesment3.Data;
using assesment3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace assesment3
{
    /// <summary>
    /// Interaction logic for Developer.xaml
    /// </summary>
    public partial class Developer : Window
    {
        private int _user;
        DContext con = new DContext();
        public Developer(int user)
        {
            InitializeComponent();
           _user = user;
            LoadData();
        }
        public void LoadData()
           
        {
            List<string> list = new List<string> { "Done", "Testing", "In Progress" };
            cmb.ItemsSource = list;
            var cc = con.Tasks.Select(s => new
            {
                TaskID = s.TaskID,
                Title = s.Title,
                TStatus = s.TStatus,
                DueDate = s.DueDate,
           
            }).ToList();
            dgta.ItemsSource = cc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgta.ItemsSource != null)
            {
                dynamic du = dgta.SelectedItem;
                int task=du.TaskID;
                var select = con.Tasks.FirstOrDefault(f => f.TaskID == task);
                if (select != null)
                {
                    select.TStatus = cmb.SelectedItem.ToString();
                    con.Tasks.Update(select);
                    con.SaveChanges();
                    LoadData();
                }
            }
            //if(cmb.SelectedItem != null)
            //{
            //    var newstat = new Tasked()
            //    {
            //        AssignedToUserID=2,
            //        Projectid=1,
            //        Title="titel",
            //        TStatus=cmb.SelectedItem.ToString(),
            //        DueDate=DateTime.Now
            //    };
            //    con.Tasks.Update(newstat);
            //    con.SaveChanges();
            //    LoadData();
            //}
        }

        private void dgta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgta.SelectedItem != null)
            {
                dynamic dx = dgta.SelectedItem;
               cmb.Text=dx.TStatus.ToString();
            }
        }
    }
}
