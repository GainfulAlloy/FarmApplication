using FarmApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FarmApplication.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FarmApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<ApplicationDBContext>(options=>options.UseSqlServer(
                builder.Configuration.GetConnectionString("FarmApplicationDBContextConnection")
                ));

            // adding the login database
            // need to change the connection string and create an actual connection
            builder.Services.AddDbContext<FarmApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FarmApplicationDBContextConnection")));
            builder.Services.AddDefaultIdentity<FarmApplicationDBUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<FarmApplicationDBContext>();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.MapRazorPages();

            app.Run();
        }

        private static void connectionString(SqlServerDbContextOptionsBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
