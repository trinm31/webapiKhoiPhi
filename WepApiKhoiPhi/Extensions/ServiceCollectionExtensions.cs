using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WepApiKhoiPhi.Authorization;
using WepApiKhoiPhi.DbContext;
using WepApiKhoiPhi.Services;
using WepApiKhoiPhi.Services.IServices;

namespace WepApiKhoiPhi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service)
        {
            //Configure DbContext with Scoped Lifetime
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(AppSettings.ConnectionStrings,
                    sqlOptions => sqlOptions.CommandTimeout(12000));
            });
            return service;
        }
        
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IJwtUtils, JwtUtils>();
            return service;
        }
        
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            //auto mapper config
            var mapper = MappingConfig.RegisterMaps().CreateMapper();
            service.AddSingleton(mapper);
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return service;
        }
        
        public static IServiceCollection AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi1", Version = "v1"}); });
            return service;
        }
    }
}