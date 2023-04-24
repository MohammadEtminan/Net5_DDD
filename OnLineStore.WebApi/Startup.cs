using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OnlineStore.EntityFrameworkCore;
using OnlineStore.Application.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnLineStore.WebApi.Middlewares.ApiExceptionHandler;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnLineStore.WebApi
{
    public class Startup
    {
        #region [- ctor -]
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region [- props -]
        public IConfiguration Configuration { get; }
        #endregion


        #region [- ConfigureServices() -]

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region [- AddMvcCore() -]
            services.AddMvcCore().AddApiExplorer();
            #endregion

            #region [- AddDbContext() -]
            services.AddDbContextPool<OnlineStoreDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Default"));

            });
            #endregion

            #region [- AddAutoMapper() -]

            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            }).CreateMapper();

            services.AddSingleton(mappingConfig);

            #endregion

            #region [- AddControllers() -]
            services.AddControllers();
            #endregion

            #region [- AddSwaggerDocument() -]

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ToDo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            #endregion

            services.AddServicesOfAllTypes();

            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
        }
        #endregion

        #region [- Configure() -]
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ApiExceptionMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}