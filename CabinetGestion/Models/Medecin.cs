using System.Collections.Generic;

namespace CabinetGestion.Models
{
    public class Medecin : Utilisateur

    {
        private int prixVisite;
        private bool activate;
        private int cin;
        private int specialiteID;
        private int dateDeTravailId;
        public virtual ICollection<RDV> RdvList { get; set; }
        // private ICollection<RDV> rdvList;

        public Medecin(int id, string nom, string prenom, string email, string mdp, int prixVisite, bool activate, int cin) : base(id, nom, prenom, email, mdp)
        {
            this.PrixVisite = prixVisite;
            this.Activate = activate;
            this.Cin = cin;
        }

        public Medecin():base()
        {

        }

        public int PrixVisite { get => prixVisite; set => prixVisite = value; }
        public bool Activate { get => activate; set => activate = value; }
        public int Cin { get => cin; set => cin = value; }
        public int SpecialiteID { get => specialiteID; set => specialiteID = value; }
        public virtual Specialite Specialite { get; set; }
        public int DateDeTravailId { get => dateDeTravailId; set => dateDeTravailId = value; }
        public virtual DateDeTravail DateDeTravail { get; set; }


    }
}
