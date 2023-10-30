using Microsoft.EntityFrameworkCore;
using ToDo_List.Models;

namespace ToDo_List.Context
{
    public class DataContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        public DataContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;User Id=postgres;Database=tasks_db;Password=Samara2752777");
        }
    }
}
