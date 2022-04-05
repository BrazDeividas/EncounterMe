using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Autofac.Extras.NLog;
using Castle.DynamicProxy;
using EncounterMe.Functions;
using EncounterMe.Interfaces;
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
using WebAPI.Database;
using WebAPI.Middleware;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var options = new DbContextOptionsBuilder<BaseDbContext>()
                .UseSqlite(Configuration.GetConnectionString("DefaultConnection")).Options;

            builder.RegisterType<BaseDbContext>()
                .WithParameter("options", options)
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerDependency();

            builder.RegisterType<FriendRepository>()
                .As<IFriendRepository>()
                .InstancePerDependency();

            builder.RegisterType<FriendRequestRepository>()
                .As<IFriendRequestRepository>()
                .InstancePerDependency();

            builder.RegisterType<FriendService>()
                .As<IFriendService>()
                .InstancePerDependency();

            builder.RegisterModule<NLogModule>();

            builder.Register(c => new LogicInterceptor());

            builder.RegisterType<GameLogic>().As<IGame>()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(LogicInterceptor))
                .InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestResponseLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
