using Microsoft.AspNetCore.Mvc;
using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Medicos;
using PatientApp.Middlewares;

namespace PatientApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoService _medicoService;
        private readonly ValidateUserSession _validateUserSession;


        public MedicoController(IMedicoService medicoService, ValidateUserSession validateUserSession) 
        {
            _medicoService = medicoService;
            _validateUserSession = validateUserSession;
        }
    
        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            
            return View(await _medicoService.GetAllVM());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SaveMedico", new SaveMedicoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveMedicoViewModel spvm)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveMedico", spvm);
            }
            else
            {
                await _medicoService.Add(spvm);
                return RedirectToRoute(new { Controller = "Medico", Action = "Index" });
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SaveMedico", await _medicoService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveMedicoViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }

            if (!ModelState.IsValid)
            {
                return View("SaveMedico", spvm);
            }
            else
            {
                await _medicoService.Update(spvm);
                return RedirectToRoute(new { Controller = "Medico", Action = "Index" });
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _medicoService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            await _medicoService.Delete(Id);
            return RedirectToRoute(new { Controller = "Medico", Action = "Index" });

        }

    }
}
