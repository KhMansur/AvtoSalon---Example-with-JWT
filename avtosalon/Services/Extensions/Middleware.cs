using avtosalon.Repositories;
using avtosalon.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Web.data.AdDbConection;
using Web.data.model;

namespace avtosalon.Services.Extensions
{
    public static class Middleware
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IKompaniyaService, KompaniyaService>();
            services.AddTransient<IMashinaService, MashinaService>();
            services.AddTransient<IAuthManager, AuthManager>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IKompaniyaRepository, KompaniyaRepository>();
            services.AddTransient<IMashinaRepository, MashinaRepository>();
        }

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"DavlatShahar project API",
                    Version = $"v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                    new string[] {}
                    }
                });

            });
        }

        public static void AddConfigurationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApiUser, Role>(q => q.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbcontext>().AddDefaultTokenProviders();
        }

        public static void AddConfigurationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            var key = jwtSettings.GetSection("Key").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
