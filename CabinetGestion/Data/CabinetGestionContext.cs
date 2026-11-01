using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CabinetGestion.Models;

namespace CabinetGestion.Data
{
    public class CabinetGestionContext : DbContext
    {
        public CabinetGestionContext (DbContextOptions<CabinetGestionContext> options)
            : base(options)
        {
        }

       
        public DbSet<CabinetGestion.Models.Utilisateur> Utilisateur { get; set; }

        public DbSet<CabinetGestion.Models.Medecin> Medecin { get; set; }

        public DbSet<CabinetGestion.Models.Patient> Patient { get; set; }

        public DbSet<CabinetGestion.Models.DateDeTravail> DateDeTravail { get; set; }

        public DbSet<CabinetGestion.Models.Specialite> Specialite { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<RDV>().HasKey(table => new {
                table.PatientId,
                table.MedecinId
                
            });
         
        }


        public DbSet<CabinetGestion.Models.RDV> RDV { get; set; }
       
    }


}
