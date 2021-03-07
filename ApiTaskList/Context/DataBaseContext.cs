
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskList2.Models;
using TaskList2.Entities;
namespace TaskList2.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
      
        public DbSet<User> Users { get; set; }
        public DbSet<ListTask> ListsTask { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Entities.HistoryTask> HistoryTasks { get; set; }
    }
}
