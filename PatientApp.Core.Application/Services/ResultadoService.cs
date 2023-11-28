using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Application.ViewModels.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Services
{
    internal class ResultadoService 
    {
        private readonly IResultadoRepository _resultadoRepository;

        public ResultadoService(IResultadoRepository resultadoRepository)
        {
            _resultadoRepository = resultadoRepository;
        }

        //-----------------Metodo para Extraer----------------//
        //public async Task<List<ResultadoViewModel>> GetAllVM()
        //{
        //    var list = await _resultadoRepository.GetAllAsync();

        //    return list.Select(x => new ResultadoViewModel
        //    {
        //        Id = x.Id,
               
        //    }).ToList();
        //}

    }
}
