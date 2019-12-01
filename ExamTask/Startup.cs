using DBO.Contracts;
using DBO.Entities;
using DBO.Repositories;
using ExamTask.API.Middlewares;
using ExamTask.Services.Contracts;
using ExamTask.Services.Implementation;
using ExamTask.Services.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ExamTask
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<DBO.Contexts.OrdersDbContext>();


            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IXmlOrdersImporter, XmlOrdersImporter>();
            services.AddScoped<IOrderValidator, OrderValidator>();

            ConfigureRepositories(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Exam Task API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Exam Task API");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ValidationExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
