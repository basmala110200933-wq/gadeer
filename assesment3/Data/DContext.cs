using assesment3.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesment3.Data
{
    public class DContext:DbContext
    {
       public DbSet<User> Users { get; set; }
        public DbSet<Tasked> Tasks {  get; set; }
        public DbSet<Project> Projects {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM176-LAB3\\SQLEXPRESS;Initial Catalog=ProjectManagement;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
