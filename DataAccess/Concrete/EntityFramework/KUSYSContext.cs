using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class KUSYSContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KUSYS;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get;}
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set;}
        public DbSet<Course> Course { get; set; }
        public DbSet<Session> Session { get; set; }



    }
}
