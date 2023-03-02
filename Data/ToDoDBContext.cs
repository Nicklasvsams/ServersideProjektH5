using Microsoft.EntityFrameworkCore;
using ServersideProjektH5.Models;

namespace ServersideProjektH5.Data
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options){}

        public DbSet<ToDoModel> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoModel>()
                .Property<int>("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
