using assesment3.Data;
using assesment3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace assesment3
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        DContext con = new DContext();
        public Manager()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            var aa = con.Users.ToList();
            cmb.ItemsSource = aa;
            cmb.DisplayMemberPath = "UName";
            cmb.SelectedValuePath = "UserID";
            var cc = con.Projects.Include(u => u.taskeds).Select(s => new
            {
                ProjectID = s.ProjectID,
                PName=s.PName,
                PDescription=s.PDescription,
                StartDate =s.StartDate,
                EndDate =s.EndDate
            }).ToList();
            dgemp.ItemsSource = cc;
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtdes.Text))
            {
                MessageBox.Show("complete");
                return;
            }
            var newproj = new Project()
            {
              
                PName=txtname.Text,
                PDescription=txtdes.Text,
                StartDate=DateTime.Now,
                EndDate=DateTime.Now,
            };
            con.Projects.Add(newproj);
            con.SaveChanges();
            LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           if(dgemp.ItemsSource != null)
            {
                var select=con.Projects.FirstOrDefault(f=>f.ProjectID==int.Parse(txtid.Text));
                if(select != null)
                {
                    select.PName=txtname.Text;
                    select.PDescription=txtdes.Text;
                    con.Projects.Update(select);
                    con.SaveChanges();
                    LoadData();
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(dgemp.SelectedItem!=null)
            {
                
                var select = con.Projects.FirstOrDefault(f => f.ProjectID == int.Parse(txtid.Text));
                var res=MessageBox.Show("Are you sure?","confirm",MessageBoxButton.YesNo);
                if(res == MessageBoxResult.Yes)
                {
                    con.Projects.Remove(select);
                    con.SaveChanges();
                    LoadData();
                }
            }
        }

        private void dgemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgemp.SelectedItem != null)
            {
                dynamic dx=dgemp.SelectedItem;
                txtid.Text=dx.ProjectID.ToString();
                txtname.Text=dx.PName;
                txtdes.Text=dx.PDescription;
            }
            if (dgemp.SelectedItem != null)
            {
                var ww = con.Tasks.Include(u => u.project).Where(f => f.project.ProjectID == int.Parse(txtid.Text)).ToList();
                dgtask.ItemsSource = ww;
            }

        }

      

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dgtask.SelectedItem != null)
            {
                dynamic ds = dgtask.SelectedItem;
                int taskid = ds.TaskID;
                var ww = con.Tasks.Include(u => u.project).Where(f => f.TaskID == taskid).FirstOrDefault();
                User u = cmb.SelectedItem as User;
                var ss = con.Users.FirstOrDefault(f => f.UserID == f.UserID);
                ww.AssignedToUserID = ss.UserID;
                con.SaveChanges();
            }
        }
    }
}
