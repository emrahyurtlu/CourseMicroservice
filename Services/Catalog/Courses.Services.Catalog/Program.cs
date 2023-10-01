using Courses.Services.Catalog.Services;
using Courses.Services.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Courses.Services.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                // This line adds [Authorize] attribute for all controllers
                options.Filters.Add(new AuthorizeFilter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Automapper settings
            builder.Services.AddAutoMapper(typeof(Program));

            // AppSetting Reading
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<DatabaseSettings>>().Value);

            // Dependency Injection
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            // This settings is for protecting the Catalog microservice by JWT token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                // This line show that who gives the token
                options.Authority = builder.Configuration["IdentityServerUrl"];
                // resource_catalog constant comes from identity server Config class.
                options.Audience = "resource_catalog";
                // Since we dont use https, we set this configuration false.
                // Auth mechanism waits https request
                // by default if we dont set it
                options.RequireHttpsMetadata = false;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}