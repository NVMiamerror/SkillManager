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
using vhec.SkillInventory.DAL.DataContext;
using vhec.SkillInventory.DAL.Repositories.Functions;
using vhec.SkillInventory.DAL.Repositories.Interfaces;
using vhec.SkillInventory.Logic;

namespace vhec.SkillInventory.Api
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
            services.AddDbContext<SkillManagerDbContext>(option =>
            {
                option.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vhec.SkillInventory.Api", Version = "v1" });
            });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<ISkillLogic, SkillLogic>();
            services.AddScoped<ISkillRepository, SkillRepository>(); 

            services.AddTransient<IDetailSkillLogic, DetailSkillLogic>();
            services.AddScoped<IDetailSkillRepository, DetailSkillRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vhec.SkillInventory.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
