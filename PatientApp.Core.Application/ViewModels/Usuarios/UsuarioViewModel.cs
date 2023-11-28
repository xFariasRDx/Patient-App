using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Password { get; set; }
        public string Tipo_Usuario { get; set; }
    }
}
