using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductService.API.Repository;
using ProductService.API.Repository.Interface;
using ProductService.Model.Repository;
using ProductServices.Model;
using ProductServices.Repository;
using ProductServices.Repository.Interface;
using ProductServices.Services;


namespace ProductService.API
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
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
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

        public IConfiguration Configuration { get; }

        // Note: configure appsettings.json according to specific environment
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("ShopItEasyDb"),
                b => b.MigrationsAssembly(typeof(ProductContext).Assembly.FullName)));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton(typeof(IGenericRepository<>), typeof(DataRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductSerivce>();


            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();


            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IPurchasedItemsRepository, PurchasedItemsRepository>();

            services.AddTransient<IPromoRepository, PromoRepository>();
            services.AddTransient<IPromoService, PromoService>();


            services.AddTransient<IUserViewRepository, UserViewRepository>();
            services.AddTransient<IUserViewService, UserViewService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "ProductService.API",
                        Description = "API used for products managements",
                        Version = "v1"
                    });

                //var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                //options.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                //options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
