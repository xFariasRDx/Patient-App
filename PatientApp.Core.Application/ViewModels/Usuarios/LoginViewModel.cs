using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Usuarios
{
    public class LoginViewModel
    {
        //------------------------------------------------//

        [Required(ErrorMessage ="Debe colocar el nombre de usuario")]
        [DataType(DataType.Text)]
        public string Nombre_Usuario { get; set; }

        //------------------------------------------------//

        [Required(ErrorMessage = "Debe colocar una contraseña correcta")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //------------------------------------------------//

    }
}