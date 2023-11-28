using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.Services;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AppApplicationLayer(this IServiceCollection services)
        {

            #region "Services"
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IMedicoService, MedicoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPruebaService, PruebaService>();
            #endregion
        
        }
    }
}
