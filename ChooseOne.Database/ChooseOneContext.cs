using ChooseOne.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChooseOne.Database
{
    public class ChooseOneContext : DbContext
    {
        public virtual DbSet<Customization> Customizations { get; set; }

        public ChooseOneContext()
        {
            
        }

        public ChooseOneContext(DbContextOptions<ChooseOneContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public async void CreateDataBase() 
        { 
            await Database.EnsureCreatedAsync();    
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bridge
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\j.edson\\AppData\\Local\\Packages\\e1ff6e24-3aa6-422f-9608-2de1199cd5ec_m2sbgxy9ct12p\\LocalState\\ChooseOneDatabase.db");
            
            //UWP
            //optionsBuilder.UseSqlite("Data Source=C:\\Users\\j.edson\\AppData\\Local\\Packages\\35224404-d17a-4ce3-9d0f-5d51d9eb8fc5_m2sbgxy9ct12p\\LocalState\\ChooseOneDatabase.db");
            
            //optionsBuilder.UseSqlite("Data Source=ChooseOneDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
