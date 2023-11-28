using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientApp.Core.Application.Helpers;
using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Application.ViewModels.Usuarios;
using PatientApp.Core.Domain.Entities;
using PatientApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Infrastructure.Persistence.Respositories
{
    public class UsuarioRepository : GenericRepository<Usuarios>, IUsuarioRepository
    {   
        private readonly ApplicationContext _dbContext;
        public UsuarioRepository(ApplicationContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public override async Task<Usuarios> AddAsync(Usuarios entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Usuarios>LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncryption = PasswordEncryption.ComputeSha256Hash(loginVm.Password);
            Usuarios usuarios = await _dbContext.Set<Usuarios>()
                .FirstOrDefaultAsync(usuarios => usuarios.Nombre_Usuario == loginVm.Nombre_Usuario && usuarios.Password == passwordEncryption);
            
            return usuarios;
        }
    
    }
}
