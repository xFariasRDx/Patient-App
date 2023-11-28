using Microsoft.EntityFrameworkCore;
using PatientApp.Core.Application.Interfaces.Repositories;
using PatientApp.Core.Domain.Entities;
using PatientApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Infrastructure.Persistence.Respositories
{
    public class CitaRepository : GenericRepository<Citas>, ICitaRepository
    {
        private readonly ApplicationContext _dbContext;

        public CitaRepository(ApplicationContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 