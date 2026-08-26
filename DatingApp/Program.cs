using DatingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    config.RoutePrefix = "";
                });
            }
            app.UseCors("MyCors");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}
