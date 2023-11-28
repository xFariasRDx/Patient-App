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
    public class PruebaRepository : GenericRepository<Prueba_Lab>, IPruebaRepository
    {
        private readonly ApplicationContext _dbContext;
        public PruebaRepository(ApplicationContext dbcontexts) : base(dbcontexts)
        {
            _dbContext = dbcontexts;
        }

    }
}
