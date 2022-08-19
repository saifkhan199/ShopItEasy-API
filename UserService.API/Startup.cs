using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Model.Repository;
using UserService.Repository;
using UserService.Repository.Interaface;
using UserService.Repository.Interface;
using UserService.Service;
using UserService.Service.Interface;

namespace UserService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            // Note: configure appsettings.json according to specific environment
            Env = env;

            var contentRootPath = env.ContentRootPath;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(contentRootPath);


            if (env.IsDevelopment())
            {
                builder
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                Configuration = builder.Build();
            }
            if (env.IsProduction())
            {
                builder
                    .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                Configuration = builder.Build();
            }


        }
      

        // Note: configure appsettings.json according to specific environment
        public IWebHostEnvironment Env { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add mail setting from AppSettings
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IMailRepository, MailRepository>();
            services.AddMemoryCache();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options=>
                {
                    //Token will be valid if it follows following settings

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:5001",
                        ValidAudience = "https://localhost:5001",

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecret@12345678910"))

                    };

                });
            //SetupJWTServices(services);

            services.AddControllers();
            services.AddDbContext<UserContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("ShopItEasyUserDb"),
                b => b.MigrationsAssembly(typeof(UserContext).Assembly.FullName)));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "UserService.API",
                        Description = "API used for User managements",
                        Version = "v1"
                    });

                //var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                //options.IncludeXmlComments(filePath);
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(DataRepository<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, Service.UserService>();

        }

        //private void SetupJWTServices(IServiceCollection services)
        //{
        //    string key = "my_secret_key_12345"; //this should be same which is used while creating token      
        //    var issuer = "https://localhost:44387/UserMgmt/Login";  //this should be same which is used while creating token  

        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //  .AddJwtBearer(options =>
        //  {
        //      options.TokenValidationParameters = new TokenValidationParameters
        //      {
        //          ValidateIssuer = true,
        //          ValidateAudience = true,
        //          ValidateIssuerSigningKey = true,
        //          ValidIssuer = issuer,
        //          ValidAudience = issuer,
        //          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        //      };

        //      options.Events = new JwtBearerEvents
        //      {
        //          OnAuthenticationFailed = context =>
        //          {
        //              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
        //              {
        //                  context.Response.Headers.Add("Token-Expired", "true");
        //              }
        //              return Task.CompletedTask;
        //          }
        //      };
        //  });
        //}


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                //options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
