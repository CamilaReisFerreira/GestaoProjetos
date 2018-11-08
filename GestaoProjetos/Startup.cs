using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProjetos.DAL.Context;
using GestaoProjetos.DAL.Interfaces;
using GestaoProjetos.DAL.Persistencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace GestaoProjetos
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()); services.AddMvc();
            services.AddDbContext<EFContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICargoDAL, CargoDAL>();
            services.AddScoped<IColaboradorDAL, ColaboradorDAL>();
            services.AddScoped<IColaboradorTarefaDAL, ColaboradorTarefaDAL>();
            services.AddScoped<IHorasColaboradorDAL, HorasColaboradorDAL>();
            services.AddScoped<IProjetoDAL, ProjetoDAL>();
            services.AddScoped<ITarefaDAL, TarefaDAL>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Cargo}/{action=Index}/{id?}");
            });
        }
    }
}
