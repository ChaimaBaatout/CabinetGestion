namespace CabinetGestion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Patient : Utilisateur
    {
        private string cnss;
        private DateTime dateDenaiss;
        public virtual ICollection<RDV> lRDV { get; set; }

        public Patient(int id, string nom, string prenom, string email, string mdp, string cnss, DateTime dateDenaiss) : base(id, nom, prenom, email, mdp)
        {
            this.Cnss = cnss;
            this.DateDenaiss = dateDenaiss;
        }

        public Patient()
        {

        }

        public string Cnss { get => cnss; set => cnss = value; }
        [DataType(DataType.Date)]
        public DateTime DateDenaiss { get => dateDenaiss; set => dateDenaiss = value; }
        // public ICollection<RDV> LRDV { get => lRDV; set => lRDV = value; }
    }
}
