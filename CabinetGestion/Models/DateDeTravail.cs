namespace CabinetGestion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class DateDeTravail
    {
        private int id;
        private string jours;
        private DateTime heureDebut;
        private DateTime heureFin;


        public DateDeTravail(int id, string jours, DateTime heureDebut, DateTime heureFin)
        {
            this.Id = id;
            this.Jours = jours;
            this.HeureDebut = heureDebut;
            this.HeureFin = heureFin;
        }

        public DateDeTravail()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Jours { get => jours; set => jours = value; }
        [DataType(DataType.Time)]
        public DateTime HeureDebut { get => heureDebut; set => heureDebut = value; }
        [DataType(DataType.Time)]
        public DateTime HeureFin { get => heureFin; set => heureFin = value; }
        public virtual ICollection<Medecin> MedecinList { get; set; }
    }
}
