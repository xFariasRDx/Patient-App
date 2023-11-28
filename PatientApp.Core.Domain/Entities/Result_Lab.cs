using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Domain.Entities
{
    public class Result_Lab
    {
        public int Id { get; set; }
        public int PruebaId { get; set; }
        public int PacienteId { get; set; }
        public string Resultado { get; set; }

        //Navigation Property
        public Pacientes pacientes { get; set; }
        public Prueba_Lab pruebaLab { get; set; }
    }
}
