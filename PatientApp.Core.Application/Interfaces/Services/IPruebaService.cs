using PatientApp.Core.Application.ViewModels.Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Interfaces.Services
{
    public interface IPruebaService : IGenericService <PruebaViewModel, SavePruebaViewModel>
    {
    }
}
