using BashTest.Data;
using BashTest.Repository;
using Expenses.Api.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BashTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureOptions<DataBaseOptionsSetup>();

            builder.Services.AddDbContext<DatabaseContext>(
                (serviceProvider, DbContextOptionsBuilder) =>
                {
                    var databaseOptions = serviceProvider.GetService<IOptions<DataBaseOptions>>()!.Value;

                    DbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqliteOptionsAction =>
                    {
                        sqliteOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);
                    });
                    DbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                    DbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
                });
            // Add services to the container.           
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSwaggerGen();

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