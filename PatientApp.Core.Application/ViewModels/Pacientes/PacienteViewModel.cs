using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Pacientes
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Img_Paciente { get; set; }
        public bool Fumador { get; set; }
        public bool Alergias { get; set; }
    
    }
}
