using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using NmarketTestApp.Data;
using NmarketTestApp.Services;
using NmarketTestApp.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace NmarketTestApp
{
  public class Startup
  {
    IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration, IHostingEnvironment env)
    {
      Configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      //Using SQL Server   
      var connectionString = Configuration["DbContextSettings:ConnectionString"];
      string assemblyName = typeof(NmarketDbContext).Namespace;
      services.AddDbContext<NmarketDbContext>(options =>
        options.UseSqlServer(connectionString,
            optionsBuilder =>
                optionsBuilder.MigrationsAssembly(assemblyName)
        ));
      services.AddAutoMapper();
      services.AddScoped<IObjectService, ObjectService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
           !Path.HasExtension(context.Request.Path.Value) &&
           !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });
      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
