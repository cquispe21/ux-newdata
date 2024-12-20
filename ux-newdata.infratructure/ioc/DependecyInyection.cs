using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces;
using ux_newdata.infratructure.Repository.ApiConsulta;

namespace ux_newdata.infratructure.ioc
{
    public static class DependecyInyection
    {
        public static IServiceCollection AddInfractructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddScoped<IApi, ApiRepository>();


            return services;
        }
    }
}
