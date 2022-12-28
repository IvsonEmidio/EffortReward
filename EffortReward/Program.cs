
using EffortReward.Models;
using EffortReward.Services;
using Microsoft.EntityFrameworkCore;

namespace EffortReward
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WeeklyHistoryContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("pgsql"));
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<WeeklyHistoricalService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}