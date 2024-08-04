using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using nexus.Config.Database;
using nexus.Config.Response;
using nexus.Modules.Category.Entity;
using nexus.Modules.Comment.Entity;
using nexus.Modules.Post.Entity;
using nexus.Modules.Role.Entity;
using nexus.Modules.User.Entity;

namespace nexus.Config.Startup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod() //THIS LINE RIGHT HERE IS WHAT YOU NEED
                            .AllowCredentials();
                    });
            });


            // Configure the DbContext with PostgreSQL
            services.AddDbContext<Connection>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<Response<Posts>>();
            services.AddScoped<Response<Categories>>();
            services.AddScoped<Response<Comments>>();
            services.AddScoped<Response<Users>>();
            services.AddScoped<Response<Roles>>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
