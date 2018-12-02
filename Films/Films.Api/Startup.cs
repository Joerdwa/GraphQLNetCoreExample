using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Films.Data.EntityFramework.Seed;
using Films.Core.Data;
using Films.Data.InMemory;
using Films.Api.Models;
using Films.Data.EntityFramework;

namespace Films.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<MovieQuery>();
            services.AddTransient<IFilmRepository, FilmRepository>();
            var test = Configuration["ConnectionStrings:MoviesDBConnection"];
            services.AddDbContext<MovieContext>(options =>
                                                options.UseSqlite(Configuration["ConnectionStrings:MoviesDBConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MovieContext db)
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
            app.UseMvc();

            db.EnsureSeedData();
        }
    }
}
