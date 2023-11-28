using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Medicos;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicorepository)
        {
            _medicoRepository = medicorepository;
        }

        //-----------------Metodo para Extraer----------------//
        public async Task<List<MedicoViewModel>> GetAllVM()
        {
            var list = await _medicoRepository.GetAllAsync();

            return list.Select(x => new MedicoViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo,
                Telefono = x.Telefono,
                Cedula = x.Cedula,
                Img_Medico = x.Img_Medico,
            }).ToList();
        }

        //-----------------Metodo para Agregar----------------//

        public async Task<SaveMedicoViewModel> Add(SaveMedicoViewModel manda)
        {
            Medicos medicos = new();
            medicos.Nombre = manda.Nombre;
            medicos.Apellido = manda.Apellido;
            medicos.Correo = manda.Correo;
            medicos.Telefono = manda.Telefono;
            medicos.Cedula = manda.Cedula;
            medicos.Img_Medico = manda.Img_Medico;

            medicos = await _medicoRepository.AddAsync(medicos);

            SaveMedicoViewModel saveMedicoVm = new();
            saveMedicoVm.Nombre = medicos.Nombre;
            saveMedicoVm.Apellido = medicos.Apellido;
            saveMedicoVm.Cedula = medicos.Cedula;
            saveMedicoVm.Correo= medicos.Correo;
            saveMedicoVm.Telefono = medicos.Telefono;
            saveMedicoVm.Img_Medico = medicos.Img_Medico;

            return saveMedicoVm;


        }

        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SaveMedicoViewModel trae)
        {
            Medicos medicos = await _medicoRepository.GetByIdAsync(trae.Id);
            medicos.Id = trae.Id;
            medicos.Nombre = trae.Nombre;
            medicos.Apellido = trae.Apellido;
            medicos.Correo = trae.Correo;
            medicos.Telefono = trae.Telefono;
            medicos.Cedula = trae.Cedula;
            medicos.Img_Medico = trae.Img_Medico;

            await _medicoRepository.UpdateAsync(medicos);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int Id)
        {
            var medicos = await _medicoRepository.GetByIdAsync(Id);
            await _medicoRepository.DeleteAsync(medicos);
        }

        //-----------------Metodo para Extraer by ID-------------------//

        public async Task<SaveMedicoViewModel> GetByIdSaveViewModels(int Id)
        {
            var medicos = await _medicoRepository.GetByIdAsync(Id);

            SaveMedicoViewModel smvm = new();
            smvm.Id = medicos.Id;
            smvm.Nombre = medicos.Nombre;
            smvm.Apellido = medicos.Apellido;
            smvm.Correo = medicos.Correo;
            smvm.Telefono = medicos.Telefono;
            smvm.Cedula = medicos.Cedula;
            smvm.Img_Medico = medicos.Img_Medico;

            return smvm;
        }

    }
}
