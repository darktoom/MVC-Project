using Company.Data.Contexts;
using Company.Repository.Interfaces;
using Company.Repository.Repository;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employees;
using Company.Service.Mapping;
using Company.Service.Services;
using Company.Service.Services.Employees;
using Microsoft.EntityFrameworkCore;
namespace Company.Web

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            //  builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
                   builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
              builder.Services.AddScoped<IDepartmentService,DepartmentServices>();
            builder.Services.AddScoped<IEmployeeService,EmployeeService>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()  ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
