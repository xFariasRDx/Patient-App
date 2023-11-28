using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Middlewares;
using PatientApp.Models;
using System.Diagnostics;

namespace PatientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(ILogger<HomeController> logger, ValidateUserSession validateUserSession)
        {
            _logger = logger;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Home()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuario", Action = "IndexLogin" });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}