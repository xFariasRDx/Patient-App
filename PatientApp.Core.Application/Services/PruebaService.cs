using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Application.ViewModels.Pruebas;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Services
{
    public class PruebaService : IPruebaService
    {
        private readonly IPruebaRepository _pruebaRepository;

        public PruebaService(IPruebaRepository pruebaRepository)
        {
            _pruebaRepository = pruebaRepository;
        }

        public async Task<List<PruebaViewModel>> GetAllVM()
        {
            var list = await _pruebaRepository.GetAllAsync();

            return list.Select(x => new PruebaViewModel
            {
                Id = x.Id,
                Prueba = x.Prueba,           
            }).ToList();
        }

        //-----------------Metodo para Agregar----------------//

        public async Task<SavePruebaViewModel> Add(SavePruebaViewModel manda)
        {
            Prueba_Lab prueba = new();
            prueba.Prueba = manda.Prueba;
            
            prueba = await _pruebaRepository.AddAsync(prueba);

            SavePruebaViewModel savePruebaVm = new();
            savePruebaVm.Prueba = prueba.Prueba;

            return savePruebaVm;
        }

        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SavePruebaViewModel trae)
        {
            Prueba_Lab prueba = await _pruebaRepository.GetByIdAsync(trae.Id);
            prueba.Id = trae.Id;
            prueba.Prueba = trae.Prueba;

            await _pruebaRepository.UpdateAsync(prueba);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int Id)
        {
            var paciente = await _pruebaRepository.GetByIdAsync(Id);
            await _pruebaRepository.DeleteAsync(paciente);
        }

        //-----------------Metodo para Extraer by ID-------------------//

        public async Task<SavePruebaViewModel> GetByIdSaveViewModels(int Id)
        {
            var prueba = await _pruebaRepository.GetByIdAsync(Id);

            SavePruebaViewModel spvm = new();
            spvm.Id = prueba.Id;
            spvm.Prueba = prueba.Prueba;
            
            return spvm;
        }

    }
}
