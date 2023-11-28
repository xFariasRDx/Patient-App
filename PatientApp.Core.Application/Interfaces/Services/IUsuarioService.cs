using PatientApp.Core.Application.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Interfaces.Services
{
    public interface IUsuarioService : IGenericService <UsuarioViewModel, SaveUsuarioViewModel>
    {
        Task<UsuarioViewModel> Login(LoginViewModel trae);
    }
}
