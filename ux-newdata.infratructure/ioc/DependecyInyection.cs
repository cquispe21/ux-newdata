using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces;
using ux_newdata.application.interfaces.Auth;
using ux_newdata.application.interfaces.Usuario;
using ux_newdata.infratructure.Context;
using ux_newdata.infratructure.Repository.ApiConsulta;
using ux_newdata.infratructure.Repository.Auth;
using ux_newdata.infratructure.Repository.Usuario;

namespace ux_newdata.infratructure.ioc
{
    public static class DependecyInyection
    {
        public static IServiceCollection AddInfractructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddScoped<IApi, ApiRepository>();
            services.AddScoped<ÍAuth, AuthRepository>();
            services.AddScoped<IUsuario, UsuarioRepository_cs>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var builderConnection = new SqlConnectionStringBuilder(configuration.GetConnectionString("defaultConnection"));
            services.AddDbContext<_contextApi>(options =>
            {
                options.UseSqlServer(builderConnection.ConnectionString);
            }, ServiceLifetime.Transient
           );

            return services;
        }
    }
}
