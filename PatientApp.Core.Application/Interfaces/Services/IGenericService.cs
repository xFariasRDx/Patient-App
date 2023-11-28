using PatientApp.Core.Application.ViewModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Interfaces.Services
{
    public interface IGenericService <ViewModel,SaveViewModel> 
        where ViewModel : class 
        where SaveViewModel : class

    {
        Task<List<ViewModel>> GetAllVM();
        Task<SaveViewModel> Add(SaveViewModel manda);
        Task Update(SaveViewModel trae);
        Task Delete(int Id);
        Task<SaveViewModel> GetByIdSaveViewModels(int Id);

    }
}
