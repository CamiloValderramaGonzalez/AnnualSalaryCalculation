using Domain.EmployeeAggregate.Interfaces;
using Domain.EmployeeAggregate.Services;
using Infrastructure.Respositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class StartupHelpers
    {
        public static void AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<EmployeeService>();

            services.AddHttpClient<IEmployeeRepository, EmployeeRepository>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
        }
    }
}
