using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Citas
{
    public class CitaViewModel
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime Fecha_Cita { get; set; }
        public DateTime Hora_Cita { get; set; }
        public string Causa_Cita { get; set; }
        public string Estado_Cita { get; set; }
    }
}
