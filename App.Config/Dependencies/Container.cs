using App.Config.DIAutoRegister;
using App.Infraestructure.DataBase.Context;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace App.Config.Dependencies
{
    public class Container
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {

            #region Authorization
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };
            });


            #endregion Authorization

            #region Mapper
            services.AddAutoMapper(typeof(Container));

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper= configMapper.CreateMapper();

            services.AddSingleton(mapper);
            #endregion Mapper

            #region Conexion Base de Datos
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("App.Infraestructure"));
            });
            #endregion Conexion Base de Datos

            #region Register DI
            var assebliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("App.Domain"),
                Assembly.Load("App.Infraestructure"),
                Assembly.Load("App.Common"),
                Assembly.Load("App.Authorization")
            };

            services.RegisterAssemblyPublicNonGenericClasses(assebliesToScan)
                .Where(c=>c.Name.EndsWith("Repository")||
                       c.Name.EndsWith("Service")||
                       c.Name.EndsWith("Resource"))
                .AsPublicImplementedInterfaces();


            #endregion Register DI

            #region Others

            //// ********************
            //// Setup CORS
            //// ********************

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });


            #endregion Others
        }

        public static void CreateDataBase(IHost host)
        {
            using var  scope = host.Services.CreateScope();
            var services=scope.ServiceProvider;

            try
            {
                var context= services.GetRequiredService<ApplicationContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}