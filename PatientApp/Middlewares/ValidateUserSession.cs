using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Core.Application.Helpers;
namespace PatientApp.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }
    
        public bool HasUser()
        {
            UsuarioViewModel usuarioViewModel = _httpcontextAccessor.HttpContext.Session.Get<UsuarioViewModel>("Usuario");
            if (usuarioViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
