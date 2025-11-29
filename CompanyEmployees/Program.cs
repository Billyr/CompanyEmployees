using CompanyEmployees.Extensions;
using AutoMapper;

namespace CompanyEmployees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureNpgsqlContext(builder.Configuration);
            // AutoMapper 12+
            builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly));

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
