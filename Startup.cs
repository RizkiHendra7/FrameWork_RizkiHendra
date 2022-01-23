using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RizkiHendraFrameWork.BussLogic.Custom;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using System;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using RizkiHendraFrameWork.Library.SwaggerExample;
using RizkiHendraFrameWork.Library.Middleware;
using Microsoft.AspNetCore.Http;
using RizkiHendraFrameWork.Common.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RizkiHendraFrameWork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
             
            services.AddControllers();
             
            //untuk convert config di app seting ke object
            services.Configure<appSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<appConnectionString>(Configuration.GetSection("ConnectionStrings"));

            //inject context ke interface untuk kebutuhan setting session
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //injection ke class tokenBL untuk kebutuhan key encrypt
            services.AddSingleton<tokenBL>();

            //config Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "RizkiFrameWork", Version = "v1" });

                options.ExampleFilters();

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);

            });
            //Default setting bila tidak di set swagger nya di method
            services.AddSwaggerExamplesFromAssemblyOf<Default_Example>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Custom Middleware
            app.ImplementExceptionHandlerMiddleware();
            app.ImplementAntiXssMiddleware();
            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //inject context untuk session BE
            commonClass.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            //masukkan service untuk kebutuhan distribusi value app seting.json ke luar solution API
            AppServicesHelper.Services = app.ApplicationServices;

            //untuk attachment di save di fisik, dan API return url 
            //agar bisa di hit langsung dari ui harus didaftarkan static file nya
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Data")),
                RequestPath = "/Data"
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RizkiHendraFrameWork v1"));
        }
    }
}
