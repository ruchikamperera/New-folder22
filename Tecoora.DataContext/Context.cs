 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tecoora.Models;

namespace Tecoora.DataContext
{
    public class TecooraContext : DbContext
    {
        public TecooraContext(DbContextOptions<TecooraContext> options)
            : base(options)
        {
        }
         
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<StudentPointForm> StudentPointForms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<LawyerRequestedFile> LawyerRequestedFiles { get; set; }
        public DbSet<UserFileDetail> UserFileDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
