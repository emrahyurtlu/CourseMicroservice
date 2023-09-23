
using Courses.Gateway.DelegateHandlers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Courses.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.WebHost.ConfigureAppConfiguration((context, config) =>
            //{
            //    // Configuration files are recognized by Ocelot library
            //    //config.AddJsonFile($"configuration.{context.HostingEnvironment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();
            //});

            // Configuration files are recognized by Ocelot library
            builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();

            // Add services to the container.


            builder.Services.AddHttpClient<TokenExhangeDelegateHandler>();
            builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
            {
                options.Authority = builder.Configuration["IdentityServerURL"];
                options.Audience = "resource_gateway";
                options.RequireHttpsMetadata = false;
            });

            builder.Services.AddOcelot().AddDelegatingHandler<TokenExhangeDelegateHandler>();

            builder.Services.AddControllers();
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

            app.UseOcelot();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}