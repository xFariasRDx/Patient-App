using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Middlewares;

namespace PatientApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;
        private readonly ValidateUserSession _validateUserSession;

        public PacienteController(IPacienteService pacienteService, ValidateUserSession validateUserSession)
        {
            _pacienteService = pacienteService;
            _validateUserSession= validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View(await _pacienteService.GetAllVM());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SavePaciente", new SavePacienteViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePacienteViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            if (!ModelState.IsValid)
            {
                return View("SavePaciente", spvm);
            }
         
           SavePacienteViewModel pacientevm = await _pacienteService.Add(spvm);
            if(pacientevm != null && pacientevm.Id != 0)
            {
                 pacientevm.Img_Paciente = UploadFile(spvm.Img_Upload, spvm.Id);
                 await _pacienteService.Update(pacientevm);
            }
            
            return RedirectToRoute(new { Controller = "Paciente", Action = "Index" });
            
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View("SavePaciente", await _pacienteService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePacienteViewModel spvm)
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
                await _pacienteService.Update(spvm);
                return RedirectToRoute(new { Controller = "Paciente", Action = "Index" });
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View( await _pacienteService.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }

            await _pacienteService.Delete(Id);
            return RedirectToRoute(new { Controller = "Paciente", Action = "Index" });

        }

        private string UploadFile(IFormFile file, int id)
        {
            //GET DIRECTORY PATH
            string basePath = $"/Images/Pacientes/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //CREATE FOLDER IF NOT EXIST
            if (!Directory.Exists(path))
            { 
                Directory.CreateDirectory(path);    
            }

            //GET FILE PATH
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string filename = guid + fileInfo.Extension;
            
            string filenameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(filenameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
                return Path.Combine(basePath, filename);
        }
    
    
    }

}
