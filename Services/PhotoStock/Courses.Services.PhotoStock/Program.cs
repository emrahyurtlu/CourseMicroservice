using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Courses.Services.PhotoStock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // This settings is for protecting the Catalog microservice by JWT token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                // This line show that who gives the token
                options.Authority = builder.Configuration["IdentityServerUrl"];
                // resource_catalog constant comes from identity server Config class.
                options.Audience = "resource_photo_stock"; // Defined in IdentityServer Config file
                // Since we dont use https, we set this configuration false.
                // Auth mechanism waits https request
                // by default if we dont set it
                options.RequireHttpsMetadata = false;
            });

            // Instead of adding [Authorize] filter for every controller
            // We defined it globally
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            // This middleware applies the protection settings defined before
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();



            app.Run();
        }
    }
}