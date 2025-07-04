using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using UseCases;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ToDoContext>());
            builder.Services.AddScoped<IUnitOfWork<ToDoItem>, UnitOfWork<ToDoItem>>();
            builder.Services.AddScoped<IRepository<ToDoItem>, GenericRepository<ToDoItem>>();
            builder.Services.AddTransient<ToDoListManager>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
                dbContext.Database.Migrate();
            }

            app.Run();
        }
    }
}
