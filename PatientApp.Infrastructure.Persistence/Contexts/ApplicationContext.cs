using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using PatientApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) { } //Dependency Injection

        public DbSet<Citas> citas { get; set; }
        public DbSet<Medicos> medicos { get; set; }
        public DbSet<Pacientes> pacientes { get; set; }
        public DbSet<Prueba_Lab> prueba_Labs { get; set; }
        public DbSet<Result_Lab> result_Labs { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Fluent API

            #region "Tables"
            modelbuilder.Entity<Citas>().ToTable("Citas");
            modelbuilder.Entity<Medicos>().ToTable("Medicos");
            modelbuilder.Entity<Pacientes>().ToTable("Pacientes");
            modelbuilder.Entity<Prueba_Lab>().ToTable("Pruebas Laboratorio");
            modelbuilder.Entity<Result_Lab>().ToTable("Resultados Laboratorio");
            modelbuilder.Entity<Usuarios>().ToTable("Usuarios");
            #endregion

            #region "Primary Keys"
            modelbuilder.Entity<Citas>().HasKey(g => g.Id);
            modelbuilder.Entity<Medicos>().HasKey(g => g.Id);
            modelbuilder.Entity<Pacientes>().HasKey(g => g.Id);
            modelbuilder.Entity<Prueba_Lab>().HasKey(g => g.Id);
            modelbuilder.Entity<Result_Lab>().HasKey(g => g.Id);
            modelbuilder.Entity<Usuarios>().HasKey(g => g.Id);
            #endregion

            #region "RelationShips"
           
            modelbuilder.Entity <Prueba_Lab>().HasMany(p => p.resultLab).WithOne(p => p.pruebaLab).HasForeignKey(g => g.PruebaId).OnDelete(DeleteBehavior.Cascade);
            modelbuilder.Entity<Medicos>().HasMany(p => p.citas).WithOne(p => p.medicos).HasForeignKey(g => g.MedicoId).OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<Pacientes>().HasMany(g => g.citas).WithOne(p => p.pacientes).HasForeignKey(g => g.PacienteId).OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<Pacientes>().HasMany(g => g.result_lab).WithOne(p => p.pacientes).HasForeignKey(g => g.PacienteId).OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region "Property Configuration"

            #region "Citas"
            #endregion

            #region "Medicos"
            #endregion

            #region "Pacientes"
            #endregion

            #region "Prueba Laboratorio"
            #endregion

            #region "Resultado Laboratorio"
            #endregion

            #region "Usuarios"
            #endregion

            #endregion


        }
    }
}
