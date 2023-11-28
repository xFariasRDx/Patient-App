using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuarios>
    {
        Task<Usuarios> LoginAsync(LoginViewModel loginVm);
    }
    
}
