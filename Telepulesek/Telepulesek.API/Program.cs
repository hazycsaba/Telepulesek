using Microsoft.EntityFrameworkCore;
using Telepulesek.API.Data;

namespace Telepulesek.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<TelepulesekContext>(option =>
            {
                option.UseMySql(builder.Configuration.GetConnectionString("TelepulesekDB"), ServerVersion.Parse("10.4.28-mariadb"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
