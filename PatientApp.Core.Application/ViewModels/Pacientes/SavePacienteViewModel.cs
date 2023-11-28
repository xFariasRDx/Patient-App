using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.ViewModels.Pacientes
{
    public class SavePacienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe colocar un numero de telefono")]
        [DataType(DataType.Text)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe colocar una direccion")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe colocar su documento de identidad")]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe colocar su fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }

        public string? Img_Paciente { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Img_Upload { get; set; }

        public bool Fumador { get; set; }
        public bool Alergias { get; set; }
    }
}
