using FarmApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace FarmApplication.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
        
        }
        public DbSet<Field> Fields { get; set; }
    }
}
