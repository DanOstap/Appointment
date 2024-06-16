using Microsoft.EntityFrameworkCore;
using Appointment.Models;
namespace Appointment.Service
{
    public class Context : DbContext
    {
        public DbSet<Tasks> Task_Model { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Tasks>().HasKey("Id");
        }
    }
}
