using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.BLL.IManager;
using WebAPIProject.BLL.Manager;
using WebAPIProject.DAL;
using WebAPIProject.DAL.IRepository;
using WebAPIProject.DAL.Model;
using WebAPIProject.DAL.Repository;
using WebAPIProject.Shared;

namespace WebAPIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIProject", Version = "v1" });
            });

            services.AddAutoMapper(typeof(ModelMapper));
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });


            //Adding Manager Dependency Injection
            services.AddScoped<IItemManager, ItemManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();

            //Adding Repository DI
            services.AddScoped<IApplicationRepository<Supplier>, ApplicationRepository<Supplier>>();
            services.AddScoped<IApplicationRepository<Item>, ApplicationRepository<Item>>();
            services.AddScoped<IApplicationRepository<Order>, ApplicationRepository<Order>>();
            services.AddScoped<IApplicationRepository<OrderDetail>, ApplicationRepository<OrderDetail>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIProject v1"));
            }

            app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
