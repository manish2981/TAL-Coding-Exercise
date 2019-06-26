using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTestAPI.Models;
using DevTestAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevTestAPI
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
            //configure CORS to make this API Calls works fine with other applications...
            services.AddCors(option => option.AddPolicy("MyTestPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Added DEPENDENCY INJECTION...
            services.AddDbContext<TALTestDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("TALTestDBConnection")));
            services.AddScoped<IOccupationRepository, OccupationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
             app.UseCors(
                    options => options.WithOrigins(
                    "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
                );// CORS policy inside the Configure method...
            app.UseMvc();
        }
    }
}