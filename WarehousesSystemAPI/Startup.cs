using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WarehousesSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using WarehousesSystemAPI.Storage;
using WarehousesSystemAPI.Services;
using Microsoft.OpenApi.Models;

namespace WarehousesSystemAPI
{
    public class Startup
    {
        //Hardcode for compability with tests
        private static readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=WarehousesDb;Trusted_Connection=True;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            InitDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouses API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitDependencies(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouses", Version = "v1" });
            });

            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<SqlServerDatabaseAccessor>();

            services.AddScoped<WarehousesService>();

            services.AddScoped<ProductsService>();

            services.AddScoped<WarehouseContentsService>();
        }
    }
}
