using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.CustomEntities;
using TaskTrackerSE.Core.Interfaces;
using TaskTrackerSE.Core.Services;
using TaskTrackerSE.Infrastructure.Data;
using TaskTrackerSE.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskTrackerSE.Infrastructure.Options;
using TaskTrackerSE.Infrastructure.Interfaces;
using TaskTrackerSE.Infrastructure.Services;
using Microsoft.OpenApi.Models;

namespace TaskTrackerSE.Infrastructure.Extencions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskTrackerSE_Db_Context>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr_TaskTrackerSE"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskItemService, TaskItemService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Tracker SE API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
