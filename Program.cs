using Microsoft.EntityFrameworkCore;
using SalaryApplication;
using SalaryApplication.Models;
using System;
using System.Text.Json;

namespace SalaryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors();
            var app = builder.Build();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.Run(async (context) =>
            {
                var response = context.Response;
                var request = context.Request;
                var path = request.Path;
                if (path == "/getHighestSalariesOfDevelopers" && request.Method == "GET")
                {
                    using (var scope = app.Services.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        await GetHighestSalariesOfDevelopers(dbContext, response);
                    }
                }
            });

            app.Run();

            async Task GetHighestSalariesOfDevelopers(AppDbContext dbContext, HttpResponse response)
            {
                var highSalaryDevelopers = await dbContext.Developers
                .Include(d => d.Manager)
                .Include(d => d.Department)
                .Where(d => d.Salary > d.Manager.Salary)
                .ToListAsync();

                await response.WriteAsJsonAsync(highSalaryDevelopers);
            }


        }
    }
}
