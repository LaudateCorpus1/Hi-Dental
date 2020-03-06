using BussinesLayer.UnitOfWork;
using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace HiDentalAPI.Extensions
{
    public static class StartupExtensions
    {
        public static void ImplementsCors(this IServiceCollection services)
            => services.AddCors(x => x.AddPolicy(nameof(Startup),
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

        public static void ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
          => services.AddDbContext<ApplicationDbContext>(options
              => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        public static void ImplementServices(this IServiceCollection services)
            => services.AddTransient<IUnitOfWork, UnitOfWork>();


        public static void AddDocumentation(this IServiceCollection services)
            => services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "Hi Dental Api!", Version = "v1" }));

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
            => services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetSection(nameof(AuthSetting))[nameof(AuthSetting.ValidIssuer)],
                ValidAudience = configuration.GetSection(nameof(AuthSetting))[nameof(AuthSetting.ValidAudience)],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection(nameof(AuthSetting))[nameof(AuthSetting.SecretKey)])),
                ClockSkew = TimeSpan.Zero
            });

        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Permission>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            });
        }


        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerSetting>(configuration.GetSection(nameof(SwaggerSetting)));
            services.Configure<AuthSetting>(configuration.GetSection(nameof(AuthSetting)));
            services.Configure<AppSetting>(configuration.GetSection(nameof(AppSetting)));

        }
    }
}
