using PatientApp.Core.Application.ViewModels.Citas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Interfaces.Services
{
    public interface ICitaService : IGenericService <CitaViewModel, SaveCitaViewModel>
    {
    }
}
