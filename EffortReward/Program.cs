
using EffortReward.Data;
using EffortReward.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {

                    Version = "1.0.0",
                    Title = "EffortReward API",
                    Description = "The API that help you to be the best version of you!",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {

                        Email = "contato@Ivsonemidio.com.br"
                    },


                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "License: MIT",
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("pgsql"));
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<WeeklyHistoricalService>();
            builder.Services.AddScoped<EffortService>();
            builder.Services.AddScoped<WalletService>();
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