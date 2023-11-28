using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        { _pacienteRepository = pacienteRepository; }


        //-----------------Metodo para Extraer----------------//
        public async Task<List<PacienteViewModel>> GetAllVM()
        {
            var list = await _pacienteRepository.GetAllAsync();

            return list.Select(x => new PacienteViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Cedula = x.Cedula,
                Direccion = x.Direccion,
                Fecha_Nacimiento = x.Fecha_Nacimiento,
                Fumador = x.Fumador,
                Alergias = x.Alergias,
                Telefono = x.Telefono,
                Img_Paciente = x.Img_Paciente,
            }).ToList();
        }

        //-----------------Metodo para Agregar----------------//

        public async Task<SavePacienteViewModel> Add(SavePacienteViewModel manda)
        {
            Pacientes pacientes = new();
            pacientes.Id = manda.Id;
            pacientes.Nombre = manda.Nombre;
            pacientes.Apellido = manda.Apellido;
            pacientes.Cedula = manda.Cedula;
            pacientes.Direccion = manda.Direccion;
            pacientes.Telefono = manda.Telefono;
            pacientes.Fecha_Nacimiento = manda.Fecha_Nacimiento;
            pacientes.Fumador = manda.Fumador;
            pacientes.Alergias = manda.Alergias;
            pacientes.Img_Paciente = manda.Img_Paciente;

            pacientes = await _pacienteRepository.AddAsync(pacientes);

            SavePacienteViewModel savePacienteVm = new();
            savePacienteVm.Id = pacientes.Id;
            savePacienteVm.Nombre = pacientes.Nombre;
            savePacienteVm.Apellido = pacientes.Apellido;
            savePacienteVm.Cedula = pacientes.Cedula;
            savePacienteVm.Direccion = pacientes.Direccion;
            savePacienteVm.Telefono = pacientes.Telefono;
            savePacienteVm.Fecha_Nacimiento = pacientes.Fecha_Nacimiento;
            savePacienteVm.Fumador = pacientes.Fumador;
            savePacienteVm.Alergias = pacientes.Alergias;
            savePacienteVm.Img_Paciente = pacientes.Img_Paciente;

            return savePacienteVm;
        
        }


        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SavePacienteViewModel trae)
        {
            Pacientes pacientes = await _pacienteRepository.GetByIdAsync(trae.Id);
            pacientes.Id = trae.Id;
            pacientes.Nombre = trae.Nombre;
            pacientes.Apellido = trae.Apellido;
            pacientes.Cedula = trae.Cedula;
            pacientes.Direccion = trae.Direccion;
            pacientes.Telefono = trae.Telefono;
            pacientes.Fecha_Nacimiento = trae.Fecha_Nacimiento;
            pacientes.Fumador = trae.Fumador;
            pacientes.Alergias = trae.Alergias;
            pacientes.Img_Paciente = trae.Img_Paciente;

            await _pacienteRepository.UpdateAsync(pacientes);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int Id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(Id);
            await _pacienteRepository.DeleteAsync(paciente);
        }
        
        //-----------------Metodo para Extraer by ID-------------------//

        public async Task<SavePacienteViewModel> GetByIdSaveViewModels(int Id)
        {
            var pacientes = await _pacienteRepository.GetByIdAsync(Id);

            SavePacienteViewModel spvm = new();
            spvm.Id = pacientes.Id;
            spvm.Nombre = pacientes.Nombre;
            spvm.Apellido = pacientes.Apellido;
            spvm.Cedula = pacientes.Cedula;
            spvm.Direccion = pacientes.Direccion;
            spvm.Telefono = pacientes.Telefono;
            spvm.Fecha_Nacimiento = pacientes.Fecha_Nacimiento;
            spvm.Fumador = pacientes.Fumador;
            spvm.Alergias = pacientes.Alergias;
            spvm.Img_Paciente = pacientes.Img_Paciente;

            return spvm;
        }

    }
}