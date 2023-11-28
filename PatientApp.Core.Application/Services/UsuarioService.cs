using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.Interfaces.Services;
using PatientApp.Core.Application.ViewModels.Pacientes;
using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;    
        }

        //-----------------Metodo para Extraer----------------//
        public async Task<List<UsuarioViewModel>> GetAllVM()
        {
            var list = await _usuarioRepository.GetAllAsync();

            return list.Select(x => new UsuarioViewModel
            {

                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Correo = x.Correo ,
                Nombre_Usuario = x.Nombre_Usuario,
                Tipo_Usuario = x.Tipo_Usuario,

            }).ToList();
        }

        //-----------------Metodo para Login----------------//
        public async Task<UsuarioViewModel> Login(LoginViewModel trae)
        {
            Usuarios usuarios = await _usuarioRepository.LoginAsync(trae);

            if(usuarios == null)
            {
                return null;
            }
            
            UsuarioViewModel userVm = new();
            userVm.Nombre = usuarios.Nombre;
            userVm.Apellido = usuarios.Apellido;
            userVm.Correo = usuarios.Correo;
            userVm.Nombre_Usuario = usuarios.Nombre_Usuario;
            userVm.Password = usuarios.Password;
            userVm.Tipo_Usuario = usuarios.Tipo_Usuario;


            return userVm;
        }

        //-----------------Metodo para Agregar----------------//

        public async Task<SaveUsuarioViewModel> Add(SaveUsuarioViewModel manda)
        {
            Usuarios usuarios = new();
            usuarios.Nombre = manda.Nombre;
            usuarios.Apellido = manda.Apellido;
            usuarios.Correo = manda.Correo;
            usuarios.Nombre_Usuario = manda.Nombre_Usuario;
            usuarios.Password = manda.Password;
            usuarios.Tipo_Usuario = manda.Tipo_Usuario;

            usuarios = await _usuarioRepository.AddAsync(usuarios);

            SaveUsuarioViewModel saveUsuarioVm = new();
            saveUsuarioVm.Nombre = usuarios.Nombre;
            saveUsuarioVm.Apellido = usuarios.Apellido;
            saveUsuarioVm.Correo = usuarios.Correo;
            saveUsuarioVm.Nombre_Usuario = usuarios.Nombre_Usuario;
            saveUsuarioVm.Password = usuarios.Password;
            saveUsuarioVm.Tipo_Usuario = usuarios.Tipo_Usuario;
           
            return saveUsuarioVm;

        }

        //-----------------Metodo para Actualizar----------------//
        public async Task Update(SaveUsuarioViewModel trae)
        {
            Usuarios usuarios = await _usuarioRepository.GetByIdAsync(trae.Id);
            usuarios.Nombre = trae.Nombre;
            usuarios.Apellido = trae.Apellido;
            usuarios.Correo = trae.Correo;
            usuarios.Nombre_Usuario = trae.Nombre_Usuario;
            usuarios.Password = trae.Password;
            usuarios.Tipo_Usuario = trae.Tipo_Usuario;

            await _usuarioRepository.UpdateAsync(usuarios);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int Id)
        {
            var usuarios = await _usuarioRepository.GetByIdAsync(Id);
            await _usuarioRepository.DeleteAsync(usuarios);
        }

        public async Task<SaveUsuarioViewModel> GetByIdSaveViewModels(int Id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(Id);

            SaveUsuarioViewModel suvm = new();
            suvm.Id = usuario.Id;
            suvm.Nombre = usuario.Nombre;
            suvm.Apellido = usuario.Apellido;
            suvm.Correo = usuario.Correo;
            suvm.Nombre_Usuario = usuario.Nombre_Usuario;
            suvm.Password = usuario.Password;
            suvm.Tipo_Usuario = usuario.Tipo_Usuario;

            return suvm;
        }


    }


}