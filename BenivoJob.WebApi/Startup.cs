using AutoMapper;
using BenivoJob.Application.Features.Job.Queries;
using BenivoJob.Application.Interfaces;
using BenivoJob.Domain.Repositories;
using BenivoJob.WebApi.Abstractions;
using BenivoJob.WebApi.Configuration;
using BenivoJob.WebApi.Extensions;
using BenivoJob.WebApi.Services;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using NLog;
using System;
using System.IO;
using System.Net.Http;

namespace BenivoJob.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddControllersWithViews();
            services.AddResponseCaching((options) =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });

            services.AddDbContext<JobDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IJobRpository, JobRepository>();

            #region AutoMapper
            IMapper mapper = AutoMapperConfiguration.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion AutoMapper

            #region Logger
            services.AddSingleton<ILoggerManager, LoggerManager>(); 
            #endregion

            services.AddScoped<IBookmarkRpository, BookmarkRpository>();
            services.AddMediatR(typeof(GetAllJobsQuery).Assembly);

            services.AddMemoryCache();
            services.AddScoped<ICachedJobItemsService, InMemoryCachedJobItemsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job API V1"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

            }

            app.ConfigureExceptionHandler(logger); 
            #region Caching Response
            app.UseResponseCaching();
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Method.Equals(HttpMethod.Get))
                {
                    ctx.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(15)
                    };
                    ctx.Response.Headers[HeaderNames.Vary] =
                        new string[] { "Accept-Encoding" };
                } 
                await next();
            });
            #endregion


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
