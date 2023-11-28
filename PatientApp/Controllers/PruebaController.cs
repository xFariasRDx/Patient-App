using Microsoft.AspNetCore.Mvc;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Application.ViewModels.Pruebas;
using PatientApp.Middlewares;

namespace PatientApp.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IPruebaService _pruebaService;
        private readonly ValidateUserSession _validateUserSession;

        public PruebaController(IPruebaService pruebaService, ValidateUserSession validateUserSession)
        {
            _pruebaService= pruebaService;
            _validateUserSession= validateUserSession;
        }
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _pruebaService.GetAllVM());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SavePrueba", new SavePruebaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePruebaViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePrueba", spvm);
            }
            else
            {
                await _pruebaService.Add(spvm);
                return RedirectToRoute(new { Controller = "Prueba", Action = "Index" });
            }

        }

        public async Task<IActionResult> Update(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SavePrueba", await _pruebaService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePruebaViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", spvm);
            }
            else
            {
                await _pruebaService.Update(spvm);
                return RedirectToRoute(new { Controller = "Prueba", Action = "Index" });
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _pruebaService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            await _pruebaService.Delete(Id);
            return RedirectToRoute(new { Controller = "Prueba", Action = "Index" });

        }

    }

}
