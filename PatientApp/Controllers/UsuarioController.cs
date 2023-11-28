using Microsoft.AspNetCore.Mvc;
using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.Services;
using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Core.Application.Helpers;
using PatientApp.Middlewares;

namespace PatientApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _validateUserSession;

        public UsuarioController(IUsuarioService usuarioService, ValidateUserSession validateUserSession)
        {
            _usuarioService = usuarioService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _usuarioService.GetAllVM());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SaveUsuario", new SaveUsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUsuarioViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveUsuario", spvm);
            }
            else
            {
                await _usuarioService.Add(spvm);
                return RedirectToRoute(new { Controller = "Usuario", Action = "Index" });
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SaveUsuario", await _usuarioService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUsuarioViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveUsuario", spvm);
            }
            else
            {
                await _usuarioService.Update(spvm);
                return RedirectToRoute(new { Controller = "Usuario", Action = "Index" });
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _usuarioService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            await _usuarioService.Delete(Id);
            return RedirectToRoute(new { Controller = "Usuario", Action = "Index" });

        }

        public IActionResult IndexLogin()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Home", Action = "Home" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexLogin(LoginViewModel loginVm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Home", Action = "Home" });
            }
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            UsuarioViewModel userVm = await _usuarioService.Login(loginVm);
            
            if(userVm != null)
            {
                HttpContext.Session.Set<UsuarioViewModel>("Usuario", userVm);
                return RedirectToRoute(new { Controller = "Home", Action="Home" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrectos");
            }
            return View(loginVm);
        }



    }
}
