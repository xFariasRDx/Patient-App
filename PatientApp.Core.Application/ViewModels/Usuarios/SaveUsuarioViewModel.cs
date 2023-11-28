using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Usuarios
{
    public class SaveUsuarioViewModel
    {
        public int Id { get; set; }

        //------------------------------------------------//
        
        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        //------------------------------------------------//

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        //------------------------------------------------//

        [Required(ErrorMessage = "Debe colocar un correo electronico")]
        [DataType(DataType.Text)]
        public string Correo { get; set; }

        //------------------------------------------------//
       
        [Required(ErrorMessage = "Debe colocar un nombre de usuario")]
        [DataType(DataType.Text)]
        public string Nombre_Usuario { get; set; }

        //------------------------------------------------//
       
        [Required(ErrorMessage = "Debe colocar un contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //------------------------------------------------//
        [Compare(nameof(Password),ErrorMessage ="Las contraseñas deben coincidir")]
        [Required(ErrorMessage = "Reescriba la contraseña")]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }

        //------------------------------------------------//
       
        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Tipo_Usuario { get; set; }

        //------------------------------------------------//
    }
}
