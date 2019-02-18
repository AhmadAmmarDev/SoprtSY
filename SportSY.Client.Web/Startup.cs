using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportSY.Client.Web.Models;
using SportSY.Client.Web.Services;
using SportSY.Core.Interfaces;
using SportSY.Data.Repository.SQL.Repositories;
//using SportSY.Data.Repository.SQL.Data;
using SportSY.Data.Repository.SQL.Models;
using SportSY.Client.Web.Data;
//using SportSY.Data.Repository.SQL.Data;

namespace SportSY.Client.Web
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
			//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SYSportDBEntities")));
			services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.ClaimsIdentity.RoleClaimType = "Claim";
			});

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddMvc();
			services.AddScoped<IPersonRepository, PersonRepository>();
			services.AddScoped<ITeamRepository, TeamsRepository>();
            services.AddScoped<DbContext, ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}