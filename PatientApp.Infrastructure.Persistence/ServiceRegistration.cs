using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Infrastructure.Persistence.Contexts;
using PatientApp.Infrastructure.Persistence.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {

        //EXTENCION METHOD = DECORATOR
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Contexts"
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region "Repositories"

            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IPruebaRepository, PruebaRepository>();
            services.AddTransient<IResultadoRepository, ResultadoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #endregion

        }
    }
}
