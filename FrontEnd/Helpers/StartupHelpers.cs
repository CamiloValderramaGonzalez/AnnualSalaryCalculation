using FrontEnd.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Helpers
{
    public static class StartupHelpers
    {
        public static void AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<EmployeeService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
        }
    }
}
