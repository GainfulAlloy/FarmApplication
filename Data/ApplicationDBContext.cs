using FarmApplication.Model;
using Microsoft.EntityFrameworkCore;


// this DBContext was used for creating the field datatype, it was meant as a test table, hence the poorly named file

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
