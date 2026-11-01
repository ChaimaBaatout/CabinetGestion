namespace CabinetGestion.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RDV
    {
        private DateTime dateRDV;
        private string ordonnance;

        public RDV(DateTime dateRDV, string ordonnance)
        {

            this.dateRDV = dateRDV;
            this.ordonnance = ordonnance;
        }
       
        public RDV(int medecinId, int patientId, DateTime dateRDV, string ordonnance)
        {
            MedecinId = medecinId;
            PatientId = patientId;
            DateRDV = dateRDV;
            Ordonnance = ordonnance;
        }

        public RDV()
        {

        }
        public int Id { get; set; }
        public int MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string Ordonnance { get => ordonnance; set => ordonnance = value; }

    }
}
