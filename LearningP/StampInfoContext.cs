using System;
using Microsoft.EntityFrameworkCore;

namespace LearningP
{
    public class StampInfoContext : DbContext
    {
        public DbSet<StampInfo> Stamps { get; set; }
        public DbSet<TestClass> Tests { get; set; } // Удалить
        public StampInfoContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<StampInfo>().HasKey(x => x.Key);
            // Убрать
            modelBuilder.Entity<StampInfo>().HasData(
                new StampInfo[]
                {
                    new StampInfo("Abcde"),
                    new StampInfo{ Key = Guid.NewGuid(), Reason = "Reason", Time = System.DateTime.Now, Stamp = null, StampGuid = Guid.NewGuid() }
                }
                );
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Stamps;Trusted_Connection=True;");//@"Server=(.\SQLEXPRESS);Database=Stamps;Trusted_Connection=True;");//@"Data Source=MSI/Denis;Initial Catalog=Stamps;Integrated Security=True");
            //base.OnConfiguring(optionsBuilder);
        }*/
    }
}
