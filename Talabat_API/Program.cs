
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.API.Middleware;
using Talabat.core.Interfaces;
using Talabat.Repository.Data;
using Talabat.Repository.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace Talabat_API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(
                option => option
                         .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
            // To Configure Errors 
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (action) =>
                {
                    var Errors = action.ModelState.Where(p => p.Value.Errors.Count() > 0)
                    .SelectMany(p => p.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                    var Response = new APIValidationErrorResponse()
                    {
                        Errors = Errors
                    };

                    return new BadRequestObjectResult(Response);
                };
            });

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext = services.GetRequiredService<StoreDbContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbcontext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occurred During Migration");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                try
                {

                    await next.Invoke(context);
                }
                catch (Exception ex)
                {

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var response = new APIExiptionResponse(app.Environment.IsDevelopment() ? ex.StackTrace.ToString() : "Internal Server Error");
                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                }
            });

            app.MapControllers();
            app.Run();
        }

    }
}
