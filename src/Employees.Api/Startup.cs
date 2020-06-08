using Employees.Api.Infrastracture;
using Employees.Core.Business.Employees;
using Employees.Core.Business.Salary;
using Employees.Core.Interfaces.Business.Employees;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.Business.Salary;
using Employees.Core.Interfaces.DatаAccess;
using Employees.DataAccess.Dapper.Infrastracture;
using Employees.DataAccess.Dapper.SalaryDao;
using Employees.DataAcсess.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Employees.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Employee API", Version = "v1" });
                c.EnableAnnotations();
            });
            
            ConfigureDataAccessServices(services);
            ConfigureBuisnessServices(services);
        }


        public void ConfigureBuisnessServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IEmployeeCreator), typeof(EmployeeCreator));
            services.AddScoped(typeof(IEmployeeReader), typeof(EmployeeReader));
            services.AddScoped(typeof(IEmployeeUpdater), typeof(EmployeeUpdater));
            services.AddScoped(typeof(IEmployeeRemover), typeof(EmployeeRemover));

            services.AddSingleton(typeof(ISalaryCalculatorFactory), typeof(SalaryCalculatorFactory));   
            services.AddSingleton(typeof(ISalaryCalculator), typeof(FixedSalaryCalculator));
            services.AddSingleton(typeof(ISalaryCalculator), typeof(HourlySalaryCalculator));
            services.AddSingleton(typeof(ISalaryReader), typeof(SalaryReader));
        }

        public void ConfigureDataAccessServices(IServiceCollection services)
        {
            // EF    

            var sp = services.BuildServiceProvider();          

            services.AddDbContext<ApplicationDbContext>(c =>
              c.UseSqlServer(
                  Configuration["ConnectionString"],
                  providerOptions => providerOptions.CommandTimeout(10))
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Dapper
            services.AddSingleton(typeof(ISqlDbExecutor), typeof(SqlDbExecutor));
            services.AddSingleton(typeof(ISalaryDao), typeof(SalaryDao));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("default");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();


        }
    }
}
