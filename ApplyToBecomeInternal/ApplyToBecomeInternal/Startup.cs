using ApplyToBecome.Data;
using ApplyToBecome.Data.Mock;
using ApplyToBecomeInternal.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApplyToBecomeInternal
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			_env = env;
		}

		public IConfiguration Configuration { get; }
		private readonly IWebHostEnvironment _env;

		public void ConfigureServices(IServiceCollection services)
		{
			var razorPages = services.AddRazorPages();
			if (_env.IsDevelopment())
			{
				razorPages.AddRazorRuntimeCompilation();
			}

			services.AddSingleton<ITrusts, MockTrusts>();
			services.AddSingleton<IApplications, MockApplications>();
			services.AddSingleton<IProjectNotes, MockProjectNotes>();

			services.AddHttpClient<IProjects, ProjectsService>(client =>
			{
				var tramsApiOptions = Configuration.GetSection(TramsApiOptions.Name).Get<TramsApiOptions>();
				client.BaseAddress = new Uri(tramsApiOptions.Endpoint);
				client.DefaultRequestHeaders.Add("ApiKey", tramsApiOptions.ApiKey);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}