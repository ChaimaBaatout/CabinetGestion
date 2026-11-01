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

            builder.Entity<RDV>()
                .HasOne(r => r.Medecin)
                .WithMany(m => m.RdvList)
                .HasForeignKey(r => r.MedecinId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RDV>()
                .HasOne(r => r.Patient)
                .WithMany(p => p.lRDV)
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
         
        }


        public DbSet<CabinetGestion.Models.RDV> RDV { get; set; }
       
    }


}
