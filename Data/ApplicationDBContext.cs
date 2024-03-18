using FarmApplication.Migrations.FarmApplicationDB;
using FarmApplication.Model;
using Microsoft.EntityFrameworkCore;


// this DBContext was used for creating the field datatype, it was meant as a test table, hence the poorly named file
// to add mulitple tables to one database you can do it in this file

namespace FarmApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
        
        }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Workers> Workers { get; set; }
        /*
        public DbSet<UserData> UserData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().HasData(
                new UserData
                {
                    


                }
                );
        }
        */
    }
}
